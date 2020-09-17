using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class Checkbox : IUiElement
    {
        private RenderWindow Window { get; }

        public Checkbox(RenderWindow window)
        {
            Window = window;
            Window.MouseButtonReleased += OnMouseButtonReleased;
            IsVisible = true;
            IsChecked = false;
            Position = new Vector2f(0, 0);
            Width = 25f;
            Height = 25f;
            FillColor = Color.White;
            CrossColor = Color.Red;
            CrossThickness = 3f;
            BorderEnabled = false;
            BorderColor = Color.Green;
            BorderThickness = 20f;
        }

        public float CrossThickness { get; set; }
        public Color CrossColor { get; set; }
        public Color FillColor { get; set; }
        public bool IsChecked { get; set; }
        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool BorderEnabled { get; set; }
        public Color BorderColor { get; set; }
        public float BorderThickness { get; set; }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }
        public void Draw() 
        {
            if (IsVisible)
            {
                RectangleShape shape = new RectangleShape();
                shape.FillColor = FillColor;
                shape.Position = (BorderEnabled) ? Position + new Vector2f(BorderThickness, BorderThickness) : Position;
                shape.Size = new Vector2f(Width, Height);
                if (BorderEnabled)
                {
                    shape.Size -= new Vector2f(BorderThickness * 2, BorderThickness * 2);
                    shape.OutlineColor = BorderColor;
                    shape.OutlineThickness = BorderThickness;
                }
                Window.Draw(shape);

                if (IsChecked)
                {
                    var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    var borderOffset = (BorderEnabled) ? BorderThickness : 0f;
                    VertexArray vertexArray1 = new VertexArray(PrimitiveType.TriangleFan, 6);
                    vertexArray1[0] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + Height - offset - borderOffset), CrossColor);
                    vertexArray1[1] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + Height - borderOffset), CrossColor);
                    vertexArray1[2] = new Vertex(new Vector2f(Position.X + offset + borderOffset, Position.Y + Height - borderOffset), CrossColor);
                    
                    vertexArray1[3] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + offset + borderOffset), CrossColor);
                    vertexArray1[4] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + borderOffset), CrossColor);
                    vertexArray1[5] = new Vertex(new Vector2f(Position.X + Width - offset - borderOffset, Position.Y + borderOffset), CrossColor);
                    
                    VertexArray vertexArray2 = new VertexArray(PrimitiveType.TriangleFan, 6);
                    vertexArray2[0] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + offset + borderOffset), CrossColor);
                    vertexArray2[1] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + borderOffset), CrossColor);
                    vertexArray2[2] = new Vertex(new Vector2f(Position.X + offset + borderOffset, Position.Y + borderOffset), CrossColor);
                    
                    vertexArray2[3] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + Height - offset - borderOffset), CrossColor);
                    vertexArray2[4] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + Height - borderOffset), CrossColor);
                    vertexArray2[5] = new Vertex(new Vector2f(Position.X + Width - offset - borderOffset, Position.Y + Height - borderOffset), CrossColor);
                    
                    Window.Draw(vertexArray1);
                    Window.Draw(vertexArray2);
                    
                }
            }
        }

        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (Position.X <= e.X && e.X <= Position.X + Width && Position.Y <= e.Y && e.Y <= Position.Y + Height)
            {
                Toggle();
            }
        }
    }
}