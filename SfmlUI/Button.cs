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
        private float _hight;
        public float Height
        {
            get
            {
                return _hight;
            }
            set
            {
                _hight = value;
            }
        }
        public event Action MouseHeld;
        private void Update()
        {
            
            _window.MouseButtonReleased += OnMouseButtonRealeased;
            _window.MouseButtonPressed += OnMouseButtonPressed;
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
        private void OnMouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            if (!Pressed && e.X <=_position.X + _hight && e.X >= _position.X && e.Y <= _position.Y + _width && e.Y >= _position.Y)
            {
                Pressed = true;
                MousePressed?.Invoke();
            }
            if (Pressed)
            {
                if (!(e.X <= _position.X + _hight && e.X >= _position.X && e.Y <= _position.Y + _width && e.Y >= _position.Y))
                {
                    Pressed = false;
                }
            }
        }


        public void Draw()
        {
            Update();
            var rect = new RectangleShape(new Vector2f(1000, 1000));
            rect.FillColor = new Color(220, 220, 220);
            rect.Position = new Vector2f(0, 0);

            var radio = new RectangleShape(new Vector2f(_hight, _width));
            radio.FillColor = new Color(100, 100, 100);
            radio.OutlineThickness = 10;
            radio.OutlineColor = new Color(0, 0, 0);
            radio.Position = _position;
            

            if (_isVisible == true)
            {
                _window.Draw(rect);

                _window.Draw(radio);
                
                
            }
        }
        //private void OnMouseReleased(object sender, keyE)
    }
}
