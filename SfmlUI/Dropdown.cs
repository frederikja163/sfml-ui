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

        // private ekstra metoder
        private float Right { get { return _position.X + _size.X; } }
        private float Left { get { return _position.Y; } }
        private float Top { get { return _position.X; } }
        private float Bottom { get { return _position.Y + _size.Y; } }



        public Dropdown(RenderWindow window, Vector2f position, Vector2f size, Shape shape, params Text[] textList)
        {
            _window = window;
            _isVisible = true;

            if (position == null) { _position = new Vector2f(0, 0); } // hvis ingen input sæt en default værdi
            else { _position = position; }

            if (size == null) { _size = new Vector2f(100, 20); } // hvis ingen input sæt en default værdi
            else { _size = size; }

            if (shape == null) { _shape = new RectangleShape(_size); } // hvis ingen input sæt en default værdi
            else { _shape = shape; }

            _active = false;
            foreach (Text item in textList)
            {
                _list.Add(item);
            }
        }

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
                _active = true;
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
