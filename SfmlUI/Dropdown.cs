using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.ComponentModel;

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
        private uint _fontSize = 0;
        private List<Text> _list = new List<Text>();

        // nedarvede metoder
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }

        public Vector2f Position { get { return _position; } }

        public float Width { get { return _size.X; } }

        public float Height { get { return _size.Y; } }

        // public ekstra metoder
        public Shape Shape { get { return _shape; } set { _shape = value; } }


        // private ekstra metoder
        private float Right { get { return _position.X + _size.X * _shape.Scale.X; } }
        private float Left { get { return _position.Y; } }
        private float Top { get { return _position.X; } }
        private float Bottom { get { return _position.Y + _size.Y * _shape.Scale.Y; } }

        // konstruktøren
        public Dropdown(RenderWindow window, Vector2f position, float width, Font font, uint fontSize, params string[] textList)
        {
            _fontSize = fontSize;
            foreach (string item in textList)
            {
                _list.Add(new Text(item, font, fontSize));
            }
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Position = new Vector2f(position.X, position.Y + fontSize * i);
            }
            _window = window;
            _isVisible = true;
            _position = position;
            _size = new Vector2f(width, fontSize);
            _shape = new RectangleShape(new Vector2f(width, fontSize));
            _shape.Position = position;
            _shape.Scale = new Vector2f(1, 1);
            _shape.OutlineColor = Color.Black;
            _shape.OutlineThickness = 2;
            _active = false;

            // sæt event handler for musen
            _window.MouseButtonReleased += OnClick;
        }

        // Tegn objectet
        public void Draw()
        {
            if (_isVisible)
            {
                if (_active)
                {
                    _shape.Scale = new Vector2f(1, _list.Count);
                    _size.Y = _fontSize * _list.Count;
                    _window.Draw(_shape);
                    foreach (Text item in _list)
                    {
                        _window.Draw(item);
                    }
                } else
                {
                    _shape.Scale = new Vector2f(1, 1);
                    _size.Y = _fontSize;
                    _window.Draw(_shape);
                }
            }
        }

        // Click event
        public void OnClick( object sender, MouseButtonEventArgs e)
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

        // Check om musen er indenfor feltet
        public bool IsInside(MouseButtonEventArgs e)
        {
            return (e.X <= Right && e.X >= Left) && (e.Y <= Bottom && e.Y >= Top);
        }
    }
}
