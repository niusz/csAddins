namespace csAddins
{
    partial class NoteCoordForm
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
            this.grpTxtDir = new System.Windows.Forms.GroupBox();
            this.rdoHoriz = new System.Windows.Forms.RadioButton();
            this.rdoVert = new System.Windows.Forms.RadioButton();
            this.grpLabel = new System.Windows.Forms.GroupBox();
            this.rdoEN = new System.Windows.Forms.RadioButton();
            this.rdoXY = new System.Windows.Forms.RadioButton();
            this.grpTxtDir.SuspendLayout();
            this.grpLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTxtDir
            // 
            this.grpTxtDir.Controls.Add(this.rdoVert);
            this.grpTxtDir.Controls.Add(this.rdoHoriz);
            this.grpTxtDir.Location = new System.Drawing.Point(178, 76);
            this.grpTxtDir.Name = "grpTxtDir";
            this.grpTxtDir.Size = new System.Drawing.Size(406, 100);
            this.grpTxtDir.TabIndex = 0;
            this.grpTxtDir.TabStop = false;
            this.grpTxtDir.Text = "Text Direction";
            // 
            // rdoHoriz
            // 
            this.rdoHoriz.AutoSize = true;
            this.rdoHoriz.Checked = true;
            this.rdoHoriz.Location = new System.Drawing.Point(21, 25);
            this.rdoHoriz.Name = "rdoHoriz";
            this.rdoHoriz.Size = new System.Drawing.Size(108, 19);
            this.rdoHoriz.TabIndex = 0;
            this.rdoHoriz.TabStop = true;
            this.rdoHoriz.Text = "Horizontal";
            this.rdoHoriz.UseVisualStyleBackColor = true;
            // 
            // rdoVert
            // 
            this.rdoVert.AutoSize = true;
            this.rdoVert.Location = new System.Drawing.Point(221, 25);
            this.rdoVert.Name = "rdoVert";
            this.rdoVert.Size = new System.Drawing.Size(92, 19);
            this.rdoVert.TabIndex = 1;
            this.rdoVert.TabStop = true;
            this.rdoVert.Text = "Vertical";
            this.rdoVert.UseVisualStyleBackColor = true;
            // 
            // grpLabel
            // 
            this.grpLabel.Controls.Add(this.rdoXY);
            this.grpLabel.Controls.Add(this.rdoEN);
            this.grpLabel.Location = new System.Drawing.Point(178, 231);
            this.grpLabel.Name = "grpLabel";
            this.grpLabel.Size = new System.Drawing.Size(406, 100);
            this.grpLabel.TabIndex = 1;
            this.grpLabel.TabStop = false;
            this.grpLabel.Text = "Label";
            // 
            // rdoEN
            // 
            this.rdoEN.AutoSize = true;
            this.rdoEN.Checked = true;
            this.rdoEN.Location = new System.Drawing.Point(21, 43);
            this.rdoEN.Name = "rdoEN";
            this.rdoEN.Size = new System.Drawing.Size(52, 19);
            this.rdoEN.TabIndex = 1;
            this.rdoEN.TabStop = true;
            this.rdoEN.Text = "EN=";
            this.rdoEN.UseVisualStyleBackColor = true;
            // 
            // rdoXY
            // 
            this.rdoXY.AutoSize = true;
            this.rdoXY.Location = new System.Drawing.Point(221, 43);
            this.rdoXY.Name = "rdoXY";
            this.rdoXY.Size = new System.Drawing.Size(52, 19);
            this.rdoXY.TabIndex = 1;
            this.rdoXY.TabStop = true;
            this.rdoXY.Text = "XY=";
            this.rdoXY.UseVisualStyleBackColor = true;
            // 
            // NoteCoordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 404);
            this.Controls.Add(this.grpLabel);
            this.Controls.Add(this.grpTxtDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteCoordForm";
            this.ShowIcon = false;
            this.Text = "NoteCoordForm";
            this.grpTxtDir.ResumeLayout(false);
            this.grpTxtDir.PerformLayout();
            this.grpLabel.ResumeLayout(false);
            this.grpLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTxtDir;
        public System.Windows.Forms.RadioButton rdoVert;
        public System.Windows.Forms.RadioButton rdoHoriz;
        private System.Windows.Forms.GroupBox grpLabel;
        public System.Windows.Forms.RadioButton rdoXY;
        public System.Windows.Forms.RadioButton rdoEN;
    }
}