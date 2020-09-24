using System;
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

            TextInput textInput = new TextInput(window, new Vector2f(20, 20), 700f, 85f, new Font("Arial.ttf")) { BackgroundColor = Color.White, TextColor = Color.White };

            TextInput textInput2 = new TextInput(window, new Vector2f(20, 250), 500f, 20f, new Font("Arial.ttf")) { BackgroundColor = Color.White, TextColor = Color.White };

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(new Color(100, 100, 100));

                textInput.Draw();

                textInput2.Draw();

                window.Display();
            }
        }
    }
}
