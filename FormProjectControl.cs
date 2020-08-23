using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FormProjectControl : Form
    {
        public class ProMessage //查询信息传输类
        {
            public string userName { get; set; }
            public string pwd { get; set; }
            public string token { get; set; }
        }
        public FormProjectControl()
        {
            InitializeComponent();

            //启动项目管理窗口，拉取数据
            string projectMessege;
            ProMessage res = new ProMessage();
            res.userName = Common.userCode;
            res.pwd = "";
            res.token = "";
            string jsonUserCode = JsonConvert.SerializeObject(res, Formatting.Indented);

            var httpWebRequestGet = (HttpWebRequest)WebRequest.Create("http://10.254.40.240:8080/content");
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {



        }

        private void FormProjectControl_Load(object sender, EventArgs e)
        {
           

                if (Common.userStatus == 1)
                {
                    //生成目录树
                    treeView1.Nodes.Add(Common.projectTreeView);
                    //展开全部
                    //treeView1.ExpandAll();


                }

            
        }
    }
}
