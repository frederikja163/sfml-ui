using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SfmlUI
{
    public class Button : IUiElement
    {
        
        
        public Button(RenderWindow Window, Vector2f Position, Vector2f Size)
        {
            _window = Window;
            _position = Position;
            _size = Size;
            //HorizontalAlign = alignHorizontal.Left;
            //VerticalAlign = alignVertical.Top;



            Update();
        }

        private static RenderWindow _window;
        /*public enum alignHorizontal { Center, Left, Right };
        private alignHorizontal _horizontalAlign = alignHorizontal.Left;
        public alignHorizontal HorizontalAlign {
            get
            {
                return HorizontalAlign;
            }
            set
            {
                
            }
        }
        void VerticalAlign.Top()
        {

        }
        public enum alignVertical { Top, Center, Buttom };
        private alignVertical _verticalAlign = alignVertical.Top;
        public alignVertical VerticalAlign
        {
            get
            {
                return VerticalAlign;
            }
            set
            {

            }
        }*/
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
            if (!Pressed && e.X <=_position.X + _size.X && e.X >= _position.X && e.Y <= _position.Y + _size.Y && e.Y >= _position.Y)
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


        public void Draw()
        {
            
            
            //Update();

            if (Pressed)
            {
                MouseHeld?.Invoke();
                if (!(MousePosition.X <= _position.X + _size.X && MousePosition.X >= _position.X && MousePosition.Y <= _position.Y + _size.Y && MousePosition.Y >= _position.Y))
                {
                    Pressed = false;
                }
            }
            var radio = new RectangleShape(_size);
            radio.FillColor = new Color(100, 100, 100);
            radio.OutlineThickness = 10;
            radio.OutlineColor = new Color(0, 0, 0);
            radio.Position = _position;

            if (_isVisible == true)
            {
                

                _window.Draw(radio);
                
                
            }
        }
        //private void OnMouseReleased(object sender, keyE)
    }
}
