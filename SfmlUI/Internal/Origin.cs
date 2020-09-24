using SFML.System;


namespace SfmlUI
{
    public class Origin
    {
        public HorizontalOrigin Horizontal;
        public VerticalOrigin Vertical;
        internal Vector2f Size
        {
            private get
            {
                return Size;
            }
            set
            {
                Horizontal.Size = value.X;
                Vertical.Size = value.Y;
            }
        }
        internal Vector2f Position
        {
            private get
            {
                return Position;
            }
            set
            {
                Horizontal.Position = value.X;
                Vertical.Position = value.Y;
            }
        }
        internal Vector2f TruePosition
        {
            get
            {
                return new Vector2f(Horizontal.TruePosition, Vertical.TruePosition);
            }
            private set
            {

            }
        }
        internal Origin(Vector2f Position, Vector2f Size)
        {    
            Horizontal = new HorizontalOrigin(Position.X, Size.X);
            Vertical = new VerticalOrigin(Position.Y, Size.Y);
        }  
    }
}
