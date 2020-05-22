using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class vulnerabilidadeBO
    {
        #region Member Variables
        public int codigo;
        public string descricao;
        public string nivelImpacto;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totVul">Total de vulnerabilidades</param>
        /// <param name="desc"> Descricao da vulnerabilidade</param>
        public vulnerabilidadeBO(int totVul, string desc, string n)
        {
            codigo = totVul + 1;
            descricao = desc;
            nivelImpacto = n;
        }
        #endregion


        #region Properties
        public int Codigo
        {
            get { return codigo; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string NivelImpacto
        {
            get { return nivelImpacto; }
            set { nivelImpacto = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return string.Format("Codigo: {0} \nDescricao: {1} \nNivel Impacto: {2}", codigo, descricao, nivelImpacto);
        }
        #endregion
    }
}
