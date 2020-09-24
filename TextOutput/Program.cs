using System;
using SfmlUI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TextOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow Window = new RenderWindow( new VideoMode(400,300), "JUst A box", Styles.Titlebar | Styles.Close);
            Window.Closed += OnClose;
            TextBox box = new TextBox(Window, new Vector2f(60, 20), 200f, 200f, new Font("Arial.ttf"), 20);
            box.BackgroundColor = Color.White;
            box.OutlineThickness = 1;
            box.OutlineColor = Color.Cyan;
            box.TextColor = Color.Black ;
            box.Output("HELLo wOrld!");
            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();
                
                box.Draw();

                Window.Display();
            }

            static void OnClose(object sender, EventArgs e)
            {
                RenderWindow Window = (RenderWindow)sender;
                Window.Close();
                Environment.Exit(0);
            }
        }
    }
    }
