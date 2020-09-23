using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Linq;

namespace SfmlUI
{
    public class Dropdown : IUiElement
    {
        // egenskaber
        private RenderWindow _window;
        private bool _isVisible;
        private bool _active;
        private Vector2f _position;
        private Vector2f _size;
        private Shape _shape;
        private Shape _activeShape;
        private uint _fontSize = 0;
        private List<Text> _list = new List<Text>();
        private Text _primedText;
        private Color _textColor = new Color(0, 0, 0, 255);
        private Color _highlightColor = new Color(100, 100, 100, 100);

        // nedarvede metoder
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }

        public Vector2f Position { get { return _position; } set { setPosition(value); } }

        public float Width { get { return _shape.GetGlobalBounds().Width; } }

        public float Height { get { if (_active) { return _activeShape.GetGlobalBounds().Height; } else { return _shape.GetGlobalBounds().Height; } } }

        // public ekstra metoder
        public Shape Shape { get { return _shape; } set { _shape = value; } }
        public string GetChosenItem { get { return _list[0].DisplayedString; } }

        // konstruktøren
        public Dropdown(RenderWindow window, Vector2f position, Font font, uint fontSize, params string[] textList)
        {
            _fontSize = fontSize;
            foreach (string item in textList)
            {
                _list.Add(new Text(item, font, fontSize));
            }
            float maxWidth = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Position = new Vector2f(position.X + fontSize * 0.5f, position.Y + fontSize * i);
                _list[i].FillColor = Color.Black;
                if (_list[i].GetLocalBounds().Width > maxWidth) { maxWidth = _list[i].GetLocalBounds().Width; }
            }
            _window = window;
            _isVisible = true;
            _position = position;
            _size = new Vector2f(maxWidth + fontSize, fontSize + 0.2f * fontSize);
            _shape = new RectangleShape(new Vector2f(maxWidth + fontSize, fontSize + 0.2f * fontSize));
            _shape.Scale = new Vector2f(1, 1);
            _shape.OutlineColor = Color.Black;
            _shape.OutlineThickness = 2;
            _shape.Position = position + new Vector2f(_shape.OutlineThickness, _shape.OutlineThickness);
            _activeShape = new RectangleShape(new Vector2f(maxWidth + fontSize, textList.Count() * fontSize + 0.2f * fontSize));
            _activeShape.Scale = new Vector2f(1, 1);
            _activeShape.OutlineColor = Color.Black;
            _activeShape.OutlineThickness = 2;
            _activeShape.Position = position + new Vector2f(_shape.OutlineThickness, _shape.OutlineThickness);
            _active = false;

            // sæt event handler for musen
            _window.MouseButtonReleased += OnClick;
            _window.MouseMoved += OnMove;
        }

        // Tegn objectet
        public void Draw()
        {
            if (_isVisible)
            {
                if (_active)
                {
                    _window.Draw(_activeShape);
                    foreach (Text item in _list)
                    {
                        _window.Draw(item);
                    }
                } else
                {
                    _window.Draw(_shape);
                    _window.Draw(_list[0]);
                }
            }
        }

        // Mouse click event
        public void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (_isVisible && e.Button == Mouse.Button.Left && IsInside(e))
            {
                if (!_active)
                {
                    _active = true;
                } else
                {
                    // Selection of highlighted item
                    Text tempHolder = _list[0];
                    int occurence = _list.IndexOf(_primedText);
                    _list[occurence] = tempHolder;
                    _list[0] = _primedText;
                    _list[0].FillColor = _textColor;

                    // Adjusting position of items
                    for (int i = 0; i < _list.Count(); i++)
                    {
                        _list[i].Position = new Vector2f(_position.X + _fontSize * 0.5f, _position.Y + _fontSize * i);
                    }

                    // deactivaing dropdown
                    _active = false;
                }
            } else
            {
                _active = false;
            }
        }

        // Mouse move event
        public void OnMove(object sender, MouseMoveEventArgs e)
        {
            if (_active)
            {
                foreach (Text item in _list)
                {
                    // Check if mouse is on item and highlighting of item
                    if (item.GetGlobalBounds().Contains(e.X, e.Y))
                    {
                        _primedText = item;
                        item.FillColor = _highlightColor;
                    } else
                    {
                        item.FillColor = _textColor;
                    }
                }
            }
        }

        // Check if mouse is inside shape
        public bool IsInside(MouseButtonEventArgs e)
        {
            if (!_active)
            {
                return _shape.GetGlobalBounds().Contains(e.X, e.Y);
            } else
            {
                return _activeShape.GetGlobalBounds().Contains(e.X, e.Y);
            }
        }

        // Customization functions
        private void setFontColor(Color color)
        {
            foreach (Text item in _list) { item.FillColor = color; }
            _textColor = color;
        }

        private void setBackgroundColor(Color color)
        {
            _shape.FillColor = color;
            _activeShape.FillColor = color;
        }

        private void setOutlineColor(Color color)
        {
            _shape.OutlineColor = color;
            _activeShape.OutlineColor = color;
        }

        private void setOutlineThickness(float percent)
        {
            _shape.OutlineThickness = 2 * (percent / 100);
            _activeShape.OutlineThickness = 2 * (percent / 100);
        }

        // public customization methods
        public Color FontColor { get { return _textColor; } set { setFontColor(value); } }
        public Color BackgroundColor { get { return _shape.FillColor; } set { setBackgroundColor(value); } }
        public Color OutlineColor { get { return _shape.OutlineColor; } set { setOutlineColor(value); } }
        public float OutlineThickness { get { return _shape.OutlineThickness; } set { setOutlineThickness(value); } }
        public Color HighlightColor { get { return _highlightColor; } set { _highlightColor = value; } }

        // private positioning function
        public void setPosition(Vector2f pos)
        {
            _position = pos;
            _shape.Position = pos;
            _activeShape.Position = pos;
            for (int i = 0; i < _list.Count(); i++)
            {
                _list[i].Position = new Vector2f(_position.X + _fontSize * 0.5f, _position.Y + _fontSize * i);
            }
        }
    }
}
