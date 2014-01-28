using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Silverlight;

namespace IFCommonAutomation.Pages.Actions
{
    class BaseActions
    {
        public void ClickLink(FrameworkElement element)
        {
            element.User.Click();
        }

        public void HoverOverLink(FrameworkElement element)
        {
            element.User.HoverOver();
        }
    }
}
