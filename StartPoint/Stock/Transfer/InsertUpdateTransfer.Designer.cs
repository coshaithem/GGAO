﻿namespace GGAO.Stock.Transfer
{
    partial class InsertUpdateTransfer
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxCalc = new System.Windows.Forms.CheckBox();
            this.checkBoxPrinting = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToPoleCombobox = new VMultiColumnComboBox.MultiColumComboBox( );
            this.ToPoleCombobox.setFilter(new int[] { 1, 2 });
            this.ToPoleCombobox.setFilter(new int[] { 1, 2 });
            this.label10 = new System.Windows.Forms.Label();
            this.DriverCombobox = new VMultiColumnComboBox.MultiColumComboBox( );
            this.DriverCombobox.setFilter(new int[] { 1, 2 });
            this.KilotextBox = new System.Windows.Forms.TextBox();
            this.PoleCombobox = new VMultiColumnComboBox.MultiColumComboBox( );
            this.PoleCombobox.setFilter(new int[] { 1, 2 });
            this.label2 = new System.Windows.Forms.Label();
            this.ProductCombobox = new VMultiColumnComboBox.MultiColumComboBox( );
            this.ProductCombobox.setFilter(new int[] { 1, 2 });
            this.label4 = new System.Windows.Forms.Label();
            this.EngineCombobox = new VMultiColumnComboBox.MultiColumComboBox( );
            this.EngineCombobox.setFilter(new int[] { 1, 2,5,7 });
            this.QuanitytextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.ReftextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCalc);
            this.groupBox2.Controls.Add(this.checkBoxPrinting);
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 60);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // checkBoxCalc
            // 
            this.checkBoxCalc.AutoSize = true;
            this.checkBoxCalc.Checked = true;
            this.checkBoxCalc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCalc.Enabled = false;
            this.checkBoxCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxCalc.Location = new System.Drawing.Point(126, 21);
            this.checkBoxCalc.Name = "checkBoxCalc";
            this.checkBoxCalc.Size = new System.Drawing.Size(85, 24);
            this.checkBoxCalc.TabIndex = 21;
            this.checkBoxCalc.Text = "Calculer";
            this.checkBoxCalc.UseVisualStyleBackColor = true;
            this.checkBoxCalc.Visible = false;
            // 
            // checkBoxPrinting
            // 
            this.checkBoxPrinting.AutoSize = true;
            this.checkBoxPrinting.Checked = true;
            this.checkBoxPrinting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrinting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrinting.Enabled = false;
            this.checkBoxPrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxPrinting.Location = new System.Drawing.Point(14, 21);
            this.checkBoxPrinting.Name = "checkBoxPrinting";
            this.checkBoxPrinting.Size = new System.Drawing.Size(90, 24);
            this.checkBoxPrinting.TabIndex = 20;
            this.checkBoxPrinting.Text = "Imprimer";
            this.checkBoxPrinting.UseVisualStyleBackColor = true;
            this.checkBoxPrinting.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(445, 15);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 35);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ToPoleCombobox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.DriverCombobox);
            this.groupBox1.Controls.Add(this.KilotextBox);
            this.groupBox1.Controls.Add(this.PoleCombobox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ProductCombobox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EngineCombobox);
            this.groupBox1.Controls.Add(this.QuanitytextBox);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.TypeComboBox);
            this.groupBox1.Controls.Add(this.ReftextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 269);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // ToPoleCombobox
            // 
            this.ToPoleCombobox.ColumnWidth = null;
            this.ToPoleCombobox.DataSource = null;
            this.ToPoleCombobox.DisplayColumnNo = 1;
            this.ToPoleCombobox.DropDownHeight = 200;
            this.ToPoleCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ToPoleCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.ToPoleCombobox.Location = new System.Drawing.Point(382, 60);
            this.ToPoleCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToPoleCombobox.Name = "ToPoleCombobox";
            this.ToPoleCombobox.SelectedItem = null;
            this.ToPoleCombobox.ShowHeader = true;
            this.ToPoleCombobox.Size = new System.Drawing.Size(175, 26);
            this.ToPoleCombobox.SourceDataHeader = null;
            this.ToPoleCombobox.SourceDataString = null;
            this.ToPoleCombobox.TabIndex = 6;
            this.ToPoleCombobox.ValueColumnNo = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(286, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Destination";
            // 
            // DriverCombobox
            // 
            this.DriverCombobox.ColumnWidth = null;
            this.DriverCombobox.DataSource = null;
            this.DriverCombobox.DisplayColumnNo = 1;
            this.DriverCombobox.DropDownHeight = 200;
            this.DriverCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DriverCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.DriverCombobox.Location = new System.Drawing.Point(381, 172);
            this.DriverCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DriverCombobox.Name = "DriverCombobox";
            this.DriverCombobox.SelectedItem = null;
            this.DriverCombobox.ShowHeader = true;
            this.DriverCombobox.Size = new System.Drawing.Size(175, 26);
            this.DriverCombobox.SourceDataHeader = null;
            this.DriverCombobox.SourceDataString = null;
            this.DriverCombobox.TabIndex = 9;
            this.DriverCombobox.ValueColumnNo = 0;
            // 
            // KilotextBox
            // 
            this.KilotextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KilotextBox.Location = new System.Drawing.Point(111, 138);
            this.KilotextBox.Name = "KilotextBox";
            this.KilotextBox.Size = new System.Drawing.Size(158, 26);
            this.KilotextBox.TabIndex = 3;
            // 
            // PoleCombobox
            // 
            this.PoleCombobox.ColumnWidth = null;
            this.PoleCombobox.DataSource = null;
            this.PoleCombobox.DisplayColumnNo = 1;
            this.PoleCombobox.DropDownHeight = 200;
            this.PoleCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PoleCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.PoleCombobox.Location = new System.Drawing.Point(381, 22);
            this.PoleCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PoleCombobox.Name = "PoleCombobox";
            this.PoleCombobox.SelectedItem = null;
            this.PoleCombobox.ShowHeader = true;
            this.PoleCombobox.Size = new System.Drawing.Size(175, 26);
            this.PoleCombobox.SourceDataHeader = null;
            this.PoleCombobox.SourceDataString = null;
            this.PoleCombobox.TabIndex = 5;
            this.PoleCombobox.ValueColumnNo = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kilométrage";
            // 
            // ProductCombobox
            // 
            this.ProductCombobox.ColumnWidth = null;
            this.ProductCombobox.DataSource = null;
            this.ProductCombobox.DisplayColumnNo = 1;
            this.ProductCombobox.DropDownHeight = 200;
            this.ProductCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ProductCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.ProductCombobox.Location = new System.Drawing.Point(382, 135);
            this.ProductCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProductCombobox.Name = "ProductCombobox";
            this.ProductCombobox.SelectedItem = null;
            this.ProductCombobox.ShowHeader = true;
            this.ProductCombobox.Size = new System.Drawing.Size(175, 26);
            this.ProductCombobox.SourceDataHeader = null;
            this.ProductCombobox.SourceDataString = null;
            this.ProductCombobox.TabIndex = 8;
            this.ProductCombobox.ValueColumnNo = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantité";
            // 
            // EngineCombobox
            // 
            this.EngineCombobox.ColumnWidth = null;
            this.EngineCombobox.DataSource = null;
            this.EngineCombobox.DisplayColumnNo = 1;
            this.EngineCombobox.DropDownHeight = 200;
            this.EngineCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EngineCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.EngineCombobox.Location = new System.Drawing.Point(382, 97);
            this.EngineCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EngineCombobox.Name = "EngineCombobox";
            this.EngineCombobox.SelectedItem = null;
            this.EngineCombobox.ShowHeader = true;
            this.EngineCombobox.Size = new System.Drawing.Size(175, 26);
            this.EngineCombobox.SourceDataHeader = null;
            this.EngineCombobox.SourceDataString = null;
            this.EngineCombobox.TabIndex = 7;
            this.EngineCombobox.ValueColumnNo = 0;
            // 
            // QuanitytextBox
            // 
            this.QuanitytextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuanitytextBox.Location = new System.Drawing.Point(111, 175);
            this.QuanitytextBox.Name = "QuanitytextBox";
            this.QuanitytextBox.Size = new System.Drawing.Size(158, 26);
            this.QuanitytextBox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(111, 60);
            this.dateTimePicker.MaxDate = new System.DateTime(2200, 2, 5, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(158, 26);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.Value = System.DateTime.Now;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DisplayMember = "j";
            this.TypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Bon Transfer",
            "Carte Naftal",
            "TAC",
            "Bon Pour",
            "Autres"});
            this.TypeComboBox.Location = new System.Drawing.Point(111, 99);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(158, 28);
            this.TypeComboBox.TabIndex = 2;
            this.TypeComboBox.Text = "Bon Transfer";
            // 
            // ReftextBox
            // 
            this.ReftextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReftextBox.Location = new System.Drawing.Point(111, 24);
            this.ReftextBox.Name = "ReftextBox";
            this.ReftextBox.Size = new System.Drawing.Size(158, 26);
            this.ReftextBox.TabIndex = 0;
            this.ReftextBox.Text = "REF" + System.DateTime.Now.Day.ToString();

            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(285, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Chauffeure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(285, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Source";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Produit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(286, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Engine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference";
            // 
            // InsertUpdateTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 269);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InsertUpdateTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.InsertUpdateTransfer_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void setTitle(bool insertOrupdate)
        {
            if (!insertOrupdate)
            {
                this.Text = "Mise a jour un Bon";
                this.SaveButton.Text = "Mettre a jour";
            }
            else
            {
                this.Text = "Nouveau Bon";
                this.SaveButton.Text = "Enregistrer";
            }
        }
        void setInitialValue(string _Ref, string _type, string _date, string _quanity, string _kilo,
            string _Driver, string _Pole, string _ToPole, string _Product, string _Engine )
        {
 
            ReftextBox.Text = _Ref;

            string[] a = _date.Split(' ');
            string[] splitedDate = a[0].Split('/');
            dateTimePicker.Value = new System.DateTime(int.Parse(splitedDate[2]), int.Parse(splitedDate[1]), int.Parse(splitedDate[0]), 0, 0, 0, 0); //dateValue


            TypeComboBox.Text = _type;
            QuanitytextBox.Text = _quanity;
            KilotextBox.Text = _kilo;
            //System.Windows.Forms.MessageBox.Show( _Driver + _Pole + _Product + _Engine.Split('-')[0].Trim());
            // #bugs12022021
        }

        bool fieldsAreEmpty(bool InsertOrUpdate)
        {
            /* System.Windows.Forms.MessageBox.Show(
                  ReftextBox.Text.Trim()+" * "+ TypeComboBox.ValueMember.Trim()+" * "+ QuanitytextBox.Text.Trim()+" * "+
                  KilotextBox.Text.Trim()+" * "+ DriverCombobox.SelectedItem.ToString() +" * "+ PoleCombobox.SelectedItem.ToString() +" * "+ ProductCombobox.SelectedItem.ToString() +" * "+
                  EngineCombobox.SelectedItem.ToString());
            */
            bool level1 = true, level2 = true;
            int a;
            float b;
            int.TryParse(ReftextBox.Text.Trim(), out a);
            if ((string.IsNullOrEmpty(ReftextBox.Text.Trim()) ||
                TypeComboBox.Text.Trim().Equals("") || 
                string.IsNullOrEmpty(QuanitytextBox.Text.Trim()) ||
                string.IsNullOrEmpty(KilotextBox.Text.Trim())))
            {
                level1 = false;
            }
            if (!int.TryParse(KilotextBox.Text.Trim(), out a) || !float.TryParse(QuanitytextBox.Text.Trim(), out b))
            {
                level2 = false;
            }
            /*
           System.Windows.Forms.MessageBox.Show(
                ReftextBox.Text+(ReftextBox.Text.Trim() =="").ToString() +
                " [" + TypeComboBox.Text + "] " + ( TypeComboBox.Text.Trim().Equals("")).ToString() +
                " " + QuanitytextBox.Text + " " + (QuanitytextBox.Text.Trim() == "").ToString() +
                KilotextBox.Text + " " + (KilotextBox.Text.Trim() == "").ToString()

                , "Alert");
            
            System.Windows.Forms.MessageBox.Show(level1.ToString() + level2.ToString(), "Alert");
           */
            if (InsertOrUpdate)
            { //means insert new record
                if (!level1 || !level2) { return true; }
                else
                {
                    if (DriverCombobox.SelectedItem == null || ToPoleCombobox.SelectedItem == null || PoleCombobox.SelectedItem == null || EngineCombobox.SelectedItem == null)
                        return true;
                    else
                        return false; // means all fields are filled
                }
            }
            else
            {
                return (!level1 || !level2);
            }

        }
        void ResetFields()
        {
            
            ReftextBox.Text = "REF"+ System.DateTime.Now.Day.ToString();
            TypeComboBox.Text = "Bon Transfer";
            //TypeComboBox.ValueMember 
            QuanitytextBox.Text = "";
            KilotextBox.Text = "";
            DriverCombobox.setTextBox("");
            PoleCombobox.setTextBox("");
            ToPoleCombobox.setTextBox("");
            ProductCombobox.setTextBox("");
            EngineCombobox.setTextBox("");
        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxCalc;
        private System.Windows.Forms.CheckBox checkBoxPrinting;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private VMultiColumnComboBox.MultiColumComboBox DriverCombobox;
        private System.Windows.Forms.TextBox KilotextBox;
        private VMultiColumnComboBox.MultiColumComboBox PoleCombobox;
        private System.Windows.Forms.Label label2;
        private VMultiColumnComboBox.MultiColumComboBox ProductCombobox;
        private System.Windows.Forms.Label label4;
        private VMultiColumnComboBox.MultiColumComboBox EngineCombobox;
        private System.Windows.Forms.TextBox QuanitytextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.TextBox ReftextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private VMultiColumnComboBox.MultiColumComboBox ToPoleCombobox;
        private System.Windows.Forms.Label label10;
    }
}