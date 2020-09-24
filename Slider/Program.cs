using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SfmlUI;

namespace Slider1
{
    class Program
    {
        private static RenderWindow _window;
        private static Slider _slider;

        static void Main(string[] args)
        {
            _window = new RenderWindow(VideoMode.DesktopMode, "Test Slider");
            _slider = new Slider(_window, new Vector2f(_window.Size.X/2f,_window.Size.Y/2f),400f,50f,0f,1f);
            _window.Closed += WindowClosed;
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);


            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                _slider.Draw();
                _window.Display();
            }
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

    }
}