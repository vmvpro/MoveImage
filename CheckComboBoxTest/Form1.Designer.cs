namespace CheckComboBox {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtOut = new System.Windows.Forms.TextBox();
			this.CheckedComboBox1 = new CheckComboBox.CheckedComboBox();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(12, 162);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(382, 132);
            this.txtOut.TabIndex = 1;
            // 
            // ccb
            // 
			this.CheckedComboBox1.CheckOnClick = true;
			this.CheckedComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.CheckedComboBox1.DropDownHeight = 1;
			this.CheckedComboBox1.FormattingEnabled = true;
			this.CheckedComboBox1.IntegralHeight = false;
			this.CheckedComboBox1.Location = new System.Drawing.Point(12, 22);
			this.CheckedComboBox1.Name = "ccb";
			this.CheckedComboBox1.Size = new System.Drawing.Size(382, 21);
			this.CheckedComboBox1.TabIndex = 0;
			this.CheckedComboBox1.ValueSeparator = ", ";
			this.CheckedComboBox1.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 306);
            this.Controls.Add(this.txtOut);
			this.Controls.Add(this.CheckedComboBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CheckedComboBox Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private CheckedComboBox CheckedComboBox1;
        private System.Windows.Forms.TextBox txtOut;
    }
}

