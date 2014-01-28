using System;
using IFCommonAutomation.Pages;

namespace IFCommonAutomation.Pages.Actions
{
    class MainMenuActions : MainMenu
    {
        public void HoverOverMenuLink(string itemName)
        {
            MnuLink(itemName).User.HoverOver();
        }

        public void ClickMenuLink(string itemName)
        {
            MnuLink(itemName).User.Click();
        }
    }
}
