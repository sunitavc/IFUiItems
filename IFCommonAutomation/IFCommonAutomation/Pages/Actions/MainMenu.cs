using System;
using IFCommonAutomation.Pages.Repo;

namespace IFCommonAutomation.Pages.Actions
{
    class MainMenuActions : BaseActions
    {
        public void HoverOverMenuLink(string itemName)
        {
            HoverOverLink(MnuLink(itemName));
        }

        public void SelectMenuLink(string itemName)
        {
            ClickLink(MnuLink(itemName));    
        }
    }
}
