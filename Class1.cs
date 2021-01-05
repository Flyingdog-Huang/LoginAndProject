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
using Newtonsoft.Json.Linq;
using System.Data;

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
        public const string name_project = "projectName";// 母项目tag        
        public const string name_son_project = "sonProjectName";// 子项目tag
        //public static JObject allProjectName_Id = new JObject();//所有子项目名字和ID对应
        public static JObject allProject = new JObject();//母项目对应的子项目ID信息
        //public const string URL = "http://88.168.3.24:8080/";// 服务器地址
        public const string URL = "http://10.254.40.225:8080/";// 本地地址

        public static string dataStartProjectId = "";//发起流程的子项id-查询数据

        public static TreeNode subProjectChooseTree = new TreeNode();//子项专业图纸选择树-展示数据

        public static List<JObject> listSubProjectMajor = new List<JObject>();//子项专业图纸信息列表-查询数据

        //图纸选择传递信息
        public static int flagChoose = 0;
        public static string majorChooseMessage;
        public static string nameDrawingChooseMessage;
        public static string numDrawingChooseMessage;
        public static JArray checker;
        public static JArray checkerId;
        public static JArray auditor;
        public static JArray auditorId;
        public static JArray authorizer;
        public static JArray authorizerId;

        /// <summary>
        /// 发送请求并获取数据(默认post)
        /// </summary>
        /// <returns></returns>
        public static dynamic AskData(dynamic pushData, string URLType, string method = "POST")
        {
            string jsonData = JsonConvert.SerializeObject(pushData, Formatting.Indented);

            var httpWebRequestGet = (HttpWebRequest)WebRequest.Create(URL + URLType);
            httpWebRequestGet.ContentType = "application/json";
            httpWebRequestGet.Method = method;

            using (var streamWriter = new StreamWriter(httpWebRequestGet.GetRequestStream()))
            {
                streamWriter.Write(jsonData);

            }

            var httpResponseGet = (HttpWebResponse)httpWebRequestGet.GetResponse();
            using (var streamReader = new StreamReader(httpResponseGet.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                dynamic res = JsonConvert.DeserializeObject(result);
                return res;

            }
        }

        // 子项项目信息
        public static DataTable allSubProjectMessage = new DataTable();
        // 校审流程信息
        public static DataTable flowMessage = new DataTable();
        // 校审流程ID判断处理校审
        public static bool unicodeFlag = true;
        // 校审流程ID
        public static string unicode = "";
        // 定义全局按钮
        public static Button button;
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

            //MessageBox.Show("__");

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
