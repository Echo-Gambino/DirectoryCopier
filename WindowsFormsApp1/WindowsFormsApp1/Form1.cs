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
            String path = "";
            String[] path_token = Directory.GetCurrentDirectory().Split('\\');
            int max_depth = 2;

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

            if (path == "")
                path = Directory.GetCurrentDirectory();

            input_textBox.Text = path;

            info_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            info_label.Text = "";
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input_button_Click(object sender, EventArgs e)
        {
            select_path_Handler(input_textBox);
        }

        private void output_button_Click(object sender, EventArgs e)
        {
            select_path_Handler(output_textBox);
        }

        private void select_path_Handler(TextBox textBox) {

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                textBox.Text = folderBrowserDialog.SelectedPath;
            }

            user_input_Check(input_textBox.Text, output_textBox.Text);

            return;
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            String input_dir = input_textBox.Text;
            String output_dir = output_textBox.Text;
            String seperator = " ";

            if (!user_input_Check(input_dir, output_dir))
                return;

            if (hyphen_checkBox.Checked)
                seperator = "-";

            SearchDir.copyDirectories(input_dir, output_dir, seperator);
            return;
        }

        private bool user_input_Check(String input_dir, String output_dir)
        {
            if (input_dir == "" || output_dir == "")
            {
                info_label.Text = "Cannot Copy: Please select both a target destination and a copy destination.";
                return false;
            }

            info_label.Text = "";
            return true;
        }

    }

    public class SearchDir
    {
        private static String[] getDirectories(String path)
        {
            return Directory.GetDirectories(path);
        }

        private static String getFolderInPath(String path)
        {
            String[] folders = path.Split('\\');
            int i = folders.Count();
            return folders[i - 1];
        }

        private static String replaceSpacesInFolder(String folder_name)
        {
            String output = "";
            String[] all_tokens = folder_name.Split(' ');

            foreach (String token in all_tokens)
            {
                if (output == "")
                    output = token;
                else if (token != "")
                    output = output + '-' + token;
            }

            return output;
        }

        public static void copyDirectories(String targ_path, String dest_path, String seperator)
        {
            String new_folder_path = "";
            String folder = SearchDir.getFolderInPath(targ_path);

            folder = SearchDir.replaceSpacesInFolder(folder);

            new_folder_path = dest_path + "\\" + folder;

            while (Directory.Exists(new_folder_path))
            {
                new_folder_path = new_folder_path + seperator + "Copy";
            }

            Directory.CreateDirectory(new_folder_path);

            String[] all_sub_paths = Directory.GetDirectories(targ_path);
            foreach (String sub_path in all_sub_paths)
            {
                SearchDir.copyDirectories(sub_path, new_folder_path, seperator);
            }

            return;
        }

    }
    
}
