
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
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // chbAllowDiagonal
            // 
            resources.ApplyResources(this.chbAllowDiagonal, "chbAllowDiagonal");
            this.chbAllowDiagonal.Name = "chbAllowDiagonal";
            this.chbAllowDiagonal.UseVisualStyleBackColor = true;
            // 
            // chbShowMazeAnim
            // 
            resources.ApplyResources(this.chbShowMazeAnim, "chbShowMazeAnim");
            this.chbShowMazeAnim.Name = "chbShowMazeAnim";
            this.chbShowMazeAnim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.lblTheLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRunTime);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblTheLength
            // 
            resources.ApplyResources(this.lblTheLength, "lblTheLength");
            this.lblTheLength.Name = "lblTheLength";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblRunTime
            // 
            resources.ApplyResources(this.lblRunTime, "lblRunTime");
            this.lblRunTime.Name = "lblRunTime";
            // 
            // chbShowAnimation
            // 
            resources.ApplyResources(this.chbShowAnimation, "chbShowAnimation");
            this.chbShowAnimation.Name = "chbShowAnimation";
            this.chbShowAnimation.UseVisualStyleBackColor = true;
            // 
            // btnGenerateMaze
            // 
            resources.ApplyResources(this.btnGenerateMaze, "btnGenerateMaze");
            this.btnGenerateMaze.Name = "btnGenerateMaze";
            this.btnGenerateMaze.UseVisualStyleBackColor = true;
            this.btnGenerateMaze.Click += new System.EventHandler(this.btnGenerateMaze_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRebuild
            // 
            resources.ApplyResources(this.btnRebuild, "btnRebuild");
            this.btnRebuild.Name = "btnRebuild";
            this.btnRebuild.UseVisualStyleBackColor = true;
            this.btnRebuild.Click += new System.EventHandler(this.btnRebuild_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // nudSize
            // 
            resources.ApplyResources(this.nudSize, "nudSize");
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
            this.nudSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "Form1";
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

