using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Silverlight;

namespace IFCommonAutomation.Pages.Repo
{
    class ControlZonePage : BasePage
    {
        public FrameworkElement UpdateChartLink()
        {
            return FindItem(null, "TextContent='Update chart'");
        }
    }
}
