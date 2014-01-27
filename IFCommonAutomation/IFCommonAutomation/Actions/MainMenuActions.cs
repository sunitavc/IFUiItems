using System;
using IFCommonAutomation.Pages;

namespace IFCommonAutomation.Actions
{
    class MainMenuActions : MainMenu
    {
        public void HoverOverMenuLink(String itemName)
        {
            MnuLink(itemName).User.HoverOver();
        }
    }
}
