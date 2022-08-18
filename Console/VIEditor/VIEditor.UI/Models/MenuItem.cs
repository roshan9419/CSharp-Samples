
using VIEditor.UI.Enums;

namespace VIEditor.UI.Models
{
    internal class MenuItem
    {
        public MenuItem(MenuType type, string name)
        {
            Type = type;
            Name = name;
        }

        public MenuType Type { get; }
        public string Name { get; }
    }
}
