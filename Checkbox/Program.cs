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
            RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Checkbox test");
            window.SetFramerateLimit(30);
            Checkbox checkbox = new Checkbox(window, new Vector2f(50, 50), 50, 50);
            window.Closed += (_,__) => window.Close();
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
