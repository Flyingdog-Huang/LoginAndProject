namespace LoginAndProject
{
    partial class FormProjectControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.serchBox = new System.Windows.Forms.TextBox();
            this.button_startProject = new System.Windows.Forms.Button();
            this.button_deal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "项目维度";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ItemHeight = 25;
            this.treeView1.Location = new System.Drawing.Point(32, 108);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(288, 767);
            this.treeView1.TabIndex = 38;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // serchBox
            // 
            this.serchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.serchBox.Location = new System.Drawing.Point(32, 58);
            this.serchBox.Name = "serchBox";
            this.serchBox.Size = new System.Drawing.Size(288, 28);
            this.serchBox.TabIndex = 39;
            this.serchBox.TextChanged += new System.EventHandler(this.serchBox_TextChanged);
            // 
            // button_startProject
            // 
            this.button_startProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_startProject.Location = new System.Drawing.Point(356, 837);
            this.button_startProject.Name = "button_startProject";
            this.button_startProject.Size = new System.Drawing.Size(172, 38);
            this.button_startProject.TabIndex = 41;
            this.button_startProject.Text = "发起送校审流程";
            this.button_startProject.UseVisualStyleBackColor = true;
            this.button_startProject.Click += new System.EventHandler(this.button_startProject_Click);
            // 
            // button_deal
            // 
            this.button_deal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_deal.Location = new System.Drawing.Point(1402, 840);
            this.button_deal.Name = "button_deal";
            this.button_deal.Size = new System.Drawing.Size(172, 38);
            this.button_deal.TabIndex = 42;
            this.button_deal.Text = "处理校审";
            this.button_deal.UseVisualStyleBackColor = true;
            this.button_deal.Click += new System.EventHandler(this.button_deal_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(356, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 773);
            this.panel1.TabIndex = 43;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FormProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_deal);
            this.Controls.Add(this.button_startProject);
            this.Controls.Add(this.serchBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProjectControl";
            this.Text = "项目管理";
            this.Load += new System.EventHandler(this.FormProjectControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox serchBox;
        private System.Windows.Forms.Button button_startProject;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button_deal;
    }
}