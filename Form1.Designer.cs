namespace Moskalchuk_IKM722a_2kurs_project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tClock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.onDrivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgwOpen = new System.Windows.Forms.DataGridView();
            this.bSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // tClock
            // 
            this.tClock.Interval = 30000;
            this.tClock.Tick += new System.EventHandler(this.tClock_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.workToolStripMenuItem,
            this.informationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mewToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // mewToolStripMenuItem
            // 
            this.mewToolStripMenuItem.Name = "mewToolStripMenuItem";
            this.mewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mewToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.mewToolStripMenuItem.Text = "New";
            this.mewToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // workToolStripMenuItem
            // 
            this.workToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.toolStripSeparator4,
            this.onDrivesToolStripMenuItem});
            this.workToolStripMenuItem.Name = "workToolStripMenuItem";
            this.workToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.workToolStripMenuItem.Text = "Work";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.startToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.bStart_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(138, 6);
            // 
            // onDrivesToolStripMenuItem
            // 
            this.onDrivesToolStripMenuItem.Name = "onDrivesToolStripMenuItem";
            this.onDrivesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.onDrivesToolStripMenuItem.Text = "About drives";
            this.onDrivesToolStripMenuItem.Click += new System.EventHandler(this.onDrivesToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aboutProgramToolStripMenuItem.Text = "About program";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.DefaultExt = "SoM";
            this.ofdOpen.FileName = "openFileDialog1";
            this.ofdOpen.Filter = "work files|*.SoM|All filles|*.*";
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "SoM";
            this.sfdSave.FileName = "saveFileDialog";
            this.sfdSave.Filter = "work files|*.SoM|All filles|*.*";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(741, 483);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::Moskalchuk_IKM722a_2kurs_project.Properties.Resources.smaug_the_hobbit_the_hobbit_the_desolation_of_smaug_wallpaper_preview;
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bStart);
            this.tabPage1.Controls.Add(this.tbInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data entry";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(338, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(271, 313);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(157, 33);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tbInput
            // 
            this.tbInput.Enabled = false;
            this.tbInput.Location = new System.Drawing.Point(240, 192);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(223, 20);
            this.tbInput.TabIndex = 2;
            this.tbInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInput_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::Moskalchuk_IKM722a_2kurs_project.Properties.Resources.smaug_the_hobbit_the_hobbit_the_desolation_of_smaug_wallpaper_preview;
            this.tabPage2.Controls.Add(this.dgwOpen);
            this.tabPage2.Controls.Add(this.bSearch);
            this.tabPage2.Controls.Add(this.tbSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Work with file";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgwOpen
            // 
            this.dgwOpen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOpen.Location = new System.Drawing.Point(372, 6);
            this.dgwOpen.Name = "dgwOpen";
            this.dgwOpen.Size = new System.Drawing.Size(358, 184);
            this.dgwOpen.TabIndex = 4;
            this.dgwOpen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOpen_CellContentClick);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(311, 319);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 5;
            this.bSearch.Text = "Find";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click_1);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(473, 207);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(153, 20);
            this.tbSearch.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(727, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOpen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Timer tClock;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onDrivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.DataGridView dgwOpen;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

