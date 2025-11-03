namespace ImportExport
{
    partial class FuncionariosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.importarDadosButton = new System.Windows.Forms.Button();
            this.funcionariosDataGridView = new System.Windows.Forms.DataGridView();
            this.ajustarSalariosButton = new System.Windows.Forms.Button();
            this.exportarDadosButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importarDadosButton
            // 
            this.importarDadosButton.Location = new System.Drawing.Point(12, 12);
            this.importarDadosButton.Name = "importarDadosButton";
            this.importarDadosButton.Size = new System.Drawing.Size(105, 39);
            this.importarDadosButton.TabIndex = 0;
            this.importarDadosButton.Text = "Importar Dados";
            this.importarDadosButton.UseVisualStyleBackColor = true;
            this.importarDadosButton.Click += new System.EventHandler(this.importarDadosButton_Click);
            // 
            // funcionariosDataGridView
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Moccasin;
            this.funcionariosDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.funcionariosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionariosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.funcionariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionariosDataGridView.Location = new System.Drawing.Point(13, 76);
            this.funcionariosDataGridView.MultiSelect = false;
            this.funcionariosDataGridView.Name = "funcionariosDataGridView";
            this.funcionariosDataGridView.ReadOnly = true;
            this.funcionariosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.funcionariosDataGridView.Size = new System.Drawing.Size(578, 249);
            this.funcionariosDataGridView.TabIndex = 1;
            // 
            // ajustarSalariosButton
            // 
            this.ajustarSalariosButton.Location = new System.Drawing.Point(123, 12);
            this.ajustarSalariosButton.Name = "ajustarSalariosButton";
            this.ajustarSalariosButton.Size = new System.Drawing.Size(105, 39);
            this.ajustarSalariosButton.TabIndex = 2;
            this.ajustarSalariosButton.Text = "Ajustar Salários";
            this.ajustarSalariosButton.UseVisualStyleBackColor = true;
            this.ajustarSalariosButton.Click += new System.EventHandler(this.ajustarSalariosButton_Click);
            // 
            // exportarDadosButton
            // 
            this.exportarDadosButton.Location = new System.Drawing.Point(234, 12);
            this.exportarDadosButton.Name = "exportarDadosButton";
            this.exportarDadosButton.Size = new System.Drawing.Size(105, 39);
            this.exportarDadosButton.TabIndex = 3;
            this.exportarDadosButton.Text = "Exportar Dados";
            this.exportarDadosButton.UseVisualStyleBackColor = true;
            this.exportarDadosButton.Click += new System.EventHandler(this.exportarDadosButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.FileName = "ofdFile";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            this.saveFileDialog.FileName = "sfdFile";
            // 
            // FuncionariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 337);
            this.Controls.Add(this.exportarDadosButton);
            this.Controls.Add(this.ajustarSalariosButton);
            this.Controls.Add(this.funcionariosDataGridView);
            this.Controls.Add(this.importarDadosButton);
            this.Name = "FuncionariosForm";
            this.Text = "Ferramenta Import/Export";
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importarDadosButton;
        private System.Windows.Forms.DataGridView funcionariosDataGridView;
        private System.Windows.Forms.Button ajustarSalariosButton;
        private System.Windows.Forms.Button exportarDadosButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

