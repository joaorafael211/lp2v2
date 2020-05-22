using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DL
{
    public class EquipamentoInfDL
    {
        #region MemberVariables 
        private EquipamentoInfBO equipInf;
        private static List<VulnerabilidadeDL> vulnerabilidades;
        
        #endregion

        #region Constructors

        public EquipamentoInfDL(EquipamentoInfBO equip)
        {
            equipInf = equip;
            vulnerabilidades = new List<VulnerabilidadeDL>();
        }


        #endregion

        #region Properties
        public EquipamentoInfBO EquipamentoInformatico
        {
            get { return equipInf; }
        }
        #endregion 

        #region Overrides

        public override bool Equals(object obj)
        {
            EquipamentoInfDL aux = (EquipamentoInfDL)obj;
            return (aux.equipInf.codigo == this.equipInf.codigo);
        }

        public override string ToString()
        {
            return string.Format("{0}", equipInf.ToString());
        }

        #endregion

        #region Operators

        public static bool operator == (EquipamentoInfDL eq1, EquipamentoInfDL eq2)
        {
            return (eq1.Equals(eq2));
        }

        public static bool operator != (EquipamentoInfDL eq1, EquipamentoInfDL eq2)
        {
            return (!eq1.Equals(eq2));
        }
        #endregion
    }
}
