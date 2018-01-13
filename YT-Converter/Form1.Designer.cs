namespace YT_Converter
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
            this.linkBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseDirectory = new System.Windows.Forms.Button();
            this.checkKonsool = new System.Windows.Forms.CheckBox();
            this.tõmba = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(12, 28);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(164, 20);
            this.linkBox.TabIndex = 0;
            this.linkBox.TextChanged += new System.EventHandler(this.linkBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sisesta YouTube link";
            // 
            // formatBox
            // 
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Location = new System.Drawing.Point(12, 76);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(59, 21);
            this.formatBox.TabIndex = 1;
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.formatBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vali formaat";
            // 
            // chooseDirectory
            // 
            this.chooseDirectory.Location = new System.Drawing.Point(191, 28);
            this.chooseDirectory.Name = "chooseDirectory";
            this.chooseDirectory.Size = new System.Drawing.Size(28, 20);
            this.chooseDirectory.TabIndex = 4;
            this.chooseDirectory.Text = "...";
            this.chooseDirectory.UseVisualStyleBackColor = true;
            this.chooseDirectory.Click += new System.EventHandler(this.chooseDirectory_Click);
            // 
            // checkKonsool
            // 
            this.checkKonsool.AutoSize = true;
            this.checkKonsool.Location = new System.Drawing.Point(93, 80);
            this.checkKonsool.Name = "checkKonsool";
            this.checkKonsool.Size = new System.Drawing.Size(126, 17);
            this.checkKonsool.TabIndex = 5;
            this.checkKonsool.Text = "Tahan näha konsooli";
            this.checkKonsool.UseVisualStyleBackColor = true;
            this.checkKonsool.CheckedChanged += new System.EventHandler(this.checkKonsool_CheckedChanged);
            // 
            // tõmba
            // 
            this.tõmba.Location = new System.Drawing.Point(12, 114);
            this.tõmba.Name = "tõmba";
            this.tõmba.Size = new System.Drawing.Size(75, 23);
            this.tõmba.TabIndex = 2;
            this.tõmba.Text = "Tõmba";
            this.tõmba.UseVisualStyleBackColor = true;
            this.tõmba.Click += new System.EventHandler(this.tõmba_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 159);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(207, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 200);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tõmba);
            this.Controls.Add(this.checkKonsool);
            this.Controls.Add(this.chooseDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formatBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "YT-Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox formatBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chooseDirectory;
        private System.Windows.Forms.CheckBox checkKonsool;
        private System.Windows.Forms.Button tõmba;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

