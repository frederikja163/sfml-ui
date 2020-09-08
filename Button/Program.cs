using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SfmlUI;

namespace Button1
{
    
    class Program
    {
        //private readonly SfmlUI.Button _button;
        private static RenderWindow _window;
        private static Button _button;
        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "Button");
            _button = new Button();
            _window.Closed += WindowClosed;

            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);
            _button.IsVisible = true;
            _button.Window = _window;
            _button.Height = 400f;
            _button.Width = 400f;
            _button.Position = new Vector2f(_window.Size.X/2, _window.Size.Y/2);
            



            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();


                _button.Draw();
                _window.Display();
                
            }
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
