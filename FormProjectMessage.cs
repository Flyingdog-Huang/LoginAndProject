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
    public partial class FormProjectMessage : Form
    {
        public FormProjectMessage()
        {
            InitializeComponent();
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = Common.allSubProjectMessage;
            if (dataGridView1.Columns[5].Name == "unicode")
            { this.dataGridView1.Columns[5].Visible = false; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            FormProjectControl formProjectControl = new FormProjectControl();
            Common.unicodeFlag = false;
            formProjectControl.button_deal.Enabled = Common.unicodeFlag;
            if (dataGridView1.Columns[5].Name == "unicode")
            {
                int index = e.RowIndex;
                Common.unicode = dataGridView1.Rows[index].Cells[5].Value.ToString();
                if (Common.unicode != null && Common.unicode != "")
                {
                    Common.unicodeFlag = true;
                    Common.button.Enabled = true;
                    formProjectControl.button_deal.Enabled = Common.unicodeFlag;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
