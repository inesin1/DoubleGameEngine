using Microsoft.Xna.Framework;
using System;

namespace DoubleGameEngine.Core
{
    public class GameWindow : Microsoft.Xna.Framework.GameWindow
    {
        public override bool AllowUserResizing { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Rectangle ClientBounds => throw new NotImplementedException();

        public override Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override DisplayOrientation CurrentOrientation => throw new NotImplementedException();

        public override IntPtr Handle => throw new NotImplementedException();

        public override string ScreenDeviceName => throw new NotImplementedException();

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
            throw new NotImplementedException();
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            throw new NotImplementedException();
        }

        protected override void SetSupportedOrientations(DisplayOrientation orientations)
        {
            throw new NotImplementedException();
        }

        protected override void SetTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
