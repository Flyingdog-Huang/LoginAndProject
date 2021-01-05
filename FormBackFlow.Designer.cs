namespace LoginAndProject
{
    partial class FormBackFlow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_backOpinion = new System.Windows.Forms.RichTextBox();
            this.richTextBox_commonOpinion = new System.Windows.Forms.RichTextBox();
            this.comboBox_backStage = new System.Windows.Forms.ComboBox();
            this.button_saveOpinion = new System.Windows.Forms.Button();
            this.button_deleteOpinion = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择退回到的阶段： ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(430, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "常用意见";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(52, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "退回意见内容";
            // 
            // richTextBox_backOpinion
            // 
            this.richTextBox_backOpinion.Location = new System.Drawing.Point(55, 115);
            this.richTextBox_backOpinion.Name = "richTextBox_backOpinion";
            this.richTextBox_backOpinion.Size = new System.Drawing.Size(330, 235);
            this.richTextBox_backOpinion.TabIndex = 3;
            this.richTextBox_backOpinion.Text = "";
            // 
            // richTextBox_commonOpinion
            // 
            this.richTextBox_commonOpinion.Location = new System.Drawing.Point(433, 115);
            this.richTextBox_commonOpinion.Name = "richTextBox_commonOpinion";
            this.richTextBox_commonOpinion.Size = new System.Drawing.Size(330, 235);
            this.richTextBox_commonOpinion.TabIndex = 4;
            this.richTextBox_commonOpinion.Text = "";
            // 
            // comboBox_backStage
            // 
            this.comboBox_backStage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_backStage.FormattingEnabled = true;
            this.comboBox_backStage.Location = new System.Drawing.Point(264, 31);
            this.comboBox_backStage.Name = "comboBox_backStage";
            this.comboBox_backStage.Size = new System.Drawing.Size(285, 26);
            this.comboBox_backStage.TabIndex = 5;
            // 
            // button_saveOpinion
            // 
            this.button_saveOpinion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_saveOpinion.Location = new System.Drawing.Point(225, 312);
            this.button_saveOpinion.Name = "button_saveOpinion";
            this.button_saveOpinion.Size = new System.Drawing.Size(160, 38);
            this.button_saveOpinion.TabIndex = 6;
            this.button_saveOpinion.Text = "存为常用意见";
            this.button_saveOpinion.UseVisualStyleBackColor = true;
            // 
            // button_deleteOpinion
            // 
            this.button_deleteOpinion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_deleteOpinion.Location = new System.Drawing.Point(603, 312);
            this.button_deleteOpinion.Name = "button_deleteOpinion";
            this.button_deleteOpinion.Size = new System.Drawing.Size(160, 38);
            this.button_deleteOpinion.TabIndex = 7;
            this.button_deleteOpinion.Text = "删除意见";
            this.button_deleteOpinion.UseVisualStyleBackColor = true;
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_back.Location = new System.Drawing.Point(225, 400);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(160, 38);
            this.button_back.TabIndex = 8;
            this.button_back.Text = "确认退回";
            this.button_back.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(433, 400);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(160, 38);
            this.button_cancel.TabIndex = 9;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // FormBackFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_deleteOpinion);
            this.Controls.Add(this.button_saveOpinion);
            this.Controls.Add(this.comboBox_backStage);
            this.Controls.Add(this.richTextBox_commonOpinion);
            this.Controls.Add(this.richTextBox_backOpinion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBackFlow";
            this.Text = "流程退回";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_backOpinion;
        private System.Windows.Forms.RichTextBox richTextBox_commonOpinion;
        private System.Windows.Forms.ComboBox comboBox_backStage;
        private System.Windows.Forms.Button button_saveOpinion;
        private System.Windows.Forms.Button button_deleteOpinion;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_cancel;
    }
}