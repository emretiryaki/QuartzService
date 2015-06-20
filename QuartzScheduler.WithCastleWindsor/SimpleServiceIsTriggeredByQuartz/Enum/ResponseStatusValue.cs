using System.ComponentModel;

namespace SimpleServiceIsTriggeredByQuartz.Enum
{
    public enum ResponseStatusValue
    {
        [Description("Tekrar Deneyin")]
        Retry = -2,
        [Description("Baþarýlý")]
        Success = 0,
        [Description("Baþarýsýz")]
        Failure = -1,
        [Description("Beklemede")]
        WaitingForProcessing = -3
    }
}