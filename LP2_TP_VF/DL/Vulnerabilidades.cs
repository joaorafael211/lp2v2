using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DL
{
    [Serializable]
    public class Vulnerabilidades
    {
        #region MemberVariables
        private static List<VulnerabilidadeDL> vulnerabilidades;
        private static int totVulnerabilidades;
        #endregion
        
        #region Constructors
        static Vulnerabilidades()
        {
            vulnerabilidades = new List<VulnerabilidadeDL>();
            totVulnerabilidades = 0;
        }
        #endregion

        #region Properties
        public static int TotalVulnerabilidades
        {
            get { return totVulnerabilidades; }
        }

        public static List<VulnerabilidadeDL> LstVulnerabilidades
        {
            get { return vulnerabilidades; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Verifica se a vulnerabilidade ja se encontra na lista de vulnerabilidades
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int VerificaExisteVulnerabilidade(int codigoVul)
        {
            try
            {
                int i;
                i = vulnerabilidades.FindIndex(x => x.Vulnerabilidade.codigo == codigoVul);
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
        /// Adiciona vulnerabilidade a lista de vulnerabilidades
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool AdicionaVulnerabilidade(VulnerabilidadeDL v)
        {
            try
            {
                if (VerificaExisteVulnerabilidade(v.Vulnerabilidade.codigo) == -1)
                {
                    vulnerabilidades.Add(v);
                    totVulnerabilidades++;
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
        /// Altera o estado da vulnerabilidade
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeEstado(int codigoVul)
        {
            try
            {
                int i = VerificaExisteVulnerabilidade(codigoVul);
                if (i != -1)
                {
                    if (vulnerabilidades[i].Estado == VulnerabilidadeDL.EstadoVul.ATIVO)
                    {
                        vulnerabilidades[i].Estado = VulnerabilidadeDL.EstadoVul.INATIVO;
                        return true;
                    }
                    if (vulnerabilidades[i].Estado == VulnerabilidadeDL.EstadoVul.INATIVO)
                    {
                        vulnerabilidades[i].Estado = VulnerabilidadeDL.EstadoVul.ATIVO;
                        return true;
                    }
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
        /// Altera o nivel de impacto de uma vulnerabilidade
        /// </summary>
        /// <param name="v">Vulnerabilidade</param>
        /// <param name="n">Nivel de Impacto</param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeNivelImpacto(int codigoVul, string n)
        {
            try
            {
                int i = VerificaExisteVulnerabilidade(codigoVul);
                if (i != -1)
                {
                    vulnerabilidades[i].Vulnerabilidade.nivelImpacto = n;
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
        /// Atera a descricao da vulnerabilidade
        /// </summary>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeDescricao(int codigoVul, string n)
        {
            try
            {
                int i = VerificaExisteVulnerabilidade(codigoVul);
                if (i != -1)
                {
                    vulnerabilidades[i].Vulnerabilidade.descricao = n;
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
        /// Mostra todas as vulnerabilidades da lista de vulnerabilidades 
        /// </summary>
        public static void showListVul()
        {
            vulnerabilidades.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Remove todos os elementos da lista de vulnerabilidades
        /// </summary>
        public static void ClearVulnerabilidades()
        {
            vulnerabilidades.Clear();
        }
        #endregion

        #region Ficheiros
        /// <summary>
        /// Guardar vulnerabilidades num ficheiro binario
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveVulnerabilidades(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, vulnerabilidades);
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
                    bin.Serialize(stream, vulnerabilidades);
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
        /// Carrega a lista de vulnerabilidades
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadVulnerabilidades(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    vulnerabilidades = (List<VulnerabilidadeDL>)bin.Deserialize(stream);
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
