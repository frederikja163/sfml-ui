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
            RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Checkbox", Styles.Titlebar | Styles.Close);
            window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);
            window.Closed += (_,__) => window.Close();
            
            Checkbox checkbox = new Checkbox(window);
            checkbox.Position = new Vector2f(150, 150);
            checkbox.Width = 250;
            checkbox.Height = 250;
            checkbox.CrossThickness = 20f;
            checkbox.FillColor = Color.Red;

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
