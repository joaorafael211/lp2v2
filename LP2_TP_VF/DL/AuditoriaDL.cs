using System;
using System.Collections.Generic;
using System.Text;
using BO;


namespace DL
{   
    [Serializable]
    public class AuditoriaDL
    {
        #region MemberVariables 
        private auditoriaBO auditoria;
        private List<int> codigosVul;
        #endregion

        #region Constructors
        public AuditoriaDL(auditoriaBO a)
        {
            auditoria = a;
            codigosVul = new List<int>();
        }
        #endregion

        #region Properties 
        public auditoriaBO Auditoria
        {
            get { return auditoria; }
        }

        public List<int> CodigosVul
        {
            get { return codigosVul; }
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            AuditoriaDL aux = (AuditoriaDL)obj;
            return (aux.auditoria.codigo == this.auditoria.codigo);
        }

        public override string ToString()
        {
            return string.Format(auditoria.ToString() + "Numero de Vulnerabilidades: " + codigosVul.Count + "\n"); 
        }
        #endregion

        #region Operators
        public static bool operator == (AuditoriaDL a1, AuditoriaDL a2)
        {
            return (a1.Equals(a2));
        }

        public static bool operator != (AuditoriaDL a1, AuditoriaDL a2)
        {
            return (!a1.Equals(a2));
        }
        #endregion
    }

    public class SortVulAudCresc : IComparer<AuditoriaDL>
    {
        public int Compare(AuditoriaDL a1, AuditoriaDL a2)
        {
            return a1.CodigosVul.Count - a2.CodigosVul.Count;
        }
    }

    public class SortVulAudDec : IComparer<AuditoriaDL>
    {
        public int Compare(AuditoriaDL a1, AuditoriaDL a2)
        {
            return a2.CodigosVul.Count - a1.CodigosVul.Count;
        }
    }
}
