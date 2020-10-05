using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class TextInput : IUiElement
    {
        private RenderWindow Window { get; }

        public TextInput(RenderWindow window, Vector2f position, float width, float height, Font font, string initialText = "")
        {
            Window = window;
            _position = position;
            _height = height;
            _cursorWidth = height / 20;
            _width = width;
            _font = font;
            Text = initialText;
            _cursor = initialText.Length;

            _verticalPadding = Height / 10;
            _horizontalPadding = _verticalPadding;

            _fieldColor = Color.White;
            _textColor = Color.Black;
            _outlineColor = new Color(194, 197, 204);

            UpdateTextElement();
            UpdateTextFieldElement();

            window.KeyPressed += OnPressedHandler;
            window.MouseButtonReleased += OnMouseReleasedHandler;
        }

        public bool IsVisible { get; set; } = true;

        private Vector2f _position { get; set; }
        public Vector2f Position
        {
            get => _position;
            set { _position = value; UpdateTextFieldElement(); UpdateTextElement(); }
        }

        private float _width { get; set; }
        public float Width
        {
            get => _width;
            set { _width = value; UpdateTextFieldElement(); UpdateTextElement(); }
        }

        private float _height { get; set; }
        public float Height
        {
            get => _height;
            set { _height = value; UpdateTextFieldElement(); UpdateTextElement(); }
        }

        public string Text { get; private set; }

        private Color _fieldColor { get; set; }
        public Color FieldColor
        {
            get => _fieldColor;
            set { _fieldColor = value; UpdateTextFieldElement(); }
        }

        private Color _textColor { get; set; }
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; UpdateTextElement(); }
        }

        private Color _outlineColor { get; set; }
        public Color OutlineColor
        {
            get => _outlineColor;
            set { _outlineColor = value; UpdateTextFieldElement(); }
        }

        private Font _font { get; }

        private int _cursor { get; set; }
        private bool _isFocused { get; set; } = false;
        private float _cursorWidth { get; set; }

        private float _horizontalPadding { get; }
        private float _verticalPadding { get; }

        private Text _textElement { get; set; }
        private int _textElementCursor { get; set; }
        private RectangleShape _textFieldElement { get; set; }
        private RectangleShape _cursorElement { get; set; }

        private char[] _keyMapper { get; } = {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9'
        };

        public void Draw()
        {
            if (IsVisible)
            {
                Window.Draw(_textFieldElement);
                Window.Draw(_textElement);

                if (_isFocused)
                {
                    Window.Draw(_cursorElement);
                }
            }
        }

        private void UpdateTextElement()
        {
            var text = new Text(Text, _font, (uint)((Height - 2 * _verticalPadding))) { Position = Position + new Vector2f(_horizontalPadding, 0), FillColor = TextColor };

            int lastLength;
            var newCursor = _cursor;

            do
            {
                lastLength = text.DisplayedString.Length;
                if ((text.FindCharacterPos((uint)newCursor) + Position + new Vector2f(_horizontalPadding, _verticalPadding)).X + _cursorWidth > Position.X + Width)
                {
                    text.DisplayedString = text.DisplayedString.Remove(0, 1);
                    newCursor--;
                }
            }
            while (text.DisplayedString.Length != lastLength);

            while (text.GetLocalBounds().Width > Width - _horizontalPadding && text.DisplayedString.Length > 0)
            {
                text.DisplayedString = text.DisplayedString.Remove(text.DisplayedString.Length - 1);
            }

            _textElement = text;
            _textElementCursor = newCursor;
            UpdateCursorElement();
        }

        private void UpdateTextFieldElement()
        {
            _textFieldElement = new RectangleShape()
            {
                FillColor = FieldColor,
                Position = Position,
                Size = new Vector2f(Width, Height),
                OutlineColor = OutlineColor,
                OutlineThickness = _isFocused ? _verticalPadding : 0,
            };
        }

        private void UpdateCursorElement()
        {
            _cursorElement = new RectangleShape()
            {
                Position = _textElement.FindCharacterPos((uint)_textElementCursor) + Position + new Vector2f(_horizontalPadding, _verticalPadding),
                Size = new Vector2f(_cursorWidth, Height - 2 * _verticalPadding),
                FillColor = TextColor
            };
        }

        private void OnMouseReleasedHandler(object sender, MouseButtonEventArgs e)
        {
            var onTextField = e.X >= Position.X && e.X <= Position.X + Width && e.Y >= Position.Y && e.Y <= Position.Y + Height;

            _isFocused = onTextField;
            if (_isFocused)
            {
                UpdateTextFieldElement();
            }
        }

        private void OnPressedHandler(object sender, KeyEventArgs e)
        {
            if (_isFocused)
            {

                if (e.Code == Keyboard.Key.Backspace)
                {
                    if (Text.Length > 0 && _cursor > 0)
                    {
                        Text = Text.Remove(_cursor - 1, 1);
                        _cursor--;
                        UpdateTextElement();
                    }
                }
                else if (e.Code >= 0 && (int)e.Code < _keyMapper.Length)
                {
                    AddToText(e.Shift ? _keyMapper[(int)e.Code].ToString().ToUpper() : _keyMapper[(int)e.Code].ToString().ToLower());

                }
                else if (e.Code == Keyboard.Key.Space)
                {
                    AddToText(" ");
                }
                else if (e.Code == Keyboard.Key.Right && _cursor <= Text.Length - 1)
                {
                    _cursor++;
                    UpdateTextElement();
                }
                else if (e.Code == Keyboard.Key.Left && _cursor > 0)
                {
                    _cursor--;
                    UpdateTextElement();
                }
            }
        }

        public void SetText(string newText)
        {
            Text = newText;
            _cursor = newText.Length;
            UpdateTextElement();
        }

        private void AddToText(string addtion)
        {
            Text = Text.Insert(_cursor, addtion);
            _cursor += addtion.Length;
            UpdateTextElement();
        }
    }
}