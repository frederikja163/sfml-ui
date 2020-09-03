using System;
using System.Security.Cryptography.X509Certificates;
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
            SfmlUI.Dropdown dropdown = new SfmlUI.Dropdown(Window, new SFML.System.Vector2f(0, 0), new SFML.System.Vector2f(100, 20));
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
