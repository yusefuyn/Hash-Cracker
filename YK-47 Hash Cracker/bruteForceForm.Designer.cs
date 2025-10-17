namespace YK_47_Hash_Cracker
{
    partial class bruteForceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listItems = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtItems = new System.Windows.Forms.TextBox();
            this.btnInport = new System.Windows.Forms.Button();
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.btnSelectedItemRemove = new System.Windows.Forms.Button();
            this.lblSearchList = new System.Windows.Forms.Label();
            this.btnSearchItemAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSym = new System.Windows.Forms.TextBox();
            this.txtNumeric = new System.Windows.Forms.TextBox();
            this.txtUpChar = new System.Windows.Forms.TextBox();
            this.txtLowChar = new System.Windows.Forms.TextBox();
            this.numericMaxLength = new System.Windows.Forms.NumericUpDown();
            this.lblMaxLen = new System.Windows.Forms.Label();
            this.numericMinLength = new System.Windows.Forms.NumericUpDown();
            this.lblMinLen = new System.Windows.Forms.Label();
            this.checkBoxSym = new System.Windows.Forms.CheckBox();
            this.checkBoxNum = new System.Windows.Forms.CheckBox();
            this.checkBoxUpCh = new System.Windows.Forms.CheckBox();
            this.checkBoxLowCh = new System.Windows.Forms.CheckBox();
            this.lblChar = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblToBeTried = new System.Windows.Forms.Label();
            this.lblTriedText = new System.Windows.Forms.Label();
            this.lblTriedHashItem = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblPassingTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblCombine = new System.Windows.Forms.Label();
            this.lblTried = new System.Windows.Forms.Label();
            this.lblCombineText = new System.Windows.Forms.Label();
            this.lblTriedItem = new System.Windows.Forms.Label();
            this.lblPassingTimeText = new System.Windows.Forms.Label();
            this.lblStartTimeText = new System.Windows.Forms.Label();
            this.lblAlphabe = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listItems);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.txtItems);
            this.panel1.Controls.Add(this.btnInport);
            this.panel1.Controls.Add(this.lblSearchItem);
            this.panel1.Controls.Add(this.btnSelectedItemRemove);
            this.panel1.Controls.Add(this.lblSearchList);
            this.panel1.Controls.Add(this.btnSearchItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 135);
            this.panel1.TabIndex = 11;
            // 
            // listItems
            // 
            this.listItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listItems.FormattingEnabled = true;
            this.listItems.Location = new System.Drawing.Point(157, 34);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(441, 95);
            this.listItems.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(604, 78);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtItems
            // 
            this.txtItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItems.Location = new System.Drawing.Point(157, 8);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(441, 20);
            this.txtItems.TabIndex = 1;
            this.txtItems.Text = "098F6BCD4621D373CADE4E832627B4F6";
            // 
            // btnInport
            // 
            this.btnInport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInport.Location = new System.Drawing.Point(604, 106);
            this.btnInport.Name = "btnInport";
            this.btnInport.Size = new System.Drawing.Size(108, 23);
            this.btnInport.TabIndex = 8;
            this.btnInport.Text = "İçe Aktar";
            this.btnInport.UseVisualStyleBackColor = true;
            this.btnInport.Click += new System.EventHandler(this.btnInport_Click);
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.Location = new System.Drawing.Point(6, 5);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(145, 23);
            this.lblSearchItem.TabIndex = 2;
            this.lblSearchItem.Text = "Aranacak Değer :";
            this.lblSearchItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectedItemRemove
            // 
            this.btnSelectedItemRemove.Location = new System.Drawing.Point(604, 35);
            this.btnSelectedItemRemove.Name = "btnSelectedItemRemove";
            this.btnSelectedItemRemove.Size = new System.Drawing.Size(108, 23);
            this.btnSelectedItemRemove.TabIndex = 7;
            this.btnSelectedItemRemove.Text = "Seçileni Kaldır";
            this.btnSelectedItemRemove.UseVisualStyleBackColor = true;
            this.btnSelectedItemRemove.Click += new System.EventHandler(this.btnSelectedItemRemove_Click);
            // 
            // lblSearchList
            // 
            this.lblSearchList.Location = new System.Drawing.Point(6, 28);
            this.lblSearchList.Name = "lblSearchList";
            this.lblSearchList.Size = new System.Drawing.Size(145, 23);
            this.lblSearchList.TabIndex = 3;
            this.lblSearchList.Text = "Aranacak Liste :";
            this.lblSearchList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearchItemAdd
            // 
            this.btnSearchItemAdd.Location = new System.Drawing.Point(604, 6);
            this.btnSearchItemAdd.Name = "btnSearchItemAdd";
            this.btnSearchItemAdd.Size = new System.Drawing.Size(108, 23);
            this.btnSearchItemAdd.TabIndex = 6;
            this.btnSearchItemAdd.Text = "Ekle";
            this.btnSearchItemAdd.UseVisualStyleBackColor = true;
            this.btnSearchItemAdd.Click += new System.EventHandler(this.btnSearchItemAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSym);
            this.panel2.Controls.Add(this.txtNumeric);
            this.panel2.Controls.Add(this.txtUpChar);
            this.panel2.Controls.Add(this.txtLowChar);
            this.panel2.Controls.Add(this.numericMaxLength);
            this.panel2.Controls.Add(this.lblMaxLen);
            this.panel2.Controls.Add(this.numericMinLength);
            this.panel2.Controls.Add(this.lblMinLen);
            this.panel2.Controls.Add(this.checkBoxSym);
            this.panel2.Controls.Add(this.checkBoxNum);
            this.panel2.Controls.Add(this.checkBoxUpCh);
            this.panel2.Controls.Add(this.checkBoxLowCh);
            this.panel2.Controls.Add(this.lblChar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 128);
            this.panel2.TabIndex = 12;
            // 
            // txtSym
            // 
            this.txtSym.Location = new System.Drawing.Point(203, 76);
            this.txtSym.Name = "txtSym";
            this.txtSym.Size = new System.Drawing.Size(351, 20);
            this.txtSym.TabIndex = 14;
            this.txtSym.Text = "\"é!\'^+%&/()=?_>£#$½{[]}\\|*";
            // 
            // txtNumeric
            // 
            this.txtNumeric.Location = new System.Drawing.Point(203, 53);
            this.txtNumeric.Name = "txtNumeric";
            this.txtNumeric.Size = new System.Drawing.Size(351, 20);
            this.txtNumeric.TabIndex = 13;
            this.txtNumeric.Text = "0123456789";
            // 
            // txtUpChar
            // 
            this.txtUpChar.Location = new System.Drawing.Point(203, 30);
            this.txtUpChar.Name = "txtUpChar";
            this.txtUpChar.Size = new System.Drawing.Size(351, 20);
            this.txtUpChar.TabIndex = 12;
            this.txtUpChar.Text = "ASDFGHJKLŞİZXCVBNMÖÇQWERTYUIOPĞÜ";
            // 
            // txtLowChar
            // 
            this.txtLowChar.Location = new System.Drawing.Point(203, 7);
            this.txtLowChar.Name = "txtLowChar";
            this.txtLowChar.Size = new System.Drawing.Size(351, 20);
            this.txtLowChar.TabIndex = 11;
            this.txtLowChar.Text = "asdfghjklşizxcvbnmöçqwertyuıopğü";
            // 
            // numericMaxLength
            // 
            this.numericMaxLength.Location = new System.Drawing.Point(434, 101);
            this.numericMaxLength.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMaxLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxLength.Name = "numericMaxLength";
            this.numericMaxLength.Size = new System.Drawing.Size(120, 20);
            this.numericMaxLength.TabIndex = 10;
            this.numericMaxLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblMaxLen
            // 
            this.lblMaxLen.Location = new System.Drawing.Point(283, 98);
            this.lblMaxLen.Name = "lblMaxLen";
            this.lblMaxLen.Size = new System.Drawing.Size(145, 23);
            this.lblMaxLen.TabIndex = 9;
            this.lblMaxLen.Text = "Maximum Uzunluk :";
            this.lblMaxLen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericMinLength
            // 
            this.numericMinLength.Location = new System.Drawing.Point(157, 101);
            this.numericMinLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinLength.Name = "numericMinLength";
            this.numericMinLength.Size = new System.Drawing.Size(120, 20);
            this.numericMinLength.TabIndex = 8;
            this.numericMinLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMinLen
            // 
            this.lblMinLen.Location = new System.Drawing.Point(6, 98);
            this.lblMinLen.Name = "lblMinLen";
            this.lblMinLen.Size = new System.Drawing.Size(145, 23);
            this.lblMinLen.TabIndex = 7;
            this.lblMinLen.Text = "Minimum Uzunluk :";
            this.lblMinLen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxSym
            // 
            this.checkBoxSym.AutoSize = true;
            this.checkBoxSym.Location = new System.Drawing.Point(157, 78);
            this.checkBoxSym.Name = "checkBoxSym";
            this.checkBoxSym.Size = new System.Drawing.Size(55, 17);
            this.checkBoxSym.TabIndex = 6;
            this.checkBoxSym.Text = "@!_...";
            this.checkBoxSym.UseVisualStyleBackColor = true;
            // 
            // checkBoxNum
            // 
            this.checkBoxNum.AutoSize = true;
            this.checkBoxNum.Location = new System.Drawing.Point(157, 55);
            this.checkBoxNum.Name = "checkBoxNum";
            this.checkBoxNum.Size = new System.Drawing.Size(41, 17);
            this.checkBoxNum.TabIndex = 5;
            this.checkBoxNum.Text = "0-9";
            this.checkBoxNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpCh
            // 
            this.checkBoxUpCh.AutoSize = true;
            this.checkBoxUpCh.Location = new System.Drawing.Point(157, 32);
            this.checkBoxUpCh.Name = "checkBoxUpCh";
            this.checkBoxUpCh.Size = new System.Drawing.Size(43, 17);
            this.checkBoxUpCh.TabIndex = 4;
            this.checkBoxUpCh.Text = "A-Z";
            this.checkBoxUpCh.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowCh
            // 
            this.checkBoxLowCh.AutoSize = true;
            this.checkBoxLowCh.Checked = true;
            this.checkBoxLowCh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLowCh.Location = new System.Drawing.Point(157, 9);
            this.checkBoxLowCh.Name = "checkBoxLowCh";
            this.checkBoxLowCh.Size = new System.Drawing.Size(40, 17);
            this.checkBoxLowCh.TabIndex = 3;
            this.checkBoxLowCh.Text = "a-z";
            this.checkBoxLowCh.UseVisualStyleBackColor = true;
            // 
            // lblChar
            // 
            this.lblChar.Location = new System.Drawing.Point(6, 5);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(145, 23);
            this.lblChar.TabIndex = 2;
            this.lblChar.Text = "Kullanılacak Karakterler :";
            this.lblChar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 344);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(718, 236);
            this.dataGridView1.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Hash";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Değer";
            this.Column2.Name = "Column2";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 321);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(718, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartStop.Location = new System.Drawing.Point(0, 298);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(718, 23);
            this.btnStartStop.TabIndex = 17;
            this.btnStartStop.Text = "Başlat";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboMethod);
            this.panel3.Controls.Add(this.lblMethod);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 35);
            this.panel3.TabIndex = 16;
            // 
            // comboMethod
            // 
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Location = new System.Drawing.Point(157, 6);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(409, 21);
            this.comboMethod.TabIndex = 10;
            this.comboMethod.SelectedIndexChanged += new System.EventHandler(this.comboMethod_SelectedIndexChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(6, 5);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(145, 23);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Yöntem :";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToBeTried
            // 
            this.lblToBeTried.Location = new System.Drawing.Point(702, 217);
            this.lblToBeTried.Name = "lblToBeTried";
            this.lblToBeTried.Size = new System.Drawing.Size(10, 10);
            this.lblToBeTried.TabIndex = 10;
            this.lblToBeTried.Text = "Denenecek Sayısı";
            this.lblToBeTried.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblToBeTried.Visible = false;
            // 
            // lblTriedText
            // 
            this.lblTriedText.Location = new System.Drawing.Point(12, 26);
            this.lblTriedText.Name = "lblTriedText";
            this.lblTriedText.Size = new System.Drawing.Size(200, 23);
            this.lblTriedText.TabIndex = 11;
            this.lblTriedText.Text = "Denenen Sayısı :";
            this.lblTriedText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTriedHashItem
            // 
            this.lblTriedHashItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTriedHashItem.Location = new System.Drawing.Point(3, 209);
            this.lblTriedHashItem.Name = "lblTriedHashItem";
            this.lblTriedHashItem.Size = new System.Drawing.Size(712, 23);
            this.lblTriedHashItem.TabIndex = 12;
            this.lblTriedHashItem.Text = "Hash(Denenen)";
            this.lblTriedHashItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblPassingTime);
            this.panel4.Controls.Add(this.lblStartTime);
            this.panel4.Controls.Add(this.lblCombine);
            this.panel4.Controls.Add(this.lblTried);
            this.panel4.Controls.Add(this.lblCombineText);
            this.panel4.Controls.Add(this.lblTriedItem);
            this.panel4.Controls.Add(this.lblPassingTimeText);
            this.panel4.Controls.Add(this.lblStartTimeText);
            this.panel4.Controls.Add(this.lblAlphabe);
            this.panel4.Controls.Add(this.lblTriedHashItem);
            this.panel4.Controls.Add(this.lblToBeTried);
            this.panel4.Controls.Add(this.lblTriedText);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 344);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(718, 236);
            this.panel4.TabIndex = 20;
            this.panel4.Visible = false;
            // 
            // lblPassingTime
            // 
            this.lblPassingTime.Location = new System.Drawing.Point(218, 95);
            this.lblPassingTime.Name = "lblPassingTime";
            this.lblPassingTime.Size = new System.Drawing.Size(200, 23);
            this.lblPassingTime.TabIndex = 22;
            this.lblPassingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(218, 72);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(200, 23);
            this.lblStartTime.TabIndex = 21;
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCombine
            // 
            this.lblCombine.Location = new System.Drawing.Point(218, 49);
            this.lblCombine.Name = "lblCombine";
            this.lblCombine.Size = new System.Drawing.Size(200, 23);
            this.lblCombine.TabIndex = 20;
            this.lblCombine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTried
            // 
            this.lblTried.Location = new System.Drawing.Point(218, 26);
            this.lblTried.Name = "lblTried";
            this.lblTried.Size = new System.Drawing.Size(200, 23);
            this.lblTried.TabIndex = 19;
            this.lblTried.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCombineText
            // 
            this.lblCombineText.Location = new System.Drawing.Point(12, 49);
            this.lblCombineText.Name = "lblCombineText";
            this.lblCombineText.Size = new System.Drawing.Size(200, 23);
            this.lblCombineText.TabIndex = 18;
            this.lblCombineText.Text = "Kombinasyon Sayısı :";
            this.lblCombineText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTriedItem
            // 
            this.lblTriedItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTriedItem.Location = new System.Drawing.Point(3, 187);
            this.lblTriedItem.Name = "lblTriedItem";
            this.lblTriedItem.Size = new System.Drawing.Size(712, 23);
            this.lblTriedItem.TabIndex = 17;
            this.lblTriedItem.Text = "Denenen";
            this.lblTriedItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassingTimeText
            // 
            this.lblPassingTimeText.Location = new System.Drawing.Point(12, 95);
            this.lblPassingTimeText.Name = "lblPassingTimeText";
            this.lblPassingTimeText.Size = new System.Drawing.Size(200, 23);
            this.lblPassingTimeText.TabIndex = 16;
            this.lblPassingTimeText.Text = "Geçen Süre :";
            this.lblPassingTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartTimeText
            // 
            this.lblStartTimeText.Location = new System.Drawing.Point(12, 72);
            this.lblStartTimeText.Name = "lblStartTimeText";
            this.lblStartTimeText.Size = new System.Drawing.Size(200, 23);
            this.lblStartTimeText.TabIndex = 14;
            this.lblStartTimeText.Text = "Başlangıç Süresi :";
            this.lblStartTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAlphabe
            // 
            this.lblAlphabe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlphabe.Location = new System.Drawing.Point(6, 3);
            this.lblAlphabe.Name = "lblAlphabe";
            this.lblAlphabe.Size = new System.Drawing.Size(709, 23);
            this.lblAlphabe.TabIndex = 13;
            this.lblAlphabe.Text = "Alfabe";
            this.lblAlphabe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tahmini Toplam Süre :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(218, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 23);
            this.label2.TabIndex = 24;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Kalan Süre :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(218, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 23);
            this.label4.TabIndex = 26;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bruteForceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 580);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "bruteForceForm";
            this.Text = "[Yussefuynstein] Hash Rocker V1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bruteForceForm_FormClosing);
            this.Load += new System.EventHandler(this.bruteForceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listItems;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Button btnInport;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.Button btnSelectedItemRemove;
        private System.Windows.Forms.Label lblSearchList;
        private System.Windows.Forms.Button btnSearchItemAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblChar;
        private System.Windows.Forms.CheckBox checkBoxSym;
        private System.Windows.Forms.CheckBox checkBoxNum;
        private System.Windows.Forms.CheckBox checkBoxUpCh;
        private System.Windows.Forms.CheckBox checkBoxLowCh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblMaxLen;
        private System.Windows.Forms.NumericUpDown numericMinLength;
        private System.Windows.Forms.Label lblMinLen;
        private System.Windows.Forms.NumericUpDown numericMaxLength;
        private System.Windows.Forms.TextBox txtSym;
        private System.Windows.Forms.TextBox txtNumeric;
        private System.Windows.Forms.TextBox txtUpChar;
        private System.Windows.Forms.TextBox txtLowChar;
        private System.Windows.Forms.Label lblToBeTried;
        private System.Windows.Forms.Label lblTriedText;
        private System.Windows.Forms.Label lblTriedHashItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAlphabe;
        private System.Windows.Forms.Label lblPassingTimeText;
        private System.Windows.Forms.Label lblStartTimeText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTriedItem;
        private System.Windows.Forms.Label lblCombineText;
        private System.Windows.Forms.Label lblPassingTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblCombine;
        private System.Windows.Forms.Label lblTried;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}