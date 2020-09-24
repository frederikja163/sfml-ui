using System;
using SFML.Graphics;
using SFML.Window;

namespace Dropdown
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, "Dropdown Sandbox", Styles.Titlebar | Styles.Close);
            RectangleShape Background = new RectangleShape(new SFML.System.Vector2f(Window.Size.X, Window.Size.Y));
            Background.Position = new SFML.System.Vector2f(0, 0);
            Background.FillColor = new Color(122,122,122,255);
            Window.Closed += OnClose;

            // dropdown 1
            SfmlUI.Dropdown dropdown = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(200, 150), new Font("ArialNova.ttf"), 30,
                    "Lorem Ipsum",
                    "Electric boogaloo",
                    "James",
                    "Brown fox",
                    "Doc",
                    "Docile",
                    "Pizza",
                    "Hut Hut",
                    "Last item"
                );
            dropdown.OutlineColor = Color.Cyan;
            dropdown.OutlineThickness = 50;
            dropdown.FontColor = Color.Blue;
            dropdown.HighlightColor = Color.Cyan;
            dropdown.BackgroundColor = Color.Yellow;

            // dropdown 2
            SfmlUI.Dropdown dropdown2 = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(700, 100), new Font("ArialNova.ttf"), 20,
                    "Lorem Ipsum2",
                    "Electric boogaloo2",
                    "James2",
                    "Brown fox2",
                    "Doc2",
                    "Docile2",
                    "Pizza2",
                    "Hut Hut2",
                    "Last item2",
                    "last last item",
                    "last last last item",
                    "last",
                    "last last"
                );
            dropdown2.OutlineColor = Color.Yellow;
            dropdown2.OutlineThickness = 100;
            dropdown2.FontColor = Color.Cyan;
            dropdown2.HighlightColor = Color.Red;
            dropdown2.BackgroundColor = Color.Black;

            // dropdown 3
            SfmlUI.Dropdown dropdown3 = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(700, 400), new Font("ArialNova.ttf"), 30,
                    "Lorem Ipsum2",
                    "Electric boogaloo2",
                    "James2",
                    "Brown fox2",
                    "Doc2",
                    "Docile2",
                    "Pizza2",
                    "Hut Hut2",
                    "Last item2",
                    "last last item",
                    "last last last item",
                    "last",
                    "last last"
                );

            // dropdown 4
            SfmlUI.Dropdown dropdown4 = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(800, 600), new Font("ArialNova.ttf"), 40,
                    "Lorem Ipsum2",
                    "Electric boogaloo2",
                    "James2",
                    "Brown fox2",
                    "Doc2",
                    "Docile2",
                    "Pizza2",
                    "Hut Hut2",
                    "Last item2"
                );
            dropdown4.OutlineColor = Color.Yellow;
            dropdown4.OutlineThickness = 0;
            dropdown4.FontColor = Color.Cyan;
            dropdown4.HighlightColor = Color.Red;
            dropdown4.BackgroundColor = Color.Black;
            dropdown4.Position = new SFML.System.Vector2f(1000, 200);
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                Window.Draw(Background);
                
                dropdown.Draw();
                dropdown2.Draw();
                dropdown3.Draw();
                dropdown4.Draw();
                Console.Write("dropdown 1: " + dropdown.ChosenItem + "     dropdown 2: " + dropdown2.ChosenItem);
                Console.Write("     dropdown 3: " + dropdown3.ChosenItem + "     dropdown 4: " + dropdown4.ChosenItem + "\n");

                Window.Display();         
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow Window = (RenderWindow)sender;
            Window.Close();
            Environment.Exit(0);
        }
    }
}
