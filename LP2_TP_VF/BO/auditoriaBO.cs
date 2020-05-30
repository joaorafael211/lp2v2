using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class auditoriaBO
    {
        #region Attributes 
        public int codigo;
        public DateTime data;
        public float duracao;
        public int codigoColaborador;
        #endregion

        #region Constructors
        public auditoriaBO(int totaud, DateTime dt, float dur, int codigoCol)
        {
            codigo =  totaud + 1;
            data = dt;
            duracao = dur;
            codigoColaborador = codigoCol;
        }
        #endregion

        #region Properties
        public int Codigo
        {
            get { return codigo; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public float Duracao
        {
            get { return duracao; }
            set { duracao = value; }
        }
        #endregion

      
        public override string ToString()
        {
            return string.Format("Codigo: {0} \nData: {1} \nDuracao: {2}\nCodigo Colaborador Responsavel: {3}\n", codigo.ToString(), data.ToString(), duracao.ToString(), codigoColaborador.ToString());
        }
    }
}
