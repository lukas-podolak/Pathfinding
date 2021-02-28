
namespace Pathfinding
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chbAllowDiagonal = new System.Windows.Forms.CheckBox();
            this.chbShowMazeAnim = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTheLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.chbShowAnimation = new System.Windows.Forms.CheckBox();
            this.btnGenerateMaze = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRebuild = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.White;
            this.groupBox.Controls.Add(this.chbAllowDiagonal);
            this.groupBox.Controls.Add(this.chbShowMazeAnim);
            this.groupBox.Controls.Add(this.groupBox1);
            this.groupBox.Controls.Add(this.chbShowAnimation);
            this.groupBox.Controls.Add(this.btnGenerateMaze);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnRebuild);
            this.groupBox.Controls.Add(this.btnReset);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.nudSize);
            this.groupBox.Controls.Add(this.btnStart);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox.Location = new System.Drawing.Point(854, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(180, 861);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Settings";
            // 
            // chbAllowDiagonal
            // 
            this.chbAllowDiagonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAllowDiagonal.AutoSize = true;
            this.chbAllowDiagonal.Location = new System.Drawing.Point(21, 48);
            this.chbAllowDiagonal.Name = "chbAllowDiagonal";
            this.chbAllowDiagonal.Size = new System.Drawing.Size(123, 17);
            this.chbAllowDiagonal.TabIndex = 10;
            this.chbAllowDiagonal.Text = "Allow diagonal move";
            this.chbAllowDiagonal.UseVisualStyleBackColor = true;
            // 
            // chbShowMazeAnim
            // 
            this.chbShowMazeAnim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowMazeAnim.AutoSize = true;
            this.chbShowMazeAnim.Location = new System.Drawing.Point(21, 229);
            this.chbShowMazeAnim.Name = "chbShowMazeAnim";
            this.chbShowMazeAnim.Size = new System.Drawing.Size(101, 17);
            this.chbShowMazeAnim.TabIndex = 9;
            this.chbShowMazeAnim.Text = "Show animation";
            this.chbShowMazeAnim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblTheLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRunTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lblTheLength
            // 
            this.lblTheLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTheLength.Location = new System.Drawing.Point(6, 70);
            this.lblTheLength.Name = "lblTheLength";
            this.lblTheLength.Size = new System.Drawing.Size(144, 28);
            this.lblTheLength.TabIndex = 13;
            this.lblTheLength.Text = "0";
            this.lblTheLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "The length:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Run time:";
            // 
            // lblRunTime
            // 
            this.lblRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRunTime.Location = new System.Drawing.Point(6, 29);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(144, 28);
            this.lblRunTime.TabIndex = 0;
            this.lblRunTime.Text = "00:00:00.0000000";
            this.lblRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbShowAnimation
            // 
            this.chbShowAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowAnimation.AutoSize = true;
            this.chbShowAnimation.Location = new System.Drawing.Point(21, 71);
            this.chbShowAnimation.Name = "chbShowAnimation";
            this.chbShowAnimation.Size = new System.Drawing.Size(101, 17);
            this.chbShowAnimation.TabIndex = 7;
            this.chbShowAnimation.Text = "Show animation";
            this.chbShowAnimation.UseVisualStyleBackColor = true;
            // 
            // btnGenerateMaze
            // 
            this.btnGenerateMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateMaze.Location = new System.Drawing.Point(12, 200);
            this.btnGenerateMaze.Name = "btnGenerateMaze";
            this.btnGenerateMaze.Size = new System.Drawing.Size(156, 23);
            this.btnGenerateMaze.TabIndex = 6;
            this.btnGenerateMaze.Text = "Generate Maze";
            this.btnGenerateMaze.UseVisualStyleBackColor = true;
            this.btnGenerateMaze.Click += new System.EventHandler(this.btnGenerateMaze_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(12, 797);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRebuild
            // 
            this.btnRebuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebuild.Location = new System.Drawing.Point(12, 252);
            this.btnRebuild.Name = "btnRebuild";
            this.btnRebuild.Size = new System.Drawing.Size(156, 23);
            this.btnRebuild.TabIndex = 4;
            this.btnRebuild.Text = "Rebuild";
            this.btnRebuild.UseVisualStyleBackColor = true;
            this.btnRebuild.Click += new System.EventHandler(this.btnRebuild_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(12, 826);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(156, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size";
            // 
            // nudSize
            // 
            this.nudSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSize.Location = new System.Drawing.Point(42, 281);
            this.nudSize.Maximum = new decimal(new int[] {
            57,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(126, 20);
            this.nudSize.TabIndex = 1;
            this.nudSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(12, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 861);
            this.Controls.Add(this.groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1050, 900);
            this.Name = "Form1";
            this.Text = "Pathfinding";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnRebuild;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerateMaze;
        private System.Windows.Forms.CheckBox chbShowAnimation;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.CheckBox chbShowMazeAnim;
        public System.Windows.Forms.CheckBox chbAllowDiagonal;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTheLength;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnStart;
    }
}

