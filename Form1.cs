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
        public Form1()
        {
            InitializeComponent();

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
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                tbInput.Enabled = true;// Режим дозволу
                tbInput.Focus();
                tClock.Start();
                bStart.Text = "Stop"; // зміна тексту на кнопці на "Стоп"
                this.Mode = false;
                startToolStripMenuItem.Text = "Stop";
            }
            else
            {
                tbInput.Enabled = false;// Режим заборони введення
                tClock.Stop();
                bStart.Text = "Start";// зміна тексту на кнопці на "Пуск"
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task();
                label1.Text = MajorObject.Read();
                startToolStripMenuItem.Text = "Старт";
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
            A.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)// Виклик діалогового вікна збереження файлу
            {
                MajorObject.WriteSaveFileName(sfdSave.FileName); // написання імені файлу
                MajorObject.SaveToFile(); // метод збереження в файл
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK) // Виклик діалогового вікна відкриття файлу

                MessageBox.Show(ofdOpen.FileName);
            
        }
    }
}
