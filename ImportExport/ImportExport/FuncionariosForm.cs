using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExport
{
    public partial class FuncionariosForm : Form
    {
        public FuncionariosForm()
        {
            InitializeComponent();
            importarDadosButton.Enabled = true;
            ajustarSalariosButton.Enabled = false;
            exportarDadosButton.Enabled = false;
        }

        private ArrayList funcionarios;

        //private const string arquivoParaImportar = "\\funcionarios.csv";

        //private const string arquivoParaExportar = "\\funcionarios_com_aumento.csv";

        private void importarDadosButton_Click(object sender, EventArgs e)
        {

            #region importa os dados do arquivo csv
            //Propriedade filter = string para visualizar apenas os arquivos informados
            //Se forem dois arquivos: Text files (*.txt)|*.txt|All files (*.*)|*.*
            openFileDialog.Filter = "Arquivos CSV | *.csv";
            //Classe Environment serve para variáveis ambiente. No caso, acessa a pasta do usuário
            //String verbatim : Quando coloca @ na frente, passa a tring exatamente como ela é. Sem o @, é necessário colocar 2 barras pra apontar o diretório
            openFileDialog.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop";

            //openFileDialog.ShowDialog();
            //funcionarios = Dados.ImportarDeCSV(Application.StartupPath + arquivoParaImportar);
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                funcionarios = Dados.ImportarDeCSV(openFileDialog.FileName);
            }
            else
            {
                //se um método se não retorna nada, sai do método sem passar parâmetro, senão tem que passar
                return;
            }
            #endregion

            #region vincula os dados no datagridview
            funcionariosDataGridView.DataSource = funcionarios;
            #endregion

            #region customização do datagridview
            funcionariosDataGridView.Columns[0].HeaderText = "Código";
            funcionariosDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[1].HeaderText = "Nome";
            funcionariosDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[2].HeaderText = "Sobrenome";
            funcionariosDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[3].HeaderText = "Admissão";
            funcionariosDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[4].HeaderText = "Salário Atual";
            funcionariosDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[4].DefaultCellStyle.Format = "#,##0.00";
            funcionariosDataGridView.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("en-US");
            funcionariosDataGridView.Columns[5].HeaderText = "Novo Salário";
            funcionariosDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            funcionariosDataGridView.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            funcionariosDataGridView.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("en-US");
            funcionariosDataGridView.Columns[5].DefaultCellStyle.NullValue = "---";
            #endregion

            ajustarSalariosButton.Enabled = true;

        }

        private void ajustarSalariosButton_Click(object sender, EventArgs e)
        {
            #region ajusta salarios conforme rn
            Dados.AjustarSalarios(funcionarios);
            #endregion

            #region sinaliza na interface gráfica quais os salários tiveram aumento
            for (int i = 0; i < funcionarios.Count; i++)
            {
                Funcionario func = funcionarios[i] as Funcionario;

                if (func.NovoSalario != null) //Recebeu aumento?
                {
                    funcionariosDataGridView.Rows[i].Cells[5].Value = func.NovoSalario;
                    funcionariosDataGridView.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                }
            }
            #endregion

            MessageBox.Show("Número de funcionários com aumento = " + Dados.funcAumento);
            exportarDadosButton.Enabled = true;

        }

        private void exportarDadosButton_Click(object sender, EventArgs e)
        {
            
            #region Exportar os dados para o arquivo csv
            //Dados.ExportarParaCSV(Application.StartupPath + arquivoParaExportar, funcionarios);
            saveFileDialog.Filter = "Arquivos CSV | *.csv";
            //saveFileDialog.ShowDialog();

            //salvando o nome do arquivo com a data de hoje
            saveFileDialog.FileName = string.Format("funcionarios_com_aumento_{0}.csv",System.DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss"));
            //outra forma
            //saveFileDialog.FileName = string.Format("funcionarios_com_aumento_{0:yyyy-MM-dd_hh_mm_ss}.csv" 

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dados.ExportarParaCSV(saveFileDialog.FileName.ToString(), funcionarios);
            }
            else
            {
                return;
            }
            #endregion

            #region Feedback ao usuário
            MessageBox.Show("Exportação concluída com sucesso"); 
            #endregion

            #region Abre o arquivo csv no editor de textos
            //nesse método, o primeiro argumento: nome do programa, segundo arrgumento o arquivo
            Process.Start("notepad", saveFileDialog.FileName.ToString()); 
            #endregion
        }

    }
}