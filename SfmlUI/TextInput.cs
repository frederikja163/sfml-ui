using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SfmlUI
{
    public class TextInput : IUiElement
    {
        private RenderWindow Window { get; }

        public TextInput(RenderWindow window, Vector2f position, float width, float height, Font font, bool isVisible = true)
        {
            Window = window;
            IsVisible = isVisible;
            Position = position;
            Height = height;
            Width = width;
            _Font = font;
            Text = "";
            _Cursor = 0;

            _VerticalPadding = Height / 10;
            _HorizontalPadding = _VerticalPadding;

            window.KeyPressed += OnPressedHandler;
            window.MouseButtonReleased += OnMouseReleasedHandler;
        }

        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public string Text { get; private set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        private Font _Font { get; }

        private int _Cursor { get; set; }
        private bool _CursorVisible { get; } = true;
        private bool _IsFocused { get; set; } = false;

        private float _HorizontalPadding { get; }
        private float _VerticalPadding { get; }


        private char[] _KeyMapper { get; } = {
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
                Text text = new Text(Text, _Font, (uint)((Height - 2 * _VerticalPadding))) { Position = Position + new Vector2f(_HorizontalPadding, 0), FillColor = Color.Black };


                var newCursor = _Cursor;

                int lastLength;
                var cursorWidth = Height / 20;
                do
                {
                    lastLength = text.DisplayedString.Length;
                    if ((text.FindCharacterPos((uint)newCursor) + Position + new Vector2f(_HorizontalPadding, _VerticalPadding)).X + cursorWidth > Position.X + Width)
                    {
                        text.DisplayedString = text.DisplayedString.Remove(0, 1);
                        newCursor--;
                    }
                }
                while (text.DisplayedString.Length != lastLength);

                while (text.GetLocalBounds().Width > Width - _HorizontalPadding && text.DisplayedString.Length > 0)
                {
                    text.DisplayedString = text.DisplayedString.Remove(text.DisplayedString.Length - 1);
                }


                RectangleShape textField = new RectangleShape()
                {
                    FillColor = BackgroundColor,
                    Position = Position,
                    Size = new Vector2f(Width, Height),
                    OutlineColor = new Color(194, 197, 204),
                    OutlineThickness = _IsFocused ? _VerticalPadding : 0,
                };

                Window.Draw(textField);
                Window.Draw(text);

                if (_IsFocused && _CursorVisible)
                {
                    var cursor = new RectangleShape()
                    {
                        Position = text.FindCharacterPos((uint)newCursor) + Position + new Vector2f(_HorizontalPadding, _VerticalPadding),
                        Size = new Vector2f(cursorWidth, Height - 2 * _VerticalPadding),
                        FillColor = Color.Black
                    };

                    Window.Draw(cursor);
                }
            }
        }

        private void OnMouseReleasedHandler(object sender, MouseButtonEventArgs e)
        {
            var onTextField = e.X >= Position.X && e.X <= Position.X + Width && e.Y >= Position.Y && e.Y <= Position.Y + Height;

            _IsFocused = onTextField;
        }

        private void OnPressedHandler(object sender, KeyEventArgs e)
        {
            System.Console.WriteLine("cursor: " + _Cursor.ToString());
            System.Console.WriteLine("text: " + Text);

            if (_IsFocused)
            {

                if (e.Code == Keyboard.Key.Backspace)
                {
                    if (Text.Length > 0 && _Cursor > 0)
                    {
                        Text = Text.Remove(_Cursor - 1, 1);
                        _Cursor--;
                    }
                }
                else if (e.Code >= 0 && (int)e.Code < _KeyMapper.Length)
                {
                    AddToText(e.Shift ? _KeyMapper[(int)e.Code].ToString().ToUpper() : _KeyMapper[(int)e.Code].ToString().ToLower());

                }
                else if (e.Code == Keyboard.Key.Space)
                {
                    AddToText(" ");
                }
                else if (e.Code == Keyboard.Key.Right && _Cursor <= Text.Length - 1)
                {
                    _Cursor++;
                }
                else if (e.Code == Keyboard.Key.Left && _Cursor > 0)
                {
                    _Cursor--;
                }
            }

            System.Console.WriteLine((int)e.Code);
        }

        private void AddToText(string addtion)
        {
            Text = Text.Insert(_Cursor, addtion);
            _Cursor += addtion.Length;
        }
    }
}