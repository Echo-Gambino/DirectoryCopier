﻿namespace WindowsFormsApp1
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
            this.input_label = new System.Windows.Forms.Label();
            this.output_label = new System.Windows.Forms.Label();
            this.input_textBox = new System.Windows.Forms.TextBox();
            this.output_textBox = new System.Windows.Forms.TextBox();
            this.input_button = new System.Windows.Forms.Button();
            this.output_button = new System.Windows.Forms.Button();
            this.quit_button = new System.Windows.Forms.Button();
            this.copy_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_label
            // 
            this.input_label.AutoSize = true;
            this.input_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_label.Location = new System.Drawing.Point(12, 9);
            this.input_label.MinimumSize = new System.Drawing.Size(160, 20);
            this.input_label.Name = "input_label";
            this.input_label.Size = new System.Drawing.Size(160, 20);
            this.input_label.TabIndex = 0;
            this.input_label.Text = "Target Destination";
            this.input_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // output_label
            // 
            this.output_label.AutoSize = true;
            this.output_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_label.Location = new System.Drawing.Point(12, 39);
            this.output_label.MinimumSize = new System.Drawing.Size(160, 20);
            this.output_label.Name = "output_label";
            this.output_label.Size = new System.Drawing.Size(160, 20);
            this.output_label.TabIndex = 1;
            this.output_label.Text = "Copy Destination";
            this.output_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // input_textBox
            // 
            this.input_textBox.Location = new System.Drawing.Point(178, 9);
            this.input_textBox.Name = "input_textBox";
            this.input_textBox.Size = new System.Drawing.Size(489, 20);
            this.input_textBox.TabIndex = 2;
            // 
            // output_textBox
            // 
            this.output_textBox.Location = new System.Drawing.Point(178, 39);
            this.output_textBox.Name = "output_textBox";
            this.output_textBox.Size = new System.Drawing.Size(489, 20);
            this.output_textBox.TabIndex = 3;
            // 
            // input_button
            // 
            this.input_button.Location = new System.Drawing.Point(673, 9);
            this.input_button.Name = "input_button";
            this.input_button.Size = new System.Drawing.Size(115, 20);
            this.input_button.TabIndex = 4;
            this.input_button.Text = "Browse";
            this.input_button.UseVisualStyleBackColor = true;
            // 
            // output_button
            // 
            this.output_button.Location = new System.Drawing.Point(673, 39);
            this.output_button.Name = "output_button";
            this.output_button.Size = new System.Drawing.Size(115, 20);
            this.output_button.TabIndex = 5;
            this.output_button.Text = "Browse";
            this.output_button.UseVisualStyleBackColor = true;
            // 
            // quit_button
            // 
            this.quit_button.Location = new System.Drawing.Point(402, 66);
            this.quit_button.Name = "quit_button";
            this.quit_button.Size = new System.Drawing.Size(385, 23);
            this.quit_button.TabIndex = 6;
            this.quit_button.Text = "Quit";
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.quit_button_Click);
            // 
            // copy_button
            // 
            this.copy_button.Location = new System.Drawing.Point(12, 66);
            this.copy_button.Name = "copy_button";
            this.copy_button.Size = new System.Drawing.Size(384, 23);
            this.copy_button.TabIndex = 7;
            this.copy_button.Text = "Copy";
            this.copy_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.copy_button);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.output_button);
            this.Controls.Add(this.input_button);
            this.Controls.Add(this.output_textBox);
            this.Controls.Add(this.input_textBox);
            this.Controls.Add(this.output_label);
            this.Controls.Add(this.input_label);
            this.Name = "Form1";
            this.Text = "Directory Copier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label input_label;
        private System.Windows.Forms.Label output_label;
        private System.Windows.Forms.TextBox input_textBox;
        private System.Windows.Forms.TextBox output_textBox;
        private System.Windows.Forms.Button input_button;
        private System.Windows.Forms.Button output_button;
        private System.Windows.Forms.Button quit_button;
        private System.Windows.Forms.Button copy_button;
    }
}
