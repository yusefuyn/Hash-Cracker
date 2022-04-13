namespace YK_47_Hash_Cracker
{
    partial class dictionaryAttackForm
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
            this.listWordList = new System.Windows.Forms.ListBox();
            this.txtWordList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWordListItemAdd = new System.Windows.Forms.Button();
            this.btnWordListSelectedRemove = new System.Windows.Forms.Button();
            this.btnWordListInport = new System.Windows.Forms.Button();
            this.btnWordListExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listSearchList = new System.Windows.Forms.ListBox();
            this.btnSearchListExport = new System.Windows.Forms.Button();
            this.txtSearchList = new System.Windows.Forms.TextBox();
            this.btnSearchListInport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchItemSelectedRemove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchListItemAdd = new System.Windows.Forms.Button();
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listWordList
            // 
            this.listWordList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listWordList.FormattingEnabled = true;
            this.listWordList.Location = new System.Drawing.Point(112, 33);
            this.listWordList.Name = "listWordList";
            this.listWordList.Size = new System.Drawing.Size(409, 95);
            this.listWordList.TabIndex = 0;
            // 
            // txtWordList
            // 
            this.txtWordList.Location = new System.Drawing.Point(112, 7);
            this.txtWordList.Name = "txtWordList";
            this.txtWordList.Size = new System.Drawing.Size(409, 20);
            this.txtWordList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Değer :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Liste :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnWordListItemAdd
            // 
            this.btnWordListItemAdd.Location = new System.Drawing.Point(527, 4);
            this.btnWordListItemAdd.Name = "btnWordListItemAdd";
            this.btnWordListItemAdd.Size = new System.Drawing.Size(108, 23);
            this.btnWordListItemAdd.TabIndex = 6;
            this.btnWordListItemAdd.Text = "Ekle";
            this.btnWordListItemAdd.UseVisualStyleBackColor = true;
            this.btnWordListItemAdd.Click += new System.EventHandler(this.btnWordListItemAdd_Click);
            // 
            // btnWordListSelectedRemove
            // 
            this.btnWordListSelectedRemove.Location = new System.Drawing.Point(527, 33);
            this.btnWordListSelectedRemove.Name = "btnWordListSelectedRemove";
            this.btnWordListSelectedRemove.Size = new System.Drawing.Size(108, 23);
            this.btnWordListSelectedRemove.TabIndex = 7;
            this.btnWordListSelectedRemove.Text = "Seçileni Kaldır";
            this.btnWordListSelectedRemove.UseVisualStyleBackColor = true;
            this.btnWordListSelectedRemove.Click += new System.EventHandler(this.btnWordListSelectedRemove_Click);
            // 
            // btnWordListInport
            // 
            this.btnWordListInport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWordListInport.Location = new System.Drawing.Point(527, 105);
            this.btnWordListInport.Name = "btnWordListInport";
            this.btnWordListInport.Size = new System.Drawing.Size(108, 23);
            this.btnWordListInport.TabIndex = 8;
            this.btnWordListInport.Text = "İçe Aktar";
            this.btnWordListInport.UseVisualStyleBackColor = true;
            this.btnWordListInport.Click += new System.EventHandler(this.btnWordListInport_Click);
            // 
            // btnWordListExport
            // 
            this.btnWordListExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWordListExport.Location = new System.Drawing.Point(527, 76);
            this.btnWordListExport.Name = "btnWordListExport";
            this.btnWordListExport.Size = new System.Drawing.Size(108, 23);
            this.btnWordListExport.TabIndex = 9;
            this.btnWordListExport.Text = "Dışa Aktar";
            this.btnWordListExport.UseVisualStyleBackColor = true;
            this.btnWordListExport.Click += new System.EventHandler(this.btnWordListExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listWordList);
            this.panel1.Controls.Add(this.btnWordListExport);
            this.panel1.Controls.Add(this.txtWordList);
            this.panel1.Controls.Add(this.btnWordListInport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnWordListSelectedRemove);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnWordListItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 135);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listSearchList);
            this.panel2.Controls.Add(this.btnSearchListExport);
            this.panel2.Controls.Add(this.txtSearchList);
            this.panel2.Controls.Add(this.btnSearchListInport);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSearchItemSelectedRemove);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnSearchListItemAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 123);
            this.panel2.TabIndex = 11;
            // 
            // listSearchList
            // 
            this.listSearchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listSearchList.FormattingEnabled = true;
            this.listSearchList.Location = new System.Drawing.Point(112, 33);
            this.listSearchList.Name = "listSearchList";
            this.listSearchList.Size = new System.Drawing.Size(409, 82);
            this.listSearchList.TabIndex = 0;
            // 
            // btnSearchListExport
            // 
            this.btnSearchListExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchListExport.Location = new System.Drawing.Point(527, 66);
            this.btnSearchListExport.Name = "btnSearchListExport";
            this.btnSearchListExport.Size = new System.Drawing.Size(108, 23);
            this.btnSearchListExport.TabIndex = 9;
            this.btnSearchListExport.Text = "Dışa Aktar";
            this.btnSearchListExport.UseVisualStyleBackColor = true;
            this.btnSearchListExport.Click += new System.EventHandler(this.btnSearchListExport_Click);
            // 
            // txtSearchList
            // 
            this.txtSearchList.Location = new System.Drawing.Point(112, 7);
            this.txtSearchList.Name = "txtSearchList";
            this.txtSearchList.Size = new System.Drawing.Size(409, 20);
            this.txtSearchList.TabIndex = 1;
            // 
            // btnSearchListInport
            // 
            this.btnSearchListInport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchListInport.Location = new System.Drawing.Point(527, 95);
            this.btnSearchListInport.Name = "btnSearchListInport";
            this.btnSearchListInport.Size = new System.Drawing.Size(108, 23);
            this.btnSearchListInport.TabIndex = 8;
            this.btnSearchListInport.Text = "İçe Aktar";
            this.btnSearchListInport.UseVisualStyleBackColor = true;
            this.btnSearchListInport.Click += new System.EventHandler(this.btnSearchListInport_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Aranacak Değer :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearchItemSelectedRemove
            // 
            this.btnSearchItemSelectedRemove.Location = new System.Drawing.Point(527, 36);
            this.btnSearchItemSelectedRemove.Name = "btnSearchItemSelectedRemove";
            this.btnSearchItemSelectedRemove.Size = new System.Drawing.Size(108, 23);
            this.btnSearchItemSelectedRemove.TabIndex = 7;
            this.btnSearchItemSelectedRemove.Text = "Seçileni Kaldır";
            this.btnSearchItemSelectedRemove.UseVisualStyleBackColor = true;
            this.btnSearchItemSelectedRemove.Click += new System.EventHandler(this.btnSearchItemSelectedRemove_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Aranacak Liste :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearchListItemAdd
            // 
            this.btnSearchListItemAdd.Location = new System.Drawing.Point(527, 7);
            this.btnSearchListItemAdd.Name = "btnSearchListItemAdd";
            this.btnSearchListItemAdd.Size = new System.Drawing.Size(108, 23);
            this.btnSearchListItemAdd.TabIndex = 6;
            this.btnSearchListItemAdd.Text = "Ekle";
            this.btnSearchListItemAdd.UseVisualStyleBackColor = true;
            this.btnSearchListItemAdd.Click += new System.EventHandler(this.btnSearchListItemAdd_Click);
            // 
            // comboMethod
            // 
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Location = new System.Drawing.Point(112, 7);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(409, 21);
            this.comboMethod.TabIndex = 10;
            this.comboMethod.SelectedIndexChanged += new System.EventHandler(this.comboMethod_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboMethod);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(647, 35);
            this.panel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yöntem :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartStop.Location = new System.Drawing.Point(0, 293);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(647, 23);
            this.btnStartStop.TabIndex = 13;
            this.btnStartStop.Text = "Başlat";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(647, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 339);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(647, 223);
            this.dataGridView1.TabIndex = 15;
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
            // dictionaryAttackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 562);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dictionaryAttackForm";
            this.Text = "YK-47 Hash Crack";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listWordList;
        private System.Windows.Forms.TextBox txtWordList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWordListItemAdd;
        private System.Windows.Forms.Button btnWordListSelectedRemove;
        private System.Windows.Forms.Button btnWordListInport;
        private System.Windows.Forms.Button btnWordListExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listSearchList;
        private System.Windows.Forms.Button btnSearchListExport;
        private System.Windows.Forms.TextBox txtSearchList;
        private System.Windows.Forms.Button btnSearchListInport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearchItemSelectedRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchListItemAdd;
        private System.Windows.Forms.ComboBox comboMethod;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

