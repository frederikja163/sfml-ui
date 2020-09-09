using System;
using SFML.Graphics;
using SFML.Window;
using SfmlUI;

namespace TextInputSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Checkbox", Styles.Titlebar | Styles.Close);
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();

            TextInput textInput = new TextInput(window);

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                textInput.Draw();

                window.Display();
            }
        }
    }
}
