using System;
using SFML.System;
using SFML.Graphics;

namespace SfmlUI
{
    public sealed class TextBox : IUiElement
    {
        // Private variabler går her
        private RenderWindow _window;
        private bool _isVisibble;
        private Shape _box;
        private Text _text;


        // Call metoder
        public bool IsVisible { get { return _isVisibble; } set { _isVisibble = value; } }
        public Vector2f Position { get { return _box.Position; } }
        public float Width { get { return _box.GetGlobalBounds().Width; } }
        public float Height { get { return _box.GetGlobalBounds().Height; } }

        // Konstruktør
        public TextBox(RenderWindow window, Vector2f position, float width, float height, Font font, uint fontSize)
        {
            _window = window;
            _isVisibble = true;
            _box = new RectangleShape(new Vector2f(width, height)); // baggrund/box
            _text = new Text("", font, fontSize); // text objekt til boxen
            _box.Position = position;
            _text.Position = position;
        }

        // Metoder/FunctionerS
        public void Draw() // metode til at tegne objektet
        {
            if (_isVisibble)
            {
                _window.Draw(_box);
                _window.Draw(_text);
            }
        }

        public void Toggle() // metode til at slå synlighed til og fra
        {

        }

        public void Output(string text) // metode til at ligge tekst ind i boxen
        {
            _text.DisplayedString = text;
        }
    }
}
