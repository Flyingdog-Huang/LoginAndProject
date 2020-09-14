using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace LoginAndProject
{
    [Transaction(TransactionMode.Manual), Regeneration(RegenerationOption.Manual)]
    class CmdLogin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //FormLogin formLogin = new FormLogin();
            //formLogin.ShowDialog();

            //事件、进程、线程概念与关系的逻辑

            Application.Run(new FormLogin());

            if (Common.closeflag == false)
            {
                Application.Run(new FormProjectControl());
            }

            return Result.Succeeded;
        }
    }
}