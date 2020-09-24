

namespace SfmlUI
{
    public class VerticalOrigin
    {
        internal float Size
        {
            get;
            set;
        }
        internal float Position
        {
            get;
            set;
        }
        internal float TruePosition
        {
            get
            {
                return Position + _displacement;
            }
            private set
            {

            }
        }
        private float _displacement;
        internal VerticalOrigin(float Position, float Size)
        {
            this.Size = Size;
            this.Position = Position;
        }
        public void Top()
        {
            _displacement = 0;
        }
        public void Center()
        {
            _displacement = -Size / 2;
        }
        public void Buttom()
        {
            _displacement = -Size;
        }
    }
}
