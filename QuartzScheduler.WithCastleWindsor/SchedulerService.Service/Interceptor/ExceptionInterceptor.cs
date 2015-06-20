using System;
using Castle.DynamicProxy;
using Common.Logging;
using SchedulerService.Service.Json;
using SchedulerService.Service.Log;
using LogLevel = SchedulerService.Service.Log.LogLevel;

namespace SchedulerService.Service.Interceptor
{
    public class ExceptionInterceptor : IInterceptor
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ExceptionInterceptor));
        private readonly IJsonSerializer _jsonSerializer;
        public ExceptionInterceptor(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                dynamic returnValue = invocation.ReturnValue;
                returnValue.ResponseCode = ((int)ResponseCode.Success).ToString("d4");
                returnValue.ResponseText = ResponseCode.Success.ToString();
                invocation.ReturnValue = returnValue;
               
            }
            catch (SchedulerServiceError schedulerServiceError)
            {
                if (invocation.Method.ReturnParameter != null)
                {
                    SetResponseValues(invocation, schedulerServiceError.ErrorText,
                                      (int)ResponseCode.SchedulerServiceError);
                }
            }
            catch (Exception ex)
            {
                var exceptionLogInfo = new ExceptionLogInfo(LogLevel.Error);
                exceptionLogInfo.Exception = ex;
                exceptionLogInfo.Message = (ex.Message + " \n " + ex.StackTrace).Replace("'", string.Empty);
                exceptionLogInfo.MethodName = invocation.Method.Name;
                exceptionLogInfo.ModuleName = invocation.Method.Module.Name;
                exceptionLogInfo.FileName = invocation.Method.ReflectedType.Assembly.FullName;
                logger.Error(_jsonSerializer.Serialize(exceptionLogInfo));
                if (invocation.Method.ReturnParameter != null)
                {
                    SetResponseValues(invocation, "Exception : " + ex.Message,
                                      (int)ResponseCode.UnhandledError);
                }
            }

        }

        protected static void SetResponseValues(IInvocation invocation, string responseText, int responseCode)
        {
            dynamic returnValue = Activator.CreateInstance(invocation.Method.ReturnType);
            ResponseCode code = (ResponseCode)responseCode;
            returnValue.ResponseCode = ((int)code).ToString("d4");
            switch (code)
            {
                case ResponseCode.Success:
                    returnValue.ResponseText = "Success";
                    break;
                case ResponseCode.SchedulerServiceError:
                    returnValue.ResponseText = "SchedulerServiceError";
                    break;
                case ResponseCode.UnhandledError:
                    returnValue.ResponseText = "UnhandledError";
                    break;
                default:
                    returnValue.ResponseText = "UnhandledError";
                    break;
            }

            invocation.ReturnValue = returnValue;
        }

    }

    
}