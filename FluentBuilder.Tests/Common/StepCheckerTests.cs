using FluentBuilder.Model.Common;

namespace FluentBuilder.Tests.Common
{
    public partial class StepCheckerTests
    {
        private static class Condition
        {
            public const bool Valid = false;
            public const bool Invalid = true;
        }

        private static class StepName
        {
            public const string Step1 = "1";
            public const string Step2 = "2";
            public const string Step3 = "3";
            public const string Step4 = "4";
            public const string Unknown = "unknown";
        }

        private static readonly ChainedItem<string>[] Steps =
        {
            ChainedItem.CreateFirst(StepName.Step1),
            ChainedItem.Create(StepName.Step2, StepName.Step1),
            ChainedItem.Create(StepName.Step3, StepName.Step2),
            ChainedItem.Create(StepName.Step4, StepName.Step1)
        };

        private static readonly StepChecker<string> StepCheckerTested = new StepChecker<string>(Steps);
    }
}
