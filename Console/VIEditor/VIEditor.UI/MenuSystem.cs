using System;
using VIEditor.UI.Enums;
using VIEditor.UI.Models;

namespace VIEditor.UI
{
    internal class MenuSystem
    {
        readonly MenuItem[] _menuItems;

        internal MenuSystem()
        {
            _menuItems = new MenuItem[] {
                new MenuItem(MenuType.NewFile, LabelManager.Label.Menus.NewFile),
                new MenuItem(MenuType.OpenFile, LabelManager.Label.Menus.OpenFile),
                //new MenuItem(MenuType.RecentFiles, LabelManager.Label.Menus.RecentFile),
                new MenuItem(MenuType.ChangeTheme, LabelManager.Label.Menus.ChangeTheme),
                new MenuItem(MenuType.Help, LabelManager.Label.Menus.Help),
                new MenuItem(MenuType.Exit, LabelManager.Label.Menus.Exit)
            };
        }

        internal MenuItem[] GetMenus()
        {
            return _menuItems;
        }
    }
}
