using System;
using DevExpress.XtraSplashScreen;

namespace HRM
{
    public partial class SplashScreenStarting : SplashScreen
    {
        public SplashScreenStarting()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}