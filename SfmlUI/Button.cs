using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SfmlUI
{
    public class Button : IUiElement
    {
        #region Constructer
        public Origin Origin;

        public Button(RenderWindow Window, Vector2f Position, Vector2f Size)
        {
            _window = Window;
            _position = Position;
            _size = Size;
            Origin = new Origin(_position, _size);

            Actions();
        }
        #endregion
        #region Properties & Fields
        private Color _innerColor = new Color(255, 0, 0);
        public Color InnerColor
        {
            get
            {
                return _innerColor;
            }
            set
            {
                _innerColor = value;
            }
        }
        private Color _outerColor = new Color(100, 100, 100);
        public Color OuterColor
        {
            get
            {
                return _outerColor;
            }
            set
            {
                _outerColor = value;
            }
        }
        private Color _outerOutlineColor = new Color(0, 0, 0);
        public Color OuterOutlineColor
        {
            get
            {
                return _outerOutlineColor;
            }
            set
            {
                _outerOutlineColor = value;
            }
        }
        private Color _centerOutlineColor = new Color(0, 0, 0);
        public Color CenterOutlineColor
        {
            get
            {
                return _centerOutlineColor;
            }
            set
            {
                _centerOutlineColor = value;
            }
        }
        private RenderWindow _window;
        public RenderWindow Window
        {
            get
            {
                return _window;
            }
            set
            {
                _window = value;
            }
        }
        private bool _isVisible = true;
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
                Origin.Position = value;

            }
        }

        private Vector2f _size;
        public Vector2f Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                Origin.Size = value;
            }
        }
        public float Height
        {
            get
            {
                return _size.X;

            }
            set
            {
                _size.X = value;
            }
        }
        public float Width
        {
            get
            {
                return _size.Y;

            }
            set
            {
                _size.Y = value;
            }
        }
        #endregion
        #region Actions
        public event Action MouseHeld;
        private void Actions()
        {

            _window.MouseButtonReleased += OnMouseButtonRealeased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;
        }
        public event Action MouseRealeased;
        bool Pressed;
        private void OnMouseButtonRealeased(Object? sender, MouseButtonEventArgs e)
        {
            if (Pressed)
            {
                Pressed = false;
                MouseRealeased?.Invoke();
            }

        }
        public event Action MousePressed;
        private void OnMouseButtonPressed(Object? sender, MouseButtonEventArgs e)
        {
            if (!Pressed && e.X <= Origin.Horizontal.TruePosition + _size.X && e.X >= Origin.Horizontal.TruePosition && e.Y <= Origin.Vertical.TruePosition + _size.Y && e.Y >= Origin.Vertical.TruePosition)
            {
                Pressed = true;
                MousePressed?.Invoke();
            }

        }
        private Vector2f MousePosition;
        private void OnMouseMoved(Object? sender, MouseMoveEventArgs e)
        {
            MousePosition.X = e.X;
            MousePosition.Y = e.Y;
        }
        #endregion
        #region Draw
        public void Draw()
        {
            if (Pressed)
            {
                MouseHeld?.Invoke();
                if (!(MousePosition.X <= Origin.TruePosition.X + _size.X &&
                    MousePosition.X >= Origin.TruePosition.X &&
                    MousePosition.Y <= Origin.TruePosition.Y + _size.Y &&
                    MousePosition.Y >= Origin.TruePosition.Y))
                {
                    Pressed = false;
                }
            }
            var Outer = new RectangleShape(_size);
            Outer.FillColor = _outerColor;
            Outer.OutlineThickness = 1;
            Outer.OutlineColor = _outerOutlineColor;
            Outer.Position = Origin.TruePosition;


            var Center = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f));
            Center.FillColor = _innerColor;
            Center.OutlineThickness = 3;
            Center.OutlineColor = _centerOutlineColor;
            Center.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);

            var CenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f));
            CenterPressed.FillColor = _innerColor;
            CenterPressed.OutlineThickness = 3;
            CenterPressed.OutlineColor = _centerOutlineColor;
            CenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                Origin.TruePosition.Y + 0.075f * _size.Y);

            if (_isVisible == true)
            {
                _window.Draw(Outer);
                if (!Pressed)
                {
                    _window.Draw(Center);
                }
                else
                {
                    _window.Draw(CenterPressed);
                }
            }
        }
    }

}
#endregion