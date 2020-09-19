using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SfmlUI
{
    public class Button : IUiElement
    {
        #region Constructer
        private static Allign_ _allign;
        public Allign_ Allign;
        
        public Button(RenderWindow Window, Vector2f Position, Vector2f Size)
        {
            _window = Window;
            _position = Position;
            _size = Size;
            _allign = new Allign_(_position,_size);
            Allign = _allign;

            Update();
        }
        #endregion
        #region variabels
        private static RenderWindow _window;
       
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
                _allign.Horizontal.Update(_position.X, Size.X);
                _allign.Vertical.Update(_position.Y, Size.Y);

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
                _allign.Horizontal.Update(_position.X, Size.X);
                _allign.Vertical.Update(_position.Y, Size.Y);
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
                _allign.Vertical.Update(_position.Y, Size.Y);
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
                _allign.Horizontal.Update(_position.X, Size.X);
            }
        }
        
        #endregion
        #region Actions
        public event Action MouseHeld;
        private void Update()
        {
            
            _window.MouseButtonReleased += OnMouseButtonRealeased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;            
        }
        public event Action MouseRealeased;
        bool Pressed;
        private void OnMouseButtonRealeased(Object? sender, MouseButtonEventArgs e)
        {
            if(Pressed)
            {
                Pressed = false;
                MouseRealeased?.Invoke();
            }
            
        }
        public event Action MousePressed;
        private void OnMouseButtonPressed(Object? sender, MouseButtonEventArgs e)
        {
            if (!Pressed && e.X <=_allign.Horizontal.TruePosition + _size.X && e.X >= _allign.Vertical.TruePosition && e.Y <= _allign.Vertical.TruePosition + _size.Y && e.Y >= _allign.Vertical.TruePosition)
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
            

            //Update();

            if (Pressed)
            {
                MouseHeld?.Invoke();
                if (!(MousePosition.X <= _allign.Horizontal.TruePosition + _size.X && MousePosition.X >= _allign.Horizontal.TruePosition && MousePosition.Y <= _allign.Vertical.TruePosition + _size.Y && MousePosition.Y >= _allign.Vertical.TruePosition))
                {
                    Pressed = false;
                }
            }
            var radio = new RectangleShape(_size);
            radio.FillColor = new Color(100, 100, 100);
            radio.OutlineThickness = 10;
            radio.OutlineColor = new Color(0, 0, 0);
            radio.Position = new Vector2f(_allign.Horizontal.TruePosition, _allign.Vertical.TruePosition);

            if (_isVisible == true)
            {
                

                _window.Draw(radio);
                
                
            }
        }
        #endregion
        #region Align
        public class Allign_
        {
            private static Horizontal_ _horizontal;
            public Horizontal_ Horizontal;

            private static Vertical_ _vertical;
            public Vertical_ Vertical;
            public Allign_(Vector2f Position,Vector2f Size)
            {
                _horizontal = new Horizontal_(Position.X, Size.X);
                Horizontal = _horizontal;
                _vertical = new Vertical_(Position.Y, Size.Y);
                Vertical = _vertical;
            }
            
            
            public class Horizontal_
            {
                private float _size;
                private float _position;
                public float TruePosition
                {
                    get
                    {
                        return _position + _displacement;
                    }
                    private set
                    {

                    }
                }
                private float _displacement;
                public Horizontal_(float Position, float Size)
                {
                    _size = Size;
                    _position = Position;
                }
                public void Update(float Position, float Size)
                {
                    _size = Size;
                    _position = Position;
                }
                public void Left()
                {
                    _displacement = 0;
                }
                public void Center()
                {
                    _displacement = -_size / 2;
                }
                public void Right()
                {
                    _displacement = -_size;
                }
            }
            public class Vertical_
            {
                private float _size;
                private float _position;
                public float TruePosition
                {
                    get
                    {
                        return _position + _displacement;
                    }
                    private set
                    {

                    }
                }
                private float _displacement;
                public Vertical_(float Position, float Size)
                {
                    _size = Size;
                    _position = Position;
                }
                public void Update(float Position, float Size)
                {
                    _size = Size;
                    _position = Position;
                }
                public void Top()
                {
                    _displacement = 0;
                }
                public void Center()
                {
                    _displacement = -_size / 2;
                }
                public void Buttom()
                {
                    _displacement = -_size;
                }
            }
        }
        #endregion
    }
}
