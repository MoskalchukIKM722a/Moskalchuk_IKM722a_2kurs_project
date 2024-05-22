using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections;


namespace Moskalchuk_IKM722a_2kurs_project
{
    internal class MajorWorks
    {
        private System.DateTime TimeBegin;
        private string Data; 
        private string Result;
        public bool Modify;
        private int Key;// поле ключа
        private string SaveTextFileName;// ім'я файлу для запису текстового файлу

        public Stack myStack = new Stack();
        public string[] myArr = new string[100];

        public Queue myQueue = new Queue();
        public string[] smyQueue = new string[100];

        public void SetTime() 
        {
            this.TimeBegin = System.DateTime.Now;
        }
        public System.DateTime GetTime() // Метод отримання часу завершення програми
        {
            return this.TimeBegin;
        }
        public void Write(string D)
        {
            this.Data = D;
        }
        public string Read()
        {
            return this.Result;
        }
        public void Task() 
        {
            string[] dataParts = Data.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Зберегти числа у масив:
            int[] NData = new int[dataParts.Length];
            for (int i = 0; i < dataParts.Length; i++)
            {
                NData[i] = int.Parse(dataParts[i]);
            }

            // Знайти всі піки:
            for (int i = 1; i < NData.Length - 1; i++)
            {
                if ((NData[i - 1] >= 0 && NData[i] < 0) || (NData[i - 1] < 0 && NData[i] >= 0))
                {
                    
                    this.Result += $"Peak is in position {i}: {NData[i]}\n"; // Додати результат до змінної
                }
            }
            this.Modify = true; // Дозвіл запису
        }
    
     private string SaveFileName;// ім’я файлу для запису
     private string OpenFileName;// ім’я файлу для читання
     public void WriteSaveFileName(string S)// метод запису даних в об'єкт
     {
        this.SaveFileName = S;// запам'ятати ім’я файлу для запису
     }
     public void WriteOpenFileName(string S)
     {
        this.OpenFileName = S;// запам'ятати ім’я файлу для відкриття
     }
        public void SaveToFile() // Запис даних до файлу
        {
            if (!this.Modify)
                return;
            try
            {
                Stream S; // створення потоку
                if (File.Exists(this.SaveFileName))// існує файл?
                {
                    S = File.Open(this.SaveFileName, FileMode.Append);// Відкриття файлу для збереження
                }
                else
                {
                    S = File.Open(this.SaveFileName, FileMode.Create);// створити файл
                }
                Buffer D = new Buffer(); // створення буферної змінної
                D.Data = this.Data;
                D.Result = Convert.ToString(this.Result);
                D.Key = Key;
                Key++;
                BinaryFormatter BF = new BinaryFormatter(); // створення об'єкта для форматування
                BF.Serialize(S, D);
                S.Flush(); // очищення буфера потоку
                S.Close(); // закриття потоку
                this.Modify = false; // Заборона повторного запису
                
            }
            catch
            {
                MessageBox.Show("Error working with file"); // Виведення на екран повідомлення "Помилка роботи з файлом"
            }
        }

        public void ReadFromFile(System.Windows.Forms.DataGridView DG) // зчитування з файлу
        {
            try
            {
                if (!File.Exists(this.OpenFileName))
                {
                    MessageBox.Show("Don't have file"); // Виведення на екран повідомлення "файлу немає"
                    return;
                }
                Stream S; // створення потоку
                S = File.Open(this.OpenFileName, FileMode.Open); // зчитування даних з
                Buffer D;
                object O; // буферна змінна для контролю формату
                BinaryFormatter BF = new BinaryFormatter(); // створення об'єкту для форматування
                                                            //формуємо таблицю
                System.Data.DataTable MT = new System.Data.DataTable();
                System.Data.DataColumn cKey = new System.Data.DataColumn("Key");// формуємо колонку "Ключ"
                System.Data.DataColumn cInput = new System.Data.DataColumn("Input data");// формуємо колонку "Вхідні дані
                System.Data.DataColumn cResult = new System.Data.DataColumn("Result");   // формуємо колонку "Результат"

                MT.Columns.Add(cKey);// додавання ключа
                MT.Columns.Add(cInput);// додавання вхідних даних
                MT.Columns.Add(cResult);// додавання результату
                while (S.Position < S.Length)
                {
                    O = BF.Deserialize(S); // десеріалізація
                    D = O as Buffer;
                    if (D == null) break;
                    // Виведення даних на екран
                    System.Data.DataRow MR;
                    MR = MT.NewRow();
                    MR["Key"] = D.Key; // Занесення в таблицю номер
                    MR["Input data"] = D.Data; // Занесення в таблицю вхідних даних
                    MR["Result"] = D.Result; // Занесення в таблицю результатів
                    MT.Rows.Add(MR);
                }
                DG.DataSource = MT;
                S.Close(); // закриття
            }
            catch
            {
                MessageBox.Show("Error file"); // Виведення на екран повідомлення "Помилка файлу"
            }
        } // ReadFromFile закінчився

