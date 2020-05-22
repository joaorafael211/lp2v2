using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class colaboradorBO
    {
        #region Member Variables
        public string nome;
        public int codigo;
        #endregion

        #region Constructors
        public colaboradorBO(string n, int totCol)
        {
            nome = n;
            codigo = totCol + 1;
        }
        #endregion

        #region Properties
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        #endregion


        public override string ToString()
        {
            return string.Format("Colaborador: {0} \nCodigo: {1} \n", nome, codigo);
        }
    }
}
