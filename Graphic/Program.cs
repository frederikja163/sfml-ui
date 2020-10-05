using System;
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
            element.StartFlashing(300);
            SfmlUI.Graphic scaledElement = new SfmlUI.Graphic(Window, "background.png", new Vector2f(770, 250), new Vector2f(100, 200), new Vector2f(100, 100), 2f);
            Window.KeyReleased += OnKeyReleased;

            Checkbox checkbox = new Checkbox(Window, new Vector2f(770, 470));
            checkbox.Width = 50;
            checkbox.Height = 50;
            checkbox.CrossThickness = 5f;
            checkbox.CrossColor = Color.Green;
            checkbox.FillColor = Color.Black;
            checkbox.BorderEnabled = true;
            checkbox.BorderColor = Color.White;
            checkbox.BorderThickness = 5;
            checkbox.IsChecked = true;

            var radioButton = new RadioButton(Window, new Vector2f(950, 20), 14, new Vector2f(0, 40), 5);

            Dropdown dropdown = new Dropdown(Window, new Vector2f(50, 550), new Font("ArialNova.ttf"), 30,
                    "No Blink",
                    "Fast",
                    "Medium",
                    "Slow"
                );
            Window.MouseButtonReleased += OnMouseButtonReleased;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear();
                background.Draw();
                element.Draw();
                scaledElement.Draw();
                scaledElement.IsVisible = checkbox.IsChecked;
                checkbox.Draw();
                
                radioButton.Draw();
                dropdown.Draw();

                Window.Display();
            }

            void OnMouseButtonReleased(object? sender, MouseButtonEventArgs e)
            {
                if (dropdown.ChosenItem == "No Blink") background.StopFlashing();
                if (dropdown.ChosenItem == "Fast") background.StartFlashing(100);
                if (dropdown.ChosenItem == "Medium") background.StartFlashing(300);
                if (dropdown.ChosenItem == "Slow") background.StartFlashing(600);
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
                    element.StartFlashing(300);
                    Console.WriteLine("element Blikning");
                }
                if (e.Code == Keyboard.Key.F)
                {
                    element.StartFlashing(100);
                    Console.WriteLine("element Blikning fast");
                }
                if (e.Code == Keyboard.Key.S)
                {
                    element.StartFlashing(600);
                    Console.WriteLine("element Blining slowly");
                }
                if (e.Code == Keyboard.Key.N)
                {
                    element.StopFlashing();
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
