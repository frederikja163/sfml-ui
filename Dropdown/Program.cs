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
            while (Window.IsOpen)
            {
                Window.DispatchEvents();


                Window.Clear();


                Window.Display();
            }

        }
    }
}
