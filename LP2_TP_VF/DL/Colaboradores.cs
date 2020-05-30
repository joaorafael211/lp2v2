using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DL
{
    [Serializable]
    public class Colaboradores
    {
        #region Member Variables
        private static List<ColaboradorDL> colaboradores;
        public static int totColaboradores;
        #endregion

        #region Constructors
        static Colaboradores()
        {
            colaboradores = new List<ColaboradorDL>();
            totColaboradores = 0;
        }
        #endregion

        #region Properties
        public static int TotalColaboradores
        {
            get { return totColaboradores; }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Verifica se o colaborador ja se encontra na lista de colaboradores
        /// </summary>
        /// <param name="codigoCol">Codigo do Colaborador</param>
        /// <returns></returns>
        public static int VerificaExisteColaborador(int codigoCol)
        {
            try
            {
                int i;
                i = colaboradores.FindIndex(x => x.Colaborador.codigo == codigoCol);
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
        /// Adiciona um colaborador a lista de colaboradores
        /// </summary>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool AdicionaColaborador(ColaboradorDL c)
        {
            try
            {
                if (VerificaExisteColaborador(c.Colaborador.codigo) == -1)
                {
                    colaboradores.Add(c);
                    totColaboradores++;
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
        /// Edita o nome do colaborador
        /// </summary>
        /// <param name="codigoCol">Codigo do Colaborador</param>
        /// <param name="n">Nome</param>
        /// <returns></returns>
        public static bool EditarColaboradorNome(int codigoCol, string n)
        {
            try
            {
                int i = VerificaExisteColaborador(codigoCol);
                if (i != -1)
                {
                    colaboradores[i].Colaborador.nome = n;
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
        /// ALtera o estado do colaborador
        /// </summary>
        /// <param name="codigoCol">Codigo do Colaborador</param>
        /// <returns></returns>
        public static bool AlterarColaboradorEstado(int codigoCol)
        {
            try
            {
                int i = VerificaExisteColaborador(codigoCol);
                if (i != -1)
                {
                    if(colaboradores[i].Estado == ColaboradorDL.EstadoCol.ATIVO)
                    {
                        colaboradores[i].Estado = ColaboradorDL.EstadoCol.INATIVO;
                        return true;
                    }
                    if (colaboradores[i].Estado == ColaboradorDL.EstadoCol.INATIVO)
                    {
                        colaboradores[i].Estado = ColaboradorDL.EstadoCol.ATIVO;
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
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os colaboradores da lista de colaboradores
        /// </summary>
        public static void showListColaboradores()
        {
            colaboradores.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Remove todos os elementos da lista de colaboradores 
        /// </summary>
        public static void ClearColaboradores()
        {
            colaboradores.Clear();
        }
        #endregion

        #region Ficheiros
        /// <summary>
        /// Guardar colaboradores num ficheiro binario
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveColaboradores(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, colaboradores);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("Error: " + e.Message);
                }
                catch(Exception e)
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
                    bin.Serialize(stream, colaboradores);
                    stream.Close();
                    return true;

                }
                catch (IOException e)
                {
                    Console.Write("Error:" + e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return false;
            }
        }

        /// <summary>
        /// Carrega a lista de colaboradores
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadColaboradores(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    colaboradores = (List<ColaboradorDL>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return false;
        }
        #endregion

    }
}
