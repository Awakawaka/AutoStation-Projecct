namespace autostation_v_0._1
{
    partial class ReportCashier
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
            this.dgvr = new System.Windows.Forms.DataGridView();
            this.cbroutsr = new System.Windows.Forms.ComboBox();
            this.lbroutsc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbsearchc = new System.Windows.Forms.TextBox();
            this.btncsearch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rballc = new System.Windows.Forms.RadioButton();
            this.rbtoday = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbrc = new System.Windows.Forms.TextBox();
            this.tbrtcq = new System.Windows.Forms.TextBox();
            this.lbrtc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbsum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvr)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvr
            // 
            this.dgvr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvr.BackgroundColor = System.Drawing.Color.Aquamarine;
            this.dgvr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvr.Location = new System.Drawing.Point(85, 120);
            this.dgvr.Margin = new System.Windows.Forms.Padding(4);
            this.dgvr.Name = "dgvr";
            this.dgvr.ReadOnly = true;
            this.dgvr.Size = new System.Drawing.Size(813, 468);
            this.dgvr.TabIndex = 0;
            // 
            // cbroutsr
            // 
            this.cbroutsr.FormattingEnabled = true;
            this.cbroutsr.Location = new System.Drawing.Point(245, 20);
            this.cbroutsr.Margin = new System.Windows.Forms.Padding(4);
            this.cbroutsr.Name = "cbroutsr";
            this.cbroutsr.Size = new System.Drawing.Size(249, 25);
            this.cbroutsr.TabIndex = 1;
            this.cbroutsr.SelectedIndexChanged += new System.EventHandler(this.cbroutsr_SelectedIndexChanged);
            // 
            // lbroutsc
            // 
            this.lbroutsc.AutoSize = true;
            this.lbroutsc.Location = new System.Drawing.Point(82, 24);
            this.lbroutsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbroutsc.Name = "lbroutsc";
            this.lbroutsc.Size = new System.Drawing.Size(140, 17);
            this.lbroutsc.TabIndex = 2;
            this.lbroutsc.Text = "Выберете маршрут:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(731, 620);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сформировать отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbsearchc
            // 
            this.tbsearchc.Location = new System.Drawing.Point(616, 21);
            this.tbsearchc.Margin = new System.Windows.Forms.Padding(4);
            this.tbsearchc.Name = "tbsearchc";
            this.tbsearchc.Size = new System.Drawing.Size(175, 23);
            this.tbsearchc.TabIndex = 4;
            this.tbsearchc.TextChanged += new System.EventHandler(this.tbsearchc_TextChanged);
            // 
            // btncsearch
            // 
            this.btncsearch.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btncsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncsearch.Location = new System.Drawing.Point(799, 17);
            this.btncsearch.Margin = new System.Windows.Forms.Padding(4);
            this.btncsearch.Name = "btncsearch";
            this.btncsearch.Size = new System.Drawing.Size(83, 28);
            this.btncsearch.TabIndex = 5;
            this.btncsearch.Text = "Поиск";
            this.btncsearch.UseVisualStyleBackColor = true;
            this.btncsearch.Click += new System.EventHandler(this.btncsearch_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(502, 16);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rballc
            // 
            this.rballc.AutoSize = true;
            this.rballc.Location = new System.Drawing.Point(85, 58);
            this.rballc.Name = "rballc";
            this.rballc.Size = new System.Drawing.Size(120, 21);
            this.rballc.TabIndex = 7;
            this.rballc.TabStop = true;
            this.rballc.Text = "За этот месяц";
            this.rballc.UseVisualStyleBackColor = true;
            // 
            // rbtoday
            // 
            this.rbtoday.AutoSize = true;
            this.rbtoday.Location = new System.Drawing.Point(245, 58);
            this.rbtoday.Name = "rbtoday";
            this.rbtoday.Size = new System.Drawing.Size(99, 21);
            this.rbtoday.TabIndex = 8;
            this.rbtoday.TabStop = true;
            this.rbtoday.Text = "За сегодня";
            this.rbtoday.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Маршрут:";
            // 
            // tbrc
            // 
            this.tbrc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbrc.Location = new System.Drawing.Point(160, 85);
            this.tbrc.Name = "tbrc";
            this.tbrc.ReadOnly = true;
            this.tbrc.Size = new System.Drawing.Size(150, 23);
            this.tbrc.TabIndex = 10;
            // 
            // tbrtcq
            // 
            this.tbrtcq.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbrtcq.Location = new System.Drawing.Point(559, 82);
            this.tbrtcq.Name = "tbrtcq";
            this.tbrtcq.ReadOnly = true;
            this.tbrtcq.Size = new System.Drawing.Size(100, 23);
            this.tbrtcq.TabIndex = 12;
            // 
            // lbrtc
            // 
            this.lbrtc.AutoSize = true;
            this.lbrtc.Location = new System.Drawing.Point(316, 85);
            this.lbrtc.Name = "lbrtc";
            this.lbrtc.Size = new System.Drawing.Size(237, 17);
            this.lbrtc.TabIndex = 11;
            this.lbrtc.Text = "Количетво возвращенных билетов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "На сумму:";
            // 
            // tbsum
            // 
            this.tbsum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbsum.Location = new System.Drawing.Point(744, 82);
            this.tbsum.Name = "tbsum";
            this.tbsum.ReadOnly = true;
            this.tbsum.Size = new System.Drawing.Size(100, 23);
            this.tbsum.TabIndex = 14;
            // 
            // ReportCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 693);
            this.Controls.Add(this.tbsum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbrtcq);
            this.Controls.Add(this.lbrtc);
            this.Controls.Add(this.tbrc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtoday);
            this.Controls.Add(this.rballc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btncsearch);
            this.Controls.Add(this.tbsearchc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbroutsc);
            this.Controls.Add(this.cbroutsr);
            this.Controls.Add(this.dgvr);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportCashier";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.ReportCashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvr;
        public System.Windows.Forms.ComboBox cbroutsr;
        public System.Windows.Forms.Label lbroutsc;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox tbsearchc;
        public System.Windows.Forms.Button btncsearch;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.RadioButton rballc;
        public System.Windows.Forms.RadioButton rbtoday;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbrc;
        public System.Windows.Forms.TextBox tbrtcq;
        public System.Windows.Forms.Label lbrtc;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbsum;
    }
}