using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Silverlight;

namespace IFCommonAutomation.Pages.Repo
{
    internal class MainMenuPage : BasePage
    {
//        protected FrameworkElement menuBar
//        {
//            get{}
//        }
//        public FrameworkElement mnuHome()
//        {
//            
//        }

        public FrameworkElement MnuLink(string itemName)
        {
            var menu = FindItem(null, "XamlTag=Menu");
            var menuItem = FindItem(menu, "TextContent=" + itemName);
            return menuItem;
        }
    }
}