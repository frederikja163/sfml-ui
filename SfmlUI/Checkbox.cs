using System;
using SFML.Graphics;
using SFML.System;

namespace SfmlUI
{
    public class Checkbox : IUiElement
    {

        private bool _isVisible;

        public bool IsVisible 
        { 
            get 
            { 
                return _isVisible; 
            } 
            set 
            { 
                _isVisible = value; 
            } 
        }

        public Vector2f Position
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float Width
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float Height
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}