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
            Background.FillColor = Color.Cyan;
            Window.Closed += OnClose;
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
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                Window.Draw(Background);
                
                dropdown.Draw();
                dropdown2.Draw();


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
