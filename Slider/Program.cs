using SFML.Graphics;
using SFML.Window;
using System;

namespace Slider
{
    class Program
    {
        private static RenderWindow _window;

        static void Main(string[] args)
        {
            _window = new RenderWindow(VideoMode.DesktopMode, "Test Slider");
            _window.Closed += WindowClosed;

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();



                _window.Display();
            }
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
