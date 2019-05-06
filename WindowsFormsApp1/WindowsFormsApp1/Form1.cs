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



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Perform an auto-fill for the user's default target destination */
            // This is the end result that will be outputted to input_textBox
            String path = "";
            // Break the path down to the project path down into individual folders/drives
            String[] path_token = Directory.GetCurrentDirectory().Split('\\');
            // Set the max depth, which will usually result in the end path to be relatively broad. (e.g. C:/user)
            int max_depth = 2;

            // Reconstruct the path, but stopping if the max_depth has been reached (max_depth reached zero)
            // or the path ran out of tokens to reconstruct it.
            foreach (String token in path_token)
            {
                if (max_depth <= 0)
                    break;
                max_depth--;

                if (path == "")
                    path = token;
                else
                    path = path + "\\" + token;
            }

            // If path is found to be empty somehow, just set it to the current working directory
            if (path == "")
                path = Directory.GetCurrentDirectory();

            // Finally, output the path to the input_textBox
            input_textBox.Text = path;

            /* Initiallize the properties of info_label */
            // Set info_label's font color to be red (#FF0000)
            info_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            // Set info_label to be None for now
            info_label.Text = "";
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            // Closes the application gracefully if the close button is nowhere to be found
            this.Close();
        }

        private void input_button_Click(object sender, EventArgs e)
        {
            // Sets a user selected path into input_textBox
            select_path_Handler(input_textBox);
        }

        private void output_button_Click(object sender, EventArgs e)
        {
            // Sets a user selected path into output_textBox
            select_path_Handler(output_textBox);
        }

        private void select_path_Handler(TextBox textBox) {
            /* Get user input on folder path and set it to the given textBox */
            
            // Open up a folder browser dialog,
            // If the end result is OK (i.e. user clicked 'OK' in the window),
            // Then put the selected path into the given text box 
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                textBox.Text = folderBrowserDialog.SelectedPath;
            }

            // Check for both of the text box's inputs to check if any are valid
            user_input_Check(input_textBox.Text, output_textBox.Text);

            return;
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            // Execute the copying algorithm
            String input_dir = input_textBox.Text;
            String output_dir = output_textBox.Text;
            String seperator = " ";

            // Check for user input, if user input is not okay, then pre-maturely return
            if (!user_input_Check(input_dir, output_dir))
                return;

            // If hyphen check box was checked, then set the seperator to be "-" instead of " "
            if (hyphen_checkBox.Checked)
                seperator = "-";

            // Call a method that will copy the directories over
            SearchDir.copyDirectories(input_dir, output_dir, seperator);
            return;
        }

        private bool user_input_Check(String input_dir, String output_dir)
        {
            // If input_dir or output_dir is "", then prompt the user to select a destination
            if (input_dir == "" || output_dir == "")
            {
                info_label.Text = "Cannot Copy: Please select both a target destination and copy destination.";
                return false;
            }

            // If all both inputs are valid, then set the info_label to not show anything
            info_label.Text = "";
            return true;
        }

    }

    public class SearchDir
    {
        /* getDirectories
         * 
         * Argument:
         *  String path : folder path that exits within the file system
         * 
         * Return:
         *  String[]    : subdirectories from the path
         * 
         */
        private static String[] getDirectories(String path)
        {
            return Directory.GetDirectories(path);
        }

        /* getFolderInPath
         * 
         * Argument:
         *  String path : folder path that exits within the file system
         *  
         * Return:
         *  String      : the folder name
         * 
         */
        private static String getFolderInPath(String path)
        {
            String[] folders = path.Split('\\');
            int i = folders.Count();
            return folders[i - 1];
        }

        /* replaceSpacesInFolder
         * 
         * Argument:
         *  String folder_name  : the folder name from the directory
         *  String seperator    : the character/string used to seperate the spaces
         * 
         * Return:
         *  String output       : the folder name when spaces are replaced with the seperator
         * 
         */
        private static String replaceSpacesInFolder(String folder_name, String seperator)
        {
            String output = "";
            String[] all_tokens = folder_name.Split(' ');

            foreach (String token in all_tokens)
            {
                if (output == "")
                    output = token;
                else if (token != "")
                    output = output + seperator + token;
            }

            return output;
        }

        /* copyDirectories
         * 
         * Argument:
         *  String targ_path    : the target path that the program is going to copy
         *  String dest_path    : the destination path that the copied structure is going to reside in
         *  String seperator    : the seperator that is going to replace the spaces of the folder names
         * 
         * Return:
         *  None
         * 
         * Recursively copy the target file structure from target path
         * to the destination path, while ensuring that spaces are replaced with
         * a seperator and a unique folder name is generated
         * 
         */
        public static void copyDirectories(String targ_path, String dest_path, String seperator)
        {
            String new_folder_path = "";
            String folder = SearchDir.getFolderInPath(targ_path);

            // Get the processed folder name (when spaces are replaced with seperator)
            folder = SearchDir.replaceSpacesInFolder(folder, seperator);

            // Construct the full folder path with the new folder name
            new_folder_path = dest_path + "\\" + folder;

            // If the folder path exists, then add 'seperator + Copy' at the suffix until there isn't
            while (Directory.Exists(new_folder_path))
            {
                new_folder_path = new_folder_path + seperator + "Copy";
            }

            // Generate a new directory
            Directory.CreateDirectory(new_folder_path);

            // Get all sub paths from the target path
            String[] all_sub_paths = Directory.GetDirectories(targ_path);

            // For each sub path, call copyDirectories(...)
            foreach (String sub_path in all_sub_paths)
            {
                SearchDir.copyDirectories(sub_path, new_folder_path, seperator);
            }

            return;
        }

    }
    
}
