using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.Windows.Forms;


namespace LoginAndProject
{
    public class Common //全局变量
    {
        public static string userCode { get; set; } //工号
        public static int userStatus = 0; //登录状态
        public static TreeNode projectTreeView = new TreeNode(); //项目目录树
        public static bool closeflag = true; //窗口控制
        public static bool proflag = false; //按钮控制
        public static PushButton prControlButton; //全局定义项目查询按钮
        public static string token; //状态码
        //public static int addTree = 0; //添加树操作
    }
    public class Class1 : IExternalApplication
    {
        
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //标签创建
            var tabName = "地铁设计院"; //var为?数据类型
            application.CreateRibbonTab(tabName); //创建设计院标签

            //在对应的标签下创建容器
            RibbonPanel logIn = application.CreateRibbonPanel(tabName, "登录"); //在设计院标签下创建登录容器
            RibbonPanel projectControl = application.CreateRibbonPanel(tabName, "项目管理"); //在设计院标签下创建项目管理容器

            //路径获取
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location; //获取本地路径

            //按钮创建
            var logInButtonData = new PushButtonData("Login", "登录",
                thisAssemblyPath, typeof(CmdLogin).FullName); //创建定义登录按钮信息
            var projectButtonData = new PushButtonData("ProjectControl", "项目管理",
                thisAssemblyPath, typeof(CmdProjectControl).FullName); //创建定义项目管理按钮信息

            //在对应的容器下添加按钮
            PushButton loginButton = logIn.AddItem(logInButtonData) as PushButton; //添加登录按钮
            Common.prControlButton = projectControl.AddItem(projectButtonData) as PushButton; //添加项目管理按钮

            if (Common.userStatus == 0) //登出状态下
            {
                Common.prControlButton.Enabled = false; //禁用项目查询按钮
            }
            if(Common.userStatus == 1) //登入状态下
            {
                Common.prControlButton.Enabled = true; //启用项目查询按钮
            }

            //美化按钮
            string loginImgPath = Path.GetDirectoryName(thisAssemblyPath) + @"\login.PNG"; //登录图标路径
            Uri loginUri = new Uri(loginImgPath, UriKind.RelativeOrAbsolute); //登录图标链接
            BitmapImage bitmapImageLogin = new BitmapImage(loginUri);
            loginButton.LargeImage = bitmapImageLogin;

            string prcImgPath = Path.GetDirectoryName(thisAssemblyPath) + @"\prc.PNG"; //项目管理图标路径
            Uri prcUri = new Uri(prcImgPath, UriKind.RelativeOrAbsolute); //项目管理图标链接
            BitmapImage bitmapImagePrc = new BitmapImage(prcUri);
            Common.prControlButton.LargeImage = bitmapImagePrc;

            
            return Result.Succeeded;
        }
    }
}
