
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
            this.pb_maze = new System.Windows.Forms.PictureBox();
            this.pb_mazepath = new System.Windows.Forms.PictureBox();
            this.bt_openfile = new System.Windows.Forms.Button();
            this.tb_fname = new System.Windows.Forms.TextBox();
            this.bt_createmaze = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.tb_MazeQueue = new System.Windows.Forms.TextBox();
            this.tb_maze_matrix = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mazepath)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_maze
            // 
            this.pb_maze.Location = new System.Drawing.Point(9, 4);
            this.pb_maze.Margin = new System.Windows.Forms.Padding(2);
            this.pb_maze.Name = "pb_maze";
            this.pb_maze.Size = new System.Drawing.Size(243, 275);
            this.pb_maze.TabIndex = 0;
            this.pb_maze.TabStop = false;
            // 
            // pb_mazepath
            // 
            this.pb_mazepath.Location = new System.Drawing.Point(249, 4);
            this.pb_mazepath.Margin = new System.Windows.Forms.Padding(2);
            this.pb_mazepath.Name = "pb_mazepath";
            this.pb_mazepath.Size = new System.Drawing.Size(243, 275);
            this.pb_mazepath.TabIndex = 1;
            this.pb_mazepath.TabStop = false;
            // 
            // bt_openfile
            // 
            this.bt_openfile.Location = new System.Drawing.Point(262, 289);
            this.bt_openfile.Margin = new System.Windows.Forms.Padding(2);
            this.bt_openfile.Name = "bt_openfile";
            this.bt_openfile.Size = new System.Drawing.Size(216, 53);
            this.bt_openfile.TabIndex = 4;
            this.bt_openfile.Text = "选择迷宫矩阵文件";
            this.bt_openfile.UseVisualStyleBackColor = true;
            this.bt_openfile.Click += new System.EventHandler(this.bt_openfile_Click);
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(262, 356);
            this.tb_fname.Margin = new System.Windows.Forms.Padding(2);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(216, 21);
            this.tb_fname.TabIndex = 5;
            // 
            // bt_createmaze
            // 
            this.bt_createmaze.Location = new System.Drawing.Point(262, 398);
            this.bt_createmaze.Margin = new System.Windows.Forms.Padding(2);
            this.bt_createmaze.Name = "bt_createmaze";
            this.bt_createmaze.Size = new System.Drawing.Size(216, 43);
            this.bt_createmaze.TabIndex = 6;
            this.bt_createmaze.Text = "生成迷宫矩阵并求其最短路径";
            this.bt_createmaze.UseVisualStyleBackColor = true;
            this.bt_createmaze.Click += new System.EventHandler(this.bt_createmaze_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(540, 461);
            this.Exit.Margin = new System.Windows.Forms.Padding(2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(135, 53);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tb_MazeQueue
            // 
            this.tb_MazeQueue.Location = new System.Drawing.Point(496, 4);
            this.tb_MazeQueue.Margin = new System.Windows.Forms.Padding(2);
            this.tb_MazeQueue.Multiline = true;
            this.tb_MazeQueue.Name = "tb_MazeQueue";
            this.tb_MazeQueue.Size = new System.Drawing.Size(229, 449);
            this.tb_MazeQueue.TabIndex = 8;
            // 
            // tb_maze_matrix
            // 
            this.tb_maze_matrix.Location = new System.Drawing.Point(9, 283);
            this.tb_maze_matrix.Margin = new System.Windows.Forms.Padding(2);
            this.tb_maze_matrix.Multiline = true;
            this.tb_maze_matrix.Name = "tb_maze_matrix";
            this.tb_maze_matrix.Size = new System.Drawing.Size(244, 241);
            this.tb_maze_matrix.TabIndex = 9;
            this.tb_maze_matrix.TextChanged += new System.EventHandler(this.tb_maze_matrix_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 523);
            this.Controls.Add(this.tb_maze_matrix);
            this.Controls.Add(this.tb_MazeQueue);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.bt_createmaze);
            this.Controls.Add(this.tb_fname);
            this.Controls.Add(this.bt_openfile);
            this.Controls.Add(this.pb_mazepath);
            this.Controls.Add(this.pb_maze);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_maze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mazepath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_maze;
        private System.Windows.Forms.PictureBox pb_mazepath;
        private System.Windows.Forms.Button bt_openfile;
        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.Button bt_createmaze;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox tb_MazeQueue;
        private System.Windows.Forms.TextBox tb_maze_matrix;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

