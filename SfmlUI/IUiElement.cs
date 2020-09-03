using System;
using SFML.Graphics;
using SFML.System;

namespace SfmlUI
{
    public interface IUiElement
    {
        bool IsVisible { get; set; }
        Vector2f Position { get; }
        float Width { get;  }
        float Height { get; }
       
        void Draw();
    }
}
