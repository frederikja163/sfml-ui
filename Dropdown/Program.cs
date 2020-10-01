using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SfmlUI;

namespace Dropdown1
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow Window = new RenderWindow(VideoMode.DesktopMode, "Dropdown Sandbox", Styles.Titlebar | Styles.Close);
            RectangleShape Background = new RectangleShape(new Vector2f(Window.Size.X, Window.Size.Y));
            Background.Position = new Vector2f(0, 0);
            Background.FillColor = new Color(122,122,122,255);
            Window.Closed += OnClose;

            // dropdown 1
            Dropdown dropdown = new Dropdown(Window, new Vector2f(200, 150), new Font("C:\\Users\\burni\\Source\\Repos\\sfml-ui\\Dropdown\\bin\\Debug\\netcoreapp3.1\\ArialNova.ttf"), 30,
                    "Lorem Ipsum",
                    "Electric boogaloo",
                    "James",
                    "Brown fox",
                    "Doc",
                    "Docile",
                    "Pizza",
                    "Hut Hut",
                    "Last item"
                );
            dropdown.OutlineColor = Color.Cyan;
            dropdown.OutlineThickness = 50;
            dropdown.TextColor = Color.Blue;
            dropdown.HighlightColor = Color.Cyan;
            dropdown.BackgroundColor = Color.Yellow;

            // Button
            Button button = new Button(Window, new Vector2f(200, 200), new Vector2f(100, 20));
            button.CenterColor = Color.Black;
            button.OuterColor = Color.Red;

            // Checkbox
            Checkbox checkbox = new Checkbox(Window, new Vector2f(1000, 500));
            checkbox.FillColor = Color.Yellow;
            checkbox.CrossColor = Color.Magenta;

            // RadioButton
            RadioButton radiobutton = new RadioButton(Window, new Vector2f(500, 700), 10f, 50f, 3);

            // Slider
            Slider slider = new Slider(Window, new Vector2f(1080, 500), 200f, 50f, 0f, 100f);

            // Text input
            TextInput textinput = new TextInput(Window, new Vector2f(900, 80), 900f, 50f, new Font("ArialNova.ttf"));


            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                Window.Draw(Background);
                
                dropdown.Draw();
                button.Draw();
                checkbox.Draw();
                radiobutton.Draw();
                slider.Draw();
                textinput.Draw();

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
