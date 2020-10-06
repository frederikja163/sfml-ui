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

            TextInput textInput = new TextInput(
                window,
                new Vector2f(20, 20),
                700f,
                85f,
                new Font("Arial.ttf")
            );

            TextInput textInput2 = new TextInput(window, new Vector2f(20, 250), 500f, 20f, new Font("Arial.ttf")) { FieldColor = Color.Black, TextColor = Color.White };

            TextInput textInput3 = new TextInput(
                window,
                new Vector2f(20, 350),
                500f,
                20f,
                new Font("Arial.ttf")
            )
            { FieldColor = Color.Black, TextColor = Color.White };

            textInput3.SetText("Hello i'm setting text programmatically");
            System.Console.WriteLine("And printing it to the console:");
            System.Console.WriteLine(textInput3.Text);

            textInput3.OnChange += (_, str) => System.Console.WriteLine($"OnChangeHandler called with \"{str}\"!");


            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(new Color(100, 100, 100));

                textInput.Draw();

                textInput2.Draw();

                textInput3.Draw();

                window.Display();
            }
        }
    }
}
