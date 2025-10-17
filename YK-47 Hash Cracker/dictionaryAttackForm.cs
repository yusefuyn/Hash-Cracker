using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YK_47_Hash_Cracker
{
    public partial class dictionaryAttackForm : Form
    {
        private Create.Hash.Enumerators.HashType.Type _type = Create.Hash.Enumerators.HashType.Type.MD5;
        Create.Hash.Manager hashMan = new Create.Hash.Manager();

        // Yeni alanlar
        private CancellationTokenSource _cts;
        private Task _runningTask;
        private readonly object _uiLock = new object();
        private int _processed = 0;

        public dictionaryAttackForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            // Control.CheckForIllegalCrossThreadCalls = false; <-- bunu kaldırdık, Invoke kullanacağız
        }

        private void comboMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMethod.SelectedIndex == 0) _type = Create.Hash.Enumerators.HashType.Type.MD5;
            else if (comboMethod.SelectedIndex == 1) _type = Create.Hash.Enumerators.HashType.Type.SHA1;
            else if (comboMethod.SelectedIndex == 2) _type = Create.Hash.Enumerators.HashType.Type.SHA256;
            else if (comboMethod.SelectedIndex == 3) _type = Create.Hash.Enumerators.HashType.Type.SHA384;
            else if (comboMethod.SelectedIndex == 4) _type = Create.Hash.Enumerators.HashType.Type.SHA512;
            else if (comboMethod.SelectedIndex == 5) _type = Create.Hash.Enumerators.HashType.Type.SHA3256;
            else if (comboMethod.SelectedIndex == 6) _type = Create.Hash.Enumerators.HashType.Type.SHA3384;
            else if (comboMethod.SelectedIndex == 7) _type = Create.Hash.Enumerators.HashType.Type.SHA3512;
            else if (comboMethod.SelectedIndex == 8) _type = Create.Hash.Enumerators.HashType.Type.SHAKE128;
            else if (comboMethod.SelectedIndex == 9) _type = Create.Hash.Enumerators.HashType.Type.SHAKE256;
        }
        private void btnWordListItemAdd_Click(object sender, EventArgs e)
        {
            listWordList.Items.Add(txtWordList.Text);
            txtWordList.Text = "";
        }
        private void btnWordListSelectedRemove_Click(object sender, EventArgs e)
        {
            if (listWordList.SelectedIndex != -1)
                listWordList.Items.RemoveAt(listWordList.SelectedIndex);
        }

        private void btnSearchListInport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File |.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string Line = sr.ReadLine();
                while (Line != null && Line != "")
                {
                    listSearchList.Items.Add(Line.ToUpper());
                    Line = sr.ReadLine();
                }
                sr.Close(); fs.Close();
            }
        }
        private void btnSearchItemSelectedRemove_Click(object sender, EventArgs e)
        {
            if (listSearchList.SelectedIndex != -1)
                listSearchList.Items.RemoveAt(listSearchList.SelectedIndex);
        }

        private void btnSearchListItemAdd_Click(object sender, EventArgs e)
        {
            listSearchList.Items.Add(txtSearchList.Text);
            txtSearchList.Text = "";
        }
        private void btnSearchListExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File |*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in listSearchList.Items)
                    sw.WriteLine(item.ToString());
                sw.Flush(); sw.Close(); fs.Close();
            }
        }
        private void btnWordListExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); sfd.Filter = "Text File |*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in listWordList.Items)
                    sw.WriteLine(item.ToString());
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        private void btnWordListInport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File |.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string Line = sr.ReadLine(); while (Line != null && Line != "")
                {
                    listWordList.Items.Add(Line);
                    Line = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_runningTask != null && !_runningTask.IsCompleted)
            {
                // Durdur
                _cts.Cancel();
                btnStartStop.Enabled = false; // iptal edilirken 2x tıklanmasın
                return;
            }

            // Başlat
            if (listWordList.Items.Count == 0 || listSearchList.Items.Count == 0)
            {
                MessageBox.Show("Word list veya Search list boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UI kitlenmelerini engelle
            btnStartStop.Text = "Durdur";
            btnStartStop.Enabled = true;
            comboMethod.Enabled = false;
            btnWordListItemAdd.Enabled = false;
            btnWordListInport.Enabled = false;
            btnWordListExport.Enabled = false;
            btnSearchListInport.Enabled = false;
            btnSearchListExport.Enabled = false;
            listWordList.Enabled = false;
            listSearchList.Enabled = false;
            dataGridView1.Rows.Clear();

            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            _processed = 0;

            // Optimize: aranan hashleri HashSet'e koy (böylece lookup O(1))
            var searchSet = new HashSet<string>(listWordList.Items.Cast<object>().Select(o => o.ToString()).ToList(), StringComparer.OrdinalIgnoreCase);
            var words = listSearchList.Items.Cast<string>().Select(x=> x.ToString()).ToList();

            // ProgressBar'ı "kelime bazlı" göstereceğiz (her kelime için 1 ilerleme).
            // Neden? Çünkü artık her kelime için sadece 1 hash hesaplıyor ve tüm searchSet ile karşılaştırma O(1) lookup ile yapılıyor.
            progressBar1.Minimum = 0;
            progressBar1.Maximum = words.Count;
            progressBar1.Value = 0;

            var parallelOptions = new ParallelOptions()
            {
                CancellationToken = token,
                MaxDegreeOfParallelism = Environment.ProcessorCount // CPU çekirdeği sayısını kullan
            };

            // Paralel görev başlat
            _runningTask = Task.Run(() =>
            {
                var results = new ConcurrentBag<(string Hash, string Plain)>();

                try
                {
                    Parallel.ForEach(words, parallelOptions, (word) =>
                    {
                        // Check cancellation
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                        // Hesapla yalnızca 1 kere
                        string computed = null;
                        try
                        {
                            computed = hashMan.Hash(_type, word);
                        }
                        catch (Exception ex)
                        {
                            // Hash hesaplama hatası olursa, kaydet veya atla
                            // Burada atlıyoruz
                            computed = null;
                        }

                        if (!string.IsNullOrEmpty(computed))
                        {
                            if (searchSet.Contains(computed))
                            {
                                results.Add((computed, word));
                                // UI'ye thread-safe ekleme
                                this.BeginInvoke(new Action(() =>
                                {
                                    dataGridView1.Rows.Add(new string[] { computed, word });
                                }));
                            }
                        }

                        // Progress update (thread-safe)
                        int proc = Interlocked.Increment(ref _processed);
                        if (proc % 5 == 0 || proc == words.Count) // her 5 kelimede bir veya sonuncuda UI güncelle
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Value = Math.Min(proc, progressBar1.Maximum);
                            }));
                        }
                    });
                }
                catch (OperationCanceledException)
                {
                    // iptal edildi
                }
                finally
                {
                    // Son UI işleri
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar1.Value = progressBar1.Maximum;
                        btnStartStop.Text = "Başlat";
                        comboMethod.Enabled = true;
                        btnWordListItemAdd.Enabled = true;
                        btnWordListInport.Enabled = true;
                        btnWordListExport.Enabled = true;
                        btnSearchListInport.Enabled = true;
                        btnSearchListExport.Enabled = true;
                        listWordList.Enabled = true;
                        listSearchList.Enabled = true;
                        btnStartStop.Enabled = true;
                    }));
                }
            }, token);
        }

        // (Opsiyonel) Form kapatılırken iptal et
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
            base.OnFormClosing(e);
        }
    }
}
