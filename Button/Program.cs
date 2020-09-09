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
            _button.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);
            _button.MousePressed += ButtonPressed;
            _button.MouseRealeased += ButtonReleased;
            _button.MouseHeld += ButtonHeld;
            while (_window.IsOpen)
            {
                
                _window.DispatchEvents();
                _window.Clear();
                _button.Draw();
                _window.Display();
                

            }
        }
        
        static private void ButtonHeld()
        {
            Console.WriteLine("u are holding the button");
            _button.Position = new Vector2f(_button.Position.X - 1f, _button.Position.Y -1f);
        }
        static private void ButtonPressed()
        {
            Console.WriteLine("u have pressed the button");
            
        }
        static private void ButtonReleased()
        {
            _button.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);

            Console.WriteLine("u have released the button");
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
