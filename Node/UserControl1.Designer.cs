namespace Node
{
    partial class UserControl1
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblG = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblG
            // 
            this.lblG.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblG.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblG.Location = new System.Drawing.Point(0, 0);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(100, 25);
            this.lblG.TabIndex = 0;
            this.lblG.Text = "G";
            this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblH
            // 
            this.lblH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblH.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblH.Location = new System.Drawing.Point(0, 75);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(100, 25);
            this.lblH.TabIndex = 1;
            this.lblH.Text = "H";
            this.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblF
            // 
            this.lblF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblF.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblF.Location = new System.Drawing.Point(0, 25);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(100, 50);
            this.lblF.TabIndex = 2;
            this.lblF.Text = "F";
            this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblG);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblF;
    }
}
