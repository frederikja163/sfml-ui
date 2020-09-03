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
        private List<Text> _list = new List<Text>();

        // nedarvede metoder
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }

        public Vector2f Position { get { return _position; } }

        public float Width { get { return _size.X; } }

        public float Height { get { return _size.Y; } }

        // public ekstra metoder
        public Shape Shape { get { return _shape; } set { _shape = value; } }


        // private ekstra metoder
        private float Right { get { return _position.X + _size.X; } }
        private float Left { get { return _position.Y; } }
        private float Top { get { return _position.X; } }
        private float Bottom { get { return _position.Y + _size.Y; } }

        // konstruktøren
        public Dropdown(RenderWindow window, Vector2f position, Vector2f size, params Text[] textList)
        {
            _window = window;
            _isVisible = true;
            _position = position;
            _size = size;
            _shape = new RectangleShape(size);
            _shape.Position = position;
            _active = false;
            foreach (Text item in textList)
            {
                _list.Add(item);
            }

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

                } else
                {
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
            if ((e.X <= Right && e.X >= Left) && (e.Y <= Bottom && e.Y >= Top))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
