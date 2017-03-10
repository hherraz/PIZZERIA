namespace Pizzeria
{
    partial class ConsumoLocal
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
            this.PanelConsumoLocal = new System.Windows.Forms.Panel();
            this.GridConsumo = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGuardarConsumo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.status = new System.Windows.Forms.Label();
            this.ListaMesas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ListaGarzones = new System.Windows.Forms.ComboBox();
            this.btnMesas = new System.Windows.Forms.Button();
            this.btnGarzones = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelTotal = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCambiarGarzon = new System.Windows.Forms.Button();
            this.btnCambiarMesa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.AddPizzaMenu = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.PanelConsumoLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsumo)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelConsumoLocal
            // 
            this.PanelConsumoLocal.BackgroundImage = global::Pizzeria.Properties.Resources.pizza_parallax_bg;
            this.PanelConsumoLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelConsumoLocal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelConsumoLocal.Controls.Add(this.GridConsumo);
            this.PanelConsumoLocal.Controls.Add(this.panel5);
            this.PanelConsumoLocal.Controls.Add(this.btnGuardarConsumo);
            this.PanelConsumoLocal.Controls.Add(this.groupBox1);
            this.PanelConsumoLocal.Controls.Add(this.PanelTotal);
            this.PanelConsumoLocal.Controls.Add(this.btnCambiarGarzon);
            this.PanelConsumoLocal.Controls.Add(this.btnCambiarMesa);
            this.PanelConsumoLocal.Controls.Add(this.label4);
            this.PanelConsumoLocal.Controls.Add(this.button2);
            this.PanelConsumoLocal.Controls.Add(this.AddPizzaMenu);
            this.PanelConsumoLocal.Controls.Add(this.button7);
            this.PanelConsumoLocal.Controls.Add(this.button4);
            this.PanelConsumoLocal.Controls.Add(this.button5);
            this.PanelConsumoLocal.Controls.Add(this.button6);
            this.PanelConsumoLocal.Location = new System.Drawing.Point(0, 0);
            this.PanelConsumoLocal.Name = "PanelConsumoLocal";
            this.PanelConsumoLocal.Size = new System.Drawing.Size(821, 422);
            this.PanelConsumoLocal.TabIndex = 6;
            this.PanelConsumoLocal.Visible = false;
            // 
            // GridConsumo
            // 
            this.GridConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConsumo.Location = new System.Drawing.Point(32, 104);
            this.GridConsumo.Name = "GridConsumo";
            this.GridConsumo.Size = new System.Drawing.Size(751, 202);
            this.GridConsumo.TabIndex = 26;
            this.GridConsumo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConsumo_CellClick);
            this.GridConsumo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GridConsumo_RowsRemoved);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.btn_cerrar);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(820, 27);
            this.panel5.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(8, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(206, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "CONSUMO EN EL LOCAL";
            // 
            // btnGuardarConsumo
            // 
            this.btnGuardarConsumo.BackColor = System.Drawing.Color.Blue;
            this.btnGuardarConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarConsumo.ForeColor = System.Drawing.Color.Yellow;
            this.btnGuardarConsumo.Location = new System.Drawing.Point(339, 362);
            this.btnGuardarConsumo.Name = "btnGuardarConsumo";
            this.btnGuardarConsumo.Size = new System.Drawing.Size(167, 49);
            this.btnGuardarConsumo.TabIndex = 22;
            this.btnGuardarConsumo.Text = "GUARDAR";
            this.btnGuardarConsumo.UseVisualStyleBackColor = false;
            this.btnGuardarConsumo.Click += new System.EventHandler(this.btnGuardarConsumo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.ListaMesas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ListaGarzones);
            this.groupBox1.Controls.Add(this.btnMesas);
            this.groupBox1.Controls.Add(this.btnGarzones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(75, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 55);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(220, 22);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 21;
            this.status.Text = "status";
            // 
            // ListaMesas
            // 
            this.ListaMesas.FormattingEnabled = true;
            this.ListaMesas.Location = new System.Drawing.Point(102, 17);
            this.ListaMesas.Name = "ListaMesas";
            this.ListaMesas.Size = new System.Drawing.Size(56, 21);
            this.ListaMesas.TabIndex = 19;
            this.ListaMesas.SelectedIndexChanged += new System.EventHandler(this.ListaMesas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MESA :";
            // 
            // ListaGarzones
            // 
            this.ListaGarzones.FormattingEnabled = true;
            this.ListaGarzones.Location = new System.Drawing.Point(367, 18);
            this.ListaGarzones.Name = "ListaGarzones";
            this.ListaGarzones.Size = new System.Drawing.Size(170, 21);
            this.ListaGarzones.TabIndex = 20;
            // 
            // btnMesas
            // 
            this.btnMesas.Location = new System.Drawing.Point(164, 17);
            this.btnMesas.Name = "btnMesas";
            this.btnMesas.Size = new System.Drawing.Size(52, 23);
            this.btnMesas.TabIndex = 0;
            this.btnMesas.Text = "MESAS";
            this.btnMesas.UseVisualStyleBackColor = true;
            // 
            // btnGarzones
            // 
            this.btnGarzones.Location = new System.Drawing.Point(545, 17);
            this.btnGarzones.Name = "btnGarzones";
            this.btnGarzones.Size = new System.Drawing.Size(89, 23);
            this.btnGarzones.TabIndex = 2;
            this.btnGarzones.Text = "GARZONES";
            this.btnGarzones.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "GARZON :";
            // 
            // PanelTotal
            // 
            this.PanelTotal.BackColor = System.Drawing.Color.White;
            this.PanelTotal.BackgroundImage = global::Pizzeria.Properties.Resources._240_F_99640866_dNj6uLcGW8pd5VyM8TO9lTzCePZYyvRR;
            this.PanelTotal.Controls.Add(this.label5);
            this.PanelTotal.Controls.Add(this.Total);
            this.PanelTotal.Controls.Add(this.btnPagar);
            this.PanelTotal.Location = new System.Drawing.Point(525, 311);
            this.PanelTotal.Name = "PanelTotal";
            this.PanelTotal.Size = new System.Drawing.Size(258, 100);
            this.PanelTotal.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "TOTAL";
            // 
            // Total
            // 
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(74, 12);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(166, 26);
            this.Total.TabIndex = 10;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.DarkRed;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPagar.Location = new System.Drawing.Point(24, 52);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(216, 36);
            this.btnPagar.TabIndex = 15;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btn_pagar_Click);
            // 
            // btnCambiarGarzon
            // 
            this.btnCambiarGarzon.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCambiarGarzon.Location = new System.Drawing.Point(32, 388);
            this.btnCambiarGarzon.Name = "btnCambiarGarzon";
            this.btnCambiarGarzon.Size = new System.Drawing.Size(283, 23);
            this.btnCambiarGarzon.TabIndex = 17;
            this.btnCambiarGarzon.Text = "CAMBIAR GARZON";
            this.btnCambiarGarzon.UseVisualStyleBackColor = false;
            // 
            // btnCambiarMesa
            // 
            this.btnCambiarMesa.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCambiarMesa.Location = new System.Drawing.Point(32, 363);
            this.btnCambiarMesa.Name = "btnCambiarMesa";
            this.btnCambiarMesa.Size = new System.Drawing.Size(283, 23);
            this.btnCambiarMesa.TabIndex = 16;
            this.btnCambiarMesa.Text = "CAMBIAR MESA";
            this.btnCambiarMesa.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PRODUCTOS";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "ACOMPAÑAMIENTOS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddPizzaMenu
            // 
            this.AddPizzaMenu.Location = new System.Drawing.Point(33, 311);
            this.AddPizzaMenu.Name = "AddPizzaMenu";
            this.AddPizzaMenu.Size = new System.Drawing.Size(133, 22);
            this.AddPizzaMenu.TabIndex = 2;
            this.AddPizzaMenu.Text = "PIZZA DEL MENU";
            this.AddPizzaMenu.UseVisualStyleBackColor = true;
            this.AddPizzaMenu.Click += new System.EventHandler(this.AddPizzaMenu_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(299, 334);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(133, 22);
            this.button7.TabIndex = 7;
            this.button7.Text = "OTROS";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(166, 311);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 22);
            this.button4.TabIndex = 3;
            this.button4.Text = "ARMA TU PIZZA";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(166, 334);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 22);
            this.button5.TabIndex = 6;
            this.button5.Text = "LIQUIDOS";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(33, 332);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(133, 22);
            this.button6.TabIndex = 5;
            this.button6.Text = "POSTRES";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(706, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "label20";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Location = new System.Drawing.Point(786, 2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(29, 23);
            this.btn_cerrar.TabIndex = 7;
            this.btn_cerrar.Text = "X";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // ConsumoLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 428);
            this.Controls.Add(this.PanelConsumoLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsumoLocal";
            this.Text = "TomaPedidos";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Activated += new System.EventHandler(this.ConsumoLocal_Activated);
            this.Load += new System.EventHandler(this.ConsumoLocal_Load);
            this.PanelConsumoLocal.ResumeLayout(false);
            this.PanelConsumoLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsumo)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelTotal.ResumeLayout(false);
            this.PanelTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelConsumoLocal;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCambiarGarzon;
        private System.Windows.Forms.Button btnCambiarMesa;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Panel PanelTotal;
        public System.Windows.Forms.Button btnGarzones;
        public System.Windows.Forms.Button btnMesas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ListaGarzones;
        private System.Windows.Forms.ComboBox ListaMesas;
        private System.Windows.Forms.Button btnGuardarConsumo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddPizzaMenu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.DataGridView GridConsumo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button btn_cerrar;
    }
}