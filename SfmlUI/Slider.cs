using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SfmlUI
{
    public class Slider : IUiElement
    {
        private static RenderWindow _window;
        public Slider(RenderWindow window, Vector2f Position, float Width, float Height, float Min, float Max)
        {
            _window = window;
            _position = Position;
            _handlePos = Position;
            _height = Height;
            _width = Width;
            _min = Min;
            _max = Max;
            _isVisible = true;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;
            _window.MouseButtonReleased += OnMouseButtonReleased;
        }


        private bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return _isVisible;

            }
            set
            {
                _isVisible = value;
            }
        }
        private Vector2f _position;
        public Vector2f Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        private Vector2f _handlePos;
        private float _min;
        public float Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }
        private float _max;
        public float Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }

        private float _width;
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        private float _height;
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        private bool _clicked;
        public float Value
        {
            get
            {
                return (_handlePos.X - Position.X-(_width/20)) / _width*22.22f/20f;
            }
        }

        public void Draw()
        {
            var back = new RectangleShape(new Vector2f(2000, 1000));
            back.FillColor = new Color(255, 255, 255);
            back.Position = new Vector2f(0, 0);

            var rail = new RectangleShape(new Vector2f(_width, _height));
            rail.FillColor = new Color(220, 220, 220);
            rail.Position = _position;

            var handle = new RectangleShape(new Vector2f(_width / 10, _height));
            handle.FillColor = new Color(100, 100, 100);
            handle.Position = _handlePos;
            handle.Origin = new Vector2f(_width / 20f, 0f);


            if (_isVisible == true)
            {
                _window.Draw(back);


                _window.Draw(rail);
                _window.Draw(handle);
            }
        }
        private void OnMouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            _clicked = UpdateHandle(new Vector2f(e.X, e.Y));
        }

        private bool UpdateHandle(Vector2f mousePos)
        {
            float hwidth = _width / (2f * 10f);
            if (mousePos.X >= _position.X + hwidth && mousePos.X <= _position.X + _width - hwidth &&
                mousePos.Y >= _position.Y && mousePos.Y <= _position.Y + _height)
            {
                _handlePos = new Vector2f(mousePos.X, _position.Y);
                return true;
            }
            else if (mousePos.X >= _position.X && mousePos.X <= _position.X + hwidth &&
                mousePos.Y >= _position.Y && mousePos.Y <= _position.Y + _height)
            {
                _handlePos = new Vector2f(_position.X + hwidth, _position.Y);
                return true;
            }

            else if (mousePos.X >= _position.X + _width - hwidth && mousePos.X <= _position.X + _width &&
                mousePos.Y >= _position.Y && mousePos.Y <= _position.Y + _height)
            {
                _handlePos = new Vector2f(_position.X + _width - hwidth, _position.Y);
                return true;
            }
            return false;

        }
        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (!_clicked)
            {
                return;

            }
            UpdateHandle(new Vector2f(e.X, _position.Y));
        }
        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            _clicked = false;
        }
    }
}
