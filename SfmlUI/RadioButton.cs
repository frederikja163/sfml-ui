using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SfmlUI
{
    public class RadioButton : IUiElement
    {
        public RadioButton(RenderWindow window, Vector2f position, float radius, Vector2f lineSpacing, int amount)
        {
            _window = window;
            _position = position;
            _radius = radius;
            _lineSpacing = lineSpacing;
            _amount = amount;
            _selected = -1;
            _window.MouseButtonReleased += OnMouseButtonReleased;
        }

        public int _selected { get; private set; }

        private RenderWindow _window { get; }

        public bool IsVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float Width => throw new NotImplementedException();

        public float Height => throw new NotImplementedException();

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

        private float _radius;
        public float Radius
        {
            get 
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        private Vector2f _lineSpacing;
        public Vector2f lineSpacing
        {
            get
            {
                return _lineSpacing;
            }
            set
            {
                _lineSpacing = value;
            }
        }

        private int _amount;
        public int amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < amount; i++) { 
                var radio = new CircleShape(_radius);
                radio.FillColor = new Color(255, 255, 255);
                radio.OutlineThickness = _radius/3;
                radio.OutlineColor = new Color(100, 100, 100);
                radio.Position = _position+i*new Vector2f(_lineSpacing.X,_lineSpacing.Y);

                var radioSelected = new CircleShape(_radius/1.7f);
                radioSelected.FillColor = new Color(0, 0, 255);
                radioSelected.OutlineThickness = _radius/3;
                radioSelected.OutlineColor = new Color(0, 0, 160);
                radioSelected.Position = new Vector2f(radio.Position.X +
                    _radius/2.4f, radio.Position.Y + _radius/2.4f);

                _window.Draw(radio);

                if (_selected == i)
                {
                    _window.Draw(radioSelected);
                }
            }
        }

        private void OnMouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
           
            for (int i = 0; i < amount; i++)
            {
                if (Math.Pow(e.X - (_position.X + i * lineSpacing.X + _radius), 2) + 
                    Math.Pow(e.Y - (_position.Y + i * lineSpacing.Y + _radius), 2) <=
                    Math.Pow(_radius, 2))
                {
                    if (_selected == i)
                    {
                        _selected = -1;
                    }
                    else
                    {
                        _selected = i;
                    }
                    return;
                }
            }
        }
    }
}
