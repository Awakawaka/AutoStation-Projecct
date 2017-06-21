namespace autostation_v_0._1
{
    partial class WholeRout
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
            this.dgvwholer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwholer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvwholer
            // 
            this.dgvwholer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvwholer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvwholer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwholer.Location = new System.Drawing.Point(28, 56);
            this.dgvwholer.Margin = new System.Windows.Forms.Padding(4);
            this.dgvwholer.Name = "dgvwholer";
            this.dgvwholer.Size = new System.Drawing.Size(404, 292);
            this.dgvwholer.TabIndex = 0;
            // 
            // WholeRout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 418);
            this.Controls.Add(this.dgvwholer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WholeRout";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Весь маршрут";
            this.Load += new System.EventHandler(this.WholeRout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvwholer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvwholer;
    }
}