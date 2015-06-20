using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SimpleServiceIsTriggeredByQuartzClient
{
    public class ServiceClientConfig
    {
        public bool IsExceptionThrownEnabled { get; set; }
        public Type ServiceType { get; set; }
        public Binding Binding { get; set; }
        public string EndpointUrl { get; set; }

        public ServiceClientConfig(Type serviceType, NetTcpBinding binding, string endpointUrl, bool isExceptionThrownEnabled)
        {
            this.ServiceType = serviceType;
            this.Binding = binding;
            this.EndpointUrl = endpointUrl;
            this.IsExceptionThrownEnabled = isExceptionThrownEnabled;
        }
    }
}