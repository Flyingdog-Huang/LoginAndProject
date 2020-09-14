using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndProject
{
    
    public partial class FormLogin : Form
    {

        public static string URL = "http://88.168.3.24:8080/";
        public class LoginMessage //登录信息传输类
        {
            public string userName { get; set; }
            public string pwd { get; set; }
            public string token { get; set; }
        }
        public class LoginMessageResponce //登录信息返回类
        {
            public int result { get; set; }
            public string token { get; set; }
        }

        public class ProMessage //查询信息传输类
        {
            public string userName { get; set; }
            public string pwd { get; set; }
            public string token { get; set; }
        }

        public FormLogin()
        {
            Common.closeflag = true;
            InitializeComponent();
            if (Common.userStatus == 0) //登出状态下
            {
                button1.Enabled = true; //启用登录按钮
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = false;
                Common.prControlButton.Enabled = false;

            }
            else
            {
                textBox1.Text = Common.userCode;
                textBox2.Text = "******";
                button1.Enabled = false; //登录按钮禁用
                textBox1.Enabled = false; //禁用文本框
                textBox2.Enabled = false; //禁用文本框
                button2.Enabled = true; //注销按钮启用
                ////禁用文本框和登录按钮
                //textBox1.Enabled = false;
                //textBox2.Enabled = false;
                //button1.Enabled = false;

                ////注销按钮启动
                //button2.Enabled = true;
                Common.prControlButton.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //登录按钮功能
        private void button1_Click(object sender, EventArgs e)
        {
            if (Common.userStatus == 0) //登出状态下
            {
                
                string userName = textBox1.Text; //获取用户名
                Common.userCode = userName;
                string pwd = textBox2.Text; //获取密码
                string token = "XXX";

                if (userName != null && pwd != null) //如果字段不为空
                {
                    //得到登录信息
                    LoginMessage mes = new LoginMessage();
                    mes.userName = userName;
                    mes.pwd = pwd;
                    mes.token = token;

                    string jsonStr = JsonConvert.SerializeObject(mes, Formatting.Indented); //body序列化

                    //Console.WriteLine("jsonStr：{0}", jsonStr); //输出试验
                    /* */
                    //推出请求
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL + "login");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(jsonStr);
                        //Console.WriteLine("jsonStr：{0}", jsonStr); //输出试验
                    }
                    //Console.WriteLine("httpWebRequest：{0}", httpWebRequest); //输出试验
                    //获取反馈
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        dynamic res = JsonConvert.DeserializeObject(result); //反序列化
                        Common.userStatus = res.status;
                        Common.token = res.token;
                        
                    }

                    if (Common.userStatus == 1) //登陆成功
                    {

                        //禁用文本框和登录按钮
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button1.Enabled = false;

                        //注销按钮启动
                        button2.Enabled = true;
                        Common.prControlButton.Enabled = true;

                        //更改窗口、按钮指令
                        Common.closeflag = false;
                        Common.proflag = true;

                        //启动项目管理窗口，拉取数据
                        string projectMessege;
                        ProMessage res = new ProMessage();
                        res.userName = Common.userCode;
                        res.pwd = "";
                        res.token = "";
                        string jsonUserCode = JsonConvert.SerializeObject(res, Formatting.Indented);

                        var httpWebRequestGet = (HttpWebRequest)WebRequest.Create(URL + "content");
                        httpWebRequestGet.ContentType = "application/json";
                        httpWebRequestGet.Method = "POST";

                        using (var streamWriter = new StreamWriter(httpWebRequestGet.GetRequestStream()))
                        {
                            streamWriter.Write(jsonUserCode);

                        }

                        var httpResponseGet = (HttpWebResponse)httpWebRequestGet.GetResponse();
                        using (var streamReader = new StreamReader(httpResponseGet.GetResponseStream()))
                        {
                            var resultpr = streamReader.ReadToEnd();
                            projectMessege = resultpr;

                        }
                        //
                        //解析
                        //
                        JObject res1 = (JObject)JsonConvert.DeserializeObject(projectMessege);

                        //TreeNode mainTree = new TreeNode();
                        //mainTree.Tag = "我的项目";
                        //mainTree.Text = "我的项目";
                        Common.projectTreeView.Tag = "我的项目";
                        Common.projectTreeView.Text = "我的项目";

                        JArray myPro = (JArray)res1["data"];
                        if (myPro != null)
                        {
                            foreach (JObject i in myPro)
                            {
                                TreeNode tree1 = new TreeNode();
                                tree1.Tag = i["name"];
                                tree1.Text = (string)i["name"];
                                Common.projectTreeView.Nodes.Add(tree1);

                                JArray proList = (JArray)i["proSubitemList"];
                                if (proList != null)
                                {
                                    foreach (JObject j in proList)
                                    {
                                        TreeNode tree2 = new TreeNode();
                                        tree2.Tag = j["name"];
                                        tree2.Text = (string)j["name"];
                                        tree1.Nodes.Add(tree2);

                                        JArray addList = (JArray)j["add"];
                                        if (addList != null)
                                        {
                                            foreach (JObject z in addList)
                                            {
                                                TreeNode tree3 = new TreeNode();
                                                tree3.Tag = z["name"];
                                                tree3.Text = (string)z["name"];
                                                tree2.Nodes.Add(tree3);

                                                JArray add1List = (JArray)z["add"];
                                                if (add1List != null)
                                                {
                                                    foreach (JObject p in add1List)
                                                    {
                                                        TreeNode tree4 = new TreeNode();
                                                        tree4.Tag = p["name"];
                                                        tree4.Text = (string)p["name"];
                                                        tree3.Nodes.Add(tree4);
                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                        //启用项目管理窗口
                        //if (Common.closeflag == false)
                        //{
                        //    FormProjectControl formProjectControl = new FormProjectControl();
                        //    formProjectControl.ShowDialog();
                        //}
                        //if (Common.closeflag == false)
                        //{
                        //    Application.Run(new FormProjectControl());
                        //}
                        //FormProjectControl formProjectControl = new FormProjectControl();
                        //formProjectControl.ShowDialog();


                        //启用项目管理按钮
                        if (Common.proflag == true)
                        {
                            Common.prControlButton.Enabled = true;
                        }

                        //关闭登录窗体
                        this.Close();

                        //隐藏窗口
                        //this.Hide();

                        
                        //如何调用Class1中的PushButton prControlButton


                        

                        //Common.projectTreeView.Nodes.Add(mainTree);

                        
                        //调用项目管理窗口
                        //FormProjectControl formProjectControl = new FormProjectControl();
                        //formProjectControl.ShowDialog();

                        
                    }
                    else //登录失败
                    {
                        //弹出登录失败提示窗口
                        MessageBox.Show("登陆失败，请检查用户名和密码。");

                    }
                    //res = JsonConvert.DeserializeObject();
                    //Console.WriteLine("result：{0}", result); 输出试验

                }
                else //数据为空
                {
                    //弹出数据为空提示窗口
                    MessageBox.Show("请输入用户名和密码。");

                }
            }
            //else //已经登录
            //{
            //    textBox1.Text = Common.userCode;
            //    textBox2.Text = "******";
            //    button1.Enabled = false; //登录按钮禁用
            //    textBox1.Enabled = false; //禁用文本框
            //    textBox2.Enabled = false; //禁用文本框
            //    button2.Enabled = true; //注销按钮启用
            //}
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Common.userStatus == 0)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Common.userStatus == 0)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        //注销按钮功能
        private void button2_Click(object sender, EventArgs e)
        {
            if (Common.userStatus == 0) //登出状态下禁用注销按钮
            {
                button2.Enabled = false;
            }
            else //登录状态下
            {
                button2.Enabled = true; //启用注销按钮
                //拉取发送信息
                LoginMessage mes = new LoginMessage();
                mes.userName = Common.userCode;
                mes.pwd = "";
                mes.token = "";

                string jsonStr = JsonConvert.SerializeObject(mes, Formatting.Indented); //body序列化

                //Console.WriteLine("jsonStr：{0}", jsonStr); //输出试验
                /* */
                //发送请求
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL + "logout");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonStr);
                    //Console.WriteLine("jsonStr：{0}", jsonStr); //输出试验
                }
                //Console.WriteLine("httpWebRequest：{0}", httpWebRequest); //输出试验
                //得到反馈
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(result); //反序列化
                    Common.userStatus = res.status;
                    
                }
                if (Common.userStatus==0) //登出状态下
                {
                    button2.Enabled = false; //禁用注销按钮
                    button1.Enabled = true; //启用登录按钮
                    textBox1.Enabled = true; //启用文本框
                    textBox2.Enabled = true; //启用文本框
                    //初始化
                    Common.token = "";
                    Common.userCode = "";
                    Common.projectTreeView.Nodes.Clear();
                    
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            
            
        }
    }
}
