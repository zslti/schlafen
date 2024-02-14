
namespace WindowsFormsApp10
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.console = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.RichTextBox();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.getStartedLabel = new System.Windows.Forms.Label();
            this.createNewLabel = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.Label();
            this.currentlyEditingLabel = new System.Windows.Forms.Label();
            this.closeFileButton = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runPictureBox = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.runPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(12, 180);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.console.Size = new System.Drawing.Size(539, 200);
            this.console.TabIndex = 1;
            // 
            // input
            // 
            this.input.AcceptsTab = true;
            this.input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.input.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(46, 57);
            this.input.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.input.MinimumSize = new System.Drawing.Size(100, 100);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(525, 162);
            this.input.TabIndex = 1;
            this.input.Text = "";
            this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            this.input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.input_KeyUp);
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineNumberLabel.Location = new System.Drawing.Point(-2, 60);
            this.lineNumberLabel.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.lineNumberLabel.MinimumSize = new System.Drawing.Size(1, 100);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lineNumberLabel.Size = new System.Drawing.Size(1, 100);
            this.lineNumberLabel.TabIndex = 2;
            this.lineNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // getStartedLabel
            // 
            this.getStartedLabel.AutoSize = true;
            this.getStartedLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStartedLabel.Location = new System.Drawing.Point(55, 69);
            this.getStartedLabel.Name = "getStartedLabel";
            this.getStartedLabel.Size = new System.Drawing.Size(215, 37);
            this.getStartedLabel.TabIndex = 3;
            this.getStartedLabel.Text = "Get started";
            // 
            // createNewLabel
            // 
            this.createNewLabel.AutoSize = true;
            this.createNewLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewLabel.Location = new System.Drawing.Point(88, 119);
            this.createNewLabel.Name = "createNewLabel";
            this.createNewLabel.Size = new System.Drawing.Size(233, 28);
            this.createNewLabel.TabIndex = 4;
            this.createNewLabel.Text = "Create a new file";
            this.createNewLabel.Click += new System.EventHandler(this.createNewLabel_Click);
            // 
            // openFile
            // 
            this.openFile.AutoSize = true;
            this.openFile.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFile.Location = new System.Drawing.Point(88, 159);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(285, 28);
            this.openFile.TabIndex = 5;
            this.openFile.Text = "Open an existing file";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // currentlyEditingLabel
            // 
            this.currentlyEditingLabel.AutoSize = true;
            this.currentlyEditingLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentlyEditingLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentlyEditingLabel.Location = new System.Drawing.Point(39, 9);
            this.currentlyEditingLabel.Name = "currentlyEditingLabel";
            this.currentlyEditingLabel.Size = new System.Drawing.Size(0, 37);
            this.currentlyEditingLabel.TabIndex = 6;
            this.currentlyEditingLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.currentlyEditingLabel_MouseDown);
            // 
            // closeFileButton
            // 
            this.closeFileButton.AutoSize = true;
            this.closeFileButton.BackColor = System.Drawing.Color.Transparent;
            this.closeFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeFileButton.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFileButton.Location = new System.Drawing.Point(55, 9);
            this.closeFileButton.Name = "closeFileButton";
            this.closeFileButton.Size = new System.Drawing.Size(35, 37);
            this.closeFileButton.TabIndex = 7;
            this.closeFileButton.Text = "X";
            this.closeFileButton.Click += new System.EventHandler(this.closeFileButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(154, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 50);
            this.panel1.TabIndex = 8;
            this.panel1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 68);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(127, 32);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 32);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // runPictureBox
            // 
            this.runPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("runPictureBox.Image")));
            this.runPictureBox.Location = new System.Drawing.Point(93, 16);
            this.runPictureBox.Name = "runPictureBox";
            this.runPictureBox.Size = new System.Drawing.Size(25, 25);
            this.runPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.runPictureBox.TabIndex = 10;
            this.runPictureBox.TabStop = false;
            this.runPictureBox.Click += new System.EventHandler(this.runPictureBox_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(634, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 85);
            this.panel2.TabIndex = 11;
            this.panel2.TabStop = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(646, 57);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(213, 26);
            this.searchTextBox.TabIndex = 12;
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(646, 89);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(213, 26);
            this.replaceTextBox.TabIndex = 13;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(865, 57);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(60, 30);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "next";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaceButton.Location = new System.Drawing.Point(865, 89);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(60, 30);
            this.replaceButton.TabIndex = 15;
            this.replaceButton.Text = "replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 544);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.runPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeFileButton);
            this.Controls.Add(this.currentlyEditingLabel);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.createNewLabel);
            this.Controls.Add(this.getStartedLabel);
            this.Controls.Add(this.lineNumberLabel);
            this.Controls.Add(this.input);
            this.Controls.Add(this.console);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.onResize);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.runPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.Label lineNumberLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label getStartedLabel;
        private System.Windows.Forms.Label createNewLabel;
        private System.Windows.Forms.Label openFile;
        private System.Windows.Forms.Label currentlyEditingLabel;
        private System.Windows.Forms.Label closeFileButton;
        private System.Windows.Forms.PictureBox panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.PictureBox runPictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox panel2;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button replaceButton;
    }
}

