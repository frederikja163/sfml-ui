using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class TextInput : IUiElement
    {
        private RenderWindow Window { get; }

        public TextInput(RenderWindow window, Vector2f position, float width, float height)
        {
            Window = window;
            Window.MouseButtonReleased += OnMouseButtonReleased;
            IsVisible = true;
            Position = position;
            Height = height;
            Width = width;
        }

        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public string Text { get; private set; }
        private int Cursor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }


        public void Draw()
        {
            if (IsVisible)
            {
                RectangleShape shape = new RectangleShape()
                {
                    FillColor = BackgroundColor,
                    Position = Position,
                    Size = new Vector2f(Width, Height)
                };

                Window.Draw(shape);

            }
        }

        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {

        }
    }
}