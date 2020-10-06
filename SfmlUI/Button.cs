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
        private RectangleShape _rectangleOuter;
        private RectangleShape _rectangleCenter;
        private RectangleShape _rectangleCenterPressed;
        private CircleShape _elipseOuter;
        private CircleShape _elipseCenter;
        private CircleShape _elipseCenterPressed;


        public Button(RenderWindow Window, Vector2f Position, Vector2f Size)
        {
            _window = Window;
            _position = Position;
            _size = Size;
            Origin = new Origin(_position, _size);

            _rectangleOuter = new RectangleShape(_size);
            _rectangleOuter.FillColor = _outerColor;
            _rectangleOuter.OutlineThickness = 1;
            _rectangleOuter.OutlineColor = _outerOutlineColor;
            _rectangleOuter.Position = Origin.TruePosition;
            
            _rectangleCenter = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f));
            _rectangleCenter.FillColor = _centerColor;
            _rectangleCenter.OutlineThickness = 3;
            _rectangleCenter.OutlineColor = _centerOutlineColor;
            _rectangleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);

            _rectangleCenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f));
            _rectangleCenterPressed.FillColor = _centerColor;
            _rectangleCenterPressed.OutlineThickness = 3;
            _rectangleCenterPressed.OutlineColor = _centerOutlineColor;
            _rectangleCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                Origin.TruePosition.Y + 0.075f * _size.Y);
            

            _elipseOuter = new CircleShape(_size.X / 2);
            _elipseOuter.FillColor = _outerColor;
            _elipseOuter.OutlineThickness = 1;
            _elipseOuter.OutlineColor = _outerOutlineColor;
            _elipseOuter.Position = Origin.TruePosition;
            _elipseOuter.Scale = new Vector2f(1f, _size.Y / _size.X);
            

            _elipseCenter = new CircleShape(_size.X * 0.9f / 2);
            _elipseCenter.FillColor = _centerColor;
            _elipseCenter.OutlineThickness = 3;
            _elipseCenter.OutlineColor = _centerOutlineColor;
            _elipseCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);
            _elipseCenter.Scale = new Vector2f(1f, _size.Y / _size.X);
            

            _elipseCenterPressed = new CircleShape(_size.X * 0.85f / 2);
            _elipseCenterPressed.FillColor = _centerColor;
            _elipseCenterPressed.OutlineThickness = 3;
            _elipseCenterPressed.OutlineColor = _centerOutlineColor;
            _elipseCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
            Origin.TruePosition.Y + 0.075f * _size.Y);
            _elipseCenterPressed.Scale = new Vector2f(1f, _size.Y / _size.X);

            Actions();
        }
        #endregion
        #region Properties & Fields
        private Color _centerColor = new Color(255, 0, 0);
        public Color CenterColor
        {
            get
            {
                return _centerColor;
            }
            set
            {
                _centerColor = value;
                _rectangleCenter.FillColor = _centerColor;
                _rectangleCenterPressed.FillColor = _centerColor;
                _elipseCenter.FillColor = _centerColor;
                _elipseCenterPressed.FillColor = _centerColor;
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
                _rectangleOuter.FillColor = _outerColor;
                _elipseOuter.FillColor = _outerColor;
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
                _rectangleOuter.OutlineColor = _outerColor;
                _elipseOuter.OutlineColor = _outerColor;
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
                _rectangleCenter.OutlineColor = _centerOutlineColor;
                _elipseOuter.OutlineColor = _centerOutlineColor;
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

                _rectangleCenter = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f));
                _rectangleCenter.FillColor = _centerColor;
                _rectangleCenter.OutlineThickness = 3;
                _rectangleCenter.OutlineColor = _centerOutlineColor;
                _rectangleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y);
                _elipseOuter.Position = Origin.TruePosition;
                _elipseCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y);
                _elipseCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
               Origin.TruePosition.Y + 0.075f * _size.Y);
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
                Origin.Size = new Vector2f(value.X, value.Y);

                _rectangleOuter = new RectangleShape(_size);

                _rectangleCenter = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f));
                _rectangleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y);

                _rectangleCenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f));
                _rectangleCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                    Origin.TruePosition.Y + 0.075f * _size.Y);

                _elipseOuter = new CircleShape(_size.X / 2);
                _elipseOuter.Scale = new Vector2f(1f, _size.Y / _size.X);

                _elipseCenter = new CircleShape(_size.X * 0.9f / 2);
                _elipseCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y);
                _elipseCenter.Scale = new Vector2f(1f, _size.Y / _size.X);

                _elipseCenterPressed = new CircleShape(_size.X * 0.85f / 2);
                _elipseCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
               Origin.TruePosition.Y + 0.075f * _size.Y);
                _elipseCenterPressed.Scale = new Vector2f(1f, _size.Y / _size.X);
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
        public event Action ButtonHeld;
        private void Actions()
        {

            _window.MouseButtonReleased += OnMouseButtonRealeased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;
        }
        public event Action ButtonRealeased;
        bool Pressed;
        private void OnMouseButtonRealeased(Object? sender, MouseButtonEventArgs e)
        {
            if (Pressed)
            {
                Pressed = false;
                ButtonRealeased?.Invoke();
            }

        }
        public event Action ButtonPressed;
        private void OnMouseButtonPressed(Object? sender, MouseButtonEventArgs e)
        {
            if (!Pressed && IsInside(e.X, e.Y))
            {
                Pressed = true;
                ButtonPressed?.Invoke();
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
            if (Shapes.Rectangle == _shape)
            {
                if (ex <= Size.X + Origin.TruePosition.X &&
                    ex >= Origin.TruePosition.X &&
                    ey <= Size.Y + Origin.TruePosition.Y &&
                    ey >= Origin.TruePosition.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }   
            else
            {
                
                if (MathF.Sqrt(MathF.Pow(MathF.Abs(ex - Focalpoint1.X), 2) + 
                    MathF.Pow(MathF.Abs(ey - Focalpoint1.Y), 2)) +
                    MathF.Sqrt(MathF.Pow(MathF.Abs(ex - Focalpoint2.X), 2) + 
                    MathF.Pow(MathF.Abs(ey - Focalpoint2.Y), 2)) <=
                    Radius)    
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
        public enum Shapes
        {
            Rectangle = 0,
            Elipse = 1
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
            }
        }
        private Vector2f Focalpoint1
        {
            get
            {
                if ((_size.X >= _size.Y))
                {
                    return new Vector2f(-MathF.Sqrt(MathF.Pow(_size.X / 2f, 2) - MathF.Pow(_size.Y / 2f, 2)) + Origin.TruePosition.X + _size.X/2f, 
                        Origin.TruePosition.Y + _size.Y/2f);
                }
                else
                {
                    return new Vector2f(Origin.TruePosition.X + _size.X/2f,
                        -MathF.Sqrt(MathF.Pow(_size.Y / 2f, 2) - MathF.Pow(_size.X / 2f, 2)) + Origin.TruePosition.Y + _size.Y/2f);
                }
            }
        }
        private Vector2f Focalpoint2
        {
            get
            {
                if ((_size.X >= _size.Y))
                {
                    return new Vector2f(MathF.Sqrt(MathF.Pow(_size.X / 2f, 2) - MathF.Pow(_size.Y / 2f, 2)) + Origin.TruePosition.X + _size.X/2f,
                        Origin.TruePosition.Y + _size.Y/2f);
                }
                else
                {
                    return new Vector2f(Origin.TruePosition.X + _size.X/2f,
                        MathF.Sqrt(MathF.Pow(_size.Y / 2f, 2) - MathF.Pow(_size.X / 2f, 2)) + Origin.TruePosition.Y + _size.Y/2f);
                }
            }
        }
        private float Radius
        {
            get
            {
                if (_size.X >= _size.Y)
                {
                    return MathF.Abs(Origin.TruePosition.X + Size.X - Focalpoint1.X + Origin.TruePosition.X + Size.X - Focalpoint2.X);
                }
                else
                {
                    return MathF.Abs(Origin.TruePosition.Y + Size.Y - Focalpoint1.Y + Origin.TruePosition.Y + Size.Y - Focalpoint2.Y);
                }
            }
        }
       
        public void Draw()
        {
            

            if (Pressed)
            {
                ButtonHeld?.Invoke();
                if (!IsInside(MousePosition.X, MousePosition.Y))
                {
                    Pressed = false;
                }
            }
            

            if (_isVisible == true)
            {
                if (_shape == Shapes.Rectangle)
                {
                    _window.Draw(_rectangleOuter);
                    if (!Pressed)
                    {
                        _window.Draw(_rectangleCenter);
                    }
                    else
                    {
                        _window.Draw(_rectangleCenterPressed);
                    }
                }
                else
                {
                    _window.Draw(_elipseOuter);
                    if (!Pressed)
                    {
                        _window.Draw(_elipseCenter);
                    }
                    else
                    {
                        _window.Draw(_elipseCenterPressed);
                    }
                }
            }
        }
    }

}
#endregion


