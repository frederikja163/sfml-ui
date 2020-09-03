using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace SfmlUI
{
    public class Dropdown : IUiElement
    {
        private RenderWindow _window;
        private bool _isVisible;
        private bool _active;
        private Vector2f _position;
        private Vector2f _size;
        private Shape _shape;
        private List<Text> _list;


        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }

        public Vector2f Position { get { return _position; } }

        public float Width { get { return _size.X; } }

        public float Height { get { return _size.Y; } }


        public Dropdown(RenderWindow window, Shape shape, Vector2f position, Vector2f size)
        {
            _window = window;
            _isVisible = true;
            _shape = shape;
            _position = position;
            _size = size;
            _active = false;
            _list = new List<Text>();

        }

        public void Draw()
        {

        }
    }
}
