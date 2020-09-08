using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class Checkbox : IUiElement
    {
        private RenderWindow _Window { get; }

        public Checkbox(RenderWindow window, Vector2f position, float width, float height, bool isChecked = false, bool isVisible = true)
        {
            _Window = window;
            Position = position;
            Width = width;
            Height = height;
            IsChecked = isChecked;
            IsVisible = isVisible;
            _Window.MouseButtonReleased += OnMouseButtonReleased;
        }

        private void OnMouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            //Klik mus
        }

        public bool IsChecked { get; set; }
        
        public bool IsVisible { get; set; }
        public Vector2f Position { get; }
        public float Width { get; }
        public float Height { get; }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }
        public void Draw() 
        {
            if (IsVisible)
            {
                RectangleShape shape = new RectangleShape()
                {
                    FillColor = Color.White, Size = new Vector2f(Width, Height), Position = Position
                };
                _Window.Draw(shape);  
            }
        }
    }
}