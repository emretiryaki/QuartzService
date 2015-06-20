using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.PeerResolvers;
using Castle.Core;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SchedulerService.Contract;
using SchedulerService.Service.Interceptor;
using SchedulerService.Service.Json;
using SchedulerService.Service.QuartzServer;

namespace SchedulerService.Service
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var container = new WindsorContainer();
            container
                .Register(Component.For<IJsonSerializer>().ImplementedBy<JsonSerializer>())
                .Register(Component.For<ExceptionInterceptor>().LifeStyle.PerWcfOperation())
                .Kernel.AddFacility<WcfFacility>();


            // WCF Config

            //Enables debugging and help information features for a Windows Communication Foundation (WCF) service.
            var returnFaults = new ServiceDebugBehavior
            {
                IncludeExceptionDetailInFaults = true,
                HttpHelpPageEnabled = true

            };

            //Configures run-time throughput settings that enable you to tune service performance.
            var serviceThrottlingBehavior = new ServiceThrottlingBehavior
            {
                MaxConcurrentCalls = 16,
                MaxConcurrentInstances = 10,
                MaxConcurrentSessions = Int32.MaxValue
            };

            container.Register(Component.For<IServiceBehavior>().Instance(returnFaults));
            container.Register(Component.For<IServiceBehavior>().Instance(serviceThrottlingBehavior));


            container.Register(Component.For<ISchedulerService>()
                .ImplementedBy<SchedulerService>().LifestyleTransient()
                .Interceptors(InterceptorReference.ForType<ExceptionInterceptor>()).Anywhere
                .AsWcfService(new DefaultServiceModel()
                    .AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding
                    {
                        MaxReceivedMessageSize = 200000,
                        MaxBufferSize = 200000,
                        MaxBufferPoolSize = 200000,
                    }
                        ).At(ConfigurationManager.AppSettings.Get("QuartzSoapAddress") + "BasicHttpEndPoint"))
                    .AddBaseAddresses(ConfigurationManager.AppSettings.Get("QuartzServiceUrl"))
                    .PublishMetadata(extension => extension.EnableHttpGet())
                ));

            bool isAllValid = true;
            foreach (IHandler handler in container.Kernel.GetAssignableHandlers(typeof(object)))
            {
                if (handler.CurrentState != HandlerState.Valid)
                {
                    Console.WriteLine("HandlerState NOT Valid for : " + handler.ComponentModel.ComponentName + " - " + handler.CurrentState);
                    isAllValid = false;
                }
            }
            if (!isAllValid)
                throw new Exception("Invalid components !");
            IQuartzServer server = QuartzServerFactory.CreateServer();
            server.Initialize();

            server.Start();
        }

    }
}