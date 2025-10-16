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
        private CancellationTokenSource cts = null;

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
            if (cts != null)
            {
                var r = MessageBox.Show("Devam eden bir işlem var sonlandırmak istediğinizden eminmisiniz ?", "", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    cts.Cancel();
                    cts = null;
                    this.Close();
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
                _type = Create.Hash.Enumerators.HashType.Type.SHA3256; // daha sonra sunucu kur ona yönlendir !
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



            if (btnStartStop.Text == "Başlat")
            {

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

                if (txtLowChar.Text == "" && txtNumeric.Text == "" && txtSym.Text == "" && txtUpChar.Text == "")
                {
                    MessageBox.Show("Lütfen kullanılacak karakterler giriniz!", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblAlphabe.Text = "";

                if (dataType.Where(x => x == true).Count() > 1)
                {
                    DialogResult res = MessageBox.Show("Çok tipli tarama gerçekleştirmek üzeresiniz doğru sonuç alamayabilirsiniz.\n\nYinede devam etmek istiyormusunuz ?", "Sorun !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes)
                        return;
                }

                Second = 0; Minute = 0; Hour = 0; ChangePoint = 0; Tried = 0; ToBeTried = 0;

                AlphabethUpdateMethod();
                StartAndFinishWordUpdate();

                int minLen = Convert.ToInt32(numericMinLength.Value);
                int maxLen = Convert.ToInt32(numericMaxLength.Value);
                if (minLen <= 0 || maxLen <= 0 || minLen > maxLen)
                {
                    MessageBox.Show("Lütfen geçerli bir min/max uzunluk seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ToBeTried = 0;
                for (int i = minLen; i <= maxLen; i++)
                    ToBeTried += Math.Pow((double)Alphabeth.Length, i);
                lblToBeTried.Text = "Denenecek :" + ToBeTried.ToString("N0");


                cts = new CancellationTokenSource();
                var token = cts.Token;

                Task.Run(() => Start(token), token);

                LockForm();
                lblStartTime.Text = "Başlangıç : " + DateTime.Now.ToString();
                timer1.Start();
                btnStartStop.Text = "Durdur";
            }
            else
            {
                cts?.Cancel();
                btnStartStop.Text = "Başlat";
                UnLockForm();
            }

        }


        private void Start(CancellationToken token)
        {
            int minLen = Convert.ToInt32(numericMinLength.Value);
            int maxLen = Convert.ToInt32(numericMaxLength.Value);

            for (int len = minLen; len <= maxLen; len++)
            {
                // currentWord uzunluğu len kadar olsun
                int[] currentWord = new int[len];
                for (int i = 0; i < len; i++)
                    currentWord[i] = Alphabeth[0]; // en küçük karakterle başla

                bool first = true;
                while (true)
                {
                    if (token.IsCancellationRequested)
                        return;

                    // İlk kelimeyi de dene (first == true)
                    if (first)
                    {
                        Search(currentWord);
                        first = false;
                    }
                    else
                    {
                        // sonraki kelimeyi üret; eğer döndü false ise o uzunluktaki kombinasyonlar bitti
                        if (!NextWord(currentWord, Alphabeth))
                            break;

                        Search(currentWord);
                    }

                    // Eğer tüm hedefler bulunduysa çık
                    bool empty = false;
                    this.Invoke((Action)(() => empty = listItems.Items.Count == 0));
                    if (empty) return;
                }
            }

            // Tüm uzunluklar bitti
            this.BeginInvoke((Action)(() =>
            {
                timer1.Stop();
                UnLockForm();
                MessageBox.Show("Tüm kombinasyonlar bitti ;((");
                btnStartStop.Text = "Başlat";
            }));
        }

        private bool NextWord(int[] word, int[] alph)
        {
            for (int pos = word.Length - 1; pos >= 0; pos--)
            {
                int idx = Array.IndexOf(alph, word[pos]);
                if (idx < 0) return false; // beklenmeyen karakter

                if (idx < alph.Length - 1)
                {
                    // bu pozisyonu bir sonraki karaktere yükselt
                    word[pos] = alph[idx + 1];
                    // sağ tarafı (daha düşük önemli indeksleri) en küçük karaktere sıfırla
                    for (int j = pos + 1; j < word.Length; j++)
                        word[j] = alph[0];
                    return true;
                }
                // eğer bu pozisyon son karakterse carry var -> bir yukarı geç
            }

            // Tüm pozisyonlarda taşma oldu
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Second += 1; // 2 değil 1
            if (Second >= 60) { Second = 0; Minute++; }
            if (Minute >= 60) { Minute = 0; Hour++; }
            lblPassingTime.Text = string.Format("Geçen {0} saat {1} dakika {2} saniye.", Hour, Minute, Second);
            lblTried.Text = "Denenen : " + Tried.ToString("N0");
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
            var sb = new StringBuilder(searchValue.Length);
            foreach (int ch in searchValue)
                sb.Append((char)ch);
            return sb.ToString();
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
                    {
                        UnLockForm();
                        cts?.Cancel();
                        btnStartStop.Text = "Başlat";
                    }
                    break;
                }
            }
            Tried++;
        }

        private void AlphabethUpdateMethod()
        {
            var lower = txtLowChar.Text.ToCharArray();
            var upper = txtUpChar.Text.ToCharArray();
            var num = txtNumeric.Text.ToCharArray();
            var sym = txtSym.Text.ToCharArray();

            List<int> alpha = new List<int>();

            if (checkBoxLowCh.Checked)
                foreach (var c in lower)
                    if (!alpha.Contains((int)c)) alpha.Add((int)c);
            if (checkBoxNum.Checked)
                foreach (var c in num)
                    if (!alpha.Contains((int)c)) alpha.Add((int)c);
            if (checkBoxSym.Checked)
                foreach (var c in sym)
                    if (!alpha.Contains((int)c)) alpha.Add((int)c);
            if (checkBoxUpCh.Checked)
                foreach (var c in upper)
                    if (!alpha.Contains((int)c)) alpha.Add((int)c);

            Alphabeth = alpha.ToArray();

            // gösterim
            lblAlphabe.Text = new string(Alphabeth.Select(i => (char)i).ToArray());
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
            bool add = true;
            if (txtItems.Text.Length == 32)
            {
                dataType[0] = true;
            }
            else if (txtItems.Text.Length == 40)
            {
                dataType[1] = true;
            }
            else if (txtItems.Text.Length == 48)
            {
                dataType[2] = true;
            }
            else if (txtItems.Text.Length == 56)
            {
                dataType[3] = true;
            }
            else if (txtItems.Text.Length == 64)
            {
                dataType[4] = true;
            }
            else if (txtItems.Text.Length == 80)
            {
                dataType[5] = true;
            }
            else if (txtItems.Text.Length == 96)
            {
                dataType[6] = true;
            }
            else if (txtItems.Text.Length == 128)
            {
                dataType[7] = true;
            }
            else
            {
                if (MessageBox.Show("Bu veri tanınan hash algoritmalarının sonuçlarına benzemiyor. Yinede eklemek istiyormusunuz ?", "Sorun", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    add = false;
                else
                    dataType[8] = true;
            }
            if (add)
                listItems.Items.Add(txtItems.Text.Trim().ToUpperInvariant());

        }
    }
}
