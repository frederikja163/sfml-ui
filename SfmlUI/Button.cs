using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SfmlUI
{
    public class Button : IUiElement
    {
        
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
        public event Action MouseHeld;
        private void Update()
        {
            
            _window.MouseButtonReleased += OnMouseButtonRealeased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
            _window.MouseMoved += OnMouseMoved;
            if(Pressed)
            {
                MouseHeld?.Invoke();
            }
            
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
            if (!Pressed && e.X <=_position.X + _height && e.X >= _position.X && e.Y <= _position.Y + _width && e.Y >= _position.Y)
            {
                Pressed = true;
                MousePressed?.Invoke();
            }
            
        }
        private void OnMouseMoved(Object? sender, MouseMoveEventArgs e)
        {
            if (Pressed)
            {
                if (!(e.X <= _position.X + _height && e.X >= _position.X && e.Y <= _position.Y + _width && e.Y >= _position.Y))
                {
                    Pressed = false;
                }
            }
        }


        public void Draw()
        {
            Update();
            

            var radio = new RectangleShape(new Vector2f(_height, _width));
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
