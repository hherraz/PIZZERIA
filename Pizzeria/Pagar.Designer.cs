namespace Pizzeria
{
    partial class Pagar
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
            this.lbltxtPedido = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.dgConsumo = new System.Windows.Forms.DataGridView();
            this.lbltxtTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lbltxtMesa = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lbltxtGarzon = new System.Windows.Forms.Label();
            this.lblGarzon = new System.Windows.Forms.Label();
            this.lbltxtConsumo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOtro = new System.Windows.Forms.Button();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.txtIngreso = new System.Windows.Forms.TextBox();
            this.lbltxtIngreso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.lbltxtVuelto = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltxtPedido
            // 
            this.lbltxtPedido.AutoSize = true;
            this.lbltxtPedido.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtPedido.ForeColor = System.Drawing.Color.White;
            this.lbltxtPedido.Location = new System.Drawing.Point(19, 8);
            this.lbltxtPedido.Name = "lbltxtPedido";
            this.lbltxtPedido.Size = new System.Drawing.Size(80, 13);
            this.lbltxtPedido.TabIndex = 0;
            this.lbltxtPedido.Text = "Numero Pedido";
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.BackColor = System.Drawing.Color.Transparent;
            this.lblPedido.ForeColor = System.Drawing.Color.White;
            this.lblPedido.Location = new System.Drawing.Point(119, 8);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(103, 13);
            this.lblPedido.TabIndex = 1;
            this.lblPedido.Text = "{Numero de Pedido}";
            // 
            // dgConsumo
            // 
            this.dgConsumo.AllowUserToAddRows = false;
            this.dgConsumo.AllowUserToDeleteRows = false;
            this.dgConsumo.AllowUserToResizeColumns = false;
            this.dgConsumo.AllowUserToResizeRows = false;
            this.dgConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsumo.Location = new System.Drawing.Point(16, 55);
            this.dgConsumo.Name = "dgConsumo";
            this.dgConsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsumo.Size = new System.Drawing.Size(460, 370);
            this.dgConsumo.TabIndex = 2;
            // 
            // lbltxtTotal
            // 
            this.lbltxtTotal.AutoSize = true;
            this.lbltxtTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxtTotal.ForeColor = System.Drawing.Color.White;
            this.lbltxtTotal.Location = new System.Drawing.Point(240, 434);
            this.lbltxtTotal.Name = "lbltxtTotal";
            this.lbltxtTotal.Size = new System.Drawing.Size(64, 20);
            this.lbltxtTotal.TabIndex = 3;
            this.lbltxtTotal.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(310, 431);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(166, 26);
            this.txtTotal.TabIndex = 4;
            // 
            // lbltxtMesa
            // 
            this.lbltxtMesa.AutoSize = true;
            this.lbltxtMesa.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtMesa.ForeColor = System.Drawing.Color.White;
            this.lbltxtMesa.Location = new System.Drawing.Point(515, 7);
            this.lbltxtMesa.Name = "lbltxtMesa";
            this.lbltxtMesa.Size = new System.Drawing.Size(33, 13);
            this.lbltxtMesa.TabIndex = 5;
            this.lbltxtMesa.Text = "Mesa";
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.BackColor = System.Drawing.Color.Transparent;
            this.lblMesa.ForeColor = System.Drawing.Color.White;
            this.lblMesa.Location = new System.Drawing.Point(555, 7);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(96, 13);
            this.lblMesa.TabIndex = 6;
            this.lblMesa.Text = "{Numero de Mesa}";
            // 
            // lbltxtGarzon
            // 
            this.lbltxtGarzon.AutoSize = true;
            this.lbltxtGarzon.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtGarzon.ForeColor = System.Drawing.Color.White;
            this.lbltxtGarzon.Location = new System.Drawing.Point(663, 7);
            this.lbltxtGarzon.Name = "lbltxtGarzon";
            this.lbltxtGarzon.Size = new System.Drawing.Size(41, 13);
            this.lbltxtGarzon.TabIndex = 7;
            this.lbltxtGarzon.Text = "Garzon";
            // 
            // lblGarzon
            // 
            this.lblGarzon.AutoSize = true;
            this.lblGarzon.BackColor = System.Drawing.Color.Transparent;
            this.lblGarzon.ForeColor = System.Drawing.Color.White;
            this.lblGarzon.Location = new System.Drawing.Point(705, 7);
            this.lblGarzon.Name = "lblGarzon";
            this.lblGarzon.Size = new System.Drawing.Size(106, 13);
            this.lblGarzon.TabIndex = 8;
            this.lblGarzon.Text = "{Nombre del Garzon}";
            // 
            // lbltxtConsumo
            // 
            this.lbltxtConsumo.AutoSize = true;
            this.lbltxtConsumo.BackColor = System.Drawing.Color.Black;
            this.lbltxtConsumo.ForeColor = System.Drawing.Color.White;
            this.lbltxtConsumo.Location = new System.Drawing.Point(17, 39);
            this.lbltxtConsumo.Name = "lbltxtConsumo";
            this.lbltxtConsumo.Size = new System.Drawing.Size(40, 13);
            this.lbltxtConsumo.TabIndex = 9;
            this.lbltxtConsumo.Text = "Detalle";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnOtro);
            this.groupBox1.Controls.Add(this.btnTarjeta);
            this.groupBox1.Controls.Add(this.btnEfectivo);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(511, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 116);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forma Pago";
            // 
            // btnOtro
            // 
            this.btnOtro.BackColor = System.Drawing.Color.Aqua;
            this.btnOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtro.ForeColor = System.Drawing.Color.Black;
            this.btnOtro.Location = new System.Drawing.Point(201, 20);
            this.btnOtro.Name = "btnOtro";
            this.btnOtro.Size = new System.Drawing.Size(92, 83);
            this.btnOtro.TabIndex = 2;
            this.btnOtro.Text = "OTRO";
            this.btnOtro.UseVisualStyleBackColor = false;
            this.btnOtro.Click += new System.EventHandler(this.btnOtro_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.BackColor = System.Drawing.Color.Aqua;
            this.btnTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.ForeColor = System.Drawing.Color.Black;
            this.btnTarjeta.Location = new System.Drawing.Point(104, 20);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(92, 83);
            this.btnTarjeta.TabIndex = 1;
            this.btnTarjeta.Text = "TARJETA";
            this.btnTarjeta.UseVisualStyleBackColor = false;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.BackColor = System.Drawing.Color.Aqua;
            this.btnEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.ForeColor = System.Drawing.Color.Black;
            this.btnEfectivo.Location = new System.Drawing.Point(7, 20);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(92, 83);
            this.btnEfectivo.TabIndex = 0;
            this.btnEfectivo.Text = "EFECTIVO";
            this.btnEfectivo.UseVisualStyleBackColor = false;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // txtIngreso
            // 
            this.txtIngreso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngreso.Location = new System.Drawing.Point(169, 19);
            this.txtIngreso.Name = "txtIngreso";
            this.txtIngreso.Size = new System.Drawing.Size(139, 26);
            this.txtIngreso.TabIndex = 11;
            this.txtIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngreso_KeyPress);
            this.txtIngreso.Leave += new System.EventHandler(this.txtIngreso_Leave);
            // 
            // lbltxtIngreso
            // 
            this.lbltxtIngreso.AutoSize = true;
            this.lbltxtIngreso.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxtIngreso.ForeColor = System.Drawing.Color.White;
            this.lbltxtIngreso.Location = new System.Drawing.Point(17, 22);
            this.lbltxtIngreso.Name = "lbltxtIngreso";
            this.lbltxtIngreso.Size = new System.Drawing.Size(91, 20);
            this.lbltxtIngreso.TabIndex = 12;
            this.lbltxtIngreso.Text = "INGRESO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "TOTAL A PAGAR";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.BackColor = System.Drawing.Color.White;
            this.txtTotalPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPagar.Location = new System.Drawing.Point(169, 57);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(139, 26);
            this.txtTotalPagar.TabIndex = 13;
            // 
            // lbltxtVuelto
            // 
            this.lbltxtVuelto.AutoSize = true;
            this.lbltxtVuelto.BackColor = System.Drawing.Color.Transparent;
            this.lbltxtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxtVuelto.ForeColor = System.Drawing.Color.White;
            this.lbltxtVuelto.Location = new System.Drawing.Point(17, 98);
            this.lbltxtVuelto.Name = "lbltxtVuelto";
            this.lbltxtVuelto.Size = new System.Drawing.Size(79, 20);
            this.lbltxtVuelto.TabIndex = 16;
            this.lbltxtVuelto.Text = "VUELTO";
            // 
            // txtVuelto
            // 
            this.txtVuelto.BackColor = System.Drawing.Color.White;
            this.txtVuelto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVuelto.Enabled = false;
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.ForeColor = System.Drawing.Color.Black;
            this.txtVuelto.Location = new System.Drawing.Point(169, 95);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(139, 26);
            this.txtVuelto.TabIndex = 15;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Blue;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPagar.Location = new System.Drawing.Point(520, 335);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(287, 80);
            this.btnPagar.TabIndex = 17;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(520, 420);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(287, 39);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblMesa);
            this.panel1.Controls.Add(this.lbltxtPedido);
            this.panel1.Controls.Add(this.lblPedido);
            this.panel1.Controls.Add(this.lbltxtMesa);
            this.panel1.Controls.Add(this.lbltxtGarzon);
            this.panel1.Controls.Add(this.lblGarzon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 28);
            this.panel1.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.txtIngreso);
            this.groupBox2.Controls.Add(this.lbltxtIngreso);
            this.groupBox2.Controls.Add(this.txtTotalPagar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbltxtVuelto);
            this.groupBox2.Controls.Add(this.txtVuelto);
            this.groupBox2.Location = new System.Drawing.Point(499, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 139);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // Pagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pizzeria.Properties.Resources.IMG_1467;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(830, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbltxtConsumo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lbltxtTotal);
            this.Controls.Add(this.dgConsumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pagar";
            this.Text = "Pagar";
            this.Load += new System.EventHandler(this.Pagar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltxtPedido;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.DataGridView dgConsumo;
        private System.Windows.Forms.Label lbltxtTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lbltxtMesa;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label lbltxtGarzon;
        private System.Windows.Forms.Label lblGarzon;
        private System.Windows.Forms.Label lbltxtConsumo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOtro;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.TextBox txtIngreso;
        private System.Windows.Forms.Label lbltxtIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label lbltxtVuelto;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}