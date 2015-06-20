using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Xml;
using SimpleServiceIsTriggeredByQuartz;
using SimpleServiceIsTriggeredByQuartz.Enum;

namespace SchedulerJob
{
    public class ServiceClientFactory
    {
        private readonly ServiceClientConfig _serviceClientConfig;

        public ServiceClientFactory()
        {
            _serviceClientConfig = new ServiceClientConfig(
                typeof(ISimpleService),
                new NetTcpBinding(SecurityMode.None)
                {
                    MaxReceivedMessageSize = Int32.MaxValue,
                    ReaderQuotas = new XmlDictionaryReaderQuotas() { MaxStringContentLength = Int32.MaxValue },
                },
                ConfigurationManager.AppSettings["ServiceUrl"]
                ,
                false);


        }
        public void Run(Expression<Action<ISimpleService>> method)
      
        {
            ServiceClientConfig serviceClientConfig = _serviceClientConfig;

            if (serviceClientConfig == null)
            {
               
                throw new Exception(string.Format("Service  configuration not found."));
            }

            var channelFactory = new ChannelFactory<ISimpleService>(serviceClientConfig.Binding, new EndpointAddress(serviceClientConfig.EndpointUrl));

            var service = channelFactory.CreateChannel();

            try
            {
                method.Compile().Invoke(service);
            }
            catch (Exception exception)
            {
                
                if (serviceClientConfig.IsExceptionThrownEnabled)
                {
                    throw new Exception("Service Communication Exception");
                }

            }
            finally
            {
                if (channelFactory.State != CommunicationState.Faulted)
                {
                    try
                    {
                        channelFactory.Close();
                    }
                    catch (Exception)
                    {
                        channelFactory.Abort();
                    }
                }
            }
        }
    }
}
