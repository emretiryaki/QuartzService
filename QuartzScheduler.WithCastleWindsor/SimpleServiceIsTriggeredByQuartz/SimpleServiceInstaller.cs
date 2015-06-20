using System;
using System.Configuration;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SimpleServiceIsTriggeredByQuartz
{
    public class SimpleServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string serviceHostUrl = ConfigurationManager.AppSettings.Get("ServiceUrl");

            container.Register(
               Component.For<ISimpleService>()
                   .ImplementedBy<SimpleService>()
                  
                   .LifeStyle.PerWcfOperation()
                   .AsWcfService(new DefaultServiceModel()
                       .AddEndpoints(WcfEndpoint.BoundTo(new NetTcpBinding()
                       {
                           MaxReceivedMessageSize = Int32.MaxValue,
                           ReaderQuotas =
                               new System.Xml.XmlDictionaryReaderQuotas() { MaxStringContentLength = Int32.MaxValue },
                           PortSharingEnabled = true,
                           Security = new NetTcpSecurity
                           {
                               Mode = SecurityMode.None,
                               Transport = new TcpTransportSecurity
                               {
                                   ClientCredentialType =
                                       TcpClientCredentialType.None,
                                   ProtectionLevel =
                                       System.Net.Security.ProtectionLevel.None,
                               }
                           }
                       }
                           ).At(serviceHostUrl))
                       .PublishMetadata()));

        }
    }
}