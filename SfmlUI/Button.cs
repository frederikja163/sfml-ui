using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SfmlUI
{
    public class Button : IUiElement
    {
        #region Constructers
        public Button(RenderWindow window)
        {
            _window = window;
            Origin = new Origin(_position, _size);
            UpdateShapes();
            Actions();
        }

        public Button(RenderWindow window, Vector2f position)
        {
            _window = window;
            _position = position;
            Origin = new Origin(_position, _size);
            UpdateShapes();
            Actions();
        }

        public Button(RenderWindow window, Vector2f position, Vector2f size)
        {
            _window = window;
            _position = position;
            _size = size;
            Origin = new Origin(_position, _size);

            UpdateShapes();
            Actions();
        }

        public Button(RenderWindow window, Vector2f position, Vector2f size, bool isVisible)
        {
            _window = window;
            _position = position;
            _size = size;
            _isVisible = isVisible;
            Origin = new Origin(_position, _size);
            UpdateShapes();
            Actions();
        }

        public Button(RenderWindow window, Vector2f position, Vector2f size, Color centerColor, Color outerColor)
        {
            _window = window;
            _position = position;
            _size = size;
            _centerColor = centerColor;
            _outerColor = outerColor;
            Origin = new Origin(_position, _size);
            UpdateShapes();
            Actions();
        }
        
        public Button(RenderWindow window, Vector2f position, Vector2f size,Shapes shape)
        {
            _window = window;
            _position = position;
            _size = size;
            _shape = shape;
            Origin = new Origin(_position, _size);

            UpdateShapes();
            Actions();
        }
        
        public Button(RenderWindow window, Vector2f position, Vector2f size,Shapes shape, bool isVisible)
        {
            _window = window;
            _position = position;
            _size = size;
            _shape = shape;
            _isVisible = isVisible;
            Origin = new Origin(_position, _size);

            UpdateShapes();
            Actions();
        }

        public Button(RenderWindow window, Vector2f position, Vector2f size, Shapes shape, Color centerColor, Color outerColor)
        {
            _window = window;
            _position = position;
            _size = size;
            _shape = shape;
            _centerColor = centerColor;
            _outerColor = outerColor;
            Origin = new Origin(_position, _size);

            UpdateShapes();
            Actions();
        }
        #endregion
        #region Properties & Fields
        public Origin Origin;
        private RectangleShape _rectangleOuter;
        private RectangleShape _rectangleCenter;
        private RectangleShape _rectangleCenterPressed;
        private CircleShape _elipseOuter;
        private CircleShape _elipseCenter;
        private CircleShape _elipseCenterPressed;
        private Color _centerColor = new Color(255, 0, 0);
        public Color CenterColor
        {
            get => _centerColor;
            set
            {
                _centerColor = value;
                UpdateShapes();
            }
        }
        private Color _outerColor = new Color(100, 100, 100);
        public Color OuterColor
        {
            get => _outerColor;
            set
            {
                _outerColor = value;
                UpdateShapes();
            }
        }
        private Color _outerOutlineColor = new Color(0, 0, 0, 0);
        public Color OuterOutlineColor
        {
            get => _outerOutlineColor;
            set
            {
                _outerOutlineColor = value;
                UpdateShapes();
            }
        }
        private Color _centerOutlineColor = new Color(0, 0, 0, 0);
        public Color CenterOutlineColor
        {
            get => _centerOutlineColor;
            set
            {
                _centerOutlineColor = value;
                UpdateShapes();
            }
        }
        private RenderWindow _window;
        public RenderWindow Window
        {
            get => _window;
            set => _window = value;
        }
        private bool _isVisible = true;
        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }
        private Vector2f _position;
        public Vector2f Position
        {
            get => _position;
            set
            {
                _position = value;
                Origin.Position = value;
                UpdateShapes();
            }
        }

        private Vector2f _size;
        public Vector2f Size
        {
            get => _size;
            set
            {
                _size = value;
                Origin.Size = new Vector2f(value.X, value.Y);
                UpdateShapes();
            }
        }
        public float Height
        {
            get => _size.X;
            set => _size.X = value;
        }
        public float Width
        {
            get => _size.Y;
            set => _size.Y = value;
        }
         public enum Shapes
        {
            Rectangle = 0,
            Elipse = 1
        }
        private Shapes _shape;
        public Shapes Shape
        {
            get => _shape;
            set => _shape = value;
        }
        private Vector2f Focalpoint1
        {
            get
            {
                if ((_size.X >= _size.Y))
                {
                    return new Vector2f(
                        -MathF.Sqrt(MathF.Pow(_size.X / 2f, 2) - MathF.Pow(_size.Y / 2f, 2)) + Origin.TruePosition.X +
                        _size.X / 2f, Origin.TruePosition.Y + _size.Y / 2f);
                }
                else
                {
                    return new Vector2f(Origin.TruePosition.X + _size.X / 2f,
                        -MathF.Sqrt(MathF.Pow(_size.Y / 2f, 2) - MathF.Pow(_size.X / 2f, 2)) + Origin.TruePosition.Y +
                        _size.Y / 2f);
                }
            }
        }
        private Vector2f Focalpoint2
        {
            get
            {
                if ((_size.X >= _size.Y))
                {
                    return new Vector2f(
                        MathF.Sqrt(MathF.Pow(_size.X / 2f, 2) - MathF.Pow(_size.Y / 2f, 2)) + Origin.TruePosition.X +
                        _size.X / 2f, Origin.TruePosition.Y + _size.Y / 2f);
                }
                else
                {
                    return new Vector2f(Origin.TruePosition.X + _size.X / 2f,
                        MathF.Sqrt(MathF.Pow(_size.Y / 2f, 2) - MathF.Pow(_size.X / 2f, 2)) + Origin.TruePosition.Y +
                        _size.Y / 2f);
                }
            }
        }
        private float Radius =>
            _size.X >= _size.Y
                ? MathF.Abs(Origin.TruePosition.X + Size.X - Focalpoint1.X + Origin.TruePosition.X + Size.X -
                            Focalpoint2.X)
                : MathF.Abs(Origin.TruePosition.Y + Size.Y - Focalpoint1.Y + Origin.TruePosition.Y + Size.Y -
                            Focalpoint2.Y);

        public bool IsInside(float ex, float ey)
        {
            return Shapes.Rectangle == _shape
                ? _rectangleOuter.GetGlobalBounds().Contains(ex, ey)
                : MathF.Sqrt(MathF.Pow(MathF.Abs(ex - Focalpoint1.X), 2) +
                             MathF.Pow(MathF.Abs(ey - Focalpoint1.Y), 2)) +
                  MathF.Sqrt(MathF.Pow(MathF.Abs(ex - Focalpoint2.X), 2) +
                             MathF.Pow(MathF.Abs(ey - Focalpoint2.Y), 2)) <=
                  Radius;
        }

        private bool _active = true;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                if (!value) return;
                if (!Pressed || _mouseOverButton)
                {
                    OnMovedOf?.Invoke();
                }
                Pressed = false;
            } 
        }

        private bool _mouseOverButton;
        #endregion
        #region Actions
        public event Action ButtonHeld;
        private void Actions()
        {

            _window.MouseButtonReleased += OnMouseButtonReleased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;
            
            Origin.OnOriginChanged += UpdateShapes;
        }
        public event Action ButtonReleased;
        private bool Pressed { get; set; }
        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (!Pressed || !Active) return;
            Pressed = false;
            ButtonReleased?.Invoke();
        }
        public event Action ButtonPressed;
        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (Pressed || !IsInside(e.X, e.Y) || !Active) return;
            Pressed = true;
            ButtonPressed?.Invoke();

        }
        private Vector2f _mousePosition;
        public event Action OnHover;
        public event Action OnMovedOf;
        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            _mousePosition.X = e.X;
            _mousePosition.Y = e.Y;
            if (!_active) return;
            if (!_mouseOverButton && IsInside(e.X, e.Y))
            {
                _mouseOverButton = true;
                OnHover?.Invoke();
            }
            else if (_mouseOverButton && !IsInside(e.X, e.Y))
            {
                _mouseOverButton = false;
                OnMovedOf?.Invoke();
            }
        }
        #endregion
        #region Draw
       

        private void UpdateShapes()
        {
            _rectangleOuter = new RectangleShape(_size)
            {
                FillColor = _outerColor,
                OutlineThickness = 1,
                OutlineColor = _outerOutlineColor,
                Position = Origin.TruePosition
            };

            _rectangleCenter = new RectangleShape(new Vector2f(_size.X * 0.9f, _size.Y * 0.9f))
            {
                FillColor = _centerColor,
                OutlineThickness = 3,
                OutlineColor = _centerOutlineColor,
                Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y)
            };

            _rectangleCenterPressed = new RectangleShape(new Vector2f(_size.X * 0.85f, _size.Y * 0.85f))
            {
                FillColor = _centerColor,
                OutlineThickness = 3,
                OutlineColor = _centerOutlineColor,
                Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                    Origin.TruePosition.Y + 0.075f * _size.Y)
            };
            
            _elipseOuter = new CircleShape(_size.X / 2)
            {
                FillColor = _outerColor,
                OutlineThickness = 1,
                OutlineColor = _outerOutlineColor,
                Position = Origin.TruePosition,
                Scale = new Vector2f(1f, _size.Y / _size.X)
            };
            
            _elipseCenter = new CircleShape(_size.X * 0.9f / 2)
            {
                FillColor = _centerColor,
                OutlineThickness = 3,
                OutlineColor = _centerOutlineColor,
                Position = new Vector2f(Origin.TruePosition.X + 0.05f * _size.X,
                    Origin.TruePosition.Y + 0.05f * _size.Y),
                Scale = new Vector2f(1f, _size.Y / _size.X)
            };
            
            _elipseCenterPressed = new CircleShape(_size.X * 0.85f / 2)
            {
                FillColor = _centerColor,
                OutlineThickness = 3,
                OutlineColor = _centerOutlineColor,
                Position = new Vector2f(Origin.TruePosition.X + 0.075f * _size.X,
                    Origin.TruePosition.Y + 0.075f * _size.Y),
                Scale = new Vector2f(1f, _size.Y / _size.X)
            };
        }
        public void Draw()
        {
            if (Pressed && _active)
            {
                ButtonHeld?.Invoke();
                if (!IsInside(_mousePosition.X, _mousePosition.Y))
                {
                    Pressed = false;
                }
            }

            if (!_isVisible) return;
            if (_shape == Shapes.Rectangle)
            {
                _window.Draw(_rectangleOuter);
                _window.Draw(Pressed && _active ? _rectangleCenterPressed : _rectangleCenter);
            }
            else
            {
                _window.Draw(_elipseOuter);
                _window.Draw(Pressed && _active ? _elipseCenterPressed : _elipseCenter);
            }
        }
        #endregion
    }

}


