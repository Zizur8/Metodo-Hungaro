namespace ProyectoHungaro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtFilas = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtColumnas = new TextBox();
            dtgDatosDelEjercicio = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnAceptar = new Button();
            btnResolverProblema = new Button();
            btnLimpiar = new Button();
            chkMaximizar = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgDatosDelEjercicio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(416, 55);
            label1.Name = "label1";
            label1.Size = new Size(455, 66);
            label1.TabIndex = 0;
            label1.Text = "Metedo Hungaro";
            // 
            // txtFilas
            // 
            txtFilas.Location = new Point(185, 169);
            txtFilas.Name = "txtFilas";
            txtFilas.Size = new Size(80, 27);
            txtFilas.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F);
            label2.Location = new Point(108, 169);
            label2.Name = "label2";
            label2.Size = new Size(71, 29);
            label2.TabIndex = 2;
            label2.Text = "Filas:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14F);
            label3.Location = new Point(292, 169);
            label3.Name = "label3";
            label3.Size = new Size(127, 29);
            label3.TabIndex = 4;
            label3.Text = "Columnas:";
            // 
            // txtColumnas
            // 
            txtColumnas.Location = new Point(425, 173);
            txtColumnas.Name = "txtColumnas";
            txtColumnas.Size = new Size(80, 27);
            txtColumnas.TabIndex = 3;
            // 
            // dtgDatosDelEjercicio
            // 
            dtgDatosDelEjercicio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDatosDelEjercicio.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dtgDatosDelEjercicio.Location = new Point(108, 248);
            dtgDatosDelEjercicio.MultiSelect = false;
            dtgDatosDelEjercicio.Name = "dtgDatosDelEjercicio";
            dtgDatosDelEjercicio.RowHeadersWidth = 51;
            dtgDatosDelEjercicio.Size = new Size(1084, 385);
            dtgDatosDelEjercicio.TabIndex = 5;
            dtgDatosDelEjercicio.CellContentClick += dtgDatosDelEjercicio_CellContentClick;
            dtgDatosDelEjercicio.CellValueChanged += dtgDatosDelEjercicio_CellValueChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "3";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "4";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "5";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "6";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 125;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(530, 173);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnResolverProblema
            // 
            btnResolverProblema.BackColor = Color.Yellow;
            btnResolverProblema.Location = new Point(1098, 202);
            btnResolverProblema.Name = "btnResolverProblema";
            btnResolverProblema.Size = new Size(94, 29);
            btnResolverProblema.TabIndex = 7;
            btnResolverProblema.Text = "Resolver";
            btnResolverProblema.UseVisualStyleBackColor = false;
            btnResolverProblema.Click += btnResolverProblema_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(641, 172);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // chkMaximizar
            // 
            chkMaximizar.AutoSize = true;
            chkMaximizar.Location = new Point(771, 176);
            chkMaximizar.Name = "chkMaximizar";
            chkMaximizar.Size = new Size(18, 17);
            chkMaximizar.TabIndex = 9;
            chkMaximizar.UseVisualStyleBackColor = true;
            chkMaximizar.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(132, 23);
            label4.TabIndex = 10;
            label4.Text = "Cesar Vazquez";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(862, 90);
            label5.Name = "label5";
            label5.Size = new Size(129, 23);
            label5.TabIndex = 11;
            label5.Text = "Maestro Fisher";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 674);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(chkMaximizar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnResolverProblema);
            Controls.Add(btnAceptar);
            Controls.Add(dtgDatosDelEjercicio);
            Controls.Add(label3);
            Controls.Add(txtColumnas);
            Controls.Add(label2);
            Controls.Add(txtFilas);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtgDatosDelEjercicio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFilas;
        private Label label2;
        private Label label3;
        private TextBox txtColumnas;
        private DataGridView dtgDatosDelEjercicio;
        private Button btnAceptar;
        private Button btnResolverProblema;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button btnLimpiar;
        private CheckBox chkMaximizar;
        private Label label4;
        private Label label5;
    }
}
