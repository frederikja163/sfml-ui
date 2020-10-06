using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using SfmlUI;


namespace RadioButtonSandbox //Magnus
{
    class Program
    {
        private static RenderWindow _window;

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "RadioButton");

            //RadioButton(RenderWindow = _window, startingPosition, globalRadius, lineSpacing, radioAmount)
            var radioButton = new RadioButton(_window, new Vector2f(200,200), 30, new Vector2f(0,100), 5);
            

            var _button = new Button(_window, new Vector2f(500, 200), new Vector2f(200, 200));
            _button.Shape = Button.Shapes.Elipse;

            var _slider = new Slider(_window, new Vector2f(_window.Size.X / 2f, _window.Size.Y / 2f), 400f, 50f, 0f, 1f);

            _window.Closed += WindowClosed;

            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                radioButton.Draw();
                _button.Draw();
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