using System;
using SFML.Graphics;
using SFML.Window;
using SfmlUI;

namespace Dropdown
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, "Dropdown Sandbox", Styles.Titlebar | Styles.Close);
            Window.Closed += OnClose;
            SfmlUI.Dropdown dropdown = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(0, 0), 100, new Font("ArialNova.ttf"), 12,
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
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                
                
                dropdown.Draw();


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
