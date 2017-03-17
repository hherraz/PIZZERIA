namespace Pizzeria
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_salir = new System.Windows.Forms.PictureBox();
            this.btn_administrar = new System.Windows.Forms.PictureBox();
            this.btn_cierrecaja = new System.Windows.Forms.PictureBox();
            this.btn_productos = new System.Windows.Forms.PictureBox();
            this.btn_delivery = new System.Windows.Forms.PictureBox();
            this.btn_tomapedido = new System.Windows.Forms.PictureBox();
            this.minimizar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PanelTomaPedidos = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.btnConsumoLocal = new System.Windows.Forms.Button();
            this.btnRetiroLocal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_administrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cierrecaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tomapedido)).BeginInit();
            this.panel4.SuspendLayout();
            this.PanelTomaPedidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(0, 229);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 23);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(653, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "HORA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(349, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "LOGIN DE USUARIO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(39, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "FECHA";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 146);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_salir);
            this.panel3.Controls.Add(this.btn_administrar);
            this.panel3.Controls.Add(this.btn_cierrecaja);
            this.panel3.Controls.Add(this.btn_productos);
            this.panel3.Controls.Add(this.btn_delivery);
            this.panel3.Controls.Add(this.btn_tomapedido);
            this.panel3.Location = new System.Drawing.Point(22, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 116);
            this.panel3.TabIndex = 0;
            this.panel3.Visible = false;
            // 
            // btn_salir
            // 
            this.btn_salir.Image = global::Pizzeria.Properties.Resources.salida;
            this.btn_salir.Location = new System.Drawing.Point(635, 19);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(81, 79);
            this.btn_salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_salir.TabIndex = 5;
            this.btn_salir.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_salir, "SALIR DEL SISTEMA");
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            this.btn_salir.MouseLeave += new System.EventHandler(this.btn_salir_MouseLeave);
            this.btn_salir.MouseHover += new System.EventHandler(this.btn_salir_MouseHover);
            // 
            // btn_administrar
            // 
            this.btn_administrar.Image = global::Pizzeria.Properties.Resources.usuarios;
            this.btn_administrar.Location = new System.Drawing.Point(512, 19);
            this.btn_administrar.Name = "btn_administrar";
            this.btn_administrar.Size = new System.Drawing.Size(81, 79);
            this.btn_administrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_administrar.TabIndex = 4;
            this.btn_administrar.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_administrar, "ADMINISTRAR");
            this.btn_administrar.MouseLeave += new System.EventHandler(this.btn_administrar_MouseLeave);
            this.btn_administrar.MouseHover += new System.EventHandler(this.btn_administrar_MouseHover);
            // 
            // btn_cierrecaja
            // 
            this.btn_cierrecaja.Image = global::Pizzeria.Properties.Resources.cierre;
            this.btn_cierrecaja.Location = new System.Drawing.Point(389, 19);
            this.btn_cierrecaja.Name = "btn_cierrecaja";
            this.btn_cierrecaja.Size = new System.Drawing.Size(81, 79);
            this.btn_cierrecaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_cierrecaja.TabIndex = 3;
            this.btn_cierrecaja.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_cierrecaja, "CIERRE DE CAJA");
            this.btn_cierrecaja.MouseLeave += new System.EventHandler(this.btn_cierrecaja_MouseLeave);
            this.btn_cierrecaja.MouseHover += new System.EventHandler(this.btn_cierrecaja_MouseHover);
            // 
            // btn_productos
            // 
            this.btn_productos.Image = global::Pizzeria.Properties.Resources.productos;
            this.btn_productos.Location = new System.Drawing.Point(266, 19);
            this.btn_productos.Name = "btn_productos";
            this.btn_productos.Size = new System.Drawing.Size(81, 79);
            this.btn_productos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_productos.TabIndex = 2;
            this.btn_productos.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_productos, "MANAGER DE PRODUCTOS");
            this.btn_productos.MouseLeave += new System.EventHandler(this.btn_productos_MouseLeave);
            this.btn_productos.MouseHover += new System.EventHandler(this.btn_productos_MouseHover);
            // 
            // btn_delivery
            // 
            this.btn_delivery.Image = global::Pizzeria.Properties.Resources.delivery;
            this.btn_delivery.Location = new System.Drawing.Point(143, 19);
            this.btn_delivery.Name = "btn_delivery";
            this.btn_delivery.Size = new System.Drawing.Size(81, 79);
            this.btn_delivery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_delivery.TabIndex = 1;
            this.btn_delivery.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_delivery, "ESTADO PEDIDOS / DELIVERY");
            this.btn_delivery.MouseLeave += new System.EventHandler(this.btn_delivery_MouseLeave);
            this.btn_delivery.MouseHover += new System.EventHandler(this.btn_delivery_MouseHover);
            // 
            // btn_tomapedido
            // 
            this.btn_tomapedido.Image = global::Pizzeria.Properties.Resources.pedidos;
            this.btn_tomapedido.Location = new System.Drawing.Point(20, 19);
            this.btn_tomapedido.Name = "btn_tomapedido";
            this.btn_tomapedido.Size = new System.Drawing.Size(81, 79);
            this.btn_tomapedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_tomapedido.TabIndex = 0;
            this.btn_tomapedido.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_tomapedido, "TOMA DE PEDIDOS");
            this.btn_tomapedido.Click += new System.EventHandler(this.btn_tomapedido_Click);
            this.btn_tomapedido.MouseLeave += new System.EventHandler(this.btn_tomapedido_MouseLeave);
            this.btn_tomapedido.MouseHover += new System.EventHandler(this.btn_tomapedido_MouseHover);
            // 
            // minimizar
            // 
            this.minimizar.BackColor = System.Drawing.Color.Black;
            this.minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizar.ForeColor = System.Drawing.Color.White;
            this.minimizar.Location = new System.Drawing.Point(719, 5);
            this.minimizar.Name = "minimizar";
            this.minimizar.Size = new System.Drawing.Size(36, 29);
            this.minimizar.TabIndex = 3;
            this.minimizar.Text = "--";
            this.toolTip1.SetToolTip(this.minimizar, "MINIMIZAR");
            this.minimizar.UseVisualStyleBackColor = false;
            this.minimizar.Click += new System.EventHandler(this.minimizar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.minimizar);
            this.panel4.Controls.Add(this.cerrar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 37);
            this.panel4.TabIndex = 5;
            // 
            // cerrar
            // 
            this.cerrar.BackColor = System.Drawing.Color.Black;
            this.cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar.ForeColor = System.Drawing.Color.White;
            this.cerrar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.cerrar.Location = new System.Drawing.Point(761, 5);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(36, 29);
            this.cerrar.TabIndex = 4;
            this.cerrar.Text = "X";
            this.toolTip1.SetToolTip(this.cerrar, "SALIR");
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // PanelTomaPedidos
            // 
            this.PanelTomaPedidos.BackColor = System.Drawing.Color.Transparent;
            this.PanelTomaPedidos.BackgroundImage = global::Pizzeria.Properties.Resources._240_F_99640866_dNj6uLcGW8pd5VyM8TO9lTzCePZYyvRR;
            this.PanelTomaPedidos.Controls.Add(this.button1);
            this.PanelTomaPedidos.Controls.Add(this.btnDelivery);
            this.PanelTomaPedidos.Controls.Add(this.btnConsumoLocal);
            this.PanelTomaPedidos.Controls.Add(this.btnRetiroLocal);
            this.PanelTomaPedidos.Location = new System.Drawing.Point(0, 0);
            this.PanelTomaPedidos.Name = "PanelTomaPedidos";
            this.PanelTomaPedidos.Size = new System.Drawing.Size(727, 53);
            this.PanelTomaPedidos.TabIndex = 6;
            this.PanelTomaPedidos.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.Location = new System.Drawing.Point(586, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "CANCELAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.BackColor = System.Drawing.Color.Silver;
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Location = new System.Drawing.Point(395, 6);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(186, 40);
            this.btnDelivery.TabIndex = 8;
            this.btnDelivery.Text = "PEDIDO TELEFONICO";
            this.btnDelivery.UseVisualStyleBackColor = false;
            // 
            // btnConsumoLocal
            // 
            this.btnConsumoLocal.BackColor = System.Drawing.Color.Silver;
            this.btnConsumoLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumoLocal.Location = new System.Drawing.Point(17, 6);
            this.btnConsumoLocal.Name = "btnConsumoLocal";
            this.btnConsumoLocal.Size = new System.Drawing.Size(186, 40);
            this.btnConsumoLocal.TabIndex = 6;
            this.btnConsumoLocal.Text = "CONSUMO EN EL LOCAL";
            this.btnConsumoLocal.UseVisualStyleBackColor = false;
            this.btnConsumoLocal.Click += new System.EventHandler(this.btnConsumoLocal_Click);
            // 
            // btnRetiroLocal
            // 
            this.btnRetiroLocal.BackColor = System.Drawing.Color.Silver;
            this.btnRetiroLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetiroLocal.Location = new System.Drawing.Point(206, 6);
            this.btnRetiroLocal.Name = "btnRetiroLocal";
            this.btnRetiroLocal.Size = new System.Drawing.Size(186, 40);
            this.btnRetiroLocal.TabIndex = 7;
            this.btnRetiroLocal.Text = "RETIRO EN EL LOCAL";
            this.btnRetiroLocal.UseVisualStyleBackColor = false;
            this.btnRetiroLocal.Click += new System.EventHandler(this.btnRetiroLocal_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.PanelTomaPedidos);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_administrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cierrecaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tomapedido)).EndInit();
            this.panel4.ResumeLayout(false);
            this.PanelTomaPedidos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox btn_salir;
        private System.Windows.Forms.PictureBox btn_administrar;
        private System.Windows.Forms.PictureBox btn_cierrecaja;
        private System.Windows.Forms.PictureBox btn_productos;
        private System.Windows.Forms.PictureBox btn_delivery;
        private System.Windows.Forms.PictureBox btn_tomapedido;
        private System.Windows.Forms.Button minimizar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel PanelTomaPedidos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.Button btnConsumoLocal;
        private System.Windows.Forms.Button btnRetiroLocal;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cerrar;
    }
}