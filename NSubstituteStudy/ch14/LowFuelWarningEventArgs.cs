using System;

namespace NSubstituteStudy.ch14
{
    public class LowFuelWarningEventArgs : EventArgs
    {
        public int PercentLeft { get; private set; }
        public LowFuelWarningEventArgs(int percentLeft)
        {
            PercentLeft = percentLeft;
        }
    }
}
