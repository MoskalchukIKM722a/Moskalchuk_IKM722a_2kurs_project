using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Moskalchuk_IKM722a_2kurs_project
{
    public partial class Form1 : Form
    {
        private bool Mode;
        private SaveFileDialog sf;
        private MajorWorks MajorObject;

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        string InputData = String.Empty;
        delegate void SetTextCallback(string text);

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
            // отримуємо список СОМ портов системи
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            };
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
            Application.DoEvents();

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

        
        private void Push_Click(object sender, EventArgs e)
        {
            MajorObject.myStack.Push(Stacktb.Text);
            MajorObject.myArr[MajorObject.myArr.Length - MajorObject.myStack.Count] =
            Stacktb.Text;

            LabelStack.Text = "";
            for (int i = 0; i < MajorObject.myArr.Length; i++)
            {
                if (MajorObject.myArr[i] != null)
                {
                    LabelStack.Text += MajorObject.myArr[i] + (char)13;
                }
                else

                {
                    continue;
                }
            }
        }
        private void Pop_Click(object sender, EventArgs e)
        {
            if (MajorObject.myStack.Count == 0)
                MessageBox.Show("\nStack is empty!");
            else
            {
                MajorObject.myArr[MajorObject.myArr.Length - MajorObject.myStack.Count] =

                null;

                if (MajorObject.myStack.Count > 0)
                {
                    MessageBox.Show("Pop " + MajorObject.myStack.Pop());
                }
                label1.Text = "";
                for (int i = 0; i < MajorObject.myArr.Length; i++)
                {
                    if (MajorObject.myArr[i] != null)

                    {
                        label1.Text += MajorObject.myArr[i] + (char)13;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (MajorObject.myStack.Count == 0)
                    MessageBox.Show("\nStack is empty!");
            }
        }

        private void Peek_Click(object sender, EventArgs e)
        {
            if (MajorObject.myStack.Count > 0)

            {
                MessageBox.Show("Peek " + MajorObject.myStack.Peek());
            }
            if (MajorObject.myStack.Count == 0)
                MessageBox.Show("\nStack is empty!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Enqueue_Click(object sender, EventArgs e)
        {
            MajorObject.myQueue.Enqueue(Queuetb.Text);
            MajorObject.smyQueue[MajorObject.myQueue.Count - 1] = Queuetb.Text;
            LabelQueue.Text = "";
            for (int i = 0; i < MajorObject.smyQueue.Length; i++)
            {
                if (MajorObject.smyQueue[i] != null)
                {
                    LabelQueue.Text += MajorObject.smyQueue[i] + (char)13;
                }
                else
                {
                    continue;
                }
            }
        }

        private void Peek_q_Click(object sender, EventArgs e)
        {
            if (MajorObject.myQueue.Count > 0)
            {
                MessageBox.Show("Peek " + MajorObject.myQueue.Peek());
            }
            if (MajorObject.myQueue.Count == 0)
                MessageBox.Show("\nQueue is empty!");
        }

        private void Dequeue_Click(object sender, EventArgs e)
        {
            if (MajorObject.myQueue.Count == 0)

                MessageBox.Show("\nQueue is empty!");
            else
            {
                MajorObject.smyQueue[0] = null;

                // Зрушення елементів вліво на 1 позицію
                for (int i = 0; i < MajorObject.smyQueue.Length - 1; i++)
                {
                    MajorObject.smyQueue[i] = MajorObject.smyQueue[i + 1];
                }
                // Витяг елемента з черги
                if (MajorObject.myQueue.Count > 0)
                {
                    MessageBox.Show("Dequeue " + MajorObject.myQueue.Dequeue());
                }
                // Формування текста для виведення на екран
                LabelQueue.Text = "";
                for (int i = 0; i < MajorObject.smyQueue.Length - 1; i++)
                {
                    if (MajorObject.smyQueue[i] != null)
                    {
                        LabelQueue.Text += MajorObject.smyQueue[i] + (char)13;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (MajorObject.myQueue.Count == 0)
                    MessageBox.Show("\nQueue is empty!");
            }
        }

       

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.Filter = @"Текстовий файл (*.txt)|*.txt|Текстові файли TXT(*.txt)|*.txt|CSV-файл (*.csv)|*.csv|Bin-файл (*.bin)|*.bin";


            if (sf.ShowDialog() == DialogResult.OK)
            {
                MajorObject.WriteSaveTextFileName(sf.FileName);
                MajorObject.SaveToTextFile(sf.FileName, dgwOpen);
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MajorObject.SaveTextFileNameExists())
            { 
                MajorObject.SaveToTextFile(MajorObject.ReadSaveTextFileName(), dgwOpen);
            }
            else
            {
                saveAsToolStripMenuItem1_Click(sender, e);
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();

            o.Filter = @"Текстовий файл (*.txt)|*.txt|Текстовий файл TXT(*.txt)|*.txt|CSV-файл (*.csv)|*.csv|Bin-файл (*.bin)|*.bin";

            if (o.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(o.FileName, Encoding.Default);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Start")

            {
                if (port.IsOpen) port.Close();
                #region Задаем параметры порта
                port.PortName = comboBox1.Text;
                port.BaudRate = Convert.ToInt32(comboBox2.Text);
                port.DataBits = Convert.ToInt32(comboBox3.Text);
                switch (comboBox4.Text)
                {
                    case "Space":
                        port.Parity = Parity.Space;
                        break;
                    case "Chet":
                        port.Parity = Parity.Even;
                        break;
                    case "Odd":
                        port.Parity = Parity.Odd;
                        break;
                    case "Marker":
                        port.Parity = Parity.Mark;
                        break;
                    default:
                        port.Parity = Parity.None;
                        break;
                }
                switch (comboBox5.Text)
                {
                    case "2":
                        port.StopBits = StopBits.Two;
                        break;
                    case "1.5":
                        port.StopBits = StopBits.OnePointFive;
                        break;
                    case "No":
                        port.StopBits = StopBits.None;
                        break;

                    default:
                        port.StopBits = StopBits.One;
                        break;
                }
                switch (comboBox6.Text)
                {
                    case "Xon/Xoff":
                        port.Handshake = Handshake.XOnXOff;
                        break;
                    case "Hardware":
                        port.Handshake = Handshake.RequestToSend;
                        break;
                    default:
                        port.Handshake = Handshake.None;
                        break;
                }
                #endregion
                try
                {
                    port.Open();
                    button2.Text = "Stop";
                    // button2.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Port " + port.PortName + " Impossible open!",

                    "Mistake!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    comboBox1.SelectedText = "";
                    button2.Text = "Start";
                }
            }
            else
            {
                if (port.IsOpen) port.Close();
                button2.Text = "Start";
                // button2.Enabled = true;
            }
        }

        void AddData(string text)
        {
            listBox1.Items.Add(text);
        }

        private void SetText(string text)
        {
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.AddData(text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")

            {
                groupBox2.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = port.ReadExisting();
            if (InputData != String.Empty)
            {
                SetText(InputData);
            }
        }
    }
}
