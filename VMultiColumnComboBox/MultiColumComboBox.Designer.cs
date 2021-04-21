namespace VMultiColumnComboBox
{
    partial class MultiColumComboBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox = new System.Windows.Forms.TextBox();
            this.buttonDropDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox.Location = new System.Drawing.Point(0, 0);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(194, 20);
            this.txtbox.TabIndex = 0;
            this.txtbox.FontChanged += new System.EventHandler(this.txtbox_FontChanged);
            this.txtbox.TextChanged += new System.EventHandler(this.txtbox_TextChanged);
            this.txtbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbox_KeyUp);
            this.txtbox.Leave += new System.EventHandler(this.txtbox_Leave);
            // 
            // buttonDropDown
            // 
            this.buttonDropDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDropDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDropDown.Font = new System.Drawing.Font("Marlett", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonDropDown.Location = new System.Drawing.Point(195, 0);
            this.buttonDropDown.Name = "buttonDropDown";
            this.buttonDropDown.Size = new System.Drawing.Size(20, 22);
            this.buttonDropDown.TabIndex = 4;
            this.buttonDropDown.TabStop = false;
            this.buttonDropDown.Text = "u";
            this.buttonDropDown.UseVisualStyleBackColor = true;
            this.buttonDropDown.Click += new System.EventHandler(this.buttonDropDown_Click);
            // 
            // MultiColumComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDropDown);
            this.Controls.Add(this.txtbox);
            this.Name = "MultiColumComboBox";
            this.Size = new System.Drawing.Size(215, 22);
            this.Resize += new System.EventHandler(this.MultiColumComboBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void setTextBox( string value )
        {
            if ( this.txtbox != null)
            {
                this.txtbox.Text = value;
            }
        }
        public bool choiseUpdated()
        {
            return dgvSelected();
        }
        #endregion

        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Button buttonDropDown; 
    }
}
