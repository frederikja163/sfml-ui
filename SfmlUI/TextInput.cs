using System;
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
            Font = font;
            Text = "";
            Cursor = 0;

            window.KeyPressed += OnPressedHandler;
        }

        public bool IsVisible { get; set; }
        public Vector2f Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public string Text { get; private set; }
        private int Cursor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }

        private Font Font { get; }
        private bool CursorVisible { get; } = true;


        private char[] KeyMapper { get; } = {
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
        };

        public void Draw()
        {
            if (IsVisible)
            {
                Text text = new Text(Text, Font, (uint)(Height * 0.75)) { Position = Position, FillColor = Color.Black };

                RectangleShape field = new RectangleShape()
                {
                    FillColor = BackgroundColor,
                    Position = Position,
                    Size = new Vector2f(Width, Height)
                };


                var cursor = new RectangleShape()
                {
                    Position = text.FindCharacterPos((uint)Cursor),
                    Size = new Vector2f(3, Height),
                    FillColor = Color.Black
                };

                Window.Draw(field);
                Window.Draw(text);
                Window.Draw(cursor);
            }
        }

        private void OnPressedHandler(object sender, KeyEventArgs e)
        {
            System.Console.WriteLine(Cursor);
            System.Console.WriteLine(Text);
            if (e.Code == Keyboard.Key.Backspace)
            {
                if (Text.Length > 0 && Cursor > 0)
                {
                    Text = Text.Remove(Cursor - 1, 1);
                    Cursor--;
                }
            }
            else if (e.Code >= 0 && (int)e.Code < KeyMapper.Length)
            {
                AddToText(e.Shift ? KeyMapper[(int)e.Code].ToString().ToUpper() : KeyMapper[(int)e.Code].ToString().ToLower());
            }
            else if (e.Code == Keyboard.Key.Space)
            {
                AddToText(" ");
            }
            else if (e.Code == Keyboard.Key.Right && Cursor <= Text.Length - 1)
            {
                Cursor++;
            }
            else if (e.Code == Keyboard.Key.Left && Cursor > 0)
            {
                Cursor--;
            }

            System.Console.WriteLine((int)e.Code);
        }

        private void AddToText(string addtion)
        {
            System.Console.WriteLine(addtion);
            Text = Text.Insert(Cursor, addtion);
            Cursor += addtion.Length;
        }
    }
}