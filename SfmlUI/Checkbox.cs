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
                    // Virker 2x VertexArrays
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
                    
                    
                    // Fucked up
                    // var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    // VertexArray vertexArray = new VertexArray(PrimitiveType.Triangles, 16);
                    //
                    // vertexArray[0] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    // vertexArray[1] = new Vertex(new Vector2f(Position.X, Position.Y + Height), CrossColor);
                    // vertexArray[2] = new Vertex(new Vector2f(Position.X + offset, Position.Y + Height), CrossColor);
                    //
                    // vertexArray[3] = new Vertex(new Vector2f(Position.X + Width/2, Position.Y + Height/2 + offset), CrossColor);
                    //
                    // vertexArray[4] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y + Height), CrossColor);
                    // vertexArray[5] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height), CrossColor);
                    // vertexArray[6] = new Vertex(new Vector2f(Position.X + Width, Position.Y + Height - offset), CrossColor);
                    //
                    // vertexArray[7] = new Vertex(new Vector2f(Position.X + Width/2 + offset, Position.Y + Height/2), CrossColor);
                    //
                    // vertexArray[8] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    // vertexArray[9] = new Vertex(new Vector2f(Position.X + Width, Position.Y), CrossColor);
                    // vertexArray[10] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y), CrossColor);
                    //
                    // vertexArray[11] = new Vertex(new Vector2f(Position.X + Width/2, Position.Y + Height/2 - offset), CrossColor);
                    //
                    // vertexArray[12] = new Vertex(new Vector2f(Position.X + offset, Position.Y), CrossColor);
                    // vertexArray[13] = new Vertex(new Vector2f(Position.X, Position.Y), CrossColor);
                    // vertexArray[14] = new Vertex(new Vector2f(Position.X, Position.Y + offset), CrossColor);
                    //
                    // vertexArray[15] = new Vertex(new Vector2f(Position.X + Width/2 - offset, Position.Y + Height/2), CrossColor);
                    //
                    // Window.Draw(vertexArray);
                    
                    //Selvforsøg med overlap
                    // var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    // VertexArray vertexArray = new VertexArray(PrimitiveType.Triangles, 12);
                    //
                    // vertexArray[0] = new Vertex(new Vector2f(Position.X, Position.Y + Height), CrossColor);
                    // vertexArray[1] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    // vertexArray[2] = new Vertex(new Vector2f(Position.X + offset, Position.Y + Height), CrossColor);
                    //
                    // vertexArray[3] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    // vertexArray[4] = new Vertex(new Vector2f(Position.X + offset, Position.Y + Height), CrossColor);
                    // vertexArray[5] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    //
                    // vertexArray[6] = new Vertex(new Vector2f(Position.X, Position.Y + Height - offset), CrossColor);
                    // vertexArray[7] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y), CrossColor);
                    // vertexArray[8] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    //
                    // vertexArray[9] = new Vertex(new Vector2f(Position.X + Width - offset, Position.Y), CrossColor);
                    // vertexArray[10] = new Vertex(new Vector2f(Position.X + Width, Position.Y), CrossColor);
                    // vertexArray[11] = new Vertex(new Vector2f(Position.X + Width, Position.Y + offset), CrossColor);
                    //
                    // Window.Draw(vertexArray);
                    
                    
                    //Hjælp fra Frederik
                    var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
                    var x1 = Position.X;
                    var x2 = Position.X + offset;
                    var x3 = Position.X + Width - offset;
                    var x4 = Position.X + Width;
                    var y1 = Position.Y;
                    var y2 = Position.Y + offset;
                    var y3 = Position.Y + Height - offset;
                    var y4 = Position.Y + Height;
                    var center = Position + new Vector2f(Width, Height) * 0.5f;

                    Vertex[] verts = new Vertex[]
                    {
                        new Vertex(new Vector2f(x1, y1)),
                        new Vertex(new Vector2f(x2, y1)),
                        new Vertex(new Vector2f(x3, y1)),
                        new Vertex(new Vector2f(x4, y1)),

                        new Vertex(new Vector2f(x1, y2)),
                        new Vertex(new Vector2f(x4, y2)),

                        new Vertex(new Vector2f(center.X, center.Y - offset)),
                        new Vertex(new Vector2f(center.X - offset, center.Y)),
                        new Vertex(new Vector2f(center.X + offset, center.Y)),
                        new Vertex(new Vector2f(center.X, center.Y + offset)),

                        new Vertex(new Vector2f(x1, y3)),
                        new Vertex(new Vector2f(x4, y3)),

                        new Vertex(new Vector2f(x1, y4)),
                        new Vertex(new Vector2f(x2, y4)),
                        new Vertex(new Vector2f(x3, y4)),
                        new Vertex(new Vector2f(x4, y4))
                    };
                    
                    VertexArray vao = new VertexArray(PrimitiveType.Triangles, 42);
                    vao[0] =  verts[1]; vao[1] =  verts[4]; vao[2] =  verts[0];
                    vao[3] =  verts[1]; vao[4] =  verts[6]; vao[5] =  verts[7];
                    vao[6] =  verts[1]; vao[7] =  verts[4]; vao[8] =  verts[6];
                    vao[9] =  verts[2]; vao[10] = verts[5]; vao[11] = verts[3];
                    vao[12] = verts[2]; vao[13] = verts[6]; vao[14] = verts[6];
                    vao[15] = verts[2]; vao[16] = verts[5]; vao[17] = verts[8];
                    vao[18] = verts[7]; vao[19] = verts[8]; vao[20] = verts[6];
                    vao[21] = verts[7]; vao[22] = verts[8]; vao[23] = verts[9];
                    vao[24] = verts[10]; vao[25] = verts[13]; vao[26] = verts[12];
                    vao[27] = verts[10]; vao[28] = verts[9]; vao[29] = verts[7];
                    vao[30] = verts[10]; vao[31] = verts[13]; vao[32] = verts[9];
                    vao[33] = verts[11]; vao[34] = verts[14]; vao[35] = verts[15];
                    vao[36] = verts[11]; vao[37] = verts[14]; vao[38] = verts[9];
                    vao[39] = verts[11]; vao[40] = verts[9]; vao[41] = verts[8];
                    
                    
                    Window.Draw(vao);
                    
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