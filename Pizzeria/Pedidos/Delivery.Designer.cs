namespace Pizzeria
{
    partial class Delivery
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
            this.IDCLIENTE = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.FormaPago = new System.Windows.Forms.ComboBox();
            this.deliveryBorrar = new System.Windows.Forms.Button();
            this.deliveryModificar = new System.Windows.Forms.Button();
            this.deliveryAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GridDelivery = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnGuardarConsumo = new System.Windows.Forms.Button();
            this.PanelTotal = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAcomp = new System.Windows.Forms.Button();
            this.AddPizzaMenu = new System.Windows.Forms.Button();
            this.btnArma = new System.Windows.Forms.Button();
            this.PanelConsumoLocal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDelivery)).BeginInit();
            this.panel5.SuspendLayout();
            this.PanelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelConsumoLocal
            // 
            this.PanelConsumoLocal.BackgroundImage = global::Pizzeria.Properties.Resources.pizza;
            this.PanelConsumoLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelConsumoLocal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelConsumoLocal.Controls.Add(this.IDCLIENTE);
            this.PanelConsumoLocal.Controls.Add(this.status);
            this.PanelConsumoLocal.Controls.Add(this.panel1);
            this.PanelConsumoLocal.Controls.Add(this.deliveryBorrar);
            this.PanelConsumoLocal.Controls.Add(this.deliveryModificar);
            this.PanelConsumoLocal.Controls.Add(this.deliveryAgregar);
            this.PanelConsumoLocal.Controls.Add(this.btnBuscar);
            this.PanelConsumoLocal.Controls.Add(this.groupBox3);
            this.PanelConsumoLocal.Controls.Add(this.GridDelivery);
            this.PanelConsumoLocal.Controls.Add(this.label1);
            this.PanelConsumoLocal.Controls.Add(this.panel5);
            this.PanelConsumoLocal.Controls.Add(this.label20);
            this.PanelConsumoLocal.Controls.Add(this.btnGuardarConsumo);
            this.PanelConsumoLocal.Controls.Add(this.PanelTotal);
            this.PanelConsumoLocal.Controls.Add(this.label4);
            this.PanelConsumoLocal.Controls.Add(this.btnAcomp);
            this.PanelConsumoLocal.Controls.Add(this.AddPizzaMenu);
            this.PanelConsumoLocal.Controls.Add(this.btnArma);
            this.PanelConsumoLocal.Location = new System.Drawing.Point(0, 0);
            this.PanelConsumoLocal.Name = "PanelConsumoLocal";
            this.PanelConsumoLocal.Size = new System.Drawing.Size(821, 550);
            this.PanelConsumoLocal.TabIndex = 6;
            // 
            // IDCLIENTE
            // 
            this.IDCLIENTE.Location = new System.Drawing.Point(620, 505);
            this.IDCLIENTE.Name = "IDCLIENTE";
            this.IDCLIENTE.Size = new System.Drawing.Size(63, 20);
            this.IDCLIENTE.TabIndex = 34;
            this.IDCLIENTE.Visible = false;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(546, 512);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtVuelto);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.FormaPago);
            this.panel1.Location = new System.Drawing.Point(32, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 71);
            this.panel1.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "VUELTO PARA";
            // 
            // txtVuelto
            // 
            this.txtVuelto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVuelto.Location = new System.Drawing.Point(107, 38);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(156, 20);
            this.txtVuelto.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "FORMA PAGO";
            // 
            // FormaPago
            // 
            this.FormaPago.FormattingEnabled = true;
            this.FormaPago.Location = new System.Drawing.Point(107, 12);
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.Size = new System.Drawing.Size(156, 21);
            this.FormaPago.TabIndex = 26;
            // 
            // deliveryBorrar
            // 
            this.deliveryBorrar.Location = new System.Drawing.Point(707, 139);
            this.deliveryBorrar.Name = "deliveryBorrar";
            this.deliveryBorrar.Size = new System.Drawing.Size(75, 23);
            this.deliveryBorrar.TabIndex = 31;
            this.deliveryBorrar.Text = "BORRAR";
            this.deliveryBorrar.UseVisualStyleBackColor = true;
            // 
            // deliveryModificar
            // 
            this.deliveryModificar.Location = new System.Drawing.Point(707, 115);
            this.deliveryModificar.Name = "deliveryModificar";
            this.deliveryModificar.Size = new System.Drawing.Size(75, 23);
            this.deliveryModificar.TabIndex = 30;
            this.deliveryModificar.Text = "MODIFICAR";
            this.deliveryModificar.UseVisualStyleBackColor = true;
            this.deliveryModificar.Click += new System.EventHandler(this.deliveryModificar_Click);
            // 
            // deliveryAgregar
            // 
            this.deliveryAgregar.Location = new System.Drawing.Point(707, 91);
            this.deliveryAgregar.Name = "deliveryAgregar";
            this.deliveryAgregar.Size = new System.Drawing.Size(75, 23);
            this.deliveryAgregar.TabIndex = 29;
            this.deliveryAgregar.Text = "GUARDAR";
            this.deliveryAgregar.UseVisualStyleBackColor = true;
            this.deliveryAgregar.Click += new System.EventHandler(this.deliveryAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(707, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtReferencia);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtDireccion);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtTelefono);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(32, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 124);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Enabled = false;
            this.txtReferencia.Location = new System.Drawing.Point(115, 84);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(536, 20);
            this.txtReferencia.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(16, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "REFERENCIA :";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(105, 52);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(546, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(16, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "DIRECCION :";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.Blue;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.Yellow;
            this.txtTelefono.Location = new System.Drawing.Point(471, 19);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(180, 23);
            this.txtTelefono.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(88, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "NOMBRE :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(385, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "TELEFONO :";
            // 
            // GridDelivery
            // 
            this.GridDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDelivery.Location = new System.Drawing.Point(32, 198);
            this.GridDelivery.Name = "GridDelivery";
            this.GridDelivery.Size = new System.Drawing.Size(751, 202);
            this.GridDelivery.TabIndex = 26;
            this.GridDelivery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridRetiro_BorrarFila);
            this.GridDelivery.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GridRetiro_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(748, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.btn_cerrar);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(820, 27);
            this.panel5.TabIndex = 25;
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(8, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(308, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "PEDIDOS PARA REPARTO / DELIVERY";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(701, 508);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "label20";
            this.label20.Visible = false;
            // 
            // btnGuardarConsumo
            // 
            this.btnGuardarConsumo.BackColor = System.Drawing.Color.Blue;
            this.btnGuardarConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarConsumo.ForeColor = System.Drawing.Color.Yellow;
            this.btnGuardarConsumo.Location = new System.Drawing.Point(339, 456);
            this.btnGuardarConsumo.Name = "btnGuardarConsumo";
            this.btnGuardarConsumo.Size = new System.Drawing.Size(167, 49);
            this.btnGuardarConsumo.TabIndex = 22;
            this.btnGuardarConsumo.Text = "GUARDAR";
            this.btnGuardarConsumo.UseVisualStyleBackColor = false;
            this.btnGuardarConsumo.Visible = false;
            this.btnGuardarConsumo.Click += new System.EventHandler(this.btnGuardarConsumo_Click);
            // 
            // PanelTotal
            // 
            this.PanelTotal.BackColor = System.Drawing.Color.White;
            this.PanelTotal.BackgroundImage = global::Pizzeria.Properties.Resources.fondo;
            this.PanelTotal.Controls.Add(this.label5);
            this.PanelTotal.Controls.Add(this.Total);
            this.PanelTotal.Controls.Add(this.btnPagar);
            this.PanelTotal.Location = new System.Drawing.Point(525, 405);
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
            this.Total.Enabled = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PRODUCTOS";
            // 
            // btnAcomp
            // 
            this.btnAcomp.Location = new System.Drawing.Point(299, 405);
            this.btnAcomp.Name = "btnAcomp";
            this.btnAcomp.Size = new System.Drawing.Size(133, 38);
            this.btnAcomp.TabIndex = 4;
            this.btnAcomp.Text = "ACOMPAÑAMIENTOS";
            this.btnAcomp.UseVisualStyleBackColor = true;
            this.btnAcomp.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddPizzaMenu
            // 
            this.AddPizzaMenu.Location = new System.Drawing.Point(33, 405);
            this.AddPizzaMenu.Name = "AddPizzaMenu";
            this.AddPizzaMenu.Size = new System.Drawing.Size(133, 38);
            this.AddPizzaMenu.TabIndex = 2;
            this.AddPizzaMenu.Text = "PIZZA DEL MENU";
            this.AddPizzaMenu.UseVisualStyleBackColor = true;
            this.AddPizzaMenu.Click += new System.EventHandler(this.AddPizzaMenu_Click);
            // 
            // btnArma
            // 
            this.btnArma.Location = new System.Drawing.Point(166, 405);
            this.btnArma.Name = "btnArma";
            this.btnArma.Size = new System.Drawing.Size(133, 38);
            this.btnArma.TabIndex = 3;
            this.btnArma.Text = "ARMA TU PIZZA";
            this.btnArma.UseVisualStyleBackColor = true;
            this.btnArma.Click += new System.EventHandler(this.button4_Click);
            // 
            // Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 550);
            this.Controls.Add(this.PanelConsumoLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Delivery";
            this.Text = "TomaPedidos";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Activated += new System.EventHandler(this.Delivery_Activated);
            this.Load += new System.EventHandler(this.Delivery_Load);
            this.PanelConsumoLocal.ResumeLayout(false);
            this.PanelConsumoLocal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDelivery)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.PanelTotal.ResumeLayout(false);
            this.PanelTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelConsumoLocal;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Panel PanelTotal;
        private System.Windows.Forms.Button btnGuardarConsumo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAcomp;
        private System.Windows.Forms.Button AddPizzaMenu;
        private System.Windows.Forms.Button btnArma;
        public System.Windows.Forms.DataGridView GridDelivery;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button deliveryBorrar;
        private System.Windows.Forms.Button deliveryModificar;
        private System.Windows.Forms.Button deliveryAgregar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox FormaPago;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox IDCLIENTE;
    }
}