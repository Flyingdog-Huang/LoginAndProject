using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndProject
{
    public partial class FormStartProject : Form
    {
        /// <summary>
        /// 发起流程按钮数据
        /// </summary>
        public class Data_Start
        {
            /// <summary>
            /// 子项目id
            /// </summary>
            public string projectId = Common.dataStartProjectId;
            /// <summary>
            /// 工号，即用户名
            /// </summary>
            public string userName = Common.userCode;

        }

        /// <summary>
        /// 将单节点插入到树的对应位置
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="jObject"></param>
        public void SearchAddNodes(TreeNode treeNode, JObject jObject)
        {
            string id_node = jObject["idcode"].ToString();//获取目标idcode

            if (treeNode.Nodes.Count == 0)
            {
                if (treeNode.Text == ""  || id_node.StartsWith(treeNode.Name.ToString()))
                { 
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Tag = jObject["type"].ToString();
                    treeNode1.Text = jObject["name"].ToString();
                    treeNode1.Name = jObject["idcode"].ToString();
                    treeNode.Nodes.Add(treeNode1);
                }
                
            }
            else 
            {
                int i = 0;//检测信号               
                
                foreach (TreeNode treeNode1 in treeNode.Nodes)
                {
                    string id_tree = treeNode1.Name;//获取树节点idcode
                    if (id_node.StartsWith(id_tree))
                    {
                        i = 1;
                        SearchAddNodes(treeNode1, jObject);
                        break;
                    }       
                }

                if (i == 0)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Tag = jObject["type"].ToString();
                    treeNode1.Text = jObject["name"].ToString();
                    treeNode1.Name = jObject["idcode"].ToString();
                    treeNode.Nodes.Add(treeNode1);
                }
            }                       
        }

        public FormStartProject()
        {
            InitializeComponent();

            Data_Start data_Start = new Data_Start();

            //日期时间
            label_date.Text = DateTime.Now.ToLocalTime().ToString();

            //发送请求并得到数据
            dynamic subProjectData = Common.AskData(data_Start, "getSpecialtyTree");
            JObject dataSubProject = (JObject)subProjectData;
            //数据写出查找问题
            //FileStream fs = new FileStream(@"E:\\project\\project-revit\\file\\" + data_Start.projectId + @".txt", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            //sw.Write(dataSubProject);
            //sw.Flush();
            //sw.Close();
            //fs.Close();

            //解析前先初始化清零
            Common.subProjectChooseTree.Nodes.Clear();
            Common.listSubProjectMajor.Clear();

            //数据解析
            Common.subProjectChooseTree.Tag = Common.dataStartProjectId;
            JArray treeNodeList = (JArray)dataSubProject["data"];
            foreach (JObject i in treeNodeList)
            {
                string st1 = i["type"].ToString();
                //string str2 = "工序";
                if (st1 != "工序")
                {
                    Common.listSubProjectMajor.Add(i);
                    SearchAddNodes(Common.subProjectChooseTree, i);
                }
                
            }

            

        }

        private void comboBox_major_SelectedIndexChanged(object sender, EventArgs e)
        {
            //打开专业图纸选择窗口
            FormChooseMajor formChooseMajor = new FormChooseMajor();
            formChooseMajor.ShowDialog();

            //查询信息判断
            if (Common.flagChoose == 1)
            {
                //窗口选择图册信息显示
                comboBox_major.Text = Common.majorChooseMessage;
                textBox_nameDrawing.Text = Common.nameDrawingChooseMessage;
                textBox_noDrawing.Text = Common.numDrawingChooseMessage;
                //下拉框数据绑定
                comboBox_checker.DataSource = Common.checker;
                comboBox_auditor.DataSource = Common.auditor;
                comboBox_validator.DataSource = Common.authorizer;
                //流程人员默认显示
                comboBox_checker.Text = (string)Common.checker[0];
                comboBox_auditor.Text = (string)Common.auditor[0];
                comboBox_validator.Text = (string)Common.authorizer[0];
            }
        }

        private void button_quote_Click(object sender, EventArgs e)
        {

        }
    }
}
