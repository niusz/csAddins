namespace csAddins
{
    partial class MultiScaleCopyForm
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
            this.txtScale = new System.Windows.Forms.TextBox();
            this.txtXOffset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYOffset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale:";
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(192, 26);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(100, 25);
            this.txtScale.TabIndex = 1;
            this.txtScale.Tag = "0.95";
            this.txtScale.Text = "0.95";
            this.txtScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScale_KeyPress);
            // 
            // txtXOffset
            // 
            this.txtXOffset.Location = new System.Drawing.Point(192, 77);
            this.txtXOffset.Name = "txtXOffset";
            this.txtXOffset.Size = new System.Drawing.Size(100, 25);
            this.txtXOffset.TabIndex = 3;
            this.txtXOffset.Tag = "4";
            this.txtXOffset.Text = "4";
            this.txtXOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXOffset_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "X Offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y Offset:";
            // 
            // txtYOffset
            // 
            this.txtYOffset.Location = new System.Drawing.Point(192, 114);
            this.txtYOffset.Name = "txtYOffset";
            this.txtYOffset.Size = new System.Drawing.Size(100, 25);
            this.txtYOffset.TabIndex = 5;
            this.txtYOffset.Tag = "0";
            this.txtYOffset.Text = "0";
            this.txtYOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXOffset_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Z Offset:";
            // 
            // txtZOffset
            // 
            this.txtZOffset.Location = new System.Drawing.Point(192, 168);
            this.txtZOffset.Name = "txtZOffset";
            this.txtZOffset.Size = new System.Drawing.Size(100, 25);
            this.txtZOffset.TabIndex = 7;
            this.txtZOffset.Tag = "0";
            this.txtZOffset.Text = "0";
            this.txtZOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXOffset_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Copies:";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(192, 206);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(100, 25);
            this.txtCopies.TabIndex = 9;
            this.txtCopies.Tag = "10";
            this.txtCopies.Text = "10";
            this.txtCopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCopies_KeyPress);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(111, 249);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(158, 23);
            this.btnDefault.TabIndex = 10;
            this.btnDefault.Text = "Load Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // MultiScaleCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtZOffset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtXOffset);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiScaleCopyForm";
            this.Text = "MultiScaleCopyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MultiScaleCopyForm_FormClosed);
            this.Load += new System.EventHandler(this.MultiScaleCopyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtScale;
        public System.Windows.Forms.TextBox txtXOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtYOffset;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtZOffset;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.Button btnDefault;
    }
}