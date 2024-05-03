using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Moskalchuk_IKM722a_2kurs_project
{
    public partial class Form1 : Form
    {
        private bool Mode;
        private MajorWorks MajorObject;

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Current date and time:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();

            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show ("Attention, it's been 30 seconds");
            tClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MajorObject = new MajorWorks();
            MajorObject.SetTime();
            MajorObject.Modify = false;// заборона запису
            About A = new About(); 
            A.tAbout.Start();
            A.ShowDialog();
            this.Mode = true;

            toolTip1.SetToolTip(bSearch, "Press the button for the find");
            toolTip1.IsBalloon = true;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (!Mode)
            {
                tbInput.Enabled = false;// Режим заборони введення
                tClock.Stop();
                bStart.Text = "Start";// зміна тексту на кнопці на "Пуск"
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task();
                label1.Text = MajorObject.Read();
                startToolStripMenuItem.Text = "Start";
            }
            else
            {
                tbInput.Enabled = true;// Режим дозволу
                tbInput.Focus();
                tClock.Start();
                bStart.Text = "Stop"; // зміна тексту на кнопці на "Стоп"
                this.Mode = false;
                startToolStripMenuItem.Text = "Stop";
            }
        }


        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            tClock.Stop();
            tClock.Start();
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("Wrong character", "Misstake");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s;
            s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
            MessageBox.Show(s, "During the program "); 
        }

        private void onDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] disks = System.IO.Directory.GetLogicalDrives(); // Строковий масив з логічніх дисків
             string disk = "";
            foreach (string diskPath in disks)
            {
                try
                {
                    System.IO.DriveInfo drive = new System.IO.DriveInfo(diskPath);
                    long totalSizeGB = drive.TotalSize / (1024 * 1024 * 1024); // Переведення у ГБ
                    long freeSpaceGB = drive.TotalFreeSpace / (1024 * 1024 * 1024); // Переведення у ГБ
                    disk += $"{drive.Name} - {totalSizeGB} GB - {freeSpaceGB} GB{(char)13}";
                }
            
                catch
                {
                    disk += $"{diskPath} - don't ready{(char)13}"; // якщо пристрій не готовий,
                                                                   // то виведення на екран ім’я пристрою і повідомлення «не готовий»
                }
            }

            MessageBox.Show(disk, "Disks");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.progressBar1.Hide();
            A.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK) // Виклик діалогу збереження файлу
            {
                MajorObject.WriteSaveFileName(sfdSave.FileName); // Запис імені файлу для збереження
                MajorObject.Generator();
                MajorObject.SaveToFile(); // метод збереження в файл
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK) // Виклик діалогового вікна відкриття файу
            {
                MajorObject.WriteOpenFileName(ofdOpen.FileName); // відкриття файлу M
                MajorObject.ReadFromFile(dgwOpen); // читання даних з файлу
            }
               
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //4555856
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MajorObject.SaveFileNameExists()) // задане ім’я файлу існує?
                MajorObject.SaveToFile(); // зберегти дані в файл
            else
                saveAsToolStripMenuItem_Click(sender, e); //
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MajorObject.NewRec();
            tbInput.Clear();// очистити вміст тексту
            label1.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MajorObject.Modify)
                if (MessageBox.Show("Don't save!!. Continue out?", "ATTENTION",MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true; // припинити закриття
        }

        
        private void bSearch_Click_1(object sender, EventArgs e)
        {
            MajorObject.Find(tbSearch.Text); //пошук
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgwOpen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
