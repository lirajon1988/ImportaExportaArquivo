using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport
{
    class Funcionario
    {

        #region campos/atributos
        private int _id;
        private string _primeiroNome;
        private string _sobrenome;
        private DateTime _dataAdmissao;
        private double _salarioAtual;
        private double? _novoSalario;
        #endregion

        #region propriedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string PrimeiroNome
        {
            get { return _primeiroNome; }
            set { _primeiroNome = value; }
        }
        public string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }
        public DateTime DataAdmissao
        {
            get { return _dataAdmissao; }
            set { _dataAdmissao = value; }
        }
        public double SalarioAtual
        {
            get { return _salarioAtual; }
            set { _salarioAtual = value; }
        }
        public double? NovoSalario
        {
            get { return _novoSalario; }
            set { _novoSalario = value; }
        }
        #endregion
  
    }
}
