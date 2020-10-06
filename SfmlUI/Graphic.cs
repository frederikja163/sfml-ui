using System;
using SFML.Graphics;
using SFML.System;
using System.Diagnostics;

namespace SfmlUI
{
    public class Graphic : IUiElement
    {
        public Origin Origin;

        // Properties that can be read and som of then set by property interface
        private readonly Vector2f _position;
        private Vector2f _size;
        private bool _isVisible;

        // Internal properties visible only inside this class
        private readonly RenderWindow _window;
        private Sprite _sprite;
        private Vector2f _pictPos;
        private readonly Stopwatch _watch = new Stopwatch();
        private long _time;
        private long _flashTime = 1000;
        private Boolean _flashOn = false;
        private Boolean _isFlashing = false;

        // Four different constructors, to set up an instance of the class with different properties
        public Graphic(RenderWindow window, string filename, Vector2f position) :
            this(window, filename, position, new Vector2f(float.PositiveInfinity, float.PositiveInfinity), new Vector2f(float.PositiveInfinity, float.PositiveInfinity), 1f)
        {
        }
        public Graphic(RenderWindow window, string filename, Vector2f position, float scale) : 
            this(window, filename, position, new Vector2f(float.PositiveInfinity, float.PositiveInfinity), new Vector2f(float.PositiveInfinity, float.PositiveInfinity), scale)
        {
        }
        public Graphic(RenderWindow window, string filename, Vector2f position, Vector2f pictPos, Vector2f size) : 
            this(window, filename, position, pictPos, size, 1f)
        {
        }
        // The actual constructor
        public Graphic(RenderWindow window, string filename, Vector2f position, Vector2f pictPos, Vector2f size, float scale)
        {
            // Initializing standard properties
            _window = window;
            _isVisible = true;
            Texture _graphFile = new Texture(filename);
            _position = position;
            // Using parameters to show a part of the picture, if they are send. Otherwise standard properties are used
            if (pictPos.X == float.PositiveInfinity)
            {
                _pictPos = new Vector2f(0, 0);
            }
            else
            {
                _pictPos = pictPos;
            }
            if (size.X == float.PositiveInfinity)
            {
                _size = (Vector2f)_graphFile.Size;
            }
            else
            {
                _size = size;
            }
            Origin = new Origin(_position, _size * scale);
            // Creating the sprite to be shown in the Window
            _sprite = new Sprite(_graphFile, new IntRect((int)_pictPos.X, (int)_pictPos.Y, (int)(_size.X), (int)(_size.Y)));
            _sprite.Scale = new Vector2f(scale, scale);
            _sprite.Position = Origin.TruePosition;
            // Starting the timer tom implement Blink behavior
            _watch.Start();
            _time = _watch.ElapsedMilliseconds;
        }

        // Implementation of get and set standards for visible and changeable properties
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
                return Origin.TruePosition;
            }
        }
        public float Width
        {
            get
            {
                return _size.X * _sprite.Scale.X;
            }
        }
        public float Height
        {
            get
            {
                return _size.Y * _sprite.Scale.Y;
            }
        }

        // Methods for interfacing blinking behavior
        public void StartFlashing(long time)
        {
            _flashTime = time;
            _isFlashing = true;
            _time = _watch.ElapsedMilliseconds;
        }
        public void StopFlashing()
        {
            _isFlashing = false;
        }

        public void Fade (float magnitude) 
        {
            if (magnitude < 0.0) magnitude = 0.0f;
            if (magnitude > 1.0) magnitude = 1.0f;
            Byte _fade = (Byte) (magnitude * 255.0);
            _sprite.Color = new Color(255, 255, 255, _fade);
        }
        // Draw method that implements the displaying of the picture, handling visibility and blinking
        public void Draw()
        {
            if (_isVisible) {
                _sprite.Position = Origin.TruePosition;
                if (_isFlashing)
                {
                    if (_watch.ElapsedMilliseconds - _time > _flashTime)
                    {
                        _time += _flashTime;
                        _flashOn = !_flashOn;
                    }
                    if (_flashOn)
                    {
                        _window.Draw(_sprite);
                    }
                } else { 
                    _window.Draw(_sprite);
                }
            }
        }
    }
}
