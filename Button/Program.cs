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
        private static Button[] _button = new Button[4];

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "Button");
            _window.Closed += WindowClosed;
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);
            
            _button[0] = new Button(_window, new Vector2f(200, 200), new Vector2f(200, 200));
            _button[1] = new Button(_window, new Vector2f(500, 200), new Vector2f(400, 200));
            _button[2] = new Button(_window, new Vector2f(200, 500), new Vector2f(200, 200));
            _button[3] = new Button(_window, new Vector2f(500, 500), new Vector2f(400, 200));

            _button[2].Shape = Button.Shapes.Elipse;
            _button[3].Shape = Button.Shapes.Elipse;

            _button[0].OuterColor = Color.Blue;
            _button[1].OuterColor = Color.Magenta;
            _button[2].OuterColor = Color.Red;
            _button[3].OuterColor = Color.Yellow;

            _button[0].CenterColor = Color.Cyan;
            _button[1].CenterColor = Color.White;
            _button[2].CenterColor = Color.Black;
            _button[3].CenterColor = Color.Transparent;

            _button[0].OuterOutlineColor = Color.Black;
            _button[1].OuterOutlineColor = Color.Red;
            _button[2].OuterOutlineColor = Color.Yellow;
            _button[3].OuterOutlineColor = Color.White;

            _button[0].CenterOutlineColor = Color.Transparent;
            _button[1].CenterOutlineColor = Color.Green;
            _button[2].CenterOutlineColor = Color.Magenta;
            _button[3].CenterOutlineColor = Color.Blue;

            _button[0].Origin.Horizontal.Left();
            _button[1].Origin.Horizontal.Center();
            _button[2].Origin.Horizontal.Right();
            _button[3].Origin.Horizontal.Left();
            
            _button[0].Origin.Vertical.Top();
            _button[1].Origin.Vertical.Center();
            _button[2].Origin.Vertical.Buttom();
            _button[3].Origin.Vertical.Buttom();

            _button[0].ButtonHeld += ButtonHeld;
            _button[1].ButtonHeld += ButtonHeld;
            _button[2].ButtonHeld += ButtonHeld;
            _button[3].ButtonHeld += ButtonHeld;

            _button[0].ButtonPressed += ButtonPressed;
            _button[1].ButtonPressed += ButtonPressed;
            _button[2].ButtonPressed += ButtonPressed;
            _button[3].ButtonPressed += ButtonPressed;

            _button[0].ButtonRealeased += ButtonRealesed;
            _button[1].ButtonRealeased += ButtonRealesed;
            _button[2].ButtonRealeased += ButtonRealesed;
            _button[3].ButtonRealeased += ButtonRealesed;

            while (_window.IsOpen)
            {

                _window.DispatchEvents();
                _window.Clear();
                for (int i = 0; i < 4; ++i)
                {
                    _button[i].Draw();
                }
                _window.Display();

                

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
