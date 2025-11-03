using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport
{
    class Dados
    {
        //Essa propriedade só é utilizada para guardar o número de funcionários com aumento
        private static double _funcAumento;
        public static double funcAumento
        {
            get { return _funcAumento; }
            set { _funcAumento = value;  }

        }


        //propriedade automática
        //snippet prop, cria uma propriedade
        //public static int funcAumento { get; set; }

        //tudo o que está declarado como estático é carregado na memória no momento em que inicia a aplicação
        public static ArrayList ImportarDeCSV(string nomeArquivo)
        {
            ArrayList funcionarios = new ArrayList();
            StreamReader sr = new StreamReader(nomeArquivo);
            string linhaDados;
            linhaDados = sr.ReadLine(); //cabeçalho do arquivo!!!   

            while ((linhaDados = sr.ReadLine()) != null)
            {
                string[] campos = linhaDados.Split(',');
                Funcionario func = new Funcionario();
                func.Id = Convert.ToInt32(campos[0]);
                func.PrimeiroNome = campos[1];
                func.Sobrenome = campos[2];
                func.DataAdmissao = Convert.ToDateTime(campos[5], new CultureInfo("en-US"));
                func.SalarioAtual = Convert.ToDouble(campos[7]);

                funcionarios.Add(func);
            }

            return funcionarios;
        }


        public static void AjustarSalarios(ArrayList funcionarios)
        {
            funcAumento = 0;
            foreach (Funcionario func in funcionarios)
            {
                if (func.DataAdmissao.Year <= 2003)
                {
                    func.NovoSalario = func.SalarioAtual * 1.1;
                    funcAumento++;
                }
            }
        }


        public static void ExportarParaCSV(string nomeArquivo, ArrayList funcionarios)
        {
            //Streamwriter - > classe para gravar em arquivos
            StreamWriter sw = new StreamWriter(nomeArquivo, false);
            //sintaxe chamada parâmetros nomeados. Opcional
            //StreamWriter sw = new StreamWriter(path: nomeArquivo, append: false);

            StringBuilder sb = new StringBuilder();

            string linhaDados = "EMPLOYEE_ID,FIRST_NAME,LAST_NAME,HIRE_DATE,SALARY,NEW_SALARY";

            sw.WriteLine(linhaDados);

            foreach (Funcionario func in funcionarios)
            {
                if (func.NovoSalario != null)
                {
                    sb.Clear();
                    sb.Append(func.Id);
                    sb.Append(','); //Caracter delimitado com aspas simples. As strings são delimitadas com aspas duplas
                    sb.Append(func.PrimeiroNome);
                    sb.Append(',');
                    sb.Append(func.Sobrenome);
                    sb.Append(',');
                    sb.Append(func.DataAdmissao.ToString("MM/dd/yyyy", new CultureInfo("en-US")));
                    sb.Append(',');
                    sb.Append(func.SalarioAtual.ToString("0.00", new CultureInfo("en-US")));
                    sb.Append(',');
                    //Estou convertendo tipo double? para double
                    sb.Append(Convert.ToDouble(func.NovoSalario).ToString("0.00", new CultureInfo("en-US")));
                    sb.Append(',');

                    linhaDados = sb.ToString();
                    sw.WriteLine(linhaDados);
                }
            }

            sw.WriteLine("Total de funcionários: "
                        + Convert.ToString(funcAumento)
                        + "\t\tPercentual: "
                        + Convert.ToString((Convert.ToDouble(funcionarios.Count) / 100.00) * funcAumento)
                        );

            //Type casting (double) funcionarios count
            //String Format: formata strings

            //linhaDados = string.Format("Total: {0} - {1:N2} %", 
            //            funcAumento, //substitui {0}
            //            funcAumento / (double)funcionarios.Count); //Substitui {1} - N2 = retorna 2 casas decimais
            //sw.WriteLine(linhaDados);

            //Colocando P2 já exibe no formato de porcentagem
            //linhaDados = string.Format("Total: {0} - {1:P2} %", 
            //            funcAumento, //substitui {0}
            //            funcAumento / (double)funcionarios.Count); //Substitui {1} - N2 = retorna 2 casas decimais
            //sw.WriteLine(linhaDados);

            sw.Close();

        }

    }
}
