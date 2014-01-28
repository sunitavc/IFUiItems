using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArtOfTest.Common;
using ArtOfTest.WebAii.Controls.Xaml;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;

namespace IFCommonAutomation.Pages.Repo
{
    class BasePage
    {
        #region Members

        /// <summary>
        /// gets or sets the current application
        /// </summary>
        public static IApplication Application { get; set; }

        /// <summary>
        /// gets or sets the current active browser
        /// </summary>
        public static Browser ActiveBrowser { get; set; }

        /// <summary>
        /// gets or sets the current active manager
        /// </summary>
        public static Manager Manager { get; set; }

        public static int Interval
        {
            get { return Convert.ToInt32(ConfigurationManager.GetSection("Trials/Interval").ToString()); }
        }

        public static int MaxTryCount
        {
            get { return Convert.ToInt32(ConfigurationManager.GetSection("Trials/MaxTryCount").ToString()); }
        }


        #endregion

        /// <summary>
        /// try to find an item
        /// </summary>
        /// <param name="searchFunction">function that searches for item</param>
        /// <returns>found frameworkelements</returns>
        protected static void TryFindItem(Action searchFunction)
        {
            Application.Find.Strategy = FindStrategy.WhenNotVisibleReturnElementProxy;
            var tryCount = 0;
            var blnFound = false;
            while (tryCount < MaxTryCount && !blnFound)
            {
                try
                {
                    Application.RefreshVisualTrees();
                    searchFunction.Invoke();
                    blnFound = true;
                }
                catch (Exception)
                {
                    //do nothing
                }
                finally
                {
                    Thread.Sleep(Interval);
                    tryCount++;
                }
            }
            if (!blnFound)
            {
                throw new Exception("Element can not be found");
            }
            ActiveBrowser.WaitUntilReady();
        }

        /// <summary>
        /// find all items given the searchParameters
        /// </summary>
        /// <param name="parentElement">parentElement</param>
        /// <param name="searchParameters">searchParameters</param>
        /// <returns>list of found</returns>
        protected static FrameworkElement FindItem(IFrameworkElement parentElement, params string[] searchParameters)
        {
            var findExpression = new XamlFindExpression(searchParameters);
            return ReferenceEquals(parentElement, null) ? Application.Find.ByExpression(findExpression) : parentElement.Find.ByExpression(findExpression);
        }
           
        /// <summary>
        /// find all items given the searchParameters
        /// </summary>
        /// <param name="parentElement">parentElement</param>
        /// <param name="indexOfItemToFind">indexOfItemToFind needed</param>
        /// <param name="searchParameters">searchParameters</param>
        /// <returns>list of found frameworkelements</returns>
        protected static IList<FrameworkElement> FindAllItems(IFrameworkElement parentElement, int indexOfItemToFind, params string[] searchParameters)
        {
            return FindAllItems(parentElement, new XamlFindExpression(searchParameters), indexOfItemToFind);
        }

        /// <summary>
        /// find all items given the indexToolbarItem of the parentElement and searchParameters
        /// </summary>
        /// <param name="parentElement">parentElement</param>
        /// <param name="parentLevel">level of parentElement relative to the item we're trying to find</param>
        /// <param name="indexOfItemToFind">indexOfItemToFind needed</param>
        /// <param name="searchParameters">searchParameters</param>
        /// <returns>list of found frameworkelements</returns>
        protected static IList<FrameworkElement> FindAllItems(FrameworkElement parentElement, int parentLevel, int indexOfItemToFind, params string[] searchParameters)
        {
            var findExpression = new XamlFindExpression(searchParameters);
            findExpression.AddHierarchyConstraint(new HierarchyConstraint(new XamlFindExpression("XamlTag=" + parentElement.XamlTag), parentLevel));
            return FindAllItems(parentElement, findExpression, indexOfItemToFind);
        }

        /// <summary>
        /// find all items given a find expression
        /// </summary>
        /// <param name="parentElement">parentElement to find on</param>
        /// <param name="findExpression">the find expression</param>
        /// <param name="indexOfItemToFind">indexOfItemToFind needed</param>
        /// <returns>list of found frameworkelements</returns>
        protected static IList<FrameworkElement> FindAllItems(IFrameworkElement parentElement, XamlFindExpression findExpression, int indexOfItemToFind)
        {
            var itemsFound = ReferenceEquals(parentElement, null) ? Application.Find.AllByExpression(findExpression) : parentElement.Find.AllByExpression(findExpression);
            if (ReferenceEquals(itemsFound, null) || itemsFound.Count < indexOfItemToFind + 1) return null;
            return itemsFound;
        }

        /// <summary>
        /// wait for spinner
        /// </summary>
        protected void WaitForSpinner()
        {
            Application.Find.Strategy = FindStrategy.WhenNotVisibleReturnElementProxy;
            var blnFound = true;
            while (blnFound)
            {
                try
                {
                    Application.RefreshVisualTrees();
                    var childWindow = FindItem(null, "XamlTag=SpinnerControl");
                    var button = FindItem(childWindow, "Name=progressBar");
                    if (ReferenceEquals(button, null) || !button.IsVisible) throw new Exception("Not found");
                }
                catch (Exception)
                {
                    blnFound = false;
                }
                finally
                {
                    Thread.Sleep(Interval);
                }
            }
        }
    }
}
