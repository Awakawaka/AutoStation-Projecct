namespace autostation_v_0._1
{
    partial class rt
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
            this.button1 = new System.Windows.Forms.Button();
            this.tBS = new System.Windows.Forms.TextBox();
            this.dgrt = new System.Windows.Forms.DataGridView();
            this.cbns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tns_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbrt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrt)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(448, 29);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBS
            // 
            this.tBS.Location = new System.Drawing.Point(207, 33);
            this.tBS.Margin = new System.Windows.Forms.Padding(4);
            this.tBS.Name = "tBS";
            this.tBS.Size = new System.Drawing.Size(233, 23);
            this.tBS.TabIndex = 1;
            // 
            // dgrt
            // 
            this.dgrt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbns,
            this.cldt,
            this.tns_t,
            this.cprice});
            this.dgrt.Location = new System.Drawing.Point(40, 91);
            this.dgrt.Margin = new System.Windows.Forms.Padding(4);
            this.dgrt.Name = "dgrt";
            this.dgrt.Size = new System.Drawing.Size(508, 96);
            this.dgrt.TabIndex = 2;
            // 
            // cbns
            // 
            this.cbns.HeaderText = "Номер билета";
            this.cbns.Name = "cbns";
            this.cbns.Width = 116;
            // 
            // cldt
            // 
            this.cldt.HeaderText = "Дата покупки";
            this.cldt.Name = "cldt";
            this.cldt.ReadOnly = true;
            this.cldt.Width = 114;
            // 
            // tns_t
            // 
            this.tns_t.HeaderText = "Номер места";
            this.tns_t.Name = "tns_t";
            this.tns_t.ReadOnly = true;
            this.tns_t.Width = 109;
            // 
            // cprice
            // 
            this.cprice.HeaderText = "Цена билета";
            this.cprice.Name = "cprice";
            this.cprice.ReadOnly = true;
            this.cprice.Width = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите номер билета:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сумма к возврату:";
            // 
            // tbrt
            // 
            this.tbrt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbrt.Location = new System.Drawing.Point(161, 217);
            this.tbrt.Margin = new System.Windows.Forms.Padding(4);
            this.tbrt.Name = "tbrt";
            this.tbrt.ReadOnly = true;
            this.tbrt.Size = new System.Drawing.Size(93, 23);
            this.tbrt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "грн";
            // 
            // btnrt
            // 
            this.btnrt.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnrt.FlatAppearance.BorderSize = 2;
            this.btnrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnrt.Location = new System.Drawing.Point(511, 274);
            this.btnrt.Margin = new System.Windows.Forms.Padding(4);
            this.btnrt.Name = "btnrt";
            this.btnrt.Size = new System.Drawing.Size(100, 30);
            this.btnrt.TabIndex = 7;
            this.btnrt.Text = "Вернуть";
            this.btnrt.UseVisualStyleBackColor = true;
            this.btnrt.Click += new System.EventHandler(this.btnrt_Click);
            // 
            // rt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 328);
            this.Controls.Add(this.btnrt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbrt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgrt);
            this.Controls.Add(this.tBS);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "rt";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.rt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbns;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tns_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprice;
        public System.Windows.Forms.TextBox tBS;
        public System.Windows.Forms.DataGridView dgrt;
        public System.Windows.Forms.TextBox tbrt;
        public System.Windows.Forms.Button btnrt;
    }
}