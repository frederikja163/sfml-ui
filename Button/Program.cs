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
        //private static Checkbox _checkbox;
        //private static Dropdown _dropdown;
        //private static RadioButton _radioButton;
        //private static Slider[] _slider = new Slider[4];
        //private static TextInput _textInput;

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "Button");
            _window.Closed += WindowClosed;
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            _button = new Button(_window, new Vector2f(100, 100), new Vector2f(200,200), Button.Shapes.Elipse, Color.Black, Color.Blue);
            //_checkbox = new Checkbox(_window, new Vector2f(205, 205));
            //_checkbox.Height = 200;
            //_checkbox.Width = 200;
            //_checkbox.FillColor = Color.White;
            //_checkbox.CrossColor = Color.Black;
            //_button.Shape = Button.Shapes.Elipse;
            //_button.Size = new Vector2f(200,200);
            
            _button.Origin.Horizontal.Center();
            _button.Origin.Vertical.Center();
            _button.ButtonHeld += ButtonHeld;
            _button.ButtonPressed += ButtonPressed;
            _button.ButtonReleased += ButtonRelesed;
            //_slider[0] = new Slider(_window, new Vector2f(5, 205), 800, 195, 20, 255);
            //_slider[1] = new Slider(_window, new Vector2f(5, 405), 800, 195, 0, 255);
            //slider[2] = new Slider(_window, new Vector2f(5, 605), 800, 195, 0, 255);
            //_slider[3] = new Slider(_window, new Vector2f(5, 805), 800, 195, 0, 255);
            //_radioButton = new RadioButton(_window, new Vector2f(200, 200), 30, new Vector2f(100, 100), 4);
            _button.Position = _button.Position;

            while (_window.IsOpen)
            {
                //_button.CenterColor = new Color((byte) _slider[0].Value, (byte)_slider[1].Value, (byte)_slider[2].Value, (byte)_slider[3].Value);
                _window.DispatchEvents();
                _window.Clear();
                //_slider[0].Draw();
                //_slider[1].Draw();
                //_slider[2].Draw();
                //_slider[3].Draw();
                _button.Draw();
                //_radioButton.Draw();
                //_checkbox.Draw();
                _window.Display();
               
                

                

            }
        }

        static private void ButtonHeld()
        {
            Console.WriteLine("u are holding the button");
            _button.Position = new Vector2f(_button.Position.X + 1f, _button.Position.Y + 1f);

        }
        static private void ButtonPressed()
        {
            Console.WriteLine("u have pressed the button");
            
        }

        static private void ButtonRelesed()
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
