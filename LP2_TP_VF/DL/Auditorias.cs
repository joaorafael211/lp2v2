using System;
using System.Collections.Generic;
using System.Text;
using BO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DL
{
    [Serializable]
    public class Auditorias
    {
        #region Member Variables
        private static List<AuditoriaDL> auditorias;
        private static int totAuditorias;
        #endregion

        #region Constructors
        static Auditorias()
        {
            auditorias = new List<AuditoriaDL>();
            totAuditorias = 0;
        }
        #endregion

        #region Properties

        public static int TotalAuditorias
        {
            get { return totAuditorias; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Verifica se a auditoria ja esta na lista de auditorias
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <returns>
        /// Retorna o index da auditoria se ela existir
        /// 
        /// Retorna -1 se a auditoria ja existir
        /// </returns>
        public static int VerificaExisteAuditoria(int codigoAud)
        {
            try
            {
                int i;
                i = auditorias.FindIndex(x => x.Auditoria.codigo == codigoAud);
                return i;
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return -1;
        }

        /// <summary>
        /// Verifica se o codigo da vulnerabilidade ja esta na lista de codigos de vulnerabilidades
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static int VerificaExisteVulAuditoria(int codigoAud, int codigoVul)
        {
            try
            {
                int i, j;
                i = VerificaExisteAuditoria(codigoAud);
                if (i != 1)
                {
                    j = auditorias[i].CodigosVul.FindIndex(x => x == codigoVul);
                    return j;
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
            return -1;
        }

        /// <summary>
        /// Adiciona uma auditoria a lista de auditorias
        /// </summary>
        /// <param name="a">Auditoria</param>
        /// <returns></returns>
        public static bool AdicionaAuditoria(AuditoriaDL a)
        {
            try
            {
                if (VerificaExisteAuditoria(a.Auditoria.codigo) == -1)
                {
                    auditorias.Add(a);
                    totAuditorias++;
                    return true;
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
        /// Edita a data de uma auditoria
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="dt">Data</param>
        /// <returns></returns>
        public static bool EditarAuditoriaData(int codigoAud, DateTime dt)
        {
            try
            {
                int i = VerificaExisteAuditoria(codigoAud);
                if(i != -1)
                {
                    auditorias[i].Auditoria.data = dt;
                    return true;
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
        /// Edita a duracao de uma auditoria
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="duracao">Duracao</param>
        /// <returns></returns>
        public static bool EditarAuditoriaDuracao(int codigoAud, float duracao)
        {
            try
            {
                int i = VerificaExisteAuditoria(codigoAud);
                if (i != -1)
                {
                    auditorias[i].Auditoria.duracao = duracao;
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
        /// Mostra todas as auditorias da lista de auditorias
        /// </summary>
        public static void showListAuditorias()
        {
            auditorias.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Remove todos os elementos da lista de auditorias
        /// </summary>
        public static void ClearAuditorias()
        {
            auditorias.Clear();
        }

        /// <summary>
        /// Adicionar codigo da vulnerabilidade a lista de codigos de vulnerabilidades da auditoria
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AdicionarVulnerabilidadeAuditoria(int codigoAud, int codigoVul)
        {
            try
            {
                int i = VerificaExisteAuditoria(codigoAud);
                if (i != -1)
                {
                    int j = VerificaExisteVulAuditoria(codigoAud, codigoVul);
                    if (j == -1)
                    {
                        auditorias[i].CodigosVul.Add(codigoVul);
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
                Console.Write("Error: " + e.Message);
            }
            return false;
        }


        /// <summary>
        /// Auditoria com o menor numero de vulnerabilidades
        /// </summary>
        /// <returns></returns>
        public static int AuditoriaMenorVulnerabilidades()
        {
            int count = 0;
            int index = 0;
            int min = auditorias[0].CodigosVul.Count;
            foreach(AuditoriaDL a in auditorias)
            {
                if (a.CodigosVul.Count < min)
                {
                    min = a.CodigosVul.Count;
                    index = count;
                }
                count++;
            }
            return auditorias[index].Auditoria.codigo;
        }


        /// <summary>
        /// Auditoria com o maior numero de vulnerabilidades
        /// </summary>
        /// <returns></returns>
        public static int AuditoriaMaiorVulnerabilidades()
        {
            int count = 0;
            int index = 0;
            int max = auditorias[0].CodigosVul.Count;
            foreach (AuditoriaDL a in auditorias)
            {
                if (a.CodigosVul.Count > max)
                {
                    max = a.CodigosVul.Count;
                    index = count;
                }
                count++;
            }
            return auditorias[index].Auditoria.codigo;
        }

        /// <summary>
        /// Ordena a lista de auditorias pelo numero de vulnerabilidades crescente
        /// </summary>
        public static void AudNumeroVulCresc()
        {
            auditorias.Sort(new SortVulAudCresc());
        }

        /// <summary>
        /// Ordena a lista de auditorias pelo numero de vulnerabilidades decrescent
        /// </summary>
        public static void AudNumeroVulDec()
        {
            auditorias.Sort(new SortVulAudDec());
        }
        #endregion

        #region Ficheiros
        /// <summary>
        /// Guardar auditorias num ficheiro binario
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveAuditorias(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, auditorias);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("ERRO:" + e.Message);
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
                    bin.Serialize(stream, auditorias);
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
        /// Carrega a lista de auditorias
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadAuditorias(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    auditorias = (List<AuditoriaDL>)bin.Deserialize(stream);
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
