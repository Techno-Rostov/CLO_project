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
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;


namespace CLO_project
{
    public partial class Form1 : Form
    {
        int num = 1000;
        int decnumber = 1;
        List<string> points = new List<string>();
        List<string> stringsWPoints = new List<string>();
        List<string> somedata = new List<string>();
        List<string> titles = new List<string>();
        List<string> newpoints = new List<string>();
        List<string> newhex = new List<string>();
        List<string> newText = new List<string>();
        List<string> NewFile = new List<string>();
        public OpenFileDialog OPF = new OpenFileDialog();
        public SaveFileDialog SF = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < listText.Count; i++)
            {
                listText[i].Enabled = false;
            }
            btn.Enabled = false;
        }
        #region Пользовательский интерфейс
        public void CellsButton_Click(object sender, EventArgs e)
        {
            ChooseFile();
        }
        public void FillCells(string filename)
        {
            //Записываем массив точек в таблицу.
            HexFromFile(filename);
            for (int i = 0; i < listText.Count; i++)
            {
                listText[i].Text = points[i];
            }
        }
        public void ChartPoints()
        {
            for (int i = 0; i < listText.Count; i++)
            {
                if (float.TryParse(listText[i].Text, NumberStyles.Float, CultureInfo.CreateSpecificCulture("ru-RU"), out float dec))
                {
                    listText[i].Text = dec.ToString();
                    float y = float.Parse(listText[i].Text, NumberStyles.Float, CultureInfo.CreateSpecificCulture("ru-RU"));
                    int x = i + 1;
                    chart1.Series[0].Points.AddXY(x, y);
                    chart1.Series[0].ToolTip = "X = #VALX{N1} \nY = #VALY{N3}";
                    listText[i].Enabled = true;

                }

            }

        }
        public void ChooseFile()
        {
            OPF.Title = "Открыть файл";
            OPF.Filter = "Intel HEX|*.hex";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                btn.Enabled = true;
                ClearData();
                string filename = OPF.FileName;
                FillCells(filename);
                ChartPoints();
            }
        }
        public void ClearData()
        {

            chart1.Series[0].Points.Clear();
            titles.Clear();
            somedata.Clear();
            stringsWPoints.Clear();
            points.Clear();
            //NewFile.Clear();
            for (int i = 0; i < listText.Count; i++)
            {
                listText[i].Clear();
                listText[i].Enabled = true;
            }
        }
        public void TB_PressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Thread.Sleep(150);
                for (int i = 0; i < listText.Count; i++)
                {
                    if (listText[i].Text.Contains('.'))
                    {
                        listText[i].Text.Replace('.', ','); //Работает только для точки с numpad.
                    }

                    if (float.TryParse(listText[i].Text, NumberStyles.Float, CultureInfo.CreateSpecificCulture("ru-RU"), out float dec))
                    {
                        //Проверка вводимых значений.
                        if (dec <= 1 && dec >= 0.3)
                        {
                            string decstring = dec.ToString();
                            if (decstring.Length>4)
                            {
                                decstring = decstring.Substring(0, 4);
                            }
                            listText[i].Text = decstring;
                            chart1.Series[0].Points.Clear();
                            ChartPoints();
                        }
                        else
                        {
                            listText[i].Text = points[i];
                        }
                    }
                    else
                    {
                        listText[i].Text = points[i];
                    }
                }
            }
        }


        public void btn_SaveNewFile_Click(object sender, EventArgs e)
        {
            newpoints.Clear();
            NewPoints();
            if (newpoints.Count != 100)
            {
                newpoints.Clear();
            }
            else
            {
                MakeNewFile();
            }
        }
        public void ShowHelp1(object sender, EventArgs e)
        {
            toolTip1.Show(" Для начала работы нажмите на кнопку и выберите файл в формате \".hex.\" \n Ниже появится график, соответствующий данным из файла. Одна точка соответствует одному месяцу.", CellsButton);
        }
        public void ShowHelp2(object sender, EventArgs e)
        {
            toolTip1.Show(" В таблице ниже представлены коэффициенты компенсации. Каждая ячейка соответствует точке на графике слева. \n Вы можете задать свои в диапазоне от 0,30 до 1 с разделителем-запятой. \n Нажмите Enter, чтобы увидеть изменения на графике. Эта кнопка сохранит изменения в новом или существующем файле.", btn);
        }
        public void Form1_MouseClick(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        public void Instruction_Click(object sender, EventArgs e)
        {
            Instr Ins = new Instr();
            if (Application.OpenForms["Instr"]==null)
            {
                Ins.Show();
            }
            else
            {
                Ins.Close();
            }
        }

        #endregion

        #region Чтение данных из файла

        public void SplitString()
        {
            foreach (string str in stringsWPoints)
            {
                //Делим строку на подстроки и загоняем в массив точек.
                int pointSearch = str.Length / 4;
                for (int j = 0; j < pointSearch; j++)
                {
                    string hexnumber = str.Substring(j * 4, 4);
                    decnumber = int.Parse(hexnumber, NumberStyles.HexNumber);   //Точки изначально в формате hex, поэтому для удобства
                    double decfloat = (double)decnumber / num;                    //переводим их в десятичный формат. Выводим в таблицу в виде дробных чисел,
                    string dec = decfloat.ToString();                           //где целая часть - тысячи, в дробной части - сотни, десятки и единицы.
                    points.Add(dec);
                }
            }

        }
        public void HexFromFile(string filename)
        {
            int sumSearch = 0;
            //Чтение файла и преобразование данных.
            string[] file = File.ReadAllLines(filename);

            for (int i = file.Length - 15; i < file.Length - 1; i++)
            {
                string withPoints = file[i].Substring(9, file[i].Length - 11); //У куска, в котором встречаются точки, убираем заголовок и CRC-сумму,
                int pointSearch = withPoints.Length / 4;                       //делим оставшееся на 4 и считаем, сколько частей получилось. Это нужно далее.
                sumSearch += pointSearch;
            }

            for (int i = 0; i < file.Count(); i++)
            {
                string title = file[i].Substring(1, 8);
                titles.Add(title);              //Собираем массив из заголовков.
                string Data = file[i].Substring(9, file[i].Length - 11);    //Убираем везде заголовки и сумму, готовим файл к изменениям.
                if (i < file.Length - 15)
                {
                    somedata.Add(Data);         //Собираем в массив все, что не нужно изменять.
                }
                if (i == file.Length - 15)
                {
                    int unusDataWP = sumSearch - 100;
                    string unusData = Data.Substring(0, unusDataWP * 4);    //Строго определенную строку сохраняем в зависимости от того, сколько 
                    somedata.Add(unusData);                                 //кусочков выше получилось. Если таких кусочков больше 100 - есть что сохранить.
                    int datalength = Data.Length - unusDataWP * 4;
                    if (datalength != 0)    //Если кусков окажется ровно 100, в этой строке нет точек - мы ее просто сохранили выше (и datalength=0). 
                    {
                        string stringPoints = Data.Substring(unusDataWP * 4, datalength); //Иначе - делим остаток на равные части.  
                        stringsWPoints.Add(stringPoints);                                 //Записываем в массив точек.
                    }
                }
                if (i > file.Length - 15 && i < file.Count() - 1)
                {
                    stringsWPoints.Add(Data);           //Начиная отсюда у нас будут только строки с точками (не считая последней нулевой), их мы делим на
                }                                       //равные части и записываем в массив точек. В сумме их получится 100.
            }
            SplitString();
        }


        #endregion

        #region Заполнение нового файла
        public void NewPoints()
        {
            //Собрали массив новых точек.
            for (int i = 0; i < listText.Count; i++)
            {
                if (listText[i].Text.Contains("."))
                {
                    listText[i].Text.Replace('.', ','); //Работает только для точки с numpad.
                }
                if (float.TryParse(listText[i].Text, NumberStyles.Float, CultureInfo.CreateSpecificCulture("ru-RU"), out float dec))
                {
                    //Проверка вводимых значений.
                    if (dec <= 1 && dec >= 0.3)
                    {
                        string decstring = dec.ToString();
                        if (decstring.Length > 4)
                        {
                            decstring = decstring.Substring(0, 4);
                        }
                        listText[i].Text = decstring;
                        newpoints.Add(listText[i].Text);
                    }
                    else
                    {
                        listText[i].Text = points[i];
                    }

                }
                else
                {
                    listText[i].Text = points[i];
                }
            }

        }

        public void MakeNewFile()
        {
            //Чистим буфер и собираем файл.
            newText.Clear();
            NewFile.Clear();
            newhex.Clear();
            GetNewHex();
            MakeNewText();
            SaveFileDialog SF = new SaveFileDialog();
            SF.Title = "Сохранить файл";
            SF.Filter = "Intel HEX|*.hex";
            if (SF.ShowDialog() == DialogResult.OK)
            {
                string newfilename = SF.FileName;
                File.WriteAllLines(newfilename, NewFile);   //Записываем в новый файл или перезаписываем ЦЕЛИКОМ старый.
            }
        }
        public void CollectFileText(string fileString)
        {
            fileString += CRC(fileString); //Считаем CRC-сумму для полученной строки и записываем в конец строки.
            newText.Add(fileString);       //Записываем полученную строку в массив строк для нового файла.
        }
        public void MakeNewText()
        {
            //Собираем новый текст: неизмененная часть + новые точки.
            string fileString = "";
            for (int i = 0; i < titles.Count; i++)
            {
                if (i < titles.Count - 15)
                {
                    fileString = titles[i] + somedata[i];
                    CollectFileText(fileString);
                }

                //Собираем строки, содержащие новые точки:
                if (i >= titles.Count - 15 && i < titles.Count)
                {
                    if (i == somedata.Count - 1)
                    {
                        //Для случая, когда первые несколько точек содержатся в одной строке с неизменными данными:
                        fileString = titles[titles.Count - 15] + somedata[titles.Count - 15];
                    }
                    else
                    {
                        //Во всех остальных случаях (+ для записи строк исключительно из точек):
                        fileString = titles[i];
                    }
                    for (int j = 0; j < newhex.Count + 1; j++)
                    {
                        if (i < titles.Count - 1)
                        {
                            //В каждой строке, содержащей только точки, может быть до 8ми таких точек:
                            if (fileString.Length < 40 && j < newhex.Count)
                            {

                                fileString += newhex[j];
                            }
                            else
                            {
                                CollectFileText(fileString);
                                i++;
                                j--;
                                fileString = titles[i];
                            }
                        }
                    }
                }
                if (i == titles.Count - 1)
                {
                    fileString = titles[i];
                    CollectFileText(fileString);
                }
            }
            foreach (string str in newText)
            {
                //Здесь построково собираем новый текст в файл в формате intel.hex.
                string newstr = ":" + str;
                NewFile.Add(newstr);
            }


        }
        public string FormNewhex(string str)
        {
            //Преобразование новых точек из таблицы в шестнадцатеричный формат.
            double decfloat = double.Parse(str, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("ru-RU")) * 1000;
            int decnum = (int)decfloat;
            return decnum.ToString("X4");
        }
        public void GetNewHex()
        {

            foreach (string str in newpoints)
            {
                //Точки из массива новых точек переводим в шестнадцатеричный формат и собираем в новый массив.
                newhex.Add(FormNewhex(str));
            }
        }
        public string CRC(string hex)
        {
            //Здесь мы считаем CRC-сумму каждой строки.
            int sum = 0;
            int countInd = hex.Length / 2;
            for (int i = 0; i < countInd; i++)
            {
                string doubbyte = hex.Substring(i * 2, 2);
                int decnumber = int.Parse(doubbyte, NumberStyles.HexNumber);
                sum += decnumber;
            }
            string hexsum = sum.ToString("X4");
            string sub = hexsum.Substring(hexsum.Length - 2);
            int razn = int.Parse("FF", NumberStyles.HexNumber) - int.Parse(sub, NumberStyles.HexNumber) + 1;
            return razn.ToString("X2");
        }
        #endregion
    }
}
