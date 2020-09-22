using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Linq;

namespace SfmlUI
{
    public class Dropdown : IUiElement
    {
        // egenskaber
        private RenderWindow _window;
        private bool _isVisible;
        private bool _active;
        private Vector2f _position;
        private Vector2f _size;
        private Shape _shape;
        private Shape _activeShape;
        private uint _fontSize = 0;
        private List<Text> _list = new List<Text>();
        private Text _primedText;

        // nedarvede metoder
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }

        public Vector2f Position { get { return _position; } }

        public float Width { get { return _size.X; } }

        public float Height { get { return _size.Y; } }

        // public ekstra metoder
        public Shape Shape { get { return _shape; } set { _shape = value; } }
        public string ChosenItem { get { return _list[0].DisplayedString; } }

        // konstruktøren
        public Dropdown(RenderWindow window, Vector2f position, Font font, uint fontSize, params string[] textList)
        {
            _fontSize = fontSize;
            foreach (string item in textList)
            {
                _list.Add(new Text(item, font, fontSize));
            }
            float maxWidth = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Position = new Vector2f(position.X + fontSize * 0.5f, position.Y + fontSize * i);
                _list[i].FillColor = Color.Black;
                if (_list[i].GetLocalBounds().Width > maxWidth) { maxWidth = _list[i].GetLocalBounds().Width; }
            }
            _window = window;
            _isVisible = true;
            _position = position;
            _size = new Vector2f(maxWidth + fontSize, fontSize + 0.2f * fontSize);
            _shape = new RectangleShape(new Vector2f(maxWidth + fontSize, fontSize + 0.2f * fontSize));
            _shape.Scale = new Vector2f(1, 1);
            _shape.OutlineColor = Color.Black;
            _shape.OutlineThickness = 2;
            _shape.Position = position + new Vector2f(_shape.OutlineThickness, _shape.OutlineThickness);
            _activeShape = new RectangleShape(new Vector2f(maxWidth + fontSize, textList.Count() * fontSize + 0.2f * fontSize));
            _activeShape.Scale = new Vector2f(1, 1);
            _activeShape.OutlineColor = Color.Black;
            _activeShape.OutlineThickness = 2;
            _activeShape.Position = position + new Vector2f(_shape.OutlineThickness, _shape.OutlineThickness);
            _active = false;

            // sæt event handler for musen
            _window.MouseButtonReleased += OnClick;
            _window.MouseMoved += OnMove;
        }

        // Tegn objectet
        public void Draw()
        {
            if (_isVisible)
            {
                if (_active)
                {
                    _window.Draw(_activeShape);
                    foreach (Text item in _list)
                    {
                        _window.Draw(item);
                    }
                } else
                {
                    _window.Draw(_shape);
                    _window.Draw(_list[0]);
                }
            }
        }

        // Mouse click event
        public void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (_isVisible && e.Button == Mouse.Button.Left && IsInside(e))
            {
                if (!_active)
                {
                    _active = true;
                } else
                {

                }
            } else
            {
                _active = false;
            }
        }

        // Mouse move event
        public void OnMove(object sender, MouseMoveEventArgs e)
        {
            if (_active)
            {
                foreach (Text item in _list)
                {
                    if (item.GetGlobalBounds().Contains(e.X, e.Y))
                    {

                    }
                }
            }
        }

        // Check om musen er indenfor feltet
        public bool IsInside(MouseButtonEventArgs e)
        {
            if (!_active)
            {
                return _shape.GetGlobalBounds().Contains(e.X, e.Y);
            } else
            {
                return _activeShape.GetGlobalBounds().Contains(e.X, e.Y);
            }
        }
    }
}
