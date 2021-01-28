using System.Windows.Forms;

namespace GGAO.Driver
{
    partial class InsertUpdateDriver
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
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label prenomLabel;
            System.Windows.Forms.Label cINLabel;
            System.Windows.Forms.Label dateNaissanceLabel;
            System.Windows.Forms.Label lieuNaissanceLabel;
            System.Windows.Forms.Label mobileLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mobileTextBox = new System.Windows.Forms.TextBox();
            this.lieuNaissanceTextBox = new System.Windows.Forms.TextBox();
            this.dateNaissanceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cINTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            nomLabel = new System.Windows.Forms.Label();
            prenomLabel = new System.Windows.Forms.Label();
            cINLabel = new System.Windows.Forms.Label();
            dateNaissanceLabel = new System.Windows.Forms.Label();
            lieuNaissanceLabel = new System.Windows.Forms.Label();
            mobileLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.BackColor = System.Drawing.Color.Transparent;
            nomLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomLabel.Location = new System.Drawing.Point(81, 32);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(52, 21);
            nomLabel.TabIndex = 0;
            nomLabel.Text = "Nom:";
            // 
            // prenomLabel
            // 
            prenomLabel.AutoSize = true;
            prenomLabel.BackColor = System.Drawing.Color.Transparent;
            prenomLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prenomLabel.Location = new System.Drawing.Point(77, 69);
            prenomLabel.Name = "prenomLabel";
            prenomLabel.Size = new System.Drawing.Size(74, 21);
            prenomLabel.TabIndex = 2;
            prenomLabel.Text = "Prenom:";
            // 
            // cINLabel
            // 
            cINLabel.AutoSize = true;
            cINLabel.BackColor = System.Drawing.Color.Transparent;
            cINLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cINLabel.Location = new System.Drawing.Point(90, 229);
            cINLabel.Name = "cINLabel";
            cINLabel.Size = new System.Drawing.Size(43, 21);
            cINLabel.TabIndex = 4;
            cINLabel.Text = "CIN:";
            // 
            // dateNaissanceLabel
            // 
            dateNaissanceLabel.AutoSize = true;
            dateNaissanceLabel.BackColor = System.Drawing.Color.Transparent;
            dateNaissanceLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dateNaissanceLabel.Location = new System.Drawing.Point(17, 152);
            dateNaissanceLabel.Name = "dateNaissanceLabel";
            dateNaissanceLabel.Size = new System.Drawing.Size(131, 21);
            dateNaissanceLabel.TabIndex = 6;
            dateNaissanceLabel.Text = "Date Naissance:";
            // 
            // lieuNaissanceLabel
            // 
            lieuNaissanceLabel.AutoSize = true;
            lieuNaissanceLabel.BackColor = System.Drawing.Color.Transparent;
            lieuNaissanceLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lieuNaissanceLabel.Location = new System.Drawing.Point(22, 189);
            lieuNaissanceLabel.Name = "lieuNaissanceLabel";
            lieuNaissanceLabel.Size = new System.Drawing.Size(126, 21);
            lieuNaissanceLabel.TabIndex = 8;
            lieuNaissanceLabel.Text = "Lieu Naissance:";
            // 
            // mobileLabel
            // 
            mobileLabel.AutoSize = true;
            mobileLabel.BackColor = System.Drawing.Color.Transparent;
            mobileLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mobileLabel.Location = new System.Drawing.Point(77, 108);
            mobileLabel.Name = "mobileLabel";
            mobileLabel.Size = new System.Drawing.Size(67, 21);
            mobileLabel.TabIndex = 10;
            mobileLabel.Text = "Mobile:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(mobileLabel);
            this.groupBox1.Controls.Add(this.cINTextBox);
            this.groupBox1.Controls.Add(this.mobileTextBox);
            this.groupBox1.Controls.Add(cINLabel);
            this.groupBox1.Controls.Add(lieuNaissanceLabel);
            this.groupBox1.Controls.Add(this.lieuNaissanceTextBox);
            this.groupBox1.Controls.Add(dateNaissanceLabel);
            this.groupBox1.Controls.Add(this.dateNaissanceDateTimePicker);
            this.groupBox1.Controls.Add(prenomLabel);
            this.groupBox1.Controls.Add(this.prenomTextBox);
            this.groupBox1.Controls.Add(nomLabel);
            this.groupBox1.Controls.Add(this.nomTextBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 269);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chauffeur Information";
            // 
            // mobileTextBox
            // 
            this.mobileTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileTextBox.Location = new System.Drawing.Point(152, 104);
            this.mobileTextBox.Name = "mobileTextBox";
            this.mobileTextBox.Size = new System.Drawing.Size(200, 28);
            this.mobileTextBox.TabIndex = 2;
            // 
            // lieuNaissanceTextBox
            // 
            this.lieuNaissanceTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lieuNaissanceTextBox.Location = new System.Drawing.Point(152, 186);
            this.lieuNaissanceTextBox.Name = "lieuNaissanceTextBox";
            this.lieuNaissanceTextBox.Size = new System.Drawing.Size(200, 28);
            this.lieuNaissanceTextBox.TabIndex = 4;
            // 
            // dateNaissanceDateTimePicker
            // 
            this.dateNaissanceDateTimePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNaissanceDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNaissanceDateTimePicker.Location = new System.Drawing.Point(152, 148);
            this.dateNaissanceDateTimePicker.Name = "dateNaissanceDateTimePicker";
            this.dateNaissanceDateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.dateNaissanceDateTimePicker.TabIndex = 3;
            this.dateNaissanceDateTimePicker.Value = new System.DateTime(2021, 1, 27, 0, 0, 0, 0);
            // 
            // cINTextBox
            // 
            this.cINTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cINTextBox.Location = new System.Drawing.Point(152, 225);
            this.cINTextBox.Name = "cINTextBox";
            this.cINTextBox.Size = new System.Drawing.Size(200, 28);
            this.cINTextBox.TabIndex = 5;
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenomTextBox.Location = new System.Drawing.Point(152, 66);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(200, 28);
            this.prenomTextBox.TabIndex = 1;
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.Location = new System.Drawing.Point(152, 29);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(200, 28);
            this.nomTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Location = new System.Drawing.Point(0, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(250, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 31);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // InsertUpdateDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 338);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InsertUpdateDriver";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void setTitle( bool insertOrupdate)
        {
            if (!insertOrupdate)
            {
                this.Text = "Mise a jour un Chauffeur";
                this.SaveButton.Text = "Mettre a jour";
            }
            else
            {
                this.Text = "Nouveau Chauffeur";
                this.SaveButton.Text = "Enregistrer";
            }
        }
        #endregion
        void setInitialValue(string _nom, string _prenom, string _cin, string _date, string _lieu, string _mobile)
        {
            nomTextBox.Text = _nom;
            prenomTextBox.Text = _prenom;
            cINTextBox.Text = _cin;
            string[] a = _date.Split(' ');
            string[]  splitedDate = a[0].Split('/');
            
            dateNaissanceDateTimePicker.Value = new System.DateTime( int.Parse( splitedDate[2] ) , int.Parse(splitedDate[1]), int.Parse(splitedDate[0]), 0, 0, 0, 0); //dateValue
            lieuNaissanceTextBox.Text = _lieu;
            mobileTextBox.Text = _mobile;
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.TextBox mobileTextBox;
        private System.Windows.Forms.TextBox lieuNaissanceTextBox;
        private System.Windows.Forms.DateTimePicker dateNaissanceDateTimePicker;
        private System.Windows.Forms.TextBox cINTextBox;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.Button SaveButton;
    }
}