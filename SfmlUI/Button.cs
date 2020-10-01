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
                Origin.Size = new Vector2f(value.X, value.Y);
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
                return _rectangleOuter.GetGlobalBounds().Contains(ex, ey);
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
            RectangleCenter.FillColor = _centerColor;
            RectangleCenter.OutlineThickness = 3;
            RectangleCenter.OutlineColor = _centerOutlineColor;
            RectangleCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);

            var RectangleCenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f));
            RectangleCenterPressed.FillColor = _centerColor;
            RectangleCenterPressed.OutlineThickness = 3;
            RectangleCenterPressed.OutlineColor = _centerOutlineColor;
            RectangleCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                Origin.TruePosition.Y + 0.075f * _size.Y);

            var ElipseOuter = new CircleShape(_size.X/2);
            ElipseOuter.FillColor = _outerColor;
            ElipseOuter.OutlineThickness = 1;
            ElipseOuter.OutlineColor = _outerOutlineColor;
            ElipseOuter.Position = Origin.TruePosition;
            ElipseOuter.Scale = new Vector2f(1f, _size.Y/_size.X);

            var ElipseCenter = new CircleShape(_size.X * 0.9f/2);
            ElipseCenter.FillColor = _centerColor;
            ElipseCenter.OutlineThickness = 3;
            ElipseCenter.OutlineColor = _centerOutlineColor;
            ElipseCenter.Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                Origin.TruePosition.Y + 0.05f * _size.Y);
            ElipseCenter.Scale = new Vector2f(1f, _size.Y / _size.X);

            var ElipseCenterPressed = new CircleShape(_size.X * 0.85f/2);
            ElipseCenterPressed.FillColor = _centerColor;
            ElipseCenterPressed.OutlineThickness = 3;
            ElipseCenterPressed.OutlineColor = _centerOutlineColor;
            ElipseCenterPressed.Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
            Origin.TruePosition.Y + 0.075f * _size.Y);
            ElipseCenterPressed.Scale = new Vector2f(1f, _size.Y / _size.X);

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
                    _window.Draw(ElipseOuter);
                    if (!Pressed)
                    {
                        _window.Draw(ElipseCenter);
                    }
                    else
                    {
                        _window.Draw(ElipseCenterPressed);
                    }
                }
            }
        }
    }

}
#endregion


