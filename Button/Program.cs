using System;
using SFML.Graphics;
using SFML.Window;

namespace Button
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Button test");
            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                window.Display();
            }
        }
    }
}
