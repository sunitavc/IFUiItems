using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;

namespace IFCommonAutomation.Pages.Actions
{
    class Storyboard : Story
    {
        public void RefreshStoryboard()
        {           
            storyboardBuilder.HoverOverTreeviewItem(0, 1);
            storyboardBuilder.ClickOnTreeviewItem(0, MouseClickType.LeftClick, 1, 0);
            StopUI();

            StartAssert("RefreshStoryboard");
            AssertNavigationEvents(Constants.StartPageNav);
            AssertNavigationEvent(true, Constants.StoryboardBuilderNav);
            AssertOpenStoryboardBuilderEvents();
            AssertOpenStoryboardEvents(Constants.DefaultStoryboardId);
            StopAssert();
        }
    }
}
