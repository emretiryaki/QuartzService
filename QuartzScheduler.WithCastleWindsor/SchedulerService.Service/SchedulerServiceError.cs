using System;

namespace SchedulerService.Service
{
    internal class SchedulerServiceError : Exception
    {
        private readonly string _errorText;
        public SchedulerServiceError(string errorText)
        {
            _errorText = errorText;
        }

        public string ErrorText
        {
            get
            {
                return _errorText;
            }
        }
    }
}