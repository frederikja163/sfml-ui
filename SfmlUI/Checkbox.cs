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
            IsChecked = true;
            Position = new Vector2f(0, 0);
            Width = 25f;
            Height = 25f;
            FillColor = Color.White;
            CrossColor = Color.Red;
            CrossThickness = 3f;
        }

        public float CrossThickness { get; set; }
        public Color CrossColor { get; set; }
        public Color FillColor { get; set; }
        public bool IsChecked { get; set; }
        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

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
                shape.Position = Position;
                shape.Size = new Vector2f(Width, Height);
                Window.Draw(shape);

                if (IsChecked)
                {
                    // var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    // VertexArray vertexArray1 = new VertexArray(PrimitiveType.TriangleFan, 6);
                    // vertexArray1[0] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    // vertexArray1[1] = new Vertex(new Vector2f(Position.X, Position.Y + Height), CrossColor);
                    // vertexArray1[2] = new Vertex(new Vector2f(Position.X + offset, Position.Y + Height), CrossColor);
                    //
                    // vertexArray1[3] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    // vertexArray1[4] = new Vertex(new Vector2f(Position.X + Width, Position.Y), CrossColor);
                    // vertexArray1[5] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y), CrossColor);
                    //
                    // VertexArray vertexArray2 = new VertexArray(PrimitiveType.TriangleFan, 6);
                    // vertexArray2[0] = new Vertex(new Vector2f(Position.X, Position.Y + offset), CrossColor);
                    // vertexArray2[1] = new Vertex(new Vector2f(Position.X, Position.Y), CrossColor);
                    // vertexArray2[2] = new Vertex(new Vector2f(Position.X + offset, Position.Y), CrossColor);
                    //
                    // vertexArray2[3] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height - offset), CrossColor);
                    // vertexArray2[4] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height), CrossColor);
                    // vertexArray2[5] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y + Height), CrossColor);
                    //
                    // Window.Draw(vertexArray1);
                    // Window.Draw(vertexArray2);
                    
                    var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip, 16);
                    
                    vertexArray[0] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    vertexArray[1] = new Vertex(new Vector2f(Position.X, Position.Y + Height), CrossColor);
                    vertexArray[2] = new Vertex(new Vector2f(Position.X + offset, Position.Y + Height), CrossColor);
                    
                    vertexArray[3] = new Vertex(new Vector2f(Position.X + Width/2, Position.Y + Height/2 + offset), CrossColor);
                    
                    vertexArray[4] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y + Height), CrossColor);
                    vertexArray[5] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height), CrossColor);
                    vertexArray[6] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height - offset), CrossColor);
                    
                    vertexArray[7] = new Vertex(new Vector2f(Position.X + Width/2 + offset, Position.Y + Height/2), CrossColor);
                    
                    vertexArray[8] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    vertexArray[9] = new Vertex(new Vector2f(Position.X + Width, Position.Y), CrossColor);
                    vertexArray[10] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y), CrossColor);
                    
                    vertexArray[11] = new Vertex(new Vector2f(Position.X + Width/2, Position.Y + Height/2 - offset), CrossColor);
                    
                    vertexArray[12] = new Vertex(new Vector2f(Position.X + offset, Position.Y), CrossColor);
                    vertexArray[13] = new Vertex(new Vector2f(Position.X, Position.Y), CrossColor);
                    vertexArray[14] = new Vertex(new Vector2f(Position.X, Position.Y + offset), CrossColor);
                    
                    vertexArray[15] = new Vertex(new Vector2f(Position.X + Width/2 - offset, Position.Y + Height/2), CrossColor);
                    
                    Window.Draw(vertexArray);
                    
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