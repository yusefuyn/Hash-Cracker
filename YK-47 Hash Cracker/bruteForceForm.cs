using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using YK_47_Hash_Cracker.Create.Hash;
using YK_47_Hash_Cracker.Create.Hash.Enumerators;

namespace YK_47_Hash_Cracker
{
    public partial class bruteForceForm : Form
    {
        public bruteForceForm()
        {
            InitializeComponent();
        }

        private int Second = 0, Minute = 0, Hour = 0, ChangePoint = 0, Tried = 0;
        private int[] Uppercase, Lowercase, Numeric, Special, Alphabeth, startWord, finishWord;
        bool[] dataType = new bool[] { false, false, false, false, false, false, false, false, false, false, false };
        private double ToBeTried = 0;

        private Manager hashMan = new Manager();
        private HashType.Type _type = HashType.Type.MD5;
        private Thread task;

        MD5 md5 = new MD5CryptoServiceProvider();

        private void btnSearchItemAdd_Click(object sender, EventArgs e)
        {
            DataControl();
            txtItems.Text = "";
        }
        private void btnSelectedItemRemove_Click(object sender, EventArgs e)
        {
            if (listItems.SelectedIndex != -1)
                listItems.Items.RemoveAt(listItems.SelectedIndex);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File(*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in listItems.Items)
                    sw.WriteLine(item.ToString());
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        private void btnInport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File(*.txt)|.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string Line = sr.ReadLine();
                while (Line != null && Line != "")
                {
                    listItems.Items.Add(Line.ToUpper());
                    Line = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
        }
        private void bruteForceForm_Load(object sender, EventArgs e)
        {
            comboMethod.Items.Add("MD5");
            comboMethod.Items.Add("SHA1");
            comboMethod.Items.Add("SHA256");
            comboMethod.Items.Add("SHA384");
            comboMethod.Items.Add("SHA512");
            comboMethod.Items.Add("SHA3256");
            comboMethod.Items.Add("SHA3384");
            comboMethod.Items.Add("SHA3512");
            comboMethod.Items.Add("SHAKE128");
            comboMethod.Items.Add("SHAKE256");
            Control.CheckForIllegalCrossThreadCalls = false;
            comboMethod.SelectedIndex = 0;
        }
        private void bruteForceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (task != null)
            {
                if (MessageBox.Show("Yürütülen bir operasyon var durdurmak istediğinize eminmisiniz?", "Sorun !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    task.Abort();
                    task = null;
                }
            }
        }
        private void comboMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMethod.SelectedIndex == 0)
                _type = Create.Hash.Enumerators.HashType.Type.MD5;
            else if (comboMethod.SelectedIndex == 1)
                _type = Create.Hash.Enumerators.HashType.Type.SHA1;
            else if (comboMethod.SelectedIndex == 2)
                _type = Create.Hash.Enumerators.HashType.Type.SHA256;
            else if (comboMethod.SelectedIndex == 3)
                _type = Create.Hash.Enumerators.HashType.Type.SHA384;
            else if (comboMethod.SelectedIndex == 4)
                _type = Create.Hash.Enumerators.HashType.Type.SHA512;
            else if (comboMethod.SelectedIndex == 5)
                _type = Create.Hash.Enumerators.HashType.Type.SHA3256;
            else if (comboMethod.SelectedIndex == 6)
                _type = Create.Hash.Enumerators.HashType.Type.SHA3384;
            else if (comboMethod.SelectedIndex == 7)
                _type = Create.Hash.Enumerators.HashType.Type.SHA3512;
            else if (comboMethod.SelectedIndex == 8)
                _type = Create.Hash.Enumerators.HashType.Type.SHAKE128;
            else if (comboMethod.SelectedIndex == 9)
                _type = Create.Hash.Enumerators.HashType.Type.SHAKE256;
        }
        private void btnStartStop_Click(object sender, EventArgs e)
        {

            lblAlphabe.Text = "";
            bool one = false, two = false;
            foreach (bool item in dataType)
                if (item == true)
                    if (one != true) { one = true; } else { two = true; break; }
            if (one == true && two == true)
            {
                DialogResult res = MessageBox.Show("Çok tipli tarama gerçekleştirmek üzeresiniz doğru sonuç alamayabilirsiniz.\n\nYinede devam etmek istiyormusunuz ?", "Sorun !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    return;
            }


            if (listItems.Items.Count == 0)
            {
                MessageBox.Show("Lütfen aranacak değer giriniz.", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBoxLowCh.Checked == false && checkBoxNum.Checked == false && checkBoxSym.Checked == false && checkBoxUpCh.Checked == false)
            {
                MessageBox.Show("Lütfen kullanılacak karakter seçiniz!", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txtLowChar.Text == "" && txtNumeric.Text == "" && txtSym.Text == "" && txtUpChar.Text == "")
                {
                    MessageBox.Show("Lütfen kullanılacak karakterler giriniz!", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



            if (btnStartStop.Text == "Başlat")
            {
                Second = 0; Minute = 0; Hour = 0; ChangePoint = 0; Tried = 0; ToBeTried = 0;
                AlphabethUpdateMethod();
                StartAndFinishWordUpdate();
                for (int i = 1; i <= numericMaxLength.Value; i++)
                    ToBeTried += (ulong)Math.Pow((double)Alphabeth.Length, (double)i);
                lblToBeTried.Text = "Denenecek :" + (ToBeTried).ToString();
                task = new Thread(() => Start());
                task.Start();
                LockForm();
                lblStartTime.Text = "Başlangıç : " + DateTime.Now.ToString();
                timer1.Start();
                btnStartStop.Text = "Durdur";
            }
            else
            {
                UnLockForm();
                task.Abort();
                task = null;
                btnStartStop.Text = "Başlat";
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Second += 2;
            if (Second >= 60)
            {
                Second = 0;
                Minute++;
            }
            if (Minute >= 60)
            {
                Minute = 0;
                Hour++;
            }
            lblPassingTime.Text = string.Format("Geçen {0} saat {1} dakika {2} saniye.", Hour, Minute, Second);
            lblTried.Text = "Denenen : " + Tried.ToString();

        }
        private void UnLockForm()
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
        }
        private void LockForm()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private string IntArrayToConvertString(int[] searchValue)
        {
            char[] test = new char[searchValue.Length];
            int i = 0;
            foreach (int item in searchValue)
            {
                test[i] = (char)item;
                i++;
            }
            return new string(test);
        }

        private void Search(int[] searchValue)
        {
            string searchVal = IntArrayToConvertString(searchValue);
            lblTriedItem.Text = searchVal;
            lblTriedHashItem.Text = hashMan.Hash(_type, searchVal);
            foreach (var item in listItems.Items)
            {
                if (lblTriedHashItem.Text == item.ToString())
                {
                    dataGridView1.Rows.Add(item.ToString(), searchVal);
                    listItems.Items.RemoveAt(listItems.Items.IndexOf(item));
                    if (listItems.Items.Count == 0)
                        stopTask();
                    break;
                }
            }
            Tried++;
        }

        private void stopTask()
        {
            task.Abort();
            timer1.Stop();
        }

        private void AlphabethUpdateMethod()
        {
            Uppercase = null; Lowercase = null; Numeric = null; Special = null; Alphabeth = null; startWord = null; finishWord = null;
            Lowercase = new int[txtLowChar.Text.Length];
            foreach (char item in txtLowChar.Text)
                Lowercase[txtLowChar.Text.ToList().IndexOf(item)] = Convert.ToInt32(item);

            Uppercase = new int[txtUpChar.Text.Length];
            foreach (char item in txtUpChar.Text)
                Uppercase[txtUpChar.Text.ToList().IndexOf(item)] = Convert.ToInt32(item);

            Numeric = new int[txtNumeric.Text.Length];
            foreach (char item in txtNumeric.Text)
                Numeric[txtNumeric.Text.ToList().IndexOf(item)] = Convert.ToInt32(item);

            Special = new int[txtSym.Text.Length];
            foreach (char item in txtSym.Text)
                Special[txtSym.Text.ToList().IndexOf(item)] = Convert.ToInt32(item);

            int alphabethCount = 0;
            if (checkBoxLowCh.Checked)
                alphabethCount += Lowercase.Length;
            if (checkBoxNum.Checked)
                alphabethCount += Numeric.Length;
            if (checkBoxSym.Checked)
                alphabethCount += Special.Length;
            if (checkBoxUpCh.Checked)
                alphabethCount += Uppercase.Length;
            Alphabeth = new int[alphabethCount];

            int i = 0;
            if (checkBoxLowCh.Checked)
                foreach (int ch in Lowercase)
                {
                    Alphabeth[i] = ch;
                    i++;
                }
            if (checkBoxNum.Checked)
                foreach (char ch in Numeric)
                {
                    Alphabeth[i] = ch;
                    i++;
                }
            if (checkBoxSym.Checked)
                foreach (char ch in Special)
                {
                    Alphabeth[i] = ch;
                    i++;
                }
            if (checkBoxUpCh.Checked)
                foreach (char ch in Uppercase)
                {
                    Alphabeth[i] = ch;
                    i++;
                }
            foreach (int item in Alphabeth)
            {
                lblAlphabe.Text += Convert.ToChar(item);
            }

        }
        private void StartAndFinishWordUpdate()
        {
            startWord = new int[Convert.ToInt32(numericMaxLength.Value)];
            finishWord = new int[Convert.ToInt32(numericMaxLength.Value)];
            for (int i = 0; i <= Convert.ToInt32(numericMaxLength.Value - 1); i++)
            {
                startWord[i] = Alphabeth[0];
                finishWord[i] = Alphabeth[Alphabeth.Length - 1];
            }
        }
        private void DataControl()
        {
            if (txtItems.Text.Length == 32)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[0] = true;
            }
            else if (txtItems.Text.Length == 40)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[1] = true;
            }
            else if (txtItems.Text.Length == 48)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[2] = true;
            }
            else if (txtItems.Text.Length == 56)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[3] = true;
            }
            else if (txtItems.Text.Length == 64)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[4] = true;
            }
            else if (txtItems.Text.Length == 80)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[5] = true;
            }
            else if (txtItems.Text.Length == 96)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[6] = true;
            }
            else if (txtItems.Text.Length == 128)
            {
                listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[7] = true;
            }
            else
            {
                if (MessageBox.Show("Bu veri tanınan hash algoritmalarının sonuçlarına benzemiyor. Yinede eklemek istiyormusunuz ?", "Sorun", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    listItems.Items.Add(txtItems.Text.ToUpper());
                dataType[8] = true;
            }
        }
        private void Start()
        {
            while (listItems.Items.Count != 0)
            {
                foreach (int item in Alphabeth)
                {
                    startWord[ChangePoint] = item;
                    Search(startWord);
                }
                plusMet(1);
            }
        }
        private void plusMet(int order)
        {
            if (order == startWord.Length)
            {
                stopTask();
                return;
            }
            if (startWord[order] == Alphabeth[Alphabeth.Length - 1])
            {
                plusMet(order + 1);
                startWord[order] = Alphabeth[0];
            }
            else
            {
                startWord[order] = Alphabeth[Alphabeth.ToList().IndexOf(startWord[order]) + 1];
            }
        }
    }
}
