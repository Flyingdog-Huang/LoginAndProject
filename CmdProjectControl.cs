using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoginAndProject
{
    [Transaction(TransactionMode.Manual), Regeneration(RegenerationOption.Manual)]

        
        class CmdProjectControl : IExternalCommand
        {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            FormProjectControl formProjectControl = new FormProjectControl();
            formProjectControl.ShowDialog();
            

            return Result.Succeeded;
        }
    }
}