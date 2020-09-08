using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SfmlUI;

namespace CheckboxSandkasse
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Checkbox");
            window.Size = new Vector2u(1280, 720);
            window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);
            window.Closed += (_,__) => window.Close();
            
            Checkbox checkbox = new Checkbox(window);
            checkbox.Position = new Vector2f(150, 150);
            checkbox.Width = 250;
            checkbox.Height = 250;
            checkbox.CrossColor = Color.Green;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                
                checkbox.Draw();
                
                window.Display();
            }
        }
    }
}
