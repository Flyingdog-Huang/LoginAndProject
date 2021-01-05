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
        /// <summary>
        /// 获取流程意见发送请求的数据类
        /// </summary>
        public class AdvicePush
        {
            /// <summary>
            /// 流程id
            /// </summary>
            public string uniCode { get; set; }
        }
        /// <summary>
        /// 单击母项目发送请求的数据类
        /// </summary>
        public class ProjectPush
        {
            /// <summary>
            /// 工号
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 子项查询编号
            /// </summary>
            public List<string> projectId = new List<string>();
        }

        /// <summary>
        /// 单击子项目发送请求的数据类
        /// </summary>
        public class SonProjectPush
        {
            /// <summary>
            /// 工号，即用户名
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 子项目id
            /// </summary>
            public string projectId { get; set; }
        }

        /// <summary>
        /// 子项目每列数据类定义
        /// </summary>
        public class SonProjectMessage
        {
            /// <summary>
            /// 流程编号
            /// </summary>
            public string subEditCode { get; set; }            
            /// <summary>
            /// 流程阶段
            /// </summary>
            public string stage { get; set; }
            /// <summary>
            /// 专业
            /// </summary>
            public string specialty { get; set; }
            /// <summary>
            /// 我的角色
            /// </summary>
            public string role { get; set; }
            /// <summary>
            /// 处理状态
            /// </summary>
            public string status { get; set; }

        }

        /// <summary>
        /// 母项目每列数据类定义
        /// </summary>
        public class ProjectMessage
        {
            /// <summary>
            /// 序号
            /// </summary>
            public string number { get; set; }
            /// <summary>
            /// 子项名称
            /// </summary>
            public string name_son_project { get; set; }
            /// <summary>
            /// 子项编号
            /// </summary>
            public string id_son_project { get; set; }
            /// <summary>
            /// 专业
            /// </summary>
            public string major { get; set; }
            /// <summary>
            /// 阶段
            /// </summary>
            public string stage { get; set; }
            /// <summary>
            /// 我的角色
            /// </summary>
            public string my_role { get; set; }
        }

        /// <summary>
        /// 将每个项目（包括母和子）的名称添加到列表资源
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="vs"></param>
        public void AddAllProjectNameToList(TreeNodeCollection treeNode, List<string> vs)
        {
            foreach (TreeNode n in treeNode)
            {
                if ((string)n.Tag == Common.name_project || (string)n.Tag == Common.name_son_project)
                {
                    vs.Add((string)n.Text);
                    if ((string)n.Tag == Common.name_project)
                    {
                        AddAllProjectNameToList(n.Nodes, vs);
                    }
                }
            }
        }

        //搜索框文字提示
        public string serchBoxText = "请输入项目名称";

        public FormProjectControl()
        {
            InitializeComponent();
            //处理校审按钮绑定
            Common.button = button_deal;
            button_deal.Enabled = Common.unicodeFlag;

            //初始化文本
            SetDefaultText();
            
            //焦点事件
            //得到焦点
            serchBox.GotFocus += new EventHandler(serchBox_Enter);
            //失去焦点
            serchBox.LostFocus += new EventHandler(serchBox_Leave);

            //隐藏浏览器
            //webBrowser_subProject.Hide();
            //if (!webBrowser_subProject.IsDisposed)
            //{
            //    //webBrowser_subProject.Dispose();
            //}

            //禁用流程发起按钮
            button_startProject.Enabled = false ;

            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //鼠标左键响应
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                string tag = (string)e.Node.Tag;//获取点击节点tag
                string text = (string)e.Node.Text;//获取点击节点text
                string name = (string)e.Node.Name;//获取点击节点name
                StartTreeViewColor(treeView1.Nodes);//初始化treeview颜色
                Common.allSubProjectMessage = new DataTable();//初始化

                //if (!webBrowser_subProject.IsDisposed)
                //{
                //    //webBrowser_subProject.Dispose();
                //}

                //如果点击为母项目则查询其子项目清单
                if (tag == Common.name_project)
                {
                    //隐藏浏览器
                    //webBrowser_subProject.Hide();
                    //if (!webBrowser_subProject.IsDisposed)
                    //{
                    //    //webBrowser_subProject.Dispose();
                    //}
                    //隐藏发起流程按钮
                    button_startProject.Enabled = false;

                    ProjectPush projectPush = new ProjectPush();
                    JArray idBodyList = (JArray)Common.allProject[text];
                    int idLength = idBodyList.Count;
                    //List<ProjectMessage> allSubProjectMessage = new List<ProjectMessage>();

                    // 初始化
                    Common.allSubProjectMessage = new DataTable();
                    //设置列标题
                    Common.allSubProjectMessage.Columns.Add("序号", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("子项名称", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("子项编号", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("专业", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("阶段", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("我的角色", System.Type.GetType("System.String"));

                    //判断母项目下的子项不为空才发请求
                    if (idLength > 0)
                    {
                        // 获取子项查询id的list
                        for (int i = 0; i < idLength; i++)
                        {
                            projectPush.projectId.Add((string)idBodyList[i]);
                        }

                        projectPush.userName = Common.userCode;//获取用户账户

                        //发送请求
                        dynamic sonProjectData = Common.AskData(projectPush, "projectDetails");
                        

                        if (sonProjectData != null)
                        { 
                            JArray list_sonProjectData = (JArray)sonProjectData;
                            if (list_sonProjectData.Count != 0)
                            {
                                // 生成行对象
                                DataRow dr;
                                //解析子项信息数据
                                int no = 0;
                                foreach (var i in list_sonProjectData)
                                {
                                    dr = Common.allSubProjectMessage.NewRow();
                                    no++;
                                    //ProjectMessage projectMessage = new ProjectMessage();
                                    string no1 = no.ToString();
                                    dr["序号"] = no1;
                                    dr["子项名称"] = (string)i["name"];
                                    dr["子项编号"] = (string)i["subProjectCode"];
                                    dr["专业"] = (string)i["specialty"];
                                    dr["阶段"] = (string)i["stage"];
                                    dr["我的角色"] = (string)i["role"];
                                    Common.allSubProjectMessage.Rows.Add(dr);
                                }
                            }
                        }
                    }

                    //如母项目下无子项，则刷新数据
                    if (Common.allSubProjectMessage is null || Common.allSubProjectMessage == null || Common.allSubProjectMessage.Columns.Count == 0)
                    {
                        //ProjectMessage projectMessage = new ProjectMessage();
                        Common.allSubProjectMessage = null;
                    }

                    // 显示数据
                    FormProjectMessage form1 = new FormProjectMessage();
                    form1.FormBorderStyle = FormBorderStyle.None;
                    form1.Dock = DockStyle.Fill;
                    form1.TopLevel = false;
                    this.panel1.Controls.Clear();
                    this.panel1.Controls.Add(form1);
                    form1.Show();

                    ////设置列宽
                    //int columsWidth = 0;//记录宽度
                    //for (int i = 0; i < Common.allSubProjectMessage.Columns.Count; i++)
                    //{
                    //    //将每列设置成自动模式
                    //    Common.allSubProjectMessage.Columns[i]. AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    //    //宽度总和计算
                    //    columsWidth += dataGridView1.Columns[i].Width;
                    //}
                    ////判断调整后的宽度与原来设定的宽度的关系，
                    ////如果是调整后的宽度大于原来设定的宽度，则将DataGridView的列自动调整模式设置为显示的列即可，
                    ////如果是小于原来设定的宽度，将模式改为填充。
                    //if (columsWidth > dataGridView1.Size.Width)
                    //{
                    //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    //}
                    //else
                    //{
                    //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //}

                }

                //如点击为子项目则查询
                if (tag == Common.name_son_project)
                {
                    //显示浏览器
                    //webBrowser_subProject.Show();
                    //string URL_subProect = "http://wwww.baidu.com";
                    //string URL_subProect = "http://oatest.gmdi.cn/itg-pms-new/projindex.jsp?planid=e206ff84ba9c456583241bffa3ca8bc5&name=%u706B%u8F66%u7AD9&datapid=d2e66cae991e419c8c49dd69d72872e8&ischange=1&ucode=user-002147&isnewflow=1&token=user-00214716014288155644e5ac7d8-5484-40f1-9021-4064bc2f3a55&code=ZX-2020-122-P010";

                    //webBrowser_subProject.Navigate(URL_subProect);
                    //webBrowser_subProject.ScriptErrorsSuppressed = true;//屏蔽报错

                    //触发发起流程按钮
                    button_startProject.Enabled = true;
                    //赋值发起流程数据
                    Common.dataStartProjectId = name;

                }

                //发起流程按钮条件判断
                if (name == Common.name_son_project)
                {
                    //触发发起流程按钮
                    button_startProject.Enabled = true;
                    //赋值发起流程数据
                    Common.dataStartProjectId = tag;
                }

                //点击成品校审
                if(text == "成品校审")
                {
                    //隐藏浏览器
                    //webBrowser_subProject.Hide();
                    //if (!webBrowser_subProject.IsDisposed)
                    //{
                    //webBrowser_subProject.Dispose();
                    //}

                    // 初始化
                    Common.allSubProjectMessage = new DataTable();
                    //设置列标题
                    Common.allSubProjectMessage.Columns.Add("编号", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("流程阶段", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("专业", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("我的角色", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("处理状态", System.Type.GetType("System.String"));
                    Common.allSubProjectMessage.Columns.Add("unicode", System.Type.GetType("System.String"));

                    //赋值请求发送数据
                    SonProjectPush sonProjectPush = new SonProjectPush();
                    sonProjectPush.userName = Common.userCode;
                    sonProjectPush.projectId = tag;

                    //发送请求并得到数据
                    dynamic projectData = Common.AskData(sonProjectPush, "queryProof");

                    //新建与dataGridViewl关联的数据
                    //List<SonProjectMessage> allSonProjectMessages = new List<SonProjectMessage>();

                    //解析数据
                    JArray list_projectData = (JArray)projectData;
                    DataRow dr;//新建行数据
                    foreach (JObject i in list_projectData)
                    {
                        //SonProjectMessage sonProjectMessage = new SonProjectMessage();
                        dr = Common.allSubProjectMessage.NewRow();
                        dr["编号"] = (string)i["subEditCode"];
                        dr["流程阶段"] = (string)i["stage"];
                        dr["专业"] = (string)i["specialty"];
                        dr["我的角色"] = (string)i["role"];
                        dr["处理状态"] = (string)i["status"];
                        dr["unicode"] = (string)i["unicode"];
                        Common.allSubProjectMessage.Rows.Add(dr);
                    }
                    if (Common.allSubProjectMessage is null || Common.allSubProjectMessage == null || Common.allSubProjectMessage.Rows.Count == 0)
                    {
                        //SonProjectMessage sonProjectMessage = new SonProjectMessage();
                        Common.allSubProjectMessage = null;
                        Common.allSubProjectMessage.Clear();
                    }

                    // 显示数据
                    FormProjectMessage form1 = new FormProjectMessage();
                    form1.FormBorderStyle = FormBorderStyle.None;
                    form1.Dock = DockStyle.Fill;
                    form1.TopLevel = false;
                    this.panel1.Controls.Clear();
                    this.panel1.Controls.Add(form1);
                    form1.Show();


                    //设置列宽
                    //int columsWidth = 0;//记录宽度
                    //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    //{
                    //    //将每列设置成自动模式
                    //    dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    //    //宽度总和计算
                    //    columsWidth += dataGridView1.Columns[i].Width;
                    //}
                    ////判断调整后的宽度与原来设定的宽度的关系，
                    ////如果是调整后的宽度大于原来设定的宽度，则将DataGridView的列自动调整模式设置为显示的列即可，
                    ////如果是小于原来设定的宽度，将模式改为填充。
                    //if (columsWidth > dataGridView1.Size.Width)
                    //{
                    //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    //}
                    //else
                    //{
                    //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //}

                }

            }
            
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ClearTreeView
        /// </summary>
        /// <param name="node"></param>
        /// 
        public void ClearTreeView(TreeNodeCollection node)
        {
            foreach (TreeNode n in node)
            {
                node.Remove(n);
            }
        }



        /// <summary>
        /// 展示目录树、搜索框数据关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProjectControl_Load(object sender, EventArgs e)
        {
            if (Common.userStatus == 1)
            {
                //生成目录树                
                for (int item = 0; item < Common.projectTreeView.Nodes.Count; item++)
                {
                    treeView1.Nodes.Add(Common.projectTreeView.Nodes[item].Clone() as TreeNode);
                }

                //搜索框数据关联
                //文本框过滤
                List<string> Data = new List<string>();
                AddAllProjectNameToList(Common.projectTreeView.Nodes, Data);
                //数据绑定
                serchBox.AutoCompleteCustomSource.Clear();
                serchBox.AutoCompleteCustomSource.AddRange(Data.ToArray());


            }

            //隐藏浏览器
            //webBrowser_subProject.Hide();
            //if (!webBrowser_subProject.IsDisposed)
            //{
                //webBrowser_subProject.Dispose();
            //}
        }

        /// <summary>
        /// 初始化treeview节点颜色
        /// </summary>
        /// <param name="tree"></param>
        private void StartTreeViewColor(TreeNodeCollection tree)
        {
            

            foreach (TreeNode treeNode in tree)
            {
                if (treeNode.BackColor != Color.White) { treeNode.BackColor = Color.White; }
                if (treeNode.ForeColor != Color.Black) { treeNode.ForeColor = Color.Black; }
                StartTreeViewColor(treeNode.Nodes);
            }
        }

        /// <summary>
        /// 设置serchBox的文本改变事件，值改变时自动检索以及修改treeview的节点定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serchBox_TextChanged(object sender, EventArgs e)
        {
            string projectName = serchBox.Text;
            treeView1.CollapseAll();//首先折叠所有
            if (string.IsNullOrEmpty(projectName)) { return; }
            
            foreach (TreeNode tnc in treeView1.Nodes)//遍历treeview1
            {
                SearchNodes(tnc, projectName);
            }

        }

        /// <summary>
        /// 搜索并选中节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="projectName"></param>
        private void SearchNodes(TreeNode treeNode, string projectName)
        {
            
            if (treeNode != null)
            {
                if (treeNode.Text == projectName)
                {
                    
                    treeView1.SelectedNode = treeNode;
                    treeNode.Expand();
                    treeNode.BackColor = Color.DeepSkyBlue;
                    treeNode.ForeColor = Color.White;
                    return;
                }
                else 
                {

                    treeNode.BackColor = Color.White;
                    treeNode.ForeColor = Color.Black;
                    foreach (TreeNode tnc in treeNode.Nodes)
                    {
                        SearchNodes(tnc, projectName);
                    }
                }

                
            }
            else { return; }
        
        }

        /// <summary>
        /// 设置搜索框默认提示文本
        /// </summary>
        private void SetDefaultText()
        {
            //默认文本
            serchBox.Text = serchBoxText;
            //颜色为灰
            serchBox.ForeColor = Color.Gray;
            //设置字体为斜体
            serchBox.Font = new Font(serchBox.Font, serchBox.Font.Style^FontStyle.Italic);
        }

        /// <summary>
        /// 聚焦判断搜索框内是否有文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serchBox_Enter(object sender, EventArgs e)
        {
            if (serchBox.Text == serchBoxText)
            {
                serchBox.Text = "";
            }
            serchBox.ForeColor = Color.Black;
        }

        /// <summary>
        /// 离开文本框时通过判断，没有文字显示提示文字，有文字取消提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serchBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(serchBox.Text))
            {
                SetDefaultText();
            }            
        }

        private void projectBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_startProject_Click(object sender, EventArgs e)
        {
            if (Common.dataStartProjectId != "")
            {
                //打开发起流程新窗口
                FormStartProject formStartProject = new FormStartProject();
                formStartProject.ShowDialog();


            }
            else { MessageBox.Show("请在项目目录处选中子项目。"); }
        }

        private void button_deal_Click(object sender, EventArgs e)
        {
            // 初始化
            Common.flowMessage = new DataTable();
            //设置列标题
            Common.flowMessage.Columns.Add("序号", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("名称", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("页号/图号", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("意见", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("意见执行情况", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("意见回复", System.Type.GetType("System.String"));
            Common.flowMessage.Columns.Add("复审结论", System.Type.GetType("System.String"));

            //赋值请求发送数据
            AdvicePush advicePush= new AdvicePush();
            advicePush.uniCode = Common.unicode;

            //发送请求并得到数据
            dynamic adviceData = Common.AskData(advicePush, "getAdvice");

            //解析数据
            JArray list_adviceData = (JArray)adviceData;
            DataRow dr;//新建行数据
            int no = 0;
            foreach (JObject i in list_adviceData)
            {
                no++;
                string noi = no.ToString();
                dr = Common.flowMessage.NewRow();
                dr["序号"] = noi;
                //dr["名称"] = (string)i["id"];
                //dr["名称"] = "明挖机构主体结构图";
                dr["名称"] = "番南区间";
                dr["页号/图号"] = (string)i["object"];
                dr["意见"] = (string)i["advice"];
                //dr["意见执行情况"] = (string)i["role"];
                dr["意见回复"] = (string)i["reply"];
                //dr["复审结论"] = (string)i["unicode"];
                Common.flowMessage.Rows.Add(dr);
            }
            if (Common.flowMessage is null || Common.flowMessage == null || Common.flowMessage.Rows.Count == 0)
            {
                //SonProjectMessage sonProjectMessage = new SonProjectMessage();
                Common.flowMessage = null;
                //Common.flowMessage.Clear();
            }
            //打开意见处理新窗口
            FormDealOpinion formDealOpinion = new FormDealOpinion();
            formDealOpinion.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
