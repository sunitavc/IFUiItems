using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFCommonAutomation.Pages.Repo;

namespace IFCommonAutomation.Pages.Actions
{
    class ControlZone : ControlZonePage
    {

        public void OpenControlZone()
        {
            
        }

        public void ExpandBucket(string bucketName)
        {
            
        }

        public void AddMeasure(List<string> measures)
        {
            
        }

        public void AddDimension(string fact, List<string> dimensions)
        {
            
        }

        public void SelectAllDimensions(string fact)
        {
            
        }

        public void SelectNoDimension(string fact)
        {
            
        }

        public void TurnOn(string bucketName, string listName)
        {
            
        }

        public void UpdateChart()
        {
            ClickLink(UpdateChartLink());
        }
    }
}
