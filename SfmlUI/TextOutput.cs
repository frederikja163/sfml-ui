using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SfmlUI
{
    public sealed class TextBox : IUiElement
    {
        // Private variabler går her
        private bool _isVisibble;
        private Vector2f _position;
        private float _width;
        private float _height;
        private Drawable _draw;


        // Call metoder
        public bool IsVisible { get { return _isVisibble; } set { _isVisibble = value; } }
        public Vector2f Position { get { return _position; } }
        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
        public Drawable DrawableShape { get { return _draw; } }


        // Konstruktør
        public TextBox(/* Her skal der argumenter (bool isVisible) */)
        {
            // _isVisible = isVisible
        }

        // Metoder/FunctionerS
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
