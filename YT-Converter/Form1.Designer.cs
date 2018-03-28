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
            this.listView1 = new System.Windows.Forms.ListView();
            this.nimi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(12, 28);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(252, 20);
            this.linkBox.TabIndex = 0;
            this.linkBox.TextChanged += new System.EventHandler(this.linkBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sisesta YouTube link";
            // 
            // formatBox
            // 
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Location = new System.Drawing.Point(330, 28);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(59, 21);
            this.formatBox.TabIndex = 1;
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.formatBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vali formaat";
            // 
            // chooseDirectory
            // 
            this.chooseDirectory.Location = new System.Drawing.Point(280, 28);
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
            this.checkKonsool.Location = new System.Drawing.Point(12, 271);
            this.checkKonsool.Name = "checkKonsool";
            this.checkKonsool.Size = new System.Drawing.Size(126, 17);
            this.checkKonsool.TabIndex = 5;
            this.checkKonsool.Text = "Tahan näha konsooli";
            this.checkKonsool.UseVisualStyleBackColor = true;
            this.checkKonsool.CheckedChanged += new System.EventHandler(this.checkKonsool_CheckedChanged);
            // 
            // tõmba
            // 
            this.tõmba.Location = new System.Drawing.Point(12, 242);
            this.tõmba.Name = "tõmba";
            this.tõmba.Size = new System.Drawing.Size(75, 23);
            this.tõmba.TabIndex = 2;
            this.tõmba.Text = "Tõmba";
            this.tõmba.UseVisualStyleBackColor = true;
            this.tõmba.Click += new System.EventHandler(this.tõmba_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nimi,
            this.fileType,
            this.status});
            this.listView1.Location = new System.Drawing.Point(12, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(425, 182);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // nimi
            // 
            this.nimi.Text = "Nimi";
            this.nimi.Width = 118;
            // 
            // fileType
            // 
            this.fileType.Text = "File type";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(363, 242);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(34, 23);
            this.add.TabIndex = 9;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(403, 242);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(34, 23);
            this.remove.TabIndex = 10;
            this.remove.Text = "-";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.Text = "Staatus";
            this.status.Width = 77;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 242);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 330);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.listView1);
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
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader nimi;
        private System.Windows.Forms.ColumnHeader fileType;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

