
using System;

namespace GGAO.Stock.Consommation
{
    partial class DateIntervalleSelector
    {
        static System.Windows.Forms.DateTimePicker FromdateTime;
        static System.Windows.Forms.DateTimePicker TodateTime;
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnValide = new System.Windows.Forms.Button();
            FromdateTime = new System.Windows.Forms.DateTimePicker();
            TodateTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "A Partir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jusqu\'a";
            // 
            // BtnValide
            // 
            this.BtnValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValide.Location = new System.Drawing.Point(173, 98);
            this.BtnValide.Name = "BtnValide";
            this.BtnValide.Size = new System.Drawing.Size(75, 30);
            this.BtnValide.TabIndex = 4;
            this.BtnValide.Text = "Validé";
            this.BtnValide.UseVisualStyleBackColor = true;
            this.BtnValide.Click += new System.EventHandler(this.button1_Click);
            // 
            // FromdateTime
            // 
            FromdateTime.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FromdateTime.Location = new System.Drawing.Point(97, 12);
            FromdateTime.Name = "FromdateTime";
            FromdateTime.Size = new System.Drawing.Size(151, 27);
            FromdateTime.TabIndex = 0;
            FromdateTime.Value = new System.DateTime(2021, 10, 2, 0, 0, 0, 0);
            // 
            // TodateTime
            // 
            TodateTime.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TodateTime.Location = new System.Drawing.Point(97, 62);
            TodateTime.Name = "TodateTime";
            TodateTime.Size = new System.Drawing.Size(151, 27);
            TodateTime.TabIndex = 1;
            TodateTime.Value = new System.DateTime(2021, 10, 2, 0, 0, 0, 0);
            // 
            // DateIntervalleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 135);
            this.Controls.Add(this.BtnValide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(TodateTime);
            this.Controls.Add(FromdateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DateIntervalleSelector";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selectionner Une Intervalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
 
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnValide;
    }
}