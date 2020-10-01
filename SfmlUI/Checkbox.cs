using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class Checkbox : IUiElement
    {
        private RenderWindow Window { get; }
        
        private VertexArray VertexArray1 { get; set; }
        private VertexArray VertexArray2 { get; set; }
        public Checkbox(RenderWindow window, Vector2f position)
        {
            VertexArray1 = new VertexArray(PrimitiveType.TriangleFan, 6);
            VertexArray2 = new VertexArray(PrimitiveType.TriangleFan, 6);
            _rectangleShape = new RectangleShape();
            Window = window;
            Window.MouseButtonReleased += OnMouseButtonReleased;
            IsVisible = true;
            IsChecked = false;
            Position = position;
            Width = 25f;
            Height = 25f;
            FillColor = Color.White;
            _crossColor = Color.Red;
            _crossThickness = 3f;
            _borderEnabled = false;
            BorderColor = Color.Green;
            _borderThickness = 20f;
            UpdateBorder();
        }

        private float _crossThickness { get; set; }
        public float CrossThickness
        {
            get => _crossThickness;
            set
            {
                _crossThickness = value;
                UpdateBorder();
            }
        }

        private Color _crossColor { get; set; }
        public Color CrossColor
        {
            get
            {
                return _crossColor;
            }
            set
            {
                _crossColor = value;
                UpdateBorder();
            }
        }

        public Color FillColor
        {
            get => _rectangleShape.FillColor;
            set => _rectangleShape.FillColor = value;
        }

        public bool IsChecked { get; set; }
        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        private bool _borderEnabled { get; set; }
        public bool BorderEnabled
        {
            get => _borderEnabled;
            set
            {
                _borderEnabled = value;
                UpdateBorder();
            }
        }

        public Color BorderColor
        {
            get => _rectangleShape.OutlineColor;
            set => _rectangleShape.OutlineColor = value;
        }

        private float _borderThickness { get; set; }
        public float BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                UpdateBorder();
            }
        }
        
        private RectangleShape _rectangleShape { get; set; }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }
        public void Draw() 
        {
            if (IsVisible)
            {
                Window.Draw(_rectangleShape);

                if (IsChecked)
                {
                    Window.Draw(VertexArray1);
                    Window.Draw(VertexArray2);
                    
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

        private void UpdateBorder()
        {
            _rectangleShape.OutlineThickness = (BorderEnabled) ? _borderThickness : 0f;
            _rectangleShape.Position = (BorderEnabled) ? Position + new Vector2f(BorderThickness, BorderThickness) : Position;
            _rectangleShape.Size = (BorderEnabled) ? new Vector2f(Width, Height) - new Vector2f(BorderThickness * 2, BorderThickness * 2) : new Vector2f(Width, Height);
            var offset = (MathF.Sqrt(2) * CrossThickness) / 2;
            var borderOffset = (BorderEnabled) ? BorderThickness : 0f;
            VertexArray1[0] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + Height - offset - borderOffset), CrossColor);
            VertexArray1[1] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + Height - borderOffset), CrossColor);
            VertexArray1[2] = new Vertex(new Vector2f(Position.X + offset + borderOffset, Position.Y + Height - borderOffset), CrossColor);
            VertexArray1[3] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + offset + borderOffset), CrossColor);
            VertexArray1[4] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + borderOffset), CrossColor);
            VertexArray1[5] = new Vertex(new Vector2f(Position.X + Width - offset - borderOffset, Position.Y + borderOffset), CrossColor);
                    
            VertexArray2[0] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + offset + borderOffset), CrossColor);
            VertexArray2[1] = new Vertex(new Vector2f(Position.X + borderOffset, Position.Y + borderOffset), CrossColor);
            VertexArray2[2] = new Vertex(new Vector2f(Position.X + offset + borderOffset, Position.Y + borderOffset), CrossColor);
            VertexArray2[3] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + Height - offset - borderOffset), CrossColor);
            VertexArray2[4] = new Vertex(new Vector2f(Position.X + Width - borderOffset, Position.Y + Height - borderOffset), CrossColor);
            VertexArray2[5] = new Vertex(new Vector2f(Position.X + Width - offset - borderOffset, Position.Y + Height - borderOffset), CrossColor);
        }
    }
}