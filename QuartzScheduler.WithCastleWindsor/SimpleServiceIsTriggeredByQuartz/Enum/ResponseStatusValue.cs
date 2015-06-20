using System.ComponentModel;

namespace SimpleServiceIsTriggeredByQuartz.Enum
{
    public enum ResponseStatusValue
    {
        [Description("Tekrar Deneyin")]
        Retry = -2,
        [Description("Ba�ar�l�")]
        Success = 0,
        [Description("Ba�ar�s�z")]
        Failure = -1,
        [Description("Beklemede")]
        WaitingForProcessing = -3
    }
}