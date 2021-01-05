using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndProject
{
    public partial class FormChooseMajor : Form
    {
        /// <summary>
        /// 选择信息
        /// </summary>
        public class ChooseMessage
        {
            /// <summary>
            /// 项目id
            /// </summary>
            public string projectId;
            /// <summary>
            /// 图册id
            /// </summary>
            public string atlasId;
            /// <summary>
            /// 子项id
            /// </summary>
            public string planId;
            /// <summary>
            /// 专业id
            /// </summary>
            public string specialtyId;
            /// <summary>
            /// 用户id
            /// </summary>
            public string userId;
        }

        //判断条件
        public static string boolType;
        //显示图册名称
        public static string nameDrawing;
        //显示专业名称
        public static string nameMajor;
        //查询id
        public static string idCode;

        public FormChooseMajor()
        {
            InitializeComponent();
            //赋值展示前先初始化清零
            treeViewChooseMajor.Nodes.Clear();
            for (int i = 0; i < Common.subProjectChooseTree.Nodes.Count; i++)
            {
                treeViewChooseMajor.Nodes.Add(Common.subProjectChooseTree.Nodes[i].Clone() as TreeNode);
            }
        }

        private void FormChooseMajor_Load(object sender, EventArgs e)
        {

        }

        private void treeViewChooseMajor_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //鼠标左键响应
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                boolType = (string)e.Node.Tag;
                nameDrawing = (string)e.Node.Text;
                idCode = (string)e.Node.Name;
                if (e.Node.Parent != null)
                { 
                    nameMajor = (string)e.Node.Parent.Text;
                }
                
            }
        }

        private void button_comfirm_Click(object sender, EventArgs e)
        {
            if (boolType != "图册")
            {
                MessageBox.Show("请选择到图册节点！");
            }
            else
            {
                ChooseMessage chooseMessage = new ChooseMessage();
                JObject responce = new JObject();
                foreach (JObject i in Common.listSubProjectMajor)
                {
                    if ((string)i["idcode"] == idCode)
                    {
                        chooseMessage.projectId = (string)i["projectid"];
                        chooseMessage.atlasId = (string)i["id"];
                        chooseMessage.planId = (string)i["planid"];
                        chooseMessage.specialtyId = (string)i["specialtyPlanId"];
                        chooseMessage.userId = Common.userCode;

                        //发送请求——获得人员信息
                        dynamic peopleMessage = Common.AskData(chooseMessage, "startProcessDetails");
                        responce = (JObject)peopleMessage;
                        break;
                    }
                }
                //查询发起者是否为设计人
                int flag = 0;
                JArray designerId = (JArray)responce["designerId"];
                foreach (string i in designerId)
                {
                    string str = "user-" + Common.userCode;
                    if (str == i) { flag = 1;break; }
                }
                //若发起人不为设计人
                if (flag == 0)
                {
                    MessageBox.Show("您不是此专业的设计人，不能发起校审！");
                    Common.flagChoose = 0;
                }
                //若为设计者
                else 
                {
                    Common.majorChooseMessage = nameMajor;
                    Common.nameDrawingChooseMessage = nameDrawing;
                    Common.numDrawingChooseMessage = chooseMessage.atlasId;
                    Common.checker = (JArray)responce["checker"];
                    Common.checkerId = (JArray)responce["checkerId"];
                    Common.auditor = (JArray)responce["auditor"];
                    Common.auditorId = (JArray)responce["auditorId"];
                    Common.authorizer = (JArray)responce["authorizer"];
                    Common.authorizerId = (JArray)responce["authorizerId"];
                    Common.flagChoose = 1;

                    this.Close();
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Common.flagChoose = 0;
            this.Close();
        }

        private void treeViewChooseMajor_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
