using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SfmlUI;

namespace Button1
{
    
    class Program
    {
        
        private static RenderWindow _window;
        private static Button _button;
        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "Button");
            _button = new Button(_window, new Vector2f(_window.Size.X / 2f, _window.Size.Y / 2f), new Vector2f(400f, 400f));
            _window.Closed += WindowClosed;
            _button.Allign.Horizontal.Center();
            _button.Allign.Vertical.Buttom();
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);
            
            _button.MousePressed += ButtonPressed;
            _button.MouseRealeased += ButtonReleased;
            _button.MouseHeld += ButtonHeld;
            //_button.VerticalAlign.Top();
            while (_window.IsOpen)
            {
                
                _window.DispatchEvents();
                _window.Clear();
                _button.Draw();
                //_knap.Draw();
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
        static private void KnapReleased()
        {
            _button.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);

            Console.WriteLine("u have released the Knap");
        }
        static private void KnapHeld()
        {
            Console.WriteLine("u are holding the knap");
            _button.Position = new Vector2f(_button.Position.X + 1f, _button.Position.Y + 1f);
        }
        static private void KnapPressed()
        {
            Console.WriteLine("u have pressed the knap");

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
