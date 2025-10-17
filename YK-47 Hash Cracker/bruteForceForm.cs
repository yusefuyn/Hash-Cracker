using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private Manager hashMan = new Manager();
        private HashType.Type _type = HashType.Type.MD5;
        private CancellationTokenSource cts = null;

        private ConcurrentDictionary<string, byte> targets; // thread-safe hedef seti (value unused)
        private long triedCounter = 0, maxTried = 0, lastUiUpdateTicks = 0;
        private int progressUpdateInterval = 1000;
        private ThreadLocal<Manager> threadLocalManager;

        private void btnSearchItemAdd_Click(object sender, EventArgs e)
        {
            listItems.Items.Add(txtItems.Text.ToUpper());
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

        private void button1_Click(object sender, EventArgs e)
        {
            new dictionaryAttackForm().Show();
            this.Hide();
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

                Second = 0; Minute = 0; Hour = 0; ChangePoint = 0; Tried = 0;

                AlphabethUpdateMethod();
                maxTried = CalculateCombine();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = int.MaxValue - 1;
                StartAndFinishWordUpdate();

                int minLen = Convert.ToInt32(numericMinLength.Value);
                int maxLen = Convert.ToInt32(numericMaxLength.Value);
                if (minLen <= 0 || maxLen <= 0 || minLen > maxLen)
                {
                    MessageBox.Show("Lütfen geçerli bir min/max uzunluk seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                targets = new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase);
                foreach (var it in listItems.Items)
                {
                    string s = it.ToString().Trim().ToUpperInvariant();
                    targets.TryAdd(s, 0);
                }

                // threadpool'ü ısıt
                int procCount = Environment.ProcessorCount;
                ThreadPool.SetMinThreads(procCount * 2, procCount * 2);

                // process priority
                try { Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; } catch { }

                cts = new CancellationTokenSource();
                var token = cts.Token;

                // UI lock + hesaplamalar
                LockForm();
                lblStartTime.Text = DateTime.Now.ToString();
                timer1.Start();
                btnStartStop.Text = "Durdur";

                Task.Run(() => StartParallelByWorkers(token), token);
            }
            else
            {
                cts?.Cancel();
                btnStartStop.Text = "Başlat";
                UnLockForm();
            }

        }


        private void StartParallelByWorkers(CancellationToken token)
        {
            int minLen = Convert.ToInt32(numericMinLength.Value);
            int maxLen = Convert.ToInt32(numericMaxLength.Value);

            // hedefleri kopyala
            targets = new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase);
            foreach (var it in listItems.Items) targets.TryAdd(it.ToString().Trim().ToUpperInvariant(), 0);


            // paralelik için lazımalrs
            int workers = Environment.ProcessorCount;
            int alphN = Alphabeth.Length;
            int chunk = (int)Math.Ceiling((double)alphN / workers);

            // görev says
            var tasks = new List<Task>();
            triedCounter = 0;
            threadLocalManager = new ThreadLocal<Manager>(() => new Manager());

            for (int w = 0; w < workers; w++)
            {
                int start = w * chunk;
                int end = Math.Min(start + chunk, alphN);

                if (start >= end) continue;

                tasks.Add(Task.Run(() =>
                {
                    var mgr = threadLocalManager.Value;
                    for (int i = start; i < end; i++)
                    {
                        int prefix = Alphabeth[i];
                        for (int len = minLen; len <= maxLen; len++)
                        {
                            if (token.IsCancellationRequested) return;

                            if (len < 1) continue;
                            int[] current = new int[len];
                            current[0] = prefix;
                            for (int k = 1; k < len; k++) current[k] = Alphabeth[0];

                            bool first = true;
                            while (true)
                            {
                                if (token.IsCancellationRequested) return;

                                if (first) { ProcessAttempt(current, mgr); first = false; }
                                else
                                {
                                    if (!NextWordWithPrefix(current, Alphabeth, prefix)) break;
                                    ProcessAttempt(current, mgr);
                                }

                                if (targets.IsEmpty) { cts?.Cancel(); return; }
                            }
                        }
                    }
                }, token));
            }

            try { Task.WaitAll(tasks.ToArray()); }
            catch (AggregateException) { /* iptal edildi */ }
            finally
            {
                if (threadLocalManager != null)
                {
                    threadLocalManager.Dispose();
                }
            }

            this.BeginInvoke((Action)(() =>
            {
                timer1.Stop();
                UnLockForm();
                btnStartStop.Text = "Başlat";
                MessageBox.Show(targets.IsEmpty ? "Tüm hedefler bulundu." : "İşlem tamamlandı / iptal edildi.");
            }));
        }


        private void ProcessAttempt(int[] word, Manager localHashMan)
        {
            string plain = IntArrayToConvertString(word);
            string hashed = localHashMan.Hash(_type, plain);

            // kontrol 
            if (targets.TryRemove(hashed, out _))
            {
                // bulundu 
                this.BeginInvoke((Action)(() =>
                {
                    dataGridView1.Rows.Add(hashed, plain);
                    // listItems kaldır
                    for (int i = listItems.Items.Count - 1; i >= 0; i--)
                    {
                        if (listItems.Items[i].ToString().Equals(hashed, StringComparison.OrdinalIgnoreCase))
                        {
                            listItems.Items.RemoveAt(i);
                            break;
                        }
                    }
                }));
            }

            // sayacı artır 
            triedCounter = Interlocked.Increment(ref triedCounter);

            // ui yenileme
            if (triedCounter % progressUpdateInterval == 0)
            {
                // kontrol
                long ticks = Stopwatch.GetTimestamp();
                long elapsedTicks = ticks - Interlocked.Read(ref lastUiUpdateTicks);
                double ms = (elapsedTicks * 1000.0) / Stopwatch.Frequency;
                if (ms >= 100) // 100 yada 200ms ideal
                {
                    Interlocked.Exchange(ref lastUiUpdateTicks, ticks);
                    this.BeginInvoke((Action)(() =>
                    {
                        lblTried.Text = triedCounter.ToString();
                        lblTriedItem.Text = plain;
                        lblTriedHashItem.Text = hashed;
                        progressBar1.Value = (int)((double)triedCounter / maxTried * progressBar1.Maximum);

                    }));
                }
            }
        }

        private bool NextWordWithPrefix(int[] word, int[] alph, int prefix)
        {
            for (int pos = word.Length - 1; pos >= 1; pos--) // 0'ı sabit tut
                                                             // NextWord ile prefix uyumlu varyant:
                                                             // sağdan sola increment eder, fakat 0. pozisyon (prefix) sabit kalır.
            {
                int idx = Array.IndexOf(alph, word[pos]);
                if (idx < 0) return false;
                if (idx < alph.Length - 1)
                {
                    word[pos] = alph[idx + 1];
                    for (int j = pos + 1; j < word.Length; j++)
                        word[j] = alph[0];
                    return true;
                }
            }
            return false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Second += 1;
            if (Second >= 60) { Second = 0; Minute++; }
            if (Minute >= 60) { Minute = 0; Hour++; }
            lblPassingTime.Text = string.Format("Geçen {0} saat {1} dakika {2} saniye.", Hour, Minute, Second);
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

        public long CalculateCombine()
        {
            long max = 0;
            int alphabetLength = lblAlphabe.Text.Length;

            for (int i = Convert.ToInt32(numericMinLength.Value); i <= numericMaxLength.Value; i++)
            {
                double x = Math.Pow(alphabetLength, i);
                max += (long)x;
            }
            lblCombine.Text = max.ToString();
            return max;
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
            for (int i = 0; i < listItems.Items.Count; i++)
            {
                string item = listItems.Items[i].ToString();
                if (item.Length == 32)
                {
                    dataType[0] = true;
                }
                else if (item.Length == 40)
                {
                    dataType[1] = true;
                }
                else if (item.Length == 48)
                {
                    dataType[2] = true;
                }
                else if (item.Length == 56)
                {
                    dataType[3] = true;
                }
                else if (item.Length == 64)
                {
                    dataType[4] = true;
                }
                else if (item.Length == 80)
                {
                    dataType[5] = true;
                }
                else if (item.Length == 96)
                {
                    dataType[6] = true;
                }
                else if (item.Length == 128)
                {
                    dataType[7] = true;
                }
            }
        }
    }
}
