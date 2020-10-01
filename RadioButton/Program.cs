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
            var radioButton = new RadioButton(_window, new Vector2f(200,200), 30, 100, 5);

            _window.Closed += WindowClosed;

            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                radioButton.Draw();

                _window.Display();
            }
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}