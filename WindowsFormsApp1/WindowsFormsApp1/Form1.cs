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
            String input_directory = input_textBox.Text;
            String output_directory = output_textBox.Text;

            // String directories = Path.GetFullPath(input_directory);
            String[] directories = Directory.GetDirectories(input_directory);
            String proc_string = "";
            foreach (string s in directories)
                proc_string = proc_string + "\n" + s;
            test_label.Text = proc_string;


        }
    }
}
