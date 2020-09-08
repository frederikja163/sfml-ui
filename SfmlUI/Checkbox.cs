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
            CrossColor = Color.Black;
            CrossThickness = 5f;
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
                     RectangleShape cross1 = new RectangleShape();
                     cross1.Size = new Vector2f(MathF.Sqrt(MathF.Pow(Width, 2)+MathF.Pow(Height, 2)), 1);
                     cross1.Rotation = 45;
                     cross1.Position = Position;
                     cross1.FillColor = CrossColor;
                     cross1.OutlineThickness = CrossThickness;
                     cross1.OutlineColor = CrossColor;
                    
                     RectangleShape cross2 = new RectangleShape();
                     cross2.Size = new Vector2f(MathF.Sqrt(MathF.Pow(Width, 2)+MathF.Pow(Height, 2)), 1);
                     cross2.Rotation = -45;
                     cross2.Position = Position + new Vector2f(0, Height);
                     cross2.FillColor = CrossColor;
                     cross2.OutlineThickness = CrossThickness;
                     cross2.OutlineColor = CrossColor;
                    
                    Window.Draw(cross1);
                    Window.Draw(cross2);

                    // VertexArray vertexArray1 = new VertexArray(PrimitiveType.Lines, 2);
                    // vertexArray1[0] = new Vertex(new Vector2f(Position.X, Position.Y), CrossColor);
                    // vertexArray1[1] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height), CrossColor);
                    //
                    // VertexArray vertexArray2 = new VertexArray(PrimitiveType.Lines, 2);
                    // vertexArray2[0] = new Vertex(new Vector2f(Position.X, Position.Y + Height), CrossColor);
                    // vertexArray2[1] = new Vertex(new Vector2f(Position.X + Width, Position.Y), CrossColor);
                    //
                    // Window.Draw(vertexArray1);
                    // Window.Draw(vertexArray2);
                    
                }
            }
        }

        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            // if (Position.X <= e.X && e.X <= Position.X + Width && Position.Y <= e.Y && e.Y <= Position.Y + Height)
            // {
            //     Console.WriteLine("Klik");
            // }
            //Console.WriteLine(Position.X <= e.X);
            //Console.WriteLine(e.X <= Position.X);
            Console.WriteLine(Position.X);
            Console.WriteLine(e.X);
            Console.WriteLine(Position.X + Width);
        }
    }
}