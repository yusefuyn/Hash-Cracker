using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YK_47_Hash_Cracker
{
    public partial class dictionaryAttackForm : Form
    {

        private Create.Hash.Enumerators.HashType.Type _type = Create.Hash.Enumerators.HashType.Type.MD5;

        public dictionaryAttackForm()
        {
            InitializeComponent();
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

        private void btnWordListExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File |*.txt";
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
                string Line = sr.ReadLine();
                while (Line != null && Line != "")
                {
                    listWordList.Items.Add(Line);
                    Line = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
        }

        private void btnSearchListItemAdd_Click(object sender, EventArgs e)
        {
            listSearchList.Items.Add(txtSearchList.Text.ToUpper()); txtSearchList.Text = "";
        }

        private void btnSearchItemSelectedRemove_Click(object sender, EventArgs e)
        {
            if (listSearchList.SelectedIndex != -1)
                listSearchList.Items.RemoveAt(listSearchList.SelectedIndex);
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
                sw.Flush();
                sw.Close();
                fs.Close();
            }
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
                sr.Close();
                fs.Close();
            }
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
            Control.CheckForIllegalCrossThreadCalls = false;
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
        Create.Hash.Manager hashMan = new Create.Hash.Manager();
        Task newTask;
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Başlat")
            {
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = listWordList.Items.Count * listSearchList.Items.Count;
                newTask = new Task(() =>
                {
                    foreach (var Item in listWordList.Items)
                    {
                        foreach (var searchItem in listSearchList.Items)
                            if (hashMan.Hash(_type, Item.ToString()) == searchItem.ToString())
                                dataGridView1.Rows.Add(new string[] { searchItem.ToString(), Item.ToString() });
                        progressBar1.Value += 1;
                    }
                    btnStartStop.Text = "Başlat";
                });
                newTask.Start();
                btnStartStop.Text = "Durdur";
            }
            else if (btnStartStop.Text == "Durdur") {
                newTask.Dispose();
                btnStartStop.Text = "Başlat";
            }
        }
        

    }
}
