//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ArtOfTest.WebAii.Core;
//
//namespace IFCommonAutomation.Pages.Actions
//{
//    class Storyboard : Storyboard
//    {
//        public void RefreshStoryboard()
//        {           
//            
//        }
//
//        public void ClickOnTreeviewItem(int indexOfGroup, MouseClickType mouseClickType, params int[] linkIndexes)
//        {
//            TryFindItem(() =>
//            {
//                var panel = FindItem(null, "XamlTag=StoryboardExplorer");
//                var innerItem = FindAllItems(panel, -14, indexOfGroup, "XamlTag=SilverlightAccordionItem")[indexOfGroup];
//                var body = FindAllItems(innerItem, -5, 0, "XamlTag=SilverlightAccordionItemBody")[0];
//                var treeviewParent = FindItem(body, "Name=treeView");
//                var parentLevel = -11;
//                for (var currentIndex = 0; currentIndex < linkIndexes.Length - 1; currentIndex++)
//                {
//                    var items = FindAllItems(treeviewParent, parentLevel, linkIndexes[currentIndex], "XamlTag=IFTreeViewItem");
//                    parentLevel = -4;
//                    treeviewParent = items[linkIndexes[currentIndex]];
//                }
//                var menuItems = FindAllItems(treeviewParent, linkIndexes[linkIndexes.Length - 1], "XamlTag=IFTreeViewItem");
//                var viewItem = menuItems[linkIndexes[linkIndexes.Length - 1]];
//                var view = FindAllItems(viewItem, -5, 0, "Name=Content")[0];
//                view.User.Click(mouseClickType);
//            });
//        }
//    }
//}
