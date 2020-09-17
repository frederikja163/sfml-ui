using System;
using System.Drawing;
using System.Security;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SfmlUI;
using Color = SFML.Graphics.Color;

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
            
            Checkbox checkbox2 = new Checkbox(window);
            checkbox2.Position = checkbox.Position + new Vector2f(checkbox.Width + 50, 0);
            checkbox2.Width = 150;
            checkbox2.Height = 400;
            checkbox2.CrossThickness = 10f;
            checkbox2.CrossColor = Color.Green;
            checkbox2.FillColor = Color.Magenta;
            checkbox2.IsChecked = true;
            
            Checkbox checkbox3 = new Checkbox(window);
            checkbox3.Position = checkbox2.Position + new Vector2f(checkbox2.Width + 50, 0);
            checkbox3.Width = 500;
            checkbox3.Height = 100;
            checkbox3.CrossThickness = 10f;
            checkbox3.CrossColor = Color.Yellow;
            checkbox3.FillColor = Color.Blue;
            checkbox3.IsChecked = true;

            Checkbox checkbox4 = new Checkbox(window);
            checkbox4.Position = checkbox3.Position + new Vector2f(0, checkbox3.Height + 50);
            checkbox4.Width = 500;
            checkbox4.Height = 400;
            checkbox4.CrossThickness = 75f;
            checkbox4.CrossColor = Color.Black;
            checkbox4.FillColor = Color.White;
            checkbox4.BorderEnabled = true;
            checkbox4.BorderColor = Color.Red;
            checkbox4.IsChecked = true;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                
                checkbox.Draw();
                checkbox2.Draw();
                checkbox3.Draw();
                checkbox4.Draw();
                
                window.Display();
            }
        }
    }
}