        public void Generator() // метод формування ключового поля
        {
            try
            {
                if (!File.Exists(this.SaveFileName)) // існує файл?
                {
                    Key = 1;
                    return;
                }
                Stream S; // створення потоку
                S = File.Open(this.SaveFileName, FileMode.Open); // Відкриття файлу
                Buffer D;
                object O; // буферна змінна для контролю формату
                BinaryFormatter BF = new BinaryFormatter(); // створення елементу для форматування
                while (S.Position < S.Length)
                {
                    O = BF.Deserialize(S);
                    D = O as Buffer;
                    if (D == null) break;
                    Key = D.Key;
                }
                Key++;
                S.Close();
            }
            catch
            {
                MessageBox.Show("Error file"); // Виведення на екран повідомлення "Помилка файлу"
            }
        }

        public bool SaveFileNameExists()
        {
            if (this.SaveFileName == null)
                return false;
            else return true;
        }

        public void NewRec() // новий запис
        {
            this.Data = ""; // "" - ознака порожнього рядка
            this.Result = null; // для string- null
        }

        public void Find(string Num) // пошук
        {
            int N;
            try
            {
                N = Convert.ToInt16(Num); // перетворення номера рядка в int16 для відображення
            }
            catch
            {
                MessageBox.Show("search query error"); // Виведення на екран повідомлення "помилка пошукового запиту"
            
                 return;
            }

            try
            {
                if (!File.Exists(this.OpenFileName))
                {
                    MessageBox.Show("no file"); // Виведення на екран повідомлення "файлу немає"
                
                  return;
                }
                Stream S; // створення потоку
                S = File.Open(this.OpenFileName, FileMode.Open); // відкриття файлу
                Buffer D;
                object O; // буферна змінна для контролю формату
                BinaryFormatter BF = new BinaryFormatter(); // створення об'єкта для форматування
            
                while (S.Position < S.Length)
                {
                    O = BF.Deserialize(S);
                    D = O as Buffer;
                    if (D == null) break;
                    
                    if (D.Key == N) // перевірка дорівнює чи номер пошуку номеру рядка в таблиці
                    {
                        string ST;
                        ST = "record contains:" + (char)13 + "N" + Num + "Inputs data:" + D.Data + "Result:" + D.Result;

                        MessageBox.Show(ST, "Record found"); // Виведення на екран  повідомлення "запис містить", номер, вхідних даних і результат

                        S.Close();
                        return;
                    }
                }
                S.Close();
                MessageBox.Show("Record not found"); // Виведення на екран повідомлення "Запис не знайдена"
            }
            catch
            {
                MessageBox.Show("File error"); // Виведення на екран повідомлення "Помилка файлу"
            }
        } // Find закінчився

        public void WriteSaveTextFileName(string S)
        {
            this.SaveTextFileName = S;
        }

        public bool SaveTextFileNameExists()
        {
            if (this.SaveTextFileName == null)
                return false;
            else return true;
        }
        public string ReadSaveTextFileName()
        {
            return SaveTextFileName;
        }

        public void SaveToTextFile(string name, System.Windows.Forms.DataGridView D)
        {
            try
            {
                System.IO.StreamWriter textFile;
                if (!File.Exists(name))
                {
                    textFile = new System.IO.StreamWriter(name);
                }
                else
                {
                    textFile = new System.IO.StreamWriter(name, true);
                }
                for (int i = 0; i < D.RowCount - 1; i++)
                {
                    textFile.WriteLine("{0};{1};{2}", D[0, i].Value.ToString(), D[1,

                    i].Value.ToString(), D[2, i].Value.ToString());

                }
                textFile.Close();
            }
            catch
            {
                MessageBox.Show("Error working with file ");
            }
        }

        private string OpenTextFileName;
        public void WriteOpenTextFileName(string S)
        {
            this.OpenTextFileName = S;
        }

    }
}
