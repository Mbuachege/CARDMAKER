
namespace CARDMAKER
{
    partial class Individual_card
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
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtRegNo = new System.Windows.Forms.TextBox();
            this.TxtForm = new System.Windows.Forms.TextBox();
            this.TxtPhoneNo = new System.Windows.Forms.TextBox();
            this.TxtExpiryDate = new System.Windows.Forms.TextBox();
            this.TxtImagepath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbDesign = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(125, 84);
            this.TxtName.Multiline = true;
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(252, 26);
            this.TxtName.TabIndex = 1;
            this.TxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "RegNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Form";
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(424, 89);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(52, 13);
            this.lblPhoneNo.TabIndex = 5;
            this.lblPhoneNo.Text = "PhoneNo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Image Path";
            // 
            // TxtRegNo
            // 
            this.TxtRegNo.Location = new System.Drawing.Point(125, 134);
            this.TxtRegNo.Multiline = true;
            this.TxtRegNo.Name = "TxtRegNo";
            this.TxtRegNo.Size = new System.Drawing.Size(252, 26);
            this.TxtRegNo.TabIndex = 9;
            // 
            // TxtForm
            // 
            this.TxtForm.Location = new System.Drawing.Point(125, 174);
            this.TxtForm.Multiline = true;
            this.TxtForm.Name = "TxtForm";
            this.TxtForm.Size = new System.Drawing.Size(252, 26);
            this.TxtForm.TabIndex = 10;
            // 
            // TxtPhoneNo
            // 
            this.TxtPhoneNo.Location = new System.Drawing.Point(482, 81);
            this.TxtPhoneNo.Multiline = true;
            this.TxtPhoneNo.Name = "TxtPhoneNo";
            this.TxtPhoneNo.Size = new System.Drawing.Size(252, 26);
            this.TxtPhoneNo.TabIndex = 11;
            this.TxtPhoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPhoneNo_KeyPress);
            // 
            // TxtExpiryDate
            // 
            this.TxtExpiryDate.Location = new System.Drawing.Point(482, 121);
            this.TxtExpiryDate.Multiline = true;
            this.TxtExpiryDate.Name = "TxtExpiryDate";
            this.TxtExpiryDate.Size = new System.Drawing.Size(252, 26);
            this.TxtExpiryDate.TabIndex = 12;
            // 
            // TxtImagepath
            // 
            this.TxtImagepath.Location = new System.Drawing.Point(482, 164);
            this.TxtImagepath.Multiline = true;
            this.TxtImagepath.Name = "TxtImagepath";
            this.TxtImagepath.Size = new System.Drawing.Size(252, 26);
            this.TxtImagepath.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 36);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(741, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "- - -";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 37);
            this.label4.TabIndex = 18;
            this.label4.Text = "ADD NEW MEMBER";
            // 
            // CmbDesign
            // 
            this.CmbDesign.FormattingEnabled = true;
            this.CmbDesign.Location = new System.Drawing.Point(153, 228);
            this.CmbDesign.Name = "CmbDesign";
            this.CmbDesign.Size = new System.Drawing.Size(233, 21);
            this.CmbDesign.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(202, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Choose your Design";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(133, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 9);
            this.label8.TabIndex = 21;
            this.label8.Text = "23 CHARACTERS ONLY";
            // 
            // Individual_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(875, 341);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbDesign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtImagepath);
            this.Controls.Add(this.TxtExpiryDate);
            this.Controls.Add(this.TxtPhoneNo);
            this.Controls.Add(this.TxtForm);
            this.Controls.Add(this.TxtRegNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPhoneNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtName);
            this.Name = "Individual_card";
            this.Text = "Individual_card";
            this.Load += new System.EventHandler(this.Individual_card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtRegNo;
        private System.Windows.Forms.TextBox TxtForm;
        private System.Windows.Forms.TextBox TxtPhoneNo;
        private System.Windows.Forms.TextBox TxtExpiryDate;
        private System.Windows.Forms.TextBox TxtImagepath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbDesign;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}