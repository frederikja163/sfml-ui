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
            SfmlUI.Graphic scaledElement = new SfmlUI.Graphic(Window, "background.png", new Vector2f(870, 250), new Vector2f(100, 200), new Vector2f(100, 100), 2f);
            scaledElement.Origin.Horizontal.Center();
            SfmlUI.Graphic element2 = new SfmlUI.Graphic(Window, "background.png", new Vector2f(870, 600), new Vector2f(500, 100), new Vector2f(100, 100));
            element2.Origin.Horizontal.Center();
            element2.Origin.Vertical.Center();
            element2.Fade(0.7f);
            SfmlUI.Graphic element3 = new SfmlUI.Graphic(Window, "background.png", new Vector2f(400, 600), new Vector2f(100, 200), new Vector2f(100, 100));
            element3.Color(255, 0, 0);
            SfmlUI.Graphic element4 = new SfmlUI.Graphic(Window, "background.png", new Vector2f(570, 600), new Vector2f(100, 200), new Vector2f(100, 100));
            element4.Rotate(45f);

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

            var radioButton = new RadioButton(Window, new Vector2f(950, 500), 14, new Vector2f(0, 40), 5, 3);
            var radioButton2 = new RadioButton(Window, new Vector2f(720, 550), 14, new Vector2f(0, 40), 5);

            Dropdown dropdown = new Dropdown(Window, new Vector2f(50, 550), new Font("ArialNova.ttf"), 30,
                    "No Blink",
                    "Fast",
                    "Medium",
                    "Slow"
                );
            Dropdown dropdown2 = new Dropdown(Window, new Vector2f(250, 550), new Font("ArialNova.ttf"), 30,
                    "Red",
                    "Green",
                    "Blue",
                    "Yellow",
                    "Purple",
                    "Cyan"
                );
            Window.MouseButtonReleased += OnMouseButtonReleased;

            int _lastRadio = -2;
            int _lastRadio2 = -2;

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
                if (radioButton._selected != _lastRadio)
                {
                    _lastRadio = radioButton._selected;
                    switch(_lastRadio)
                    {
                        case 0:
                            element2.StopFlashing();
                            break;
                        case 1:
                            element2.StartFlashing(1000);
                            break;
                        case 2:
                            element2.StartFlashing(600);
                            break;
                        case 3:
                            element2.StartFlashing(300);
                            break;
                        case 4:
                            element2.StartFlashing(100);
                            break;
                    }
                }
                radioButton2.Draw();
                if (radioButton2._selected != _lastRadio2)
                {
                    _lastRadio2 = radioButton2._selected;
                    switch (_lastRadio2)
                    {
                        case 0:
                            element4.Rotate(0);
                            break;
                        case 1:
                            element4.Rotate(45);
                            break;
                        case 2:
                            element4.Rotate(90);
                            break;
                        case 3:
                            element4.Rotation(30);
                            break;
                        case 4:
                            element4.Rotation(360);
                            break;
                    }
                }

                element2.Draw();
                element3.Draw();
                element4.Draw();
                dropdown.Draw();
                dropdown2.Draw();

                Window.Display();
            }

            void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
            {
                if (dropdown.ChosenItem == "No Blink") background.StopFlashing();
                if (dropdown.ChosenItem == "Fast") background.StartFlashing(100);
                if (dropdown.ChosenItem == "Medium") background.StartFlashing(300);
                if (dropdown.ChosenItem == "Slow") background.StartFlashing(600);
                if (dropdown2.ChosenItem == "Red") element3.Color(255, 0, 0);
                if (dropdown2.ChosenItem == "Green") element3.Color(0, 255, 0);
                if (dropdown2.ChosenItem == "Blue") element3.Color(0, 0, 255);
                if (dropdown2.ChosenItem == "Yellow") element3.Color(255, 255, 0);
                if (dropdown2.ChosenItem == "Purple") element3.Color(255, 0, 255);
                if (dropdown2.ChosenItem == "Cyan") element3.Color(0, 255, 255);
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
