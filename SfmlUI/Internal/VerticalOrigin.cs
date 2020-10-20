

using System;

namespace SfmlUI
{
    public class VerticalOrigin
    {
        internal float Size { get; set; }
        internal float Position { get; set; }
        internal float TruePosition
        {
            get => Position + _displacement;
            private set{}
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
            OnOriginChanged?.Invoke();
        }
        public void Center()
        {
            _displacement = -Size / 2;
            OnOriginChanged.Invoke();
        }
        public void Buttom()
        {
            _displacement = -Size;
            OnOriginChanged?.Invoke();
        }
        internal Action OnOriginChanged;
    }
}
