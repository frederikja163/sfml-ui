using System;
using SFML.Graphics;
using SFML.System;

namespace SfmlUI
{
    public class Checkbox : IUiElement
    {
        public Checkbox(Vector2f position, float width, float height, bool isChecked)
        {
            Position = position;
            Width = width;
            Height = height;
            IsChecked = isChecked;
        }

        public bool IsChecked { get; set; }
        
        public bool IsVisible { get; set; }
        public Vector2f Position { get; }
        public float Width { get; }
        public float Height { get; }
        public void Draw() 
        {
            throw new NotImplementedException();
        }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }
    }
}