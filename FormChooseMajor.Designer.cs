namespace LoginAndProject
{
    partial class FormChooseMajor
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
            this.treeViewChooseMajor = new System.Windows.Forms.TreeView();
            this.button_comfirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewChooseMajor
            // 
            this.treeViewChooseMajor.Location = new System.Drawing.Point(12, 12);
            this.treeViewChooseMajor.Name = "treeViewChooseMajor";
            this.treeViewChooseMajor.Size = new System.Drawing.Size(405, 473);
            this.treeViewChooseMajor.TabIndex = 0;
            this.treeViewChooseMajor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewChooseMajor_AfterSelect);
            this.treeViewChooseMajor.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewChooseMajor_NodeMouseClick);
            // 
            // button_comfirm
            // 
            this.button_comfirm.Location = new System.Drawing.Point(87, 507);
            this.button_comfirm.Name = "button_comfirm";
            this.button_comfirm.Size = new System.Drawing.Size(93, 31);
            this.button_comfirm.TabIndex = 1;
            this.button_comfirm.Text = "确定";
            this.button_comfirm.UseVisualStyleBackColor = true;
            this.button_comfirm.Click += new System.EventHandler(this.button_comfirm_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(230, 507);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(93, 31);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // FormChooseMajor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 561);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_comfirm);
            this.Controls.Add(this.treeViewChooseMajor);
            this.Name = "FormChooseMajor";
            this.Text = "选择专业对应图纸";
            this.Load += new System.EventHandler(this.FormChooseMajor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewChooseMajor;
        private System.Windows.Forms.Button button_comfirm;
        private System.Windows.Forms.Button button_cancel;
    }
}