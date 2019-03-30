namespace Arsenal_A_Hearts_of_Iron_II_Mod_Manager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox_disabledMods = new System.Windows.Forms.ListBox();
            this.label_disabledMods = new System.Windows.Forms.Label();
            this.listBox_enabledMods = new System.Windows.Forms.ListBox();
            this.label_enabledMods = new System.Windows.Forms.Label();
            this.button_activateMod = new System.Windows.Forms.Button();
            this.button_deactivateMod = new System.Windows.Forms.Button();
            this.button_deployMods = new System.Windows.Forms.Button();
            this.button_pathSetup = new System.Windows.Forms.Button();
            this.button_priorityUp = new System.Windows.Forms.Button();
            this.button_priorityDown = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_about = new System.Windows.Forms.Button();
            this.button_refreshMods = new System.Windows.Forms.Button();
            this.button_createVanillaGameBackup = new System.Windows.Forms.Button();
            this.progressBar_deployMods = new System.Windows.Forms.ProgressBar();
            this.progressBar_createVanillaGameBackup = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // listBox_disabledMods
            // 
            this.listBox_disabledMods.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_disabledMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_disabledMods.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_disabledMods.FormattingEnabled = true;
            this.listBox_disabledMods.ItemHeight = 14;
            this.listBox_disabledMods.Location = new System.Drawing.Point(12, 31);
            this.listBox_disabledMods.Name = "listBox_disabledMods";
            this.listBox_disabledMods.Size = new System.Drawing.Size(200, 408);
            this.listBox_disabledMods.TabIndex = 1;
            // 
            // label_disabledMods
            // 
            this.label_disabledMods.AutoSize = true;
            this.label_disabledMods.BackColor = System.Drawing.Color.Transparent;
            this.label_disabledMods.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_disabledMods.Location = new System.Drawing.Point(62, 10);
            this.label_disabledMods.Name = "label_disabledMods";
            this.label_disabledMods.Size = new System.Drawing.Size(100, 18);
            this.label_disabledMods.TabIndex = 0;
            this.label_disabledMods.Text = "Disabled Mods";
            this.label_disabledMods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_enabledMods
            // 
            this.listBox_enabledMods.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_enabledMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_enabledMods.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_enabledMods.FormattingEnabled = true;
            this.listBox_enabledMods.ItemHeight = 14;
            this.listBox_enabledMods.Location = new System.Drawing.Point(274, 31);
            this.listBox_enabledMods.Name = "listBox_enabledMods";
            this.listBox_enabledMods.Size = new System.Drawing.Size(200, 408);
            this.listBox_enabledMods.TabIndex = 13;
            // 
            // label_enabledMods
            // 
            this.label_enabledMods.AutoSize = true;
            this.label_enabledMods.BackColor = System.Drawing.Color.Transparent;
            this.label_enabledMods.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_enabledMods.Location = new System.Drawing.Point(326, 10);
            this.label_enabledMods.Name = "label_enabledMods";
            this.label_enabledMods.Size = new System.Drawing.Size(96, 18);
            this.label_enabledMods.TabIndex = 12;
            this.label_enabledMods.Text = "Enabled Mods";
            this.label_enabledMods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_activateMod
            // 
            this.button_activateMod.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_activateMod.Location = new System.Drawing.Point(246, 77);
            this.button_activateMod.Name = "button_activateMod";
            this.button_activateMod.Size = new System.Drawing.Size(22, 30);
            this.button_activateMod.TabIndex = 5;
            this.button_activateMod.Text = ">";
            this.button_activateMod.UseVisualStyleBackColor = true;
            this.button_activateMod.Click += new System.EventHandler(this.button_activateMod_Click);
            // 
            // button_deactivateMod
            // 
            this.button_deactivateMod.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deactivateMod.Location = new System.Drawing.Point(218, 77);
            this.button_deactivateMod.Name = "button_deactivateMod";
            this.button_deactivateMod.Size = new System.Drawing.Size(22, 30);
            this.button_deactivateMod.TabIndex = 4;
            this.button_deactivateMod.Text = "<";
            this.button_deactivateMod.UseVisualStyleBackColor = true;
            this.button_deactivateMod.Click += new System.EventHandler(this.button_deactivateMod_Click);
            // 
            // button_deployMods
            // 
            this.button_deployMods.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deployMods.Location = new System.Drawing.Point(218, 113);
            this.button_deployMods.Name = "button_deployMods";
            this.button_deployMods.Size = new System.Drawing.Size(50, 80);
            this.button_deployMods.TabIndex = 6;
            this.button_deployMods.Text = "Deploy Mods";
            this.button_deployMods.UseVisualStyleBackColor = true;
            this.button_deployMods.Click += new System.EventHandler(this.button_deployMods_Click);
            // 
            // button_pathSetup
            // 
            this.button_pathSetup.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pathSetup.Location = new System.Drawing.Point(218, 31);
            this.button_pathSetup.Name = "button_pathSetup";
            this.button_pathSetup.Size = new System.Drawing.Size(50, 40);
            this.button_pathSetup.TabIndex = 3;
            this.button_pathSetup.Text = "Path Setup";
            this.button_pathSetup.UseVisualStyleBackColor = true;
            this.button_pathSetup.Click += new System.EventHandler(this.button_pathSetup_Click);
            // 
            // button_priorityUp
            // 
            this.button_priorityUp.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_priorityUp.Location = new System.Drawing.Point(274, 449);
            this.button_priorityUp.Name = "button_priorityUp";
            this.button_priorityUp.Size = new System.Drawing.Size(97, 30);
            this.button_priorityUp.TabIndex = 14;
            this.button_priorityUp.Text = "Priority Up";
            this.button_priorityUp.UseVisualStyleBackColor = true;
            this.button_priorityUp.Click += new System.EventHandler(this.button_priorityUp_Click);
            // 
            // button_priorityDown
            // 
            this.button_priorityDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_priorityDown.Location = new System.Drawing.Point(377, 449);
            this.button_priorityDown.Name = "button_priorityDown";
            this.button_priorityDown.Size = new System.Drawing.Size(97, 30);
            this.button_priorityDown.TabIndex = 15;
            this.button_priorityDown.Text = "Priority Down";
            this.button_priorityDown.UseVisualStyleBackColor = true;
            this.button_priorityDown.Click += new System.EventHandler(this.button_priorityDown_Click);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Location = new System.Drawing.Point(218, 449);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(50, 30);
            this.button_exit.TabIndex = 11;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_about
            // 
            this.button_about.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_about.Location = new System.Drawing.Point(218, 409);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(50, 30);
            this.button_about.TabIndex = 10;
            this.button_about.Text = "About";
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // button_refreshMods
            // 
            this.button_refreshMods.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refreshMods.Location = new System.Drawing.Point(12, 449);
            this.button_refreshMods.Name = "button_refreshMods";
            this.button_refreshMods.Size = new System.Drawing.Size(200, 30);
            this.button_refreshMods.TabIndex = 2;
            this.button_refreshMods.Text = "Refresh Mods List";
            this.button_refreshMods.UseVisualStyleBackColor = true;
            this.button_refreshMods.Click += new System.EventHandler(this.button_refreshMods_Click);
            // 
            // button_createVanillaGameBackup
            // 
            this.button_createVanillaGameBackup.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_createVanillaGameBackup.Location = new System.Drawing.Point(218, 294);
            this.button_createVanillaGameBackup.Name = "button_createVanillaGameBackup";
            this.button_createVanillaGameBackup.Size = new System.Drawing.Size(50, 80);
            this.button_createVanillaGameBackup.TabIndex = 8;
            this.button_createVanillaGameBackup.Text = "Create Vanilla Game Backup";
            this.button_createVanillaGameBackup.UseVisualStyleBackColor = true;
            this.button_createVanillaGameBackup.Click += new System.EventHandler(this.button_createVanillaGameBackup_Click);
            // 
            // progressBar_deployMods
            // 
            this.progressBar_deployMods.ForeColor = System.Drawing.Color.LightGreen;
            this.progressBar_deployMods.Location = new System.Drawing.Point(218, 199);
            this.progressBar_deployMods.Name = "progressBar_deployMods";
            this.progressBar_deployMods.Size = new System.Drawing.Size(50, 23);
            this.progressBar_deployMods.TabIndex = 7;
            // 
            // progressBar_createVanillaGameBackup
            // 
            this.progressBar_createVanillaGameBackup.ForeColor = System.Drawing.Color.LightGreen;
            this.progressBar_createVanillaGameBackup.Location = new System.Drawing.Point(218, 380);
            this.progressBar_createVanillaGameBackup.Name = "progressBar_createVanillaGameBackup";
            this.progressBar_createVanillaGameBackup.Size = new System.Drawing.Size(50, 23);
            this.progressBar_createVanillaGameBackup.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.progressBar_createVanillaGameBackup);
            this.Controls.Add(this.progressBar_deployMods);
            this.Controls.Add(this.button_createVanillaGameBackup);
            this.Controls.Add(this.button_refreshMods);
            this.Controls.Add(this.button_about);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_priorityDown);
            this.Controls.Add(this.button_priorityUp);
            this.Controls.Add(this.button_pathSetup);
            this.Controls.Add(this.button_deployMods);
            this.Controls.Add(this.label_enabledMods);
            this.Controls.Add(this.button_deactivateMod);
            this.Controls.Add(this.listBox_enabledMods);
            this.Controls.Add(this.button_activateMod);
            this.Controls.Add(this.label_disabledMods);
            this.Controls.Add(this.listBox_disabledMods);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 530);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 530);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Arsenal: A Hearts of Iron 2 Mod Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_disabledMods;
        private System.Windows.Forms.Label label_disabledMods;
        private System.Windows.Forms.ListBox listBox_enabledMods;
        private System.Windows.Forms.Label label_enabledMods;
        private System.Windows.Forms.Button button_deactivateMod;
        private System.Windows.Forms.Button button_activateMod;
        private System.Windows.Forms.Button button_deployMods;
        private System.Windows.Forms.Button button_pathSetup;
        private System.Windows.Forms.Button button_priorityUp;
        private System.Windows.Forms.Button button_priorityDown;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.Button button_refreshMods;
        private System.Windows.Forms.Button button_createVanillaGameBackup;
        private System.Windows.Forms.ProgressBar progressBar_deployMods;
        private System.Windows.Forms.ProgressBar progressBar_createVanillaGameBackup;
    }
}

