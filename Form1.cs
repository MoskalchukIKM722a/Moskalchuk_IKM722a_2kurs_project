using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            About A = new About(); 
            A.tAbout.Start();
            A.ShowDialog();
            MajorObject = new MajorWorks();
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
    }
}
