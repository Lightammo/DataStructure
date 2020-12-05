
namespace Queue
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_openfile_Click = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bt_createmaze_Click = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 412);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(364, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(365, 412);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(2, 421);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(366, 364);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // bt_openfile_Click
            // 
            this.bt_openfile_Click.Location = new System.Drawing.Point(386, 433);
            this.bt_openfile_Click.Name = "bt_openfile_Click";
            this.bt_openfile_Click.Size = new System.Drawing.Size(324, 79);
            this.bt_openfile_Click.TabIndex = 4;
            this.bt_openfile_Click.Text = "选择迷宫矩阵文件";
            this.bt_openfile_Click.UseVisualStyleBackColor = true;
            this.bt_openfile_Click.Click += new System.EventHandler(this.bt_openfile_Click_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(386, 528);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(328, 28);
            this.textBox2.TabIndex = 5;
            // 
            // bt_createmaze_Click
            // 
            this.bt_createmaze_Click.Location = new System.Drawing.Point(386, 571);
            this.bt_createmaze_Click.Name = "bt_createmaze_Click";
            this.bt_createmaze_Click.Size = new System.Drawing.Size(324, 64);
            this.bt_createmaze_Click.TabIndex = 6;
            this.bt_createmaze_Click.Text = "生成迷宫矩阵并求其最短路径";
            this.bt_createmaze_Click.UseVisualStyleBackColor = true;
            this.bt_createmaze_Click.Click += new System.EventHandler(this.bt_createmaze_Click_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(810, 692);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 80);
            this.button3.TabIndex = 7;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(720, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 671);
            this.textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 784);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bt_createmaze_Click);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.bt_openfile_Click);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bt_openfile_Click;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button bt_createmaze_Click;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

