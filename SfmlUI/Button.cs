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
            _Size = Size;
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
                if (_shape == Shapes.Rectangle)
                {
                    _size = value;
                    Origin.Size = new Vector2f(value.X, value.Y);
                }
                else
                {
                    Origin.Size = new Vector2f(value.X, value.X);
                }
                _Size = value;
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
                _Size.Y = value;
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
            if (!Pressed && IsInside(e.X,e.Y))
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
        public bool IsInside(float ex, float ey)
        {
            if(Shapes.Rectangle == _shape)
            {
                return _rectangleOuter.GetGlobalBounds().Contains(ex, ey);
            }
            else
            {
                if (Math.Pow(ex - Origin.TruePosition.X - Size.X/2, 2) + Math.Pow(ey - Origin.TruePosition.Y - Size.X/2, 2) <=
                    Math.Pow(Size.X/2, 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion
        #region Draw
        private Vector2f _Size;
        public enum Shapes
        {
            Rectangle = 0,
            Circle = 1
        }
        private Shapes _shape;
        public Shapes Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                _shape = value;
                if(value == Shapes.Circle)
                {
                    Size = new Vector2f(Size.X, Size.X);
                }
                _size = _Size;
            }
        }


        private RectangleShape _rectangleOuter;
        public void Draw()
        {
            var RectangleOuter = new RectangleShape(_size);
            RectangleOuter.FillColor = _outerColor;
            RectangleOuter.OutlineThickness = 1;
            RectangleOuter.OutlineColor = _outerOutlineColor;
            RectangleOuter.Position = Origin.TruePosition;
            _rectangleOuter = RectangleOuter;


            var RectangleCenter = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f));
            RectangleCenter.FillColor = _innerColor;
            RectangleCenter.OutlineThickness = 3;
            RectangleCenter.OutlineColor = _centerOutlineColor;
            RectangleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);

            var RectangleCenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f));
            RectangleCenterPressed.FillColor = _innerColor;
            RectangleCenterPressed.OutlineThickness = 3;
            RectangleCenterPressed.OutlineColor = _centerOutlineColor;
            RectangleCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                Origin.TruePosition.Y + 0.075f * _size.Y);

            var CircleOuter = new CircleShape(_size.X/2);
            CircleOuter.FillColor = _outerColor;
            CircleOuter.OutlineThickness = 1;
            CircleOuter.OutlineColor = _outerOutlineColor;
            CircleOuter.Position = Origin.TruePosition;

            var CircleCenter = new CircleShape(_size.X * 0.9f/2);
            CircleCenter.FillColor = _innerColor;
            CircleCenter.OutlineThickness = 3;
            CircleCenter.OutlineColor = _centerOutlineColor;
            CircleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.X);

            var CircleCenterPressed = new CircleShape(_size.X * 0.85f/2);
            CircleCenterPressed.FillColor = _innerColor;
            CircleCenterPressed.OutlineThickness = 3;
            CircleCenterPressed.OutlineColor = _centerOutlineColor;
            CircleCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                Origin.TruePosition.Y + 0.075f * _size.X);
            if (Pressed)
            {
                MouseHeld?.Invoke();
                if (!IsInside(MousePosition.X, MousePosition.Y))
                {
                    Pressed = false;
                }
            }
            

            if (_isVisible == true)
            {
                if (_shape == Shapes.Rectangle)
                {
                    _window.Draw(RectangleOuter);
                    if (!Pressed)
                    {
                        _window.Draw(RectangleCenter);
                    }
                    else
                    {
                        _window.Draw(RectangleCenterPressed);
                    }
                }
                else
                {
                    _window.Draw(CircleOuter);
                    if (!Pressed)
                    {
                        _window.Draw(CircleCenter);
                    }
                    else
                    {
                        _window.Draw(CircleCenterPressed);
                    }
                }
            }
        }
    }

}
#endregion


