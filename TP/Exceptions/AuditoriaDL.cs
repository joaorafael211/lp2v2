using System;
using System.Collections.Generic;
using System.Text;
using BO;


namespace DL
{
    public class AuditoriaDL
    {
        #region MemberVariables 
        private auditoriaBO auditoria;
        private List<VulnerabilidadeDL> vul;
        #endregion

        #region Constructors
        public AuditoriaDL(auditoriaBO a)
        {
            auditoria = a;
            vul = new List<VulnerabilidadeDL>();
        }

        public AuditoriaDL(auditoriaBO a, VulnerabilidadeDL v)
        {
            auditoria = a;
            vul = new List<VulnerabilidadeDL>();
            vul.Add(v);
        }
        #endregion

        #region Properties 
        public auditoriaBO Auditoria
        {
            get { return auditoria; }
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
            return string.Format(auditoria.ToString()); ;
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
}
