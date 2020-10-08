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
        private static Button[] _button = new Button[4];

        static void Main(string[] args)
        {
            _window = new RenderWindow(VideoMode.DesktopMode, "Test Slider");
            _slider = new Slider(_window, new Vector2f(_window.Size.X/2f,_window.Size.Y/2f),400f,50f,0f,1f);
            _window.Closed += WindowClosed;
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            _button[0] = new Button(_window, new Vector2f(200, 200), new Vector2f(200, 200));

            //_button[0].IsVisible = false;

            _button[0].OuterColor = Color.Blue;

            _button[0].CenterColor = Color.Cyan;

            _button[0].OuterOutlineColor = Color.Black;

            _button[0].CenterOutlineColor = Color.Transparent;

            _button[0].Origin.Horizontal.Left();

            _button[0].Origin.Vertical.Top();

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                _button[0].Draw();
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