using System;
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
            
            Checkbox checkbox = new Checkbox(window, new Vector2f(150, 150));
            checkbox.Width = 310;
            checkbox.Height = 310;
            checkbox.CrossThickness = 20f;
            
            Button button = new Button(window, checkbox.Position + new Vector2f(checkbox.Width + 5, 0), new Vector2f(100, 100));
            button.ButtonPressed += () =>
            {
                button.CenterColor = new Color((byte) new Random().Next(255), (byte) new Random().Next(255),
                    (byte) new Random().Next(255));
            };
            button.CenterColor = Color.Blue;

            Button button2 = new Button(window, button.Position + new Vector2f(0, button.Height + 5), button.Size);
            button2.CenterColor = Color.Green;
            
            Button button3 = new Button(window, button2.Position + new Vector2f(0, button2.Height + 5), button2.Size);
            
            
            TextInput textInput = new TextInput(window, button.Position + new Vector2f(button.Width + 5, 0), 500, 100, new Font("Arial.ttf"));

            Slider slider = new Slider(window, textInput.Position + new Vector2f(0, textInput.Height + 5), 500, 100, 0, 100);

            Dropdown dropdown = new Dropdown(window, checkbox.Position + new Vector2f(0, checkbox.Height + 5), new Font("Arial.ttf"), 35,
                "Lorem Ipsum",
                "Lorem Larum",
                "Lorem Lurum",
                "Lorem Durum"
            );
            
            TextBox textBox = new TextBox(window, slider.Position + new Vector2f(0, slider.Height + 5), textInput.Width, textInput.Height, new Font("Arial.ttf"), (uint) Math.Round(textInput.Height * 0.75));
            textBox.Output("DURUM");
            textBox.TextColor = Color.Black;

            Graphic graphic = new Graphic(window, "background.png", textBox.Position + new Vector2f(0, textBox.Height + 5), new Vector2f(0, 0), new Vector2f(textBox.Width, textBox.Height));

            button2.ButtonPressed += () =>
            {
                graphic.StartFlashing(1 * 1000);
            };

            button3.ButtonPressed += () =>
            {
                graphic.StopFlashing();
            };
            
            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                
                checkbox.Draw();
                button.Draw();
                textInput.Draw();
                slider.Draw();
                textInput.SetText(slider.Value.ToString());
                dropdown.Draw();
                textBox.Draw();
                graphic.Draw();
                button2.Draw();
                button3.Draw();
                
                window.Display();
            }
        }
    }
}
