namespace UDKtoUE4Tool
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BTN_Convert = new System.Windows.Forms.Button();
            this.TB_AssetPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_ContentDir = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_StaticLights = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.CB_VertextColors = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_BrowseFolder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_MultiplyPosition = new System.Windows.Forms.CheckBox();
            this.CB_MultiplyScale = new System.Windows.Forms.CheckBox();
            this.BTN_CopyToClipboard = new System.Windows.Forms.Button();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CB_UE4Mode = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.contactToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.contactToolStripMenuItem.Text = "About";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.contactToolStripMenuItem_Click);
            // 
            // BTN_Convert
            // 
            this.BTN_Convert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_Convert.Location = new System.Drawing.Point(709, 691);
            this.BTN_Convert.Name = "BTN_Convert";
            this.BTN_Convert.Size = new System.Drawing.Size(75, 23);
            this.BTN_Convert.TabIndex = 12;
            this.BTN_Convert.Text = "Convert";
            this.toolTip1.SetToolTip(this.BTN_Convert, "Converts the T3D script UE4\'s Format");
            this.BTN_Convert.UseVisualStyleBackColor = true;
            this.BTN_Convert.Click += new System.EventHandler(this.button3_Click);
            // 
            // TB_AssetPath
            // 
            this.TB_AssetPath.AllowDrop = true;
            this.TB_AssetPath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TB_AssetPath.Location = new System.Drawing.Point(127, 120);
            this.TB_AssetPath.Name = "TB_AssetPath";
            this.TB_AssetPath.Size = new System.Drawing.Size(852, 20);
            this.TB_AssetPath.TabIndex = 3;
            this.TB_AssetPath.Text = "/Game/";
            this.toolTip1.SetToolTip(this.TB_AssetPath, "If no UE4 path is found, the Path from UE3 is converted, use this to specifiy a s" +
        "ubfolder");
            this.TB_AssetPath.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Asset Path:";
            this.toolTip1.SetToolTip(this.label1, "If no UE4 path is found, the Path from UE3 is converted, use this to specifiy a s" +
        "ubfolder");
            // 
            // TB_ContentDir
            // 
            this.TB_ContentDir.AllowDrop = true;
            this.TB_ContentDir.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TB_ContentDir.Location = new System.Drawing.Point(127, 97);
            this.TB_ContentDir.Name = "TB_ContentDir";
            this.TB_ContentDir.Size = new System.Drawing.Size(771, 20);
            this.TB_ContentDir.TabIndex = 20;
            this.toolTip1.SetToolTip(this.TB_ContentDir, "Path to Your UE4 Content Folder ");
            this.TB_ContentDir.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "UE Content Directory:";
            this.toolTip1.SetToolTip(this.label10, "Path to Your UE4 Content Folder ");
            // 
            // CB_StaticLights
            // 
            this.CB_StaticLights.AutoSize = true;
            this.CB_StaticLights.Checked = true;
            this.CB_StaticLights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_StaticLights.Location = new System.Drawing.Point(859, 458);
            this.CB_StaticLights.Name = "CB_StaticLights";
            this.CB_StaticLights.Size = new System.Drawing.Size(84, 17);
            this.CB_StaticLights.TabIndex = 23;
            this.CB_StaticLights.Text = "Static Lights";
            this.toolTip1.SetToolTip(this.CB_StaticLights, "If true, non-moveable Lights will be set to static instead of Staionary");
            this.CB_StaticLights.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "fs";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CB_UE4Mode);
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Controls.Add(this.CB_VertextColors);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.CB_StaticLights);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.BTN_BrowseFolder);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.TB_ContentDir);
            this.tabPage1.Controls.Add(this.TB_AssetPath);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.CB_MultiplyPosition);
            this.tabPage1.Controls.Add(this.BTN_Convert);
            this.tabPage1.Controls.Add(this.CB_MultiplyScale);
            this.tabPage1.Controls.Add(this.BTN_CopyToClipboard);
            this.tabPage1.Controls.Add(this.BTN_Exit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(997, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Actors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AllowDrop = true;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Static Meshes",
            "Skeletal Meshes",
            "Kactors",
            "Interop Actors",
            "Destructable Actors",
            "Foilage Actors",
            "Point Lights",
            "Spot Lights",
            "Directional Lights",
            "Player Starts",
            "Cameras",
            "Decals",
            "Particles",
            "Fog",
            "Sounds"});
            this.checkedListBox1.Location = new System.Drawing.Point(859, 146);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 244);
            this.checkedListBox1.TabIndex = 33;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // CB_VertextColors
            // 
            this.CB_VertextColors.AutoSize = true;
            this.CB_VertextColors.Location = new System.Drawing.Point(859, 435);
            this.CB_VertextColors.Name = "CB_VertextColors";
            this.CB_VertextColors.Size = new System.Drawing.Size(128, 17);
            this.CB_VertextColors.TabIndex = 31;
            this.CB_VertextColors.Text = "Convert Vertex Colors";
            this.CB_VertextColors.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(262, 704);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Sounds: 0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(184, 704);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "Fog: 0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(104, 704);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "KActors: 0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 704);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Decals: 0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(368, 691);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "PlayerStarts: 0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(515, 691);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Skeletal Meshes: 0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 691);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Cameras: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 83);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(437, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "4. Copy actors in the scene, then Paste T3D from udk here, It will be coverted to" +
    " UE4 T3D.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(827, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "3. The tool will search through the files in UE4 by name and use the UE4 path if " +
    "found. If nothing is found or the UE4 Directory is not provided it will convert " +
    "the path from UDK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(805, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "1. Export all meshes and textures from UDK, and import them into UE4 with the sam" +
    "e names. Does not matter the location. You\'ll have to recreate and assign the ma" +
    "terials";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "2. Browse for your UE4 \"Content\" folder in your project directory, ";
            // 
            // BTN_BrowseFolder
            // 
            this.BTN_BrowseFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_BrowseFolder.Location = new System.Drawing.Point(904, 95);
            this.BTN_BrowseFolder.Name = "BTN_BrowseFolder";
            this.BTN_BrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.BTN_BrowseFolder.TabIndex = 22;
            this.BTN_BrowseFolder.Text = "Browse...";
            this.BTN_BrowseFolder.UseVisualStyleBackColor = true;
            this.BTN_BrowseFolder.Click += new System.EventHandler(this.folderPath_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 691);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Directional Lights: 0";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Location = new System.Drawing.Point(13, 146);
            this.richTextBox1.MaximumSize = new System.Drawing.Size(900, 532);
            this.richTextBox1.MinimumSize = new System.Drawing.Size(840, 300);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(840, 532);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "Paste UDK T3D here";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 691);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Spot Lights: 0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 691);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Point Lights: 0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 691);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Static Meshes: 0";
            // 
            // CB_MultiplyPosition
            // 
            this.CB_MultiplyPosition.AutoSize = true;
            this.CB_MultiplyPosition.Checked = true;
            this.CB_MultiplyPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_MultiplyPosition.Location = new System.Drawing.Point(859, 504);
            this.CB_MultiplyPosition.Name = "CB_MultiplyPosition";
            this.CB_MultiplyPosition.Size = new System.Drawing.Size(124, 17);
            this.CB_MultiplyPosition.TabIndex = 15;
            this.CB_MultiplyPosition.Text = "Multiply Position by 2";
            this.CB_MultiplyPosition.UseVisualStyleBackColor = true;
            this.CB_MultiplyPosition.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CB_MultiplyScale
            // 
            this.CB_MultiplyScale.AutoSize = true;
            this.CB_MultiplyScale.Checked = true;
            this.CB_MultiplyScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_MultiplyScale.Location = new System.Drawing.Point(859, 481);
            this.CB_MultiplyScale.Name = "CB_MultiplyScale";
            this.CB_MultiplyScale.Size = new System.Drawing.Size(114, 17);
            this.CB_MultiplyScale.TabIndex = 16;
            this.CB_MultiplyScale.Text = "Multiply Scale by 2";
            this.CB_MultiplyScale.UseVisualStyleBackColor = true;
            // 
            // BTN_CopyToClipboard
            // 
            this.BTN_CopyToClipboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_CopyToClipboard.Location = new System.Drawing.Point(790, 691);
            this.BTN_CopyToClipboard.Name = "BTN_CopyToClipboard";
            this.BTN_CopyToClipboard.Size = new System.Drawing.Size(116, 23);
            this.BTN_CopyToClipboard.TabIndex = 1;
            this.BTN_CopyToClipboard.Text = "Copy To Clipboard";
            this.BTN_CopyToClipboard.UseVisualStyleBackColor = true;
            this.BTN_CopyToClipboard.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_Exit.Location = new System.Drawing.Point(912, 691);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(75, 23);
            this.BTN_Exit.TabIndex = 0;
            this.BTN_Exit.Text = "Exit";
            this.BTN_Exit.UseVisualStyleBackColor = true;
            this.BTN_Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1005, 750);
            this.tabControl1.TabIndex = 23;
            // 
            // CB_UE4Mode
            // 
            this.CB_UE4Mode.AutoSize = true;
            this.CB_UE4Mode.Checked = true;
            this.CB_UE4Mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_UE4Mode.Location = new System.Drawing.Point(859, 412);
            this.CB_UE4Mode.Name = "CB_UE4Mode";
            this.CB_UE4Mode.Size = new System.Drawing.Size(47, 17);
            this.CB_UE4Mode.TabIndex = 34;
            this.CB_UE4Mode.Text = "UE4";
            this.CB_UE4Mode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1029, 794);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UDK To UE4/5 T3D Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox CB_VertextColors;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CB_StaticLights;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_BrowseFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_ContentDir;
        private System.Windows.Forms.TextBox TB_AssetPath;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CB_MultiplyPosition;
        private System.Windows.Forms.Button BTN_Convert;
        private System.Windows.Forms.CheckBox CB_MultiplyScale;
        private System.Windows.Forms.Button BTN_CopyToClipboard;
        private System.Windows.Forms.Button BTN_Exit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox CB_UE4Mode;
    }
}

