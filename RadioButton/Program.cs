using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;


namespace RadioButton //Magnus
{
    class Program
    {
        private static RenderWindow _window;

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000,1000), "RadioButton");

            _window.Closed += WindowClosed;

            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            var rect = new RectangleShape(new Vector2f(1000, 1000));
            rect.FillColor = new Color(220, 220, 220);
            rect.Position = new Vector2f(0, 0);

            var radio = new CircleShape(30);
            radio.FillColor = new Color(255, 255, 255);
            radio.OutlineThickness = 10;
            radio.OutlineColor = new Color(0, 0, 0);
            radio.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);

            var radioSelected = new CircleShape(17.5f);
            radioSelected.FillColor = new Color(0, 0, 255);
            radioSelected.OutlineThickness = 10;
            radioSelected.OutlineColor = new Color(0, 0, 160);
            radioSelected.Position = new Vector2f(radio.Position.X+12, radio.Position.Y+12);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                _window.Draw(rect);

                _window.Draw(radio);

                _window.Draw(radioSelected);

                _window.Display();
            }
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}