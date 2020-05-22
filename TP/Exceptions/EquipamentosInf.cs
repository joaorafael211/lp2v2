using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class EquipamentosInf
    {
        #region MemberVariables
        private static List<EquipamentoInfDL> equipamentoInfs;
        private static int totEquipamentos;
        #endregion

        #region Constructors
        static EquipamentosInf()
        {
            equipamentoInfs = new List<EquipamentoInfDL>();
        }
        #endregion
        
        #region Properties
        public static int TotalEquipamentos
        {
            get { return totEquipamentos; }
        }
        #endregion

        #region Functions

        /// <summary>
        /// Verifica se o equipamento ja esta na lista de equipamentos
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool VerificaExisteEquipamento(EquipamentoInfDL e)
        {
            try
            {
                if (equipamentoInfs.Contains(e))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Adiciona um equipamento a lista de equipamentos
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool AdicionaEquipamento(EquipamentoInfDL equip)
        {
            try
            {
                if (!VerificaExisteEquipamento(equip))
                {
                    equipamentoInfs.Add(equip);
                    totEquipamentos++;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Editar a data de aquisicao de um equipamento informatico
        /// </summary>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="dt">Data de Aquisicao</param>
        /// <returns></returns>
        public static bool EditarEquipInfData(EquipamentoInfDL equip, DateTime dt)
        {
            try
            {
                if (VerificaExisteEquipamento(equip))
                {
                    int i = equipamentoInfs.IndexOf(equip);
                    equipamentoInfs[i].EquipamentoInformatico.dataAquisicao = dt;
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        /// <summary>
        /// Editar o tipo de equipamento informatico
        /// </summary>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="t">Tipo</param>
        /// <returns></returns>
        public static bool EditarEquipInfTipo(EquipamentoInfDL equip, string t)
        {
            try
            {
                if (VerificaExisteEquipamento(equip))
                {
                    int i = equipamentoInfs.IndexOf(equip);
                    equipamentoInfs[i].EquipamentoInformatico.tipo = t;
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        /// <summary>
        /// Editar a marca do Equipamento Informatico
        /// </summary>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="m">Marca</param>
        /// <returns></returns>
        public static bool EditarEquipInfMarca(EquipamentoInfDL equip, string m)
        {
            try
            {
                if (VerificaExisteEquipamento(equip))
                {
                    int i = equipamentoInfs.IndexOf(equip);
                    equipamentoInfs[i].EquipamentoInformatico.marca = m;
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        /// <summary>
        /// Editar o modelo Equipamento Informatico
        /// </summary>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="mod">Modelo</param>
        /// <returns></returns>
        public static bool EditarEquipInfModelo(EquipamentoInfDL equip, string mod)
        {
            try
            {
                if (VerificaExisteEquipamento(equip))
                {
                    int i = equipamentoInfs.IndexOf(equip);
                    equipamentoInfs[i].EquipamentoInformatico.modelo = mod;
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os equipamentos informaticos na lista de equipamentos informaticos
        /// </summary>
        public static void showListEquips()
        {
            equipamentoInfs.ForEach(Console.WriteLine);
        }
        #endregion
    }
}