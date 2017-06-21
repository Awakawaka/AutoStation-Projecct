namespace autostation_v_0._1
{
    partial class fm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvm = new System.Windows.Forms.DataGridView();
            this.id_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_frm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.da_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_tme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_tmar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_pr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cl = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lms = new System.Windows.Forms.Label();
            this.bttmsrch = new System.Windows.Forms.Button();
            this.bttnmrpt = new System.Windows.Forms.Button();
            this.btnmrtkt = new System.Windows.Forms.Button();
            this.dtpm = new System.Windows.Forms.DateTimePicker();
            this.cbt = new System.Windows.Forms.ComboBox();
            this.cbxf = new System.Windows.Forms.ComboBox();
            this.cbf = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cbd = new System.Windows.Forms.CheckBox();
            this.tcm = new System.Windows.Forms.TabControl();
            this.tps = new System.Windows.Forms.TabPage();
            this.tpsort = new System.Windows.Forms.TabPage();
            this.btnall = new System.Windows.Forms.Button();
            this.mcm = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvm)).BeginInit();
            this.tcm.SuspendLayout();
            this.tps.SuspendLayout();
            this.tpsort.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvm
            // 
            this.dgvm.AllowUserToAddRows = false;
            this.dgvm.AllowUserToDeleteRows = false;
            this.dgvm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvm.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvm.BackgroundColor = System.Drawing.Color.Aquamarine;
            this.dgvm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_r,
            this.r_frm,
            this.r_to,
            this.da_r,
            this.r_tme,
            this.r_tmar,
            this.r_pr,
            this.Column1,
            this.cl});
            this.dgvm.Location = new System.Drawing.Point(43, 102);
            this.dgvm.Margin = new System.Windows.Forms.Padding(4);
            this.dgvm.Name = "dgvm";
            this.dgvm.Size = new System.Drawing.Size(904, 229);
            this.dgvm.TabIndex = 0;
            this.dgvm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id_r
            // 
            this.id_r.FillWeight = 35F;
            this.id_r.Frozen = true;
            this.id_r.HeaderText = "№";
            this.id_r.Name = "id_r";
            this.id_r.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_r.Width = 47;
            // 
            // r_frm
            // 
            this.r_frm.FillWeight = 150F;
            this.r_frm.Frozen = true;
            this.r_frm.HeaderText = "Откуда";
            this.r_frm.Name = "r_frm";
            this.r_frm.ReadOnly = true;
            this.r_frm.Width = 81;
            // 
            // r_to
            // 
            this.r_to.FillWeight = 150F;
            this.r_to.Frozen = true;
            this.r_to.HeaderText = "Куда";
            this.r_to.Name = "r_to";
            this.r_to.ReadOnly = true;
            this.r_to.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.r_to.Width = 65;
            // 
            // da_r
            // 
            this.da_r.Frozen = true;
            this.da_r.HeaderText = "День недели";
            this.da_r.Name = "da_r";
            this.da_r.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.da_r.Width = 109;
            // 
            // r_tme
            // 
            this.r_tme.FillWeight = 85F;
            this.r_tme.Frozen = true;
            this.r_tme.HeaderText = "Время отб.";
            this.r_tme.Name = "r_tme";
            this.r_tme.ReadOnly = true;
            this.r_tme.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.r_tme.Width = 97;
            // 
            // r_tmar
            // 
            this.r_tmar.FillWeight = 95F;
            this.r_tmar.Frozen = true;
            this.r_tmar.HeaderText = "Время приб.";
            this.r_tmar.Name = "r_tmar";
            this.r_tmar.ReadOnly = true;
            this.r_tmar.Width = 105;
            // 
            // r_pr
            // 
            this.r_pr.Frozen = true;
            this.r_pr.HeaderText = "Цена";
            this.r_pr.Name = "r_pr";
            this.r_pr.ReadOnly = true;
            this.r_pr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.r_pr.Width = 68;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 20F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Оформить билет";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Text = "";
            this.Column1.Width = 113;
            // 
            // cl
            // 
            this.cl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cl.Frozen = true;
            this.cl.HeaderText = "Полный маршрут";
            this.cl.Name = "cl";
            this.cl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cl.Width = 134;
            // 
            // lms
            // 
            this.lms.AutoSize = true;
            this.lms.Location = new System.Drawing.Point(177, 47);
            this.lms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lms.Name = "lms";
            this.lms.Size = new System.Drawing.Size(0, 17);
            this.lms.TabIndex = 2;
            this.lms.Click += new System.EventHandler(this.label1_Click);
            // 
            // bttmsrch
            // 
            this.bttmsrch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bttmsrch.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.bttmsrch.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew;
            this.bttmsrch.FlatAppearance.BorderSize = 3;
            this.bttmsrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttmsrch.Location = new System.Drawing.Point(569, 31);
            this.bttmsrch.Margin = new System.Windows.Forms.Padding(4);
            this.bttmsrch.Name = "bttmsrch";
            this.bttmsrch.Size = new System.Drawing.Size(81, 30);
            this.bttmsrch.TabIndex = 6;
            this.bttmsrch.Text = "Поиск";
            this.bttmsrch.UseVisualStyleBackColor = false;
            this.bttmsrch.Click += new System.EventHandler(this.bttmsrch_Click);
            // 
            // bttnmrpt
            // 
            this.bttnmrpt.BackColor = System.Drawing.Color.White;
            this.bttnmrpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnmrpt.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.bttnmrpt.FlatAppearance.BorderSize = 3;
            this.bttnmrpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnmrpt.Location = new System.Drawing.Point(233, 484);
            this.bttnmrpt.Margin = new System.Windows.Forms.Padding(4);
            this.bttnmrpt.Name = "bttnmrpt";
            this.bttnmrpt.Size = new System.Drawing.Size(149, 60);
            this.bttnmrpt.TabIndex = 10;
            this.bttnmrpt.Text = "Оформление отчета";
            this.bttnmrpt.UseVisualStyleBackColor = false;
            this.bttnmrpt.Click += new System.EventHandler(this.bttnmrpt_Click);
            // 
            // btnmrtkt
            // 
            this.btnmrtkt.BackColor = System.Drawing.Color.White;
            this.btnmrtkt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmrtkt.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnmrtkt.FlatAppearance.BorderSize = 3;
            this.btnmrtkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmrtkt.Location = new System.Drawing.Point(43, 484);
            this.btnmrtkt.Margin = new System.Windows.Forms.Padding(4);
            this.btnmrtkt.Name = "btnmrtkt";
            this.btnmrtkt.Size = new System.Drawing.Size(149, 60);
            this.btnmrtkt.TabIndex = 11;
            this.btnmrtkt.Text = "Возврат билета ";
            this.btnmrtkt.UseVisualStyleBackColor = false;
            this.btnmrtkt.Click += new System.EventHandler(this.btnmrtkt_Click);
            // 
            // dtpm
            // 
            this.dtpm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpm.Location = new System.Drawing.Point(363, 34);
            this.dtpm.Margin = new System.Windows.Forms.Padding(4);
            this.dtpm.Name = "dtpm";
            this.dtpm.Size = new System.Drawing.Size(164, 23);
            this.dtpm.TabIndex = 12;
            this.dtpm.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbt
            // 
            this.cbt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbt.FormattingEnabled = true;
            this.cbt.Location = new System.Drawing.Point(181, 34);
            this.cbt.Margin = new System.Windows.Forms.Padding(4);
            this.cbt.Name = "cbt";
            this.cbt.Size = new System.Drawing.Size(160, 25);
            this.cbt.TabIndex = 13;
            // 
            // cbxf
            // 
            this.cbxf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxf.FormattingEnabled = true;
            this.cbxf.Location = new System.Drawing.Point(4, 33);
            this.cbxf.Margin = new System.Windows.Forms.Padding(4);
            this.cbxf.Name = "cbxf";
            this.cbxf.Size = new System.Drawing.Size(160, 25);
            this.cbxf.TabIndex = 16;
            // 
            // cbf
            // 
            this.cbf.AutoSize = true;
            this.cbf.Location = new System.Drawing.Point(4, 4);
            this.cbf.Margin = new System.Windows.Forms.Padding(4);
            this.cbf.Name = "cbf";
            this.cbf.Size = new System.Drawing.Size(79, 21);
            this.cbf.TabIndex = 17;
            this.cbf.Text = "Откуда:";
            this.cbf.UseVisualStyleBackColor = true;
            this.cbf.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(181, 4);
            this.cb2.Margin = new System.Windows.Forms.Padding(4);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(63, 21);
            this.cb2.TabIndex = 18;
            this.cb2.Text = "Куда:";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cbd
            // 
            this.cbd.AutoSize = true;
            this.cbd.Location = new System.Drawing.Point(363, 4);
            this.cbd.Margin = new System.Windows.Forms.Padding(4);
            this.cbd.Name = "cbd";
            this.cbd.Size = new System.Drawing.Size(61, 21);
            this.cbd.TabIndex = 19;
            this.cbd.Text = "Дата";
            this.cbd.UseVisualStyleBackColor = true;
            // 
            // tcm
            // 
            this.tcm.Controls.Add(this.tps);
            this.tcm.Controls.Add(this.tpsort);
            this.tcm.Location = new System.Drawing.Point(43, 352);
            this.tcm.Margin = new System.Windows.Forms.Padding(4);
            this.tcm.Name = "tcm";
            this.tcm.SelectedIndex = 0;
            this.tcm.Size = new System.Drawing.Size(696, 98);
            this.tcm.TabIndex = 20;
            // 
            // tps
            // 
            this.tps.Controls.Add(this.cbt);
            this.tps.Controls.Add(this.cbd);
            this.tps.Controls.Add(this.lms);
            this.tps.Controls.Add(this.cbxf);
            this.tps.Controls.Add(this.bttmsrch);
            this.tps.Controls.Add(this.dtpm);
            this.tps.Controls.Add(this.cbf);
            this.tps.Controls.Add(this.cb2);
            this.tps.Location = new System.Drawing.Point(4, 26);
            this.tps.Margin = new System.Windows.Forms.Padding(4);
            this.tps.Name = "tps";
            this.tps.Padding = new System.Windows.Forms.Padding(4);
            this.tps.Size = new System.Drawing.Size(688, 68);
            this.tps.TabIndex = 0;
            this.tps.Text = "Поиск:";
            this.tps.UseVisualStyleBackColor = true;
            this.tps.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tpsort
            // 
            this.tpsort.Controls.Add(this.btnall);
            this.tpsort.Location = new System.Drawing.Point(4, 26);
            this.tpsort.Margin = new System.Windows.Forms.Padding(4);
            this.tpsort.Name = "tpsort";
            this.tpsort.Padding = new System.Windows.Forms.Padding(4);
            this.tpsort.Size = new System.Drawing.Size(688, 68);
            this.tpsort.TabIndex = 1;
            this.tpsort.Text = "Сортировка:";
            this.tpsort.UseVisualStyleBackColor = true;
            // 
            // btnall
            // 
            this.btnall.Location = new System.Drawing.Point(4, 8);
            this.btnall.Margin = new System.Windows.Forms.Padding(4);
            this.btnall.Name = "btnall";
            this.btnall.Size = new System.Drawing.Size(136, 30);
            this.btnall.TabIndex = 0;
            this.btnall.Text = "Все маршруты";
            this.btnall.UseVisualStyleBackColor = true;
            this.btnall.Click += new System.EventHandler(this.btnall_Click);
            // 
            // mcm
            // 
            this.mcm.Location = new System.Drawing.Point(957, 169);
            this.mcm.Name = "mcm";
            this.mcm.TabIndex = 21;
            this.mcm.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(954, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Выбирете дату:";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcm);
            this.Controls.Add(this.tcm);
            this.Controls.Add(this.btnmrtkt);
            this.Controls.Add(this.bttnmrpt);
            this.Controls.Add(this.dgvm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fm";
            this.Padding = new System.Windows.Forms.Padding(27, 78, 27, 26);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Автостанция \"Highway to Hell\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fm_FormClosing);
            this.Load += new System.EventHandler(this.fm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvm)).EndInit();
            this.tcm.ResumeLayout(false);
            this.tps.ResumeLayout(false);
            this.tps.PerformLayout();
            this.tpsort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvm;
        public System.Windows.Forms.ComboBox cbt;
        public System.Windows.Forms.ComboBox cbxf;
        public System.Windows.Forms.DateTimePicker dtpm;
        public System.Windows.Forms.Label lms;
        public System.Windows.Forms.Button bttmsrch;
        public System.Windows.Forms.Button bttnmrpt;
        public System.Windows.Forms.Button btnmrtkt;
        public System.Windows.Forms.CheckBox cbf;
        public System.Windows.Forms.CheckBox cb2;
        public System.Windows.Forms.CheckBox cbd;
        public System.Windows.Forms.TabControl tcm;
        public System.Windows.Forms.TabPage tps;
        public System.Windows.Forms.TabPage tpsort;
        public System.Windows.Forms.Button btnall;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MonthCalendar mcm;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_frm;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn da_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_tme;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_tmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_pr;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn cl;
    }
}

