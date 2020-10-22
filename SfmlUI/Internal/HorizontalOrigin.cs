

using System;

namespace SfmlUI
{
    public class HorizontalOrigin
    {
        internal float Size { get; set; } 
        internal float Position { get; set; }
        internal float TruePosition
        {
            get => Position + _displacement;
        }
        private float _displacement;
        internal HorizontalOrigin(float Position, float Size)
        {
            this.Size = Size;
            this.Position = Position;
        }
        public void Left()
        {
            _displacement = 0;
            OnOriginChanged?.Invoke();
        }
        public void Center()
        {
            _displacement = -Size / 2;
            OnOriginChanged?.Invoke();
        }
        public void Right()
        {
            _displacement = -Size;
            OnOriginChanged?.Invoke();
        }
        internal Action OnOriginChanged;
        
    }
}
