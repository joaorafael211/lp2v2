using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DL
{
    [Serializable]
    public class VulnerabilidadeDL
    {
        #region MemberVariables
        private vulnerabilidadeBO vulnerabilidade;
        private EstadoVul estado;
        #endregion

        #region Constructors
        public VulnerabilidadeDL(vulnerabilidadeBO v)
        {
            vulnerabilidade = v;
            estado = EstadoVul.ATIVO;
        }
        #endregion

        #region Properties
        public vulnerabilidadeBO Vulnerabilidade
        {
            get { return vulnerabilidade; }
        }

        public EstadoVul Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region Enums
        public enum EstadoVul
        {
            ATIVO,
            INATIVO
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            VulnerabilidadeDL aux = (VulnerabilidadeDL)obj;
            return (aux.vulnerabilidade.codigo == this.vulnerabilidade.codigo);
        }

        public override string ToString()
        {
            return string.Format("{0}\nEstado: {1}\n", vulnerabilidade.ToString(), estado.ToString());
        }
        #endregion

        #region Operators

        public static bool operator == (VulnerabilidadeDL v1, VulnerabilidadeDL v2)
        {
            return (v1.Equals(v2));
        }

        public static bool operator != (VulnerabilidadeDL v1, VulnerabilidadeDL v2)
        {
            return (!v1.Equals(v2));
        }

        #endregion  
    }
}
