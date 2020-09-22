using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SfmlUI
{
    public class Slider : IUiElement
    {
        private static RenderWindow _window;
        public Slider(RenderWindow window, Vector2f Position,float Height,float Width, float Min, float Max)
        {
            _window = window;
            _position = Position;
            _height = Height;
            _width = Width;
            _min = Min;
            _max = Max;
            _isVisible = true;
            //_isSelected = isSelected;
            //_window.MouseButtonReleased += OnMouseButtonReleased;
        }
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



        public void Draw()
        {
            var back = new RectangleShape(new Vector2f(2000, 1000));
            back.FillColor = new Color(255, 255, 255);
            back.Position = new Vector2f(0, 0);

            var rail = new RectangleShape(new Vector2f(_height,_width));
            rail.FillColor = new Color(220, 220, 220);
            rail.Position = _position;

            var handle = new RectangleShape(new Vector2f(_height/10, _width));
            handle.FillColor = new Color(100, 100, 100);            
            handle.Position = _position;


            if (_isVisible == true)
            {
                _window.Draw(back);


                _window.Draw(rail);
                _window.Draw(handle);


            }
        }
    }
    }
