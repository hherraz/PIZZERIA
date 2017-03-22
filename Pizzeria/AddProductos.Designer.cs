namespace Pizzeria
{
    partial class AddProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used. RG
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgCarrito = new System.Windows.Forms.DataGridView();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.AgregarPizzaMenu = new System.Windows.Forms.Button();
            this.dgProductos = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLiquidos = new System.Windows.Forms.Button();
            this.btnAcom = new System.Windows.Forms.Button();
            this.btnPostres = new System.Windows.Forms.Button();
            this.btnOtros = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.dgCarrito);
            this.panel1.Controls.Add(this.txtprecio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(719, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 399);
            this.panel1.TabIndex = 10;
            // 
            // dgCarrito
            // 
            this.dgCarrito.AllowUserToAddRows = false;
            this.dgCarrito.AllowUserToDeleteRows = false;
            this.dgCarrito.AllowUserToResizeColumns = false;
            this.dgCarrito.AllowUserToResizeRows = false;
            this.dgCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCarrito.ColumnHeadersVisible = false;
            this.dgCarrito.EnableHeadersVisualStyles = false;
            this.dgCarrito.Location = new System.Drawing.Point(17, 45);
            this.dgCarrito.MultiSelect = false;
            this.dgCarrito.Name = "dgCarrito";
            this.dgCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCarrito.Size = new System.Drawing.Size(240, 278);
            this.dgCarrito.TabIndex = 19;
            this.dgCarrito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgIngredientes_CellContentClick);
            // 
            // txtprecio
            // 
            this.txtprecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecio.Location = new System.Drawing.Point(17, 347);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(234, 23);
            this.txtprecio.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(104, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "TOTAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "CARRO DE COMPRAS";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(859, 470);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(125, 36);
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.Text = "CANCELAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // AgregarPizzaMenu
            // 
            this.AgregarPizzaMenu.BackColor = System.Drawing.Color.Blue;
            this.AgregarPizzaMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarPizzaMenu.ForeColor = System.Drawing.Color.Yellow;
            this.AgregarPizzaMenu.Location = new System.Drawing.Point(730, 470);
            this.AgregarPizzaMenu.Name = "AgregarPizzaMenu";
            this.AgregarPizzaMenu.Size = new System.Drawing.Size(125, 36);
            this.AgregarPizzaMenu.TabIndex = 11;
            this.AgregarPizzaMenu.Text = "AGREGAR";
            this.AgregarPizzaMenu.UseVisualStyleBackColor = false;
            this.AgregarPizzaMenu.Visible = false;
            this.AgregarPizzaMenu.Click += new System.EventHandler(this.AgregarPizzaMenu_Click);
            // 
            // dgProductos
            // 
            this.dgProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgProductos.Location = new System.Drawing.Point(15, 83);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.Size = new System.Drawing.Size(688, 423);
            this.dgProductos.TabIndex = 15;
            this.dgProductos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "ACOMPAÑAMIENTOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 31);
            this.panel2.TabIndex = 21;
            // 
            // btnLiquidos
            // 
            this.btnLiquidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidos.Location = new System.Drawing.Point(15, 41);
            this.btnLiquidos.Name = "btnLiquidos";
            this.btnLiquidos.Size = new System.Drawing.Size(132, 36);
            this.btnLiquidos.TabIndex = 22;
            this.btnLiquidos.Text = "Liquidos";
            this.btnLiquidos.UseVisualStyleBackColor = true;
            this.btnLiquidos.Click += new System.EventHandler(this.btnLiquidos_Click);
            // 
            // btnAcom
            // 
            this.btnAcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcom.Location = new System.Drawing.Point(153, 41);
            this.btnAcom.Name = "btnAcom";
            this.btnAcom.Size = new System.Drawing.Size(132, 36);
            this.btnAcom.TabIndex = 23;
            this.btnAcom.Text = "Acompañamientos";
            this.btnAcom.UseVisualStyleBackColor = true;
            this.btnAcom.Click += new System.EventHandler(this.btnAcom_Click);
            // 
            // btnPostres
            // 
            this.btnPostres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostres.Location = new System.Drawing.Point(291, 41);
            this.btnPostres.Name = "btnPostres";
            this.btnPostres.Size = new System.Drawing.Size(132, 36);
            this.btnPostres.TabIndex = 24;
            this.btnPostres.Text = "Postres";
            this.btnPostres.UseVisualStyleBackColor = true;
            this.btnPostres.Click += new System.EventHandler(this.btnPostres_Click);
            // 
            // btnOtros
            // 
            this.btnOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtros.Location = new System.Drawing.Point(429, 41);
            this.btnOtros.Name = "btnOtros";
            this.btnOtros.Size = new System.Drawing.Size(132, 36);
            this.btnOtros.TabIndex = 25;
            this.btnOtros.Text = "Otros";
            this.btnOtros.UseVisualStyleBackColor = true;
            this.btnOtros.Click += new System.EventHandler(this.btnOtros_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.Location = new System.Drawing.Point(567, 41);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(132, 36);
            this.btnTodos.TabIndex = 26;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // AddProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pizzeria.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 520);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnOtros);
            this.Controls.Add(this.btnPostres);
            this.Controls.Add(this.btnAcom);
            this.Controls.Add(this.btnLiquidos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgProductos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.AgregarPizzaMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AGREGAR PRODUCTOS";
            this.Load += new System.EventHandler(this.AddProductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AgregarPizzaMenu;
        private System.Windows.Forms.DataGridView dgProductos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgCarrito;
        private System.Windows.Forms.Button btnLiquidos;
        private System.Windows.Forms.Button btnAcom;
        private System.Windows.Forms.Button btnPostres;
        private System.Windows.Forms.Button btnOtros;
        private System.Windows.Forms.Button btnTodos;
    }
}