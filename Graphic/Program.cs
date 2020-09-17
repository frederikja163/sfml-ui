using System;
using System.Security.Cryptography.X509Certificates;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SfmlUI;

namespace Graphic
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow Window = new RenderWindow(new VideoMode(1024, 768), "Graphic test", Styles.Titlebar | Styles.Close);
            Window.Closed += OnClose;
            SfmlUI.Graphic background = new SfmlUI.Graphic(Window, "background.png", new Vector2f(20, 20));
            SfmlUI.Graphic element = new SfmlUI.Graphic(Window, "background.png", new Vector2f(820, 100), new Vector2f(100, 100), new Vector2f(100, 100));
            element.Blink(300);
            SfmlUI.Graphic scaledElement = new SfmlUI.Graphic(Window, "background.png", new Vector2f(770, 250), new Vector2f(100, 200), new Vector2f(100, 100), 2f);
            Window.KeyReleased += OnKeyReleased;
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                background.Draw();
                element.Draw();
                scaledElement.Draw();

                Window.Display();
            }

            void OnKeyReleased(object sender, KeyEventArgs e)
            {
                if (e.Code == Keyboard.Key.H)
                {
                    Console.WriteLine("element Height: " + element.Height);
                }
                if (e.Code == Keyboard.Key.W)
                {
                    Console.WriteLine("scaledElement Width: " + scaledElement.Width);
                }
                if (e.Code == Keyboard.Key.B)
                {
                    element.Blink(300);
                    Console.WriteLine("element Blikning");
                }
                if (e.Code == Keyboard.Key.F)
                {
                    element.Blink(100);
                    Console.WriteLine("element Blikning fast");
                }
                if (e.Code == Keyboard.Key.S)
                {
                    element.Blink(600);
                    Console.WriteLine("element Blining slowly");
                }
                if (e.Code == Keyboard.Key.N)
                {
                    element.NoBlink();
                    Console.WriteLine("element Not Blinking");
                }
                if (e.Code == Keyboard.Key.I)
                {
                    background.IsVisible = false;
                    Console.WriteLine("background Invisible");
                }
                if (e.Code == Keyboard.Key.V)
                {
                    background.IsVisible = true;
                    Console.WriteLine("background Visible");
                }
                if (e.Code == Keyboard.Key.Escape)
                {
                    Window.Close();
                }
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
