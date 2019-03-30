using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arsenal_A_Hearts_of_Iron_II_Mod_Manager
{
    public partial class pathSetup : Form
    {
        // Initialise the filename for the directories file.
        string pathsFilename = "./arsenalPaths.cfg";

        public pathSetup()
        {
            InitializeComponent();

            if (File.Exists(pathsFilename))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(pathsFilename))
                    {
                        // Read the paths file
                        sr.ReadLine();

                        // Apply the directories to the text boxes.
                        textBox_gameInstallPath.Text = sr.ReadLine();
                        textBox_modStagingPath.Text = sr.ReadLine();
                        textBox_vanillaBackupPath.Text = sr.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    // There was an error reading
                    MessageBox.Show("Please report this error message to the developer: " + e.Message, "Config Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Somehow, your pathSetup file is not readable. Please restart Arsenal. If the problem persists, please contact the developer.", "Config Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_browseGameInstallPath_Click(object sender, EventArgs e)
        {
            string gameInstallPath = "";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                gameInstallPath = folderBrowserDialog.SelectedPath;
            }

            textBox_gameInstallPath.Text = gameInstallPath;

            // Write the new paths file.
            try
            { writePathsFile(); } catch (Exception ex)
            {
                // There was an error writing
                MessageBox.Show("Please report this error message to the developer: " + ex.Message, "Config Write Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_browseModStagingPath_Click(object sender, EventArgs e)
        {
            string modStagingPath = "";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                modStagingPath = folderBrowserDialog.SelectedPath;
            }

            textBox_modStagingPath.Text = modStagingPath;

            // Write the new paths file.
            try
            { writePathsFile(); } catch (Exception ex)
            {
                // There was an error writing
                MessageBox.Show("Please report this error message to the developer: " + ex.Message, "Config Write Error 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_browseVanillaBackupPath_Click(object sender, EventArgs e)
        {
            string vanillaBackupPath = "";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                vanillaBackupPath = folderBrowserDialog.SelectedPath;
            }

            textBox_vanillaBackupPath.Text = vanillaBackupPath;

            // Write the new paths file.
            try
            { writePathsFile(); } catch (Exception ex)
            {
                // There was an error writing.
                MessageBox.Show("Please report this error message to the developer: " + ex.Message, "Config Write Error 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writePathsFile()
        {
            // Write a new paths file.
            using (StreamWriter sw = File.CreateText(pathsFilename))
            {
                sw.WriteLine("# Arsenal Mod Manager Configuration File");
                sw.WriteLine(textBox_gameInstallPath.Text);
                sw.WriteLine(textBox_modStagingPath.Text);
                sw.WriteLine(textBox_vanillaBackupPath.Text);
                sw.WriteLine("# END OF FILE");
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            // Just close the window.
            this.Close();
        }
    }
}
