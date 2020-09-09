using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SfmlUI
{
    public class RadioButton : IUiElement
    {
        public RadioButton(RenderWindow window, bool isSelected = false)
        {
            _window = window;
            _isSelected = isSelected;
            _window.MouseButtonReleased += OnMouseButtonReleased;
        }

        private bool _isSelected { get; set; }

        private RenderWindow _window { get; }

        public bool IsVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector2f Position => throw new NotImplementedException();

        public float Width => throw new NotImplementedException();

        public float Height => throw new NotImplementedException();

        public void Draw()
        {
            var rect = new RectangleShape(new Vector2f(1000, 1000));
            rect.FillColor = new Color(220, 220, 220);
            rect.Position = new Vector2f(0, 0);

            var radio = new CircleShape(30);
            radio.FillColor = new Color(255, 255, 255);
            radio.OutlineThickness = 10;
            radio.OutlineColor = new Color(0, 0, 0);
            radio.Position = new Vector2f(_window.Size.X / 2, _window.Size.Y / 2);

            var radioSelected = new CircleShape(17.5f);
            radioSelected.FillColor = new Color(0, 0, 255);
            radioSelected.OutlineThickness = 10;
            radioSelected.OutlineColor = new Color(0, 0, 160);
            radioSelected.Position = new Vector2f(radio.Position.X + 12, radio.Position.Y + 12);

            _window.Draw(rect);

            _window.Draw(radio);

            if (_isSelected == true)
            {
                _window.Draw(radioSelected);
            }

        }
        private void OnMouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            if (_isSelected == false)
            {
                _isSelected = true;
            } else {
                _isSelected = false;
            }
        }
    }
}
