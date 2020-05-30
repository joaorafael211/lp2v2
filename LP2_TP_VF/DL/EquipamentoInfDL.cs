using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DL
{
    [Serializable]
    public class EquipamentoInfDL
    {
        #region MemberVariables 
        private EquipamentoInfBO equipInf;
        private List<int> codigosVul;
        
        #endregion

        #region Constructors

        public EquipamentoInfDL(EquipamentoInfBO equip)
        {
            equipInf = equip;
            codigosVul = new List<int>();
        }


        #endregion

        #region Properties
        public EquipamentoInfBO EquipamentoInformatico
        {
            get { return equipInf; }
        }

        public List<int> CodigoVulnerabilidades
        {
            get { return codigosVul; }
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
            return string.Format("{0} Numero de Vulnerabilidades: {1}\n", equipInf.ToString(), codigosVul.Count);
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

    public class SortVulEquipDec : IComparer<EquipamentoInfDL>
    {
        public int Compare(EquipamentoInfDL e1, EquipamentoInfDL e2)
        {
            return e2.CodigoVulnerabilidades.Count - e1.CodigoVulnerabilidades.Count;
        }
    }

    public class SortVulEquipCresc : IComparer<EquipamentoInfDL>
    {
        public int Compare(EquipamentoInfDL e1, EquipamentoInfDL e2)
        {
            return e1.CodigoVulnerabilidades.Count - e2.CodigoVulnerabilidades.Count;
        }
    }

}
