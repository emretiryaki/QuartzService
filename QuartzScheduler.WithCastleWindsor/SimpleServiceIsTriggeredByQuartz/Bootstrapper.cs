using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using Castle.Facilities.TypedFactory;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Diagnostics;
using Castle.Windsor.Installer;

namespace SimpleServiceIsTriggeredByQuartz
{
    public class Bootstrapper
    {
        
       public IWindsorContainer container = new WindsorContainer();
        public IKernel kernel { get; private set; }

        public void Initialize(bool isHttpEnabled = false)
        {
            this.container.AddFacility<TypedFactoryFacility>().AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);

            ServiceMetadataBehavior metadata = new ServiceMetadataBehavior();

            if (isHttpEnabled)
            {
                metadata.HttpGetEnabled = true;
                metadata.HttpsGetEnabled = true;
            }

            ServiceDebugBehavior returnFaults = new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true };

            this.container.Register(
                Component.For<IServiceBehavior>().Instance(metadata),
                Component.For<IServiceBehavior>().Instance(returnFaults));

            this.container.Install(FromAssembly.InDirectory(new AssemblyFilter(ConfigurationManager.AppSettings.Get("ExtensionFolder") ?? string.Empty)));

            this.kernel = this.container.Kernel;

            
            
            CheckCastleRegisterComponent();


        }

        protected void CheckCastleRegisterComponent()
        {
           
            var host = (IDiagnosticsHost)container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
            var diagnostics = host.GetDiagnostic<IPotentiallyMisconfiguredComponentsDiagnostic>();

            var handlers = diagnostics.Inspect();

            if (handlers.Any())
            {
                var message = new StringBuilder();
                var inspector = new DependencyInspector(message);

                foreach (IExposeDependencyInfo handler in handlers)
                {
                    handler.ObtainDependencyDetails(inspector);
                }

              
                Console.WriteLine(message.ToString());
            }
            
           
           
        }

        //public static void Initialize(bool isHttpEnabled = false)
        //{
        //    var container = new WindsorContainer();
        //    container.AddFacility<TypedFactoryFacility>().AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);


        //    ServiceMetadataBehavior metadata = new ServiceMetadataBehavior();

        //    if (isHttpEnabled)
        //    {
        //        metadata.HttpGetEnabled = true;
        //        metadata.HttpsGetEnabled = true;
        //    }

        //    ServiceDebugBehavior returnFaults = new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true };


        //    container.Register(
        //                    Component.For<IServiceBehavior>().Instance(metadata),
        //                    Component.For<IServiceBehavior>().Instance(returnFaults));

        //    //container.Register(Component.For<ISimpleService>()
        //    //    .ImplementedBy<SimpleService>().LifestyleTransient()
        //    //    .AsWcfService(new DefaultServiceModel()
        //    //        .AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding
        //    //        {
        //    //            MaxReceivedMessageSize = 200000,
        //    //            MaxBufferSize = 200000,
        //    //            MaxBufferPoolSize = 200000,
        //    //        }
        //    //            ).At(ConfigurationManager.AppSettings.Get("SoapAddress") + "BasicHttpEndPoint"))
        //    //        .AddBaseAddresses(ConfigurationManager.AppSettings.Get("ServiceUrl"))
        //    //        .PublishMetadata(extension => extension.EnableHttpGet())
        //    //    ));
        //    container.Register(
        //       Component.For<ISimpleService>()
        //           .ImplementedBy<SimpleService>()
            
        //           .LifeStyle.PerWcfOperation()
        //           .AsWcfService(new DefaultServiceModel().AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding()
        //           {
        //               Security = new BasicHttpSecurity()
        //               {
        //                   Mode = BasicHttpSecurityMode.None
        //               },
        //               MaxReceivedMessageSize = Int32.MaxValue,
        //               MaxBufferPoolSize = Int32.MaxValue,
        //               ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas
        //               {
        //                   MaxStringContentLength = Int32.MaxValue
        //               }
        //           }).At(ConfigurationManager.AppSettings.Get("SoapAddress"))).AddBaseAddresses(ConfigurationManager.AppSettings.Get("SoapAddress")).PublishMetadata(o => o.EnableHttpGet())));
   
        //    bool isAllValid = true;
        //    foreach (IHandler handler in container.Kernel.GetAssignableHandlers(typeof(object)))
        //    {
        //        if (handler.CurrentState != HandlerState.Valid)
        //        {
        //            Console.WriteLine("HandlerState NOT Valid for : " + handler.ComponentModel.ComponentName + " - " + handler.CurrentState);
        //            isAllValid = false;
        //        }
        //    }
        //    if (!isAllValid)
        //        throw new Exception("Invalid components !");
          
        //}

    }
}