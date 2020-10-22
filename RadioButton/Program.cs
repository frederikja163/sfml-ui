using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using SfmlUI;


namespace RadioButtonSandbox
{
    class Program
    {
        private static RenderWindow _window;

        private static TextBox Text8;

        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(1000, 1000), "RadioButton");

            //RadioButton(RenderWindow = _window, startingPosition, globalRadius, lineSpacing, radioAmount)
            RadioButton radioButton = new RadioButton(_window, new Vector2f(100,100), 30, new Vector2f(0,100), 5);

            //TextBox(_window, position, ?, font, fontSize
            TextBox text1 = new TextBox(_window, new Vector2f(190, 115), 200f, 200f, new Font("Arial.ttf"), 30);
            text1.BackgroundColor = new Color(0, 0, 0, 0);
            text1.OutlineColor = new Color(0, 0, 160);
            text1.TextColor = Color.White;
            text1.Output("Radio button 1");

            TextBox text2 = new TextBox(_window, new Vector2f(190, 215), 200f, 200f, new Font("Arial.ttf"), 30);
            text2.BackgroundColor = new Color(0, 0, 0, 0);
            text2.OutlineColor = new Color(0, 0, 160);
            text2.TextColor = Color.White;
            text2.Output("Radio button 2");

            TextBox text3 = new TextBox(_window, new Vector2f(190, 315), 200f, 200f, new Font("Arial.ttf"), 30);
            text3.BackgroundColor = new Color(0, 0, 0, 0);
            text3.OutlineColor = new Color(0, 0, 160);
            text3.TextColor = Color.White;
            text3.Output("Radio button 3");

            TextBox text4 = new TextBox(_window, new Vector2f(190, 415), 200f, 200f, new Font("Arial.ttf"), 30);
            text4.BackgroundColor = new Color(0, 0, 0, 0);
            text4.OutlineColor = new Color(0, 0, 160);
            text4.TextColor = Color.White;
            text4.Output("Radio button 4");

            TextBox text5 = new TextBox(_window, new Vector2f(190, 515), 200f, 200f, new Font("Arial.ttf"), 30);
            text5.BackgroundColor = new Color(0, 0, 0, 0);
            text5.OutlineColor = new Color(0, 0, 160);
            text5.TextColor = Color.White;
            text5.Output("Radio button 5");

            TextBox text6 = new TextBox(_window, new Vector2f(100, 615), 200f, 200f, new Font("Arial.ttf"), 30);
            text6.BackgroundColor = new Color(0, 0, 0, 0);
            text6.OutlineColor = new Color(0, 0, 160);
            text6.TextColor = Color.White;

            //Slider(_window, position, length, height, min-value, max-value)
            Slider slider = new Slider(_window, new Vector2f(500, 100), 400f, 50f, 0f, 100f);

            TextBox text7 = new TextBox(_window, new Vector2f(600, 50), 200f, 200f, new Font("Arial.ttf"), 30);
            text7.BackgroundColor = new Color(0, 0, 0, 0);
            text7.OutlineColor = new Color(0, 0, 160);
            text7.TextColor = Color.White;

            //Button(_window, position, size)
            Button button = new Button(_window, new Vector2f(500, 200), new Vector2f(200, 200));
            button.Shape = Button.Shapes.Elipse;

            button.ButtonPressed += buttonPressed;
            button.ButtonReleased += buttonReleased;

            Text8 = new TextBox(_window, new Vector2f(750, 275), 200f, 200f, new Font("Arial.ttf"), 30);
            Text8.BackgroundColor = new Color(0, 0, 0, 0);
            Text8.OutlineColor = new Color(0, 0, 160);
            Text8.TextColor = Color.White;
            Text8.Output("Not pressed");

            //Checkbox(_window, position)
            Checkbox checkbox = new Checkbox(_window, new Vector2f(500, 450));
            checkbox.Width = 50;
            checkbox.Height = 50;
            checkbox.CrossThickness = 5f;
            checkbox.FillColor = new Color(255, 255, 255);
            checkbox.CrossColor = new Color(100, 100, 100);

            TextBox text9 = new TextBox(_window, new Vector2f(575, 455), 200f, 200f, new Font("Arial.ttf"), 30);
            text9.BackgroundColor = new Color(0, 0, 0, 0);
            text9.OutlineColor = new Color(0, 0, 160);
            text9.TextColor = Color.White;

            //Dropdown(_window, position, font, fontSize)
            Dropdown dropdown = new Dropdown(_window, new Vector2f(100, 700), new Font("Arial.ttf"), 30,
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
            dropdown.OutlineColor = new Color(100, 100, 100);
            dropdown.OutlineThickness = 50;
            dropdown.TextColor = new Color(255, 255, 255);
            dropdown.HighlightColor = new Color(255, 0, 0); ;
            dropdown.BackgroundColor = new Color(100, 100, 100);

            TextBox text10 = new TextBox(_window, new Vector2f(100, 775), 200f, 200f, new Font("Arial.ttf"), 30);
            text10.BackgroundColor = new Color(0, 0, 0, 0);
            text10.OutlineColor = new Color(0, 0, 160);
            text10.TextColor = Color.White;

            //TextInput(_window, position, width, height, font)
            TextInput textInput = new TextInput(_window, new Vector2f(500, 550), 400f, 50f, new Font("Arial.ttf"));
            textInput.OutlineColor = new Color(100, 100, 100);
            textInput.TextColor = new Color(0, 0, 0);

            TextBox text11 = new TextBox(_window, new Vector2f(500, 625), 200f, 200f, new Font("Arial.ttf"), 30);
            text11.BackgroundColor = new Color(0, 0, 0, 0);
            text11.OutlineColor = new Color(0, 0, 160);
            text11.TextColor = Color.White;

            //Graphic(_window, "name.filetype", position)
            Graphic graphic = new Graphic(_window, "image.jpg", new Vector2f (500, 700));

            _window.Closed += WindowClosed;

            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();

                radioButton.Draw();
                text1.Draw();
                text2.Draw();
                text3.Draw();
                text4.Draw();
                text5.Draw();
                if (radioButton._selected == -1)
                {
                    text6.Output("Selected button: none");
                }
                else
                {
                    text6.Output("Selected button: " + (radioButton._selected + 1));
                }  
                text6.Draw();

                slider.Draw();
                text7.Output(slider.Value.ToString());
                text7.Draw();

                button.Draw();
                Text8.Draw();

                checkbox.Draw();
                if (checkbox.IsChecked == true)
                {
                    text9.Output("Checked");
                }
                else
                {
                    text9.Output("Unchecked");
                }
                text9.Draw();

                text10.Output("Selected: " + dropdown.ChosenItem);
                text10.Draw();
                dropdown.Draw();

                textInput.Draw();
                text11.Output("Input: " + textInput.Text);
                text11.Draw();

                graphic.Draw();

                _window.Display();
            }

        }
        private static void buttonPressed()
        {
            Text8.Output("Pressed");
        }

        private static void buttonReleased()
        {
            Text8.Output("Not pressed");
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}