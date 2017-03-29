namespace Pizzeria
{
    partial class Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caja));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.BtnMail = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSorting = false;
            this.dataGrid1.AlternatingBackColor = System.Drawing.SystemColors.Menu;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGrid1.CaptionText = "PEDIDOS";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 39);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(947, 364);
            this.dataGrid1.TabIndex = 1;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Black;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Yellow;
            this.txtTotal.Location = new System.Drawing.Point(563, 409);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 19);
            this.txtTotal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "TOTAL VENTA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 33);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "ARQUEO DE CAJA";
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnExcel.BackgroundImage")));
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(627, 458);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(58, 56);
            this.BtnExcel.TabIndex = 5;
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnMail
            // 
            this.BtnMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMail.BackgroundImage")));
            this.BtnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMail.Location = new System.Drawing.Point(691, 458);
            this.BtnMail.Name = "BtnMail";
            this.BtnMail.Size = new System.Drawing.Size(58, 56);
            this.BtnMail.TabIndex = 6;
            this.BtnMail.UseVisualStyleBackColor = true;
            this.BtnMail.Click += new System.EventHandler(this.BtnMail_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrint.BackgroundImage")));
            this.BtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrint.Location = new System.Drawing.Point(755, 458);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(58, 56);
            this.BtnPrint.TabIndex = 7;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Blue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Yellow;
            this.button4.Location = new System.Drawing.Point(119, 458);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(481, 56);
            this.button4.TabIndex = 8;
            this.button4.Text = "CIERRE DE CAJA DEL DIA";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(837, 458);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 56);
            this.button5.TabIndex = 9;
            this.button5.Text = "SALIR";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 526);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnMail);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Caja";
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Button BtnMail;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}