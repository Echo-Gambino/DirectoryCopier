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

            return;
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            String input_dir = input_textBox.Text;
            String output_dir = output_textBox.Text;

            test_label.Text = SearchDir.copyDirectories(input_dir, output_dir);

            // String directories = Path.GetFullPath(input_directory);
            /*
            String[] directories = Directory.GetDirectories(input_directory);
            String proc_string = "";
            foreach (string s in directories)
                proc_string = proc_string + "\n" + s;
            test_label.Text = proc_string;
            */

        }

        private void output_textBox_TextChanged(object sender, EventArgs e)
        {

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

        public static String copyDirectories(String targ_path, String dest_path)
        {
            String new_folder_path = "";
            String folder = SearchDir.getFolderInPath(targ_path);

            new_folder_path = dest_path + "\\" + folder;

            while (Directory.Exists(new_folder_path))
            {
                new_folder_path = new_folder_path + " Copy";
            }

            Directory.CreateDirectory(new_folder_path);

            String[] all_sub_paths = Directory.GetDirectories(targ_path);
            foreach (String sub_path in all_sub_paths)
            {
                SearchDir.copyDirectories(sub_path, new_folder_path);
            }

            return "";
        }

    }
    
}
