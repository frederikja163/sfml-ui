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
        private static Checkbox _checkbox;
        private static Dropdown _dropdown;
        private static RadioButton _radioButton;
        private static Slider _slider;
        private static TextInput _textInput;

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "Button");
            _window.Closed += WindowClosed;
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);
            
            _button = new Button(_window, new Vector2f(5, 5), new Vector2f(200, 200));
            _checkbox = new Checkbox(_window, new Vector2f(205, 205));
            _checkbox.Height = 200;
            _checkbox.Width = 200;
            _checkbox.FillColor = Color.White;
            _checkbox.CrossColor = Color.Black;
            _button.ButtonHeld += ButtonHeld;
            _button.ButtonPressed += ButtonPressed;
            _button.ButtonRealeased += ButtonRealesed;
            _button.IsVisible = false;

            while (_window.IsOpen)
            {

                _window.DispatchEvents();
                _window.Clear();
                
                _button.Draw();
                _window.Display();
                _checkbox.Draw();
                

            }
        }

        static private void ButtonHeld()
        {
            Console.WriteLine("u are holding the button");
            //_button.Position = new Vector2f(_button.Position.X - 1f, _button.Position.Y -1f);

        }
        static private void ButtonPressed()
        {
            Console.WriteLine("u have pressed the button");
            if(_button.CenterColor == Color.Red)
            {
                _button.CenterColor = Color.Blue;
            }
            else
            {
                _button.CenterColor = Color.Red;
            }
        }

        static private void ButtonRealesed()
        {
            //_button.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);

            Console.WriteLine("u have released the button");
            
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
