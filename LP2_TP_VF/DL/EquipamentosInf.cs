using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DL
{
    [Serializable]
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
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <returns></returns>
        public static int VerificaExisteEquipamento(int codigoEquip)
        {
            try
            {
                int i;
                i = equipamentoInfs.FindIndex(x => x.EquipamentoInformatico.codigo == codigoEquip);
                return i;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return -1;
        }

        /// <summary>
        /// Verifica se o codigo da vulnerabilidade ja existe na lista de codigo de vulnerabilidades do equipamento informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static int VerificaExisteVulEquipamento(int codigoEquip, int codigoVul)
        {
            try
            {
                int i, j;
                i = VerificaExisteEquipamento(codigoEquip);
                if(i != 1)
                {
                    j = equipamentoInfs[i].CodigoVulnerabilidades.FindIndex(x => x == codigoVul);
                    return j;
                }
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return -1;
        }
       

        /// <summary>
        /// Adiciona um equipamento a lista de equipamentos
        /// </summary>
        /// <param name="equip">Equipamento Informatico</param>
        /// <returns></returns>
        public static bool AdicionaEquipamento(EquipamentoInfDL equip)
        {
            try
            {
                if (VerificaExisteEquipamento(equip.EquipamentoInformatico.codigo) == -1)
                {
                    equipamentoInfs.Add(equip);
                    totEquipamentos++;
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Editar a data de aquisicao de um equipamento informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="dt">Data de Aquisicao</param>
        /// <returns></returns>
        public static bool EditarEquipInfData(int codigoEquip, DateTime dt)
        {
            try
            {
                int i = VerificaExisteEquipamento(codigoEquip);
                if (i != -1)
                {
                    equipamentoInfs[i].EquipamentoInformatico.dataAquisicao = dt;
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Editar o tipo de equipamento informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="t">Tipo</param>
        /// <returns></returns>
        public static bool EditarEquipInfTipo(int codigoEquip, string t)
        {
            try
            {
                int i = VerificaExisteEquipamento(codigoEquip);
                if (i != -1)
                {
                    equipamentoInfs[i].EquipamentoInformatico.tipo = t;
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Editar a marca do Equipamento Informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="m">Marca</param>
        /// <returns></returns>
        public static bool EditarEquipInfMarca(int codigoEquip, string m)
        {
            try
            {
                int i = VerificaExisteEquipamento(codigoEquip);
                if (i != -1)
                {
                    equipamentoInfs[i].EquipamentoInformatico.marca = m;
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Editar o modelo Equipamento Informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="mod">Modelo</param>
        /// <returns></returns>
        public static bool EditarEquipInfModelo(int codigoEquip, string mod)
        {
            try
            {
                int i = VerificaExisteEquipamento(codigoEquip);
                if (i != -1)
                {
                    equipamentoInfs[i].EquipamentoInformatico.modelo = mod;
                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
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

        /// <summary>
        /// Adiciona uma vulnerabilidade ao Equipamento Informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AdicionarVulnerabilidadeEquip(int codigoEquip, int codigoVul)
        {
            try
            {
                int i = VerificaExisteEquipamento(codigoEquip);
                if (i != -1)
                {
                    int j = VerificaExisteVulEquipamento(codigoEquip, codigoVul);
                    if (j == -1)
                    {
                        equipamentoInfs[i].CodigoVulnerabilidades.Add(codigoVul);
                        return true;
                    }
                }
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;
        }
        

        /// <summary>
        /// Remove todos os elementos da lista de equipamentos informaticos
        /// </summary>
        public static void ClearEquipamentos()
        {
            equipamentoInfs.Clear();
        }

        /// <summary>
        /// Ordena a lista de equipamentos informaticos pelo numero de vulnerabilidades crescente
        /// </summary>
        public static void EquipNumeroVulCresc()
        {
            equipamentoInfs.Sort(new SortVulEquipCresc());
        }

        /// <summary>
        /// Ordena a lista de equipamentos informaticos pelo numero de vulnerabilidades decrescent
        /// </summary>
        public static void EquipNumeroVulDec()
        {
            equipamentoInfs.Sort(new SortVulEquipDec());
        }
        #endregion

        #region Ficheiros
        /// <summary>
        /// Guardar equipamentos informaticos num ficheiro binario
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveEquipamentosInformaticos(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, equipamentoInfs);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("ERRO:" + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return false;
            }
            else
            {
                try
                {
                    Stream stream = File.Create(fileName);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, equipamentoInfs);
                    stream.Close();
                    return true;

                }
                catch (IOException ex)
                {
                    Console.Write("ERRO:" + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return false;
            }
        }

        /// <summary>
        /// Carrega a lista de equipamentos informaticos
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadEquipamentosInformaticos(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    equipamentoInfs = (List<EquipamentoInfDL>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("ERRO:" + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return false;
        }
        #endregion
    }
}