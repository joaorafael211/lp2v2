using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DL
{
    [Serializable]
    public class ColaboradorDL
    {
        #region MemberVariables
        private colaboradorBO c;
        private EstadoCol estado;
        #endregion

        #region Constructors
        public ColaboradorDL(colaboradorBO col)
        {
            c = col;
            estado = EstadoCol.ATIVO;
        }
        #endregion

        #region Properties
        public colaboradorBO Colaborador
        {
            get { return c; }
        }

        public EstadoCol Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            ColaboradorDL aux = (ColaboradorDL)obj;
            return (aux.c.codigo == this.c.codigo);
        }

        public override string ToString()
        {
            return string.Format("{0}Estado: {1}", c.ToString(), estado);
        }

        #endregion

        #region Operators

        public static bool operator == (ColaboradorDL c1, ColaboradorDL c2)
        {
            return (c1.Equals(c2));
        }

        public static bool operator != (ColaboradorDL c1, ColaboradorDL c2)
        {
            return (!c1.Equals(c2));
        }
        #endregion

        #region Enums 
        public enum EstadoCol
        {
            ATIVO = 0,
            INATIVO = 1
        }
        #endregion
    }
}
