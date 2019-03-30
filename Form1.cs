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
    public partial class Form1 : Form
    {
        // Initialise the filenames for the directories file and the enabled mods file.
        string pathsFilename = "./arsenalPaths.cfg";
        string enabledModsFilename = "./enabledMods.cfg";

        // Initialise the newly-disabled mods list.
        List<string> newlyDisabledMods = new List<string>();

        public Form1()
        {
            InitializeComponent();
            refreshModLists();
        }

        private void button_refreshMods_Click(object sender, EventArgs e)
        {
            refreshModLists();
        }

        private void refreshModLists()
        {
            // Clear the displayed mods lists.
            listBox_disabledMods.Items.Clear();
            listBox_enabledMods.Items.Clear();

            // Load the configuration file.
            Tuple<string, string, string> paths = loadConfigFile(pathsFilename);

            // Populate the disabled and enabled mods lists.
            populateDisabledMods(paths);
            populateEnabledMods(enabledModsFilename);
        }

        private void button_pathSetup_Click(object sender, EventArgs e)
        {
            pathSetup pathSetup = new Arsenal_A_Hearts_of_Iron_II_Mod_Manager.pathSetup();
            pathSetup.ShowDialog();
        }

        private void button_activateMod_Click(object sender, EventArgs e)
        {
            // Check to see if there's a disabled mod selected
            if (listBox_disabledMods.SelectedItem != null)
            {
                // Add the selected disabled mod to the enabled mods list and remove it from the disabled mods list.
                listBox_enabledMods.Items.Add(listBox_disabledMods.SelectedItem);
                listBox_disabledMods.Items.Remove(listBox_disabledMods.SelectedItem);

                // Write the new enabled mods file
                writeEnabledModsFile();
            }
        }

        private void button_deactivateMod_Click(object sender, EventArgs e)
        {
            // Check to see if there's an enabled mod selected
            if (listBox_enabledMods.SelectedItem != null)
            {
                // Add the selected enabled mod to the newly-disabled mods list.
                newlyDisabledMods.Add(listBox_enabledMods.SelectedItem.ToString());

                // Remove the selected enabled mod from the enabled mods list, add it to the disabled mods list and re-sort.
                listBox_disabledMods.Items.Add(listBox_enabledMods.SelectedItem);
                listBox_enabledMods.Items.Remove(listBox_enabledMods.SelectedItem);
                listBox_disabledMods.Sorted = true;

                // Write the new enabled mods file
                writeEnabledModsFile();
            }
        }

        private async void button_deployMods_Click(object sender, EventArgs e)
        {
            // Set up the progress bar
            // Set up the progress bar
            progressBar_deployMods.Maximum = 100;
            progressBar_deployMods.Step = 1;

            var progress = new Progress<int>(v =>
            {
                progressBar_deployMods.Value = v;
            });

            // Run the task in another thread so the UI doesn't hang.
            await Task.Run(() => deployMods_DoWork(progress));

            // Set the progress bar to full.
            progressBar_deployMods.Value = 100;

            // Create a dialog box to let the user know it's done.
            MessageBox.Show("Enabled mods deployed successfully!", "Mod Deployment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deployMods_DoWork(IProgress<int> progress)
        {
            // Initialise the file list variable and the destination path variable.
            List<string> fileList = new List<string>();
            string destinationPath = "";

            // Load the paths file so we can get the mod staging path
            Tuple<string, string, string> paths = loadConfigFile(pathsFilename);

            // For each mod in the disabled mods list, generate a manifest file in its folder if one does not already exist.
            foreach (string s in listBox_disabledMods.Items)
            {
                if (!File.Exists(paths.Item2 + "\\" + s + "\\manifest.mod"))
                {
                    generateModManifest(paths.Item2, s);
                }
            }

            // For each mod in the enabled mods list, generate a manifest file in its folder if one does not already exist.
            foreach (string s in listBox_enabledMods.Items)
            {
                if (!File.Exists(paths.Item2 + "\\" + s + "\\manifest.mod"))
                {
                    generateModManifest(paths.Item2, s);
                }
            }

            // Reset the game install to its vanilla state
            vanillaReset(paths);

            // Report the first half of the progress.
            if (progress != null)
            {
                progress.Report(50);
            }

            // For each mod in the enabled mods list:
            foreach (string s in listBox_enabledMods.Items)
            {
                // Make sure the destination directory structure exists. If it doesn't, create it.
                List<String> directoryList = Directory.GetDirectories((paths.Item2 + "\\" + s + "\\"), "*", SearchOption.AllDirectories).ToList();

                foreach (string directory in directoryList)
                {
                    // Convert to the destination directory path
                    string destinationDirectoryPath = paths.Item1 + "\\" + directory.Substring((paths.Item2.Length + 2 + s.Length), (directory.Length - (paths.Item2.Length + 2 + s.Length)));

                    // If it doesn't exist
                    if (!Directory.Exists(destinationDirectoryPath))
                    {
                        // Create it
                        Directory.CreateDirectory(destinationDirectoryPath);
                    }
                }

                // Read the manifest file.
                fileList = readModManifest(paths.Item2, s);

                // For each file in the manifest file.
                foreach (string sourcePath in fileList)
                {
                    // If the source file exists.
                    if (File.Exists(sourcePath))
                    {
                        // Create the destination path.
                        destinationPath = paths.Item1 + "\\" + (sourcePath.Substring((paths.Item2.Length + 2 + s.Length), (sourcePath.Length - (paths.Item2.Length + 2 + s.Length))));

                        // Copy the file from the origin to the destination, overwriting as necessary.
                        File.Copy(sourcePath, destinationPath, true);
                    }
                }
            }
        }

        private void vanillaReset(Tuple<string, string, string> paths)
        {
            // Initialise the list of vanilla backup paths
            List<string> vanillaBackupPaths = new List<string>();

            // Purge newly-disabled mods.
            foreach (string newlyDisabledMod in newlyDisabledMods)
            {
                // Read the manifest file
                List<string> fileList = readModManifest(paths.Item2, newlyDisabledMod);

                // For each file in the manifest file
                foreach (string file in fileList)
                {
                    // Create the install path it would have and add it to a list of install paths
                    string installPath = paths.Item1 + "\\" + (file.Substring((paths.Item2.Length + 1 + newlyDisabledMod.Length), (file.Length - (paths.Item2.Length + 1 + newlyDisabledMod.Length))));

                    // Convert the install path into the vanilla backup path and add this to a list of vanilla backup paths
                    string vanillaBackupPath = paths.Item3 + installPath.Substring((paths.Item1.Length + 1), (installPath.Length - (paths.Item1.Length + 1)));
                    vanillaBackupPaths.Add(vanillaBackupPath);

                    // If the file exists in the install path
                    if (File.Exists(installPath))
                    {
                        // Remove the file
                        File.Delete(installPath);
                    }
                }
            }

            // Purge enabled mods.
            foreach (string enabledMod in listBox_enabledMods.Items)
            {
                // Read the manifest file
                List<string> fileList = readModManifest(paths.Item2, enabledMod);

                // For each file in the manifest file
                foreach (string file in fileList)
                {
                    // Create the install path it would have and add it to a list of install paths
                    string installPath = paths.Item1 + "\\" + (file.Substring((paths.Item2.Length + 1 + enabledMod.Length), (file.Length - (paths.Item2.Length + 1 + enabledMod.Length))));

                    // Convert the install path into the vanilla backup path and add this to a list of vanilla backup paths
                    string vanillaBackupPath = paths.Item3 + installPath.Substring((paths.Item1.Length + 1), (installPath.Length - (paths.Item1.Length + 1)));
                    vanillaBackupPaths.Add(vanillaBackupPath);

                    // If the file exists in the install path
                    if (File.Exists(installPath))
                    {
                        // Remove the file
                        File.Delete(installPath);
                    }
                }
            }

            // Once all mod files have been removed, restore any matching vanilla files.
            // For each vanilla backup path stored
            foreach (string vanillaBackupPath in vanillaBackupPaths)
            {
                // If the matching vanilla file exists
                if (File.Exists(vanillaBackupPath))
                {
                    // Create the install path
                    string installPath = paths.Item1 + "\\" + vanillaBackupPath.Substring((paths.Item3.Length + 1), (vanillaBackupPath.Length - (paths.Item3.Length + 1)));

                    // Copy the vanilla file to the install directory
                    File.Copy(vanillaBackupPath, installPath, true);
                }
            }
        }
        
        private async void button_createVanillaGameBackup_Click(object sender, EventArgs e)
        {
            // Set up the progress bar
            progressBar_createVanillaGameBackup.Maximum = 100;
            progressBar_createVanillaGameBackup.Step = 1;

            var progress = new Progress<int>(v =>
            {
                progressBar_createVanillaGameBackup.Value = v;
            });

            // Run the task in another thread so the UI doesn't hang.
            await Task.Run(() => createVanillaGameBackup_DoWork(progress));

            // Set the progress bar to full.
            progressBar_createVanillaGameBackup.Value = 100;

            // Create a dialog box to let the user know it's done.
            MessageBox.Show("Vanilla game backup created successfully!", "Vanilla Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void createVanillaGameBackup_DoWork(IProgress<int> progress)
        {

            // Load the paths file so we can get the vanilla backup path.
            Tuple<string, string, string> paths = loadConfigFile(pathsFilename);
            string gameInstallPath = paths.Item1;
            string vanillaBackupPath = paths.Item3;
            string destinationPath = "";

            // Get a list of all the directories.
            List<String> directoryList = Directory.GetDirectories(gameInstallPath, "*", SearchOption.AllDirectories).ToList();

            // Create the directory structure in the backup folder.
            foreach (string directory in directoryList)
            {
                // Create the destination path
                destinationPath = vanillaBackupPath + (directory.Substring(gameInstallPath.Length, (directory.Length - gameInstallPath.Length)));

                // Create the directory
                Directory.CreateDirectory(destinationPath);
            }

            // Report the first half of the progress.
            if (progress != null)
            {
                progress.Report(50);
            }

            // Get a list of all the files and their paths.
            List<String> filePathList = Directory.GetFiles(gameInstallPath, "*", SearchOption.AllDirectories).ToList();

            // For each file in this list
            foreach (string sourcePath in filePathList)
            {
                // If the source file exists (just a sanity check)
                if (File.Exists(sourcePath))
                {
                    // Create the destination path
                    destinationPath = vanillaBackupPath + (sourcePath.Substring(gameInstallPath.Length, (sourcePath.Length - gameInstallPath.Length)));

                    // And copy the file to the vanilla backup path, overwriting as necessary.
                    File.Copy(sourcePath, destinationPath, true);
                }
            }
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            aboutBox aboutBox = new Arsenal_A_Hearts_of_Iron_II_Mod_Manager.aboutBox();
            aboutBox.ShowDialog();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_priorityUp_Click(object sender, EventArgs e)
        {
            moveListItem(listBox_enabledMods, -1);

            // Write the new enabled mods file
            writeEnabledModsFile();
        }

        private void button_priorityDown_Click(object sender, EventArgs e)
        {
            moveListItem(listBox_enabledMods, 1);

            // Write the new enabled mods file
            writeEnabledModsFile();
        }

        private void moveListItem(ListBox listBox, int direction)
        {
            // Checking selected item
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
            {
                return; // No selected item - nothing to do
            }

            // Calculate new index using move direction
            int newIndex = listBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
            {
                return; // Index out of range - nothing to do
            }

            object selected = listBox.SelectedItem;

            // Removing removable element
            listBox.Items.Remove(selected);
            // Insert it in new position
            listBox.Items.Insert(newIndex, selected);
            // Restore selection
            listBox.SetSelected(newIndex, true);
        }

        private Tuple<string, string, string> loadConfigFile(string configFilePath)
        {
            // Initialise the game install directory and mod staging directory variables.
            string gameInstallPath = "";
            string modStagingPath = "";
            string vanillaBackupPath = "";

            if (File.Exists(configFilePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(configFilePath))
                    {
                        // Read the pathSetup file
                        sr.ReadLine();
                        gameInstallPath = sr.ReadLine();
                        modStagingPath = sr.ReadLine();
                        vanillaBackupPath = sr.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    // There was an error reading
                    MessageBox.Show("Please report this error message to the developer: " + e.Message, "Config Read Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {
                    // Write a new pathSetup file
                    using (StreamWriter sw = File.CreateText(configFilePath))
                    {
                        sw.WriteLine("# Arsenal Mod Manager Configuration File");
                        sw.WriteLine(gameInstallPath);
                        sw.WriteLine(modStagingPath);
                        sw.WriteLine(vanillaBackupPath);
                        sw.WriteLine("# END OF FILE");
                    }
                }
                catch (Exception e)
                {
                    // There was an error writing
                    MessageBox.Show("Please report this error message to the developer: " + e.Message, "Config Write Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return Tuple.Create(gameInstallPath, modStagingPath, vanillaBackupPath);
        }

        private void populateDisabledMods(Tuple<string, string, string> paths)
        {
            // Populate the disabled mods list, assuming there is a game install and mod staging path defined.
            if (paths.Item1 == "" || paths.Item2 == "")
            {
                MessageBox.Show("There is no game install, mod staging or vanilla backup path defined, please set them in the Path Setup screen.", "Path(s) Undefined Error 1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (string s in Directory.GetDirectories(paths.Item2))
                {
                    listBox_disabledMods.Items.Add(s.Remove(0, paths.Item2.Length + 1));
                }
            }
        }

        private void populateEnabledMods(string enabledModsFilePath)
        {
            if (File.Exists(enabledModsFilePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(enabledModsFilePath))
                    {
                        // Read the pathSetup file
                        sr.ReadLine(); // Skip the first line (title)

                        string readLine = sr.ReadLine(); // Read the next line

                        while (readLine != "# END OF FILE") // If you are not at EOF
                        {
                            listBox_enabledMods.Items.Add(readLine); // Add the item to the enabled mods list.
                            readLine = sr.ReadLine(); // Read the next line
                        }
                    }
                }
                catch (Exception e)
                {
                    // There was an error reading
                    MessageBox.Show("Please report this error message to the developer: " + e.Message, "Enabled Mods File Read Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Remove any items in the enabled list from the disabled list.
                foreach (string s in listBox_enabledMods.Items)
                {
                    listBox_disabledMods.Items.Remove(s);
                }
            }
            else
            {
                try
                {
                    // Write a new pathSetup file
                    using (StreamWriter sw = File.CreateText(enabledModsFilePath))
                    {
                        sw.WriteLine("# Arsenal Mod Manager - Enabled Mods File");
                        sw.WriteLine("# END OF FILE");
                    }
                }
                catch (Exception e)
                {
                    // There was an error writing the enabled mods file (Error 1).
                    MessageBox.Show("Please report this error message to the developer: " + e.Message, "Enabled Mods File Write Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void writeEnabledModsFile()
        {
            try
            {
                // Write the enabled mods file
                using (StreamWriter sw = File.CreateText(enabledModsFilename))
                {
                    sw.WriteLine("# Arsenal Mod Manager - Enabled Mods File");
                    foreach (string s in listBox_enabledMods.Items)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine("# END OF FILE");
                }
            }
            catch (Exception e)
            {
                // There was an error writing the enabled mods file (Error 2).
                MessageBox.Show("Please report this error message to the developer: " + e.Message, "Enabled Mods File Write Error 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generateModManifest(string modStagingPath, string modFolderName)
        {
            // Get a list of all the files and their paths.
            List<String> filePathList = Directory.GetFiles((modStagingPath + "\\" + modFolderName), "*", SearchOption.AllDirectories).ToList();

            // Write the manifest file.
            try
            {
                using (StreamWriter sw = File.CreateText(modStagingPath + "/" + modFolderName + "/manifest.mod"))
                {
                    sw.WriteLine("# Arsenal Mod Manager - Mod Manifest File: " + modFolderName);
                    foreach (string s in filePathList)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine("# END OF FILE");
                }
            }
            catch (Exception e)
            {
                // There was an error writing the mod manifest file.
                MessageBox.Show("Please report this error message to the developer: " + e.Message, "Mod Manifest File Write Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<String> readModManifest(string modStagingPath, string modFolderName)
        {
            List<String> filePathList = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(modStagingPath + "/" + modFolderName + "/manifest.mod"))
                {
                    sr.ReadLine(); // Ignore the first line
                    string readLine = sr.ReadLine(); // Read the next line
                    while (readLine != "# END OF FILE") // If you're not EOF
                    {
                        filePathList.Add(readLine); // Add the line to the list
                        readLine = sr.ReadLine(); // And go to the next one
                    }
                }
            }
            catch (Exception e)
            {
                // There was an error reading the mod manifest file.
                MessageBox.Show("Please report this error message to the developer: " + e.Message, "Mod Manifest File Read Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return filePathList;
        }
    }
}
