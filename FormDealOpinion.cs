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
    public partial class FormDealOpinion : Form
    {
        /// <summary>
        /// 获取流程意见发送请求的数据类
        /// </summary>
        public class FlowPush
        {
            /// <summary>
            /// 流程id
            /// </summary>
            public string uniCode { get; set; }
        }
        public FormDealOpinion()
        {
            InitializeComponent();

            List<string> listData = new List<string> { "优", "良", "中", "差" };
            comboBox2.DataSource = listData;

            dataGridView1.DataSource = new DataTable();

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = "序号";
            column.DataPropertyName = "序号";//对应数据源的字段
            column.HeaderText = "序号";
            this.dataGridView1.Columns.Add(column);

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.Name = "名称";
            column1.DataPropertyName = "名称";//对应数据源的字段
            column1.HeaderText = "名称";
            column1.Width = 250;
            this.dataGridView1.Columns.Add(column1);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.Name = "页号/图号";
            column3.DataPropertyName = "页号/图号";//对应数据源的字段
            column3.HeaderText = "页号/图号";
            column3.Width = 150;
            this.dataGridView1.Columns.Add(column3);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.Name = "意见";
            column2.DataPropertyName = "意见";//对应数据源的字段
            column2.HeaderText = "意见";
            column2.Width = 450;
            this.dataGridView1.Columns.Add(column2);

            DataGridViewComboBoxColumn column4 = new DataGridViewComboBoxColumn();
            column4.Name = "意见执行情况";
            column4.DataPropertyName = "意见执行情况";//对应数据源的字段
            column4.HeaderText = "意见执行情况";
            column4.Width = 150;
            this.dataGridView1.Columns.Add(column4);
            List<string> ListData = new List<string> { "采纳", "部分采纳", "不采纳" };
            column4.DataSource = ListData; //这里需要设置一下combox的itemsource,以便combox根据数据库中对应的值自动显示信息

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.Name = "意见回复";
            column5.DataPropertyName = "意见回复";//对应数据源的字段
            column5.HeaderText = "意见回复";
            column5.Width = 350;
            this.dataGridView1.Columns.Add(column5);

            DataGridViewComboBoxColumn column6 = new DataGridViewComboBoxColumn();
            column6.Name = "复审结论";
            column6.DataPropertyName = "复审结论";//对应数据源的字段
            column6.HeaderText = "复审结论";
            column6.Width = 150;
            this.dataGridView1.Columns.Add(column6);
            List<string> ListData1 = new List<string> { "同意", "不同意" };
            column6.DataSource = ListData1; //这里需要设置一下combox的itemsource,以便combox根据数据库中对应的值自动显示信息

            dataGridView1.DataSource = Common.flowMessage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
