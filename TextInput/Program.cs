using SFML.Graphics;
using SFML.Window;
using SfmlUI;
using SFML.System;

namespace TextInputSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Textinput", Styles.Titlebar | Styles.Close);
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();

            TextInput textInput = new TextInput(window, new Vector2f(), 500f, 100f, new Font("Arial.ttf")) { BackgroundColor = Color.White, TextColor = Color.White };

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
