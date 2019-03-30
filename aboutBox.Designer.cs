namespace Arsenal_A_Hearts_of_Iron_II_Mod_Manager
{
    partial class aboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutBox));
            this.pictureBox_arsenalLogo = new System.Windows.Forms.PictureBox();
            this.label_arsenal = new System.Windows.Forms.Label();
            this.label_copyright = new System.Windows.Forms.Label();
            this.label_license1 = new System.Windows.Forms.Label();
            this.label_license2 = new System.Windows.Forms.Label();
            this.label_license3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_arsenalLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_arsenalLogo
            // 
            this.pictureBox_arsenalLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_arsenalLogo.Image")));
            this.pictureBox_arsenalLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_arsenalLogo.Name = "pictureBox_arsenalLogo";
            this.pictureBox_arsenalLogo.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_arsenalLogo.TabIndex = 0;
            this.pictureBox_arsenalLogo.TabStop = false;
            // 
            // label_arsenal
            // 
            this.label_arsenal.AutoSize = true;
            this.label_arsenal.BackColor = System.Drawing.Color.Transparent;
            this.label_arsenal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_arsenal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_arsenal.Location = new System.Drawing.Point(50, 12);
            this.label_arsenal.Name = "label_arsenal";
            this.label_arsenal.Size = new System.Drawing.Size(170, 15);
            this.label_arsenal.TabIndex = 0;
            this.label_arsenal.Text = "Arsenal: A HoI2 Mod Manager";
            // 
            // label_copyright
            // 
            this.label_copyright.AutoSize = true;
            this.label_copyright.BackColor = System.Drawing.Color.Transparent;
            this.label_copyright.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_copyright.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_copyright.Location = new System.Drawing.Point(50, 29);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Size = new System.Drawing.Size(148, 15);
            this.label_copyright.TabIndex = 1;
            this.label_copyright.Text = "©2019 Lady Lambdadelta";
            // 
            // label_license1
            // 
            this.label_license1.AutoSize = true;
            this.label_license1.BackColor = System.Drawing.Color.Transparent;
            this.label_license1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_license1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_license1.Location = new System.Drawing.Point(12, 51);
            this.label_license1.Name = "label_license1";
            this.label_license1.Size = new System.Drawing.Size(185, 13);
            this.label_license1.TabIndex = 2;
            this.label_license1.Text = "This software is released to the public";
            // 
            // label_license2
            // 
            this.label_license2.AutoSize = true;
            this.label_license2.BackColor = System.Drawing.Color.Transparent;
            this.label_license2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_license2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_license2.Location = new System.Drawing.Point(12, 64);
            this.label_license2.Name = "label_license2";
            this.label_license2.Size = new System.Drawing.Size(200, 13);
            this.label_license2.TabIndex = 3;
            this.label_license2.Text = "under the terms of the \"Do What the Fuck";
            // 
            // label_license3
            // 
            this.label_license3.AutoSize = true;
            this.label_license3.BackColor = System.Drawing.Color.Transparent;
            this.label_license3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_license3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_license3.Location = new System.Drawing.Point(12, 77);
            this.label_license3.Name = "label_license3";
            this.label_license3.Size = new System.Drawing.Size(178, 13);
            this.label_license3.TabIndex = 4;
            this.label_license3.Text = "You Want To\" Public License (WTFPL).";
            // 
            // aboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(234, 96);
            this.Controls.Add(this.label_license3);
            this.Controls.Add(this.label_license2);
            this.Controls.Add(this.label_license1);
            this.Controls.Add(this.label_copyright);
            this.Controls.Add(this.label_arsenal);
            this.Controls.Add(this.pictureBox_arsenalLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 135);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 135);
            this.Name = "aboutBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Arsenal v0.1a";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_arsenalLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_arsenalLogo;
        private System.Windows.Forms.Label label_arsenal;
        private System.Windows.Forms.Label label_copyright;
        private System.Windows.Forms.Label label_license1;
        private System.Windows.Forms.Label label_license2;
        private System.Windows.Forms.Label label_license3;
    }
}