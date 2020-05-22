using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
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
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool VerificaExisteColaborador(ColaboradorDL c)
        {
            try
            {
                if (colaboradores.Contains(c))
                {
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
        /// Adiciona um colaborador a lista de colaboradores
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool AdicionaColaborador(ColaboradorDL c)
        {
            try
            {
                if (!VerificaExisteColaborador(c))
                {
                    colaboradores.Add(c);
                    totColaboradores++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Edita o nome do colaborador
        /// </summary>
        /// <param name="c">Colaborador</param>
        /// <param name="n">Nome</param>
        /// <returns></returns>
        public static bool EditarColaboradorNome(ColaboradorDL c, string n)
        {
            try
            {

                if (VerificaExisteColaborador(c))
                {
                    int i = colaboradores.IndexOf(c);
                    colaboradores[i].Colaborador.nome = n;
                    return true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return false;
        }

        
        /// <summary>
        /// ALtera o estado do colaborador
        /// </summary>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool AlterarColaboradorEstado(ColaboradorDL c)
        {
            try
            {

                if (VerificaExisteColaborador(c))
                {
                    int i = colaboradores.IndexOf(c);
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
            catch (Exception e)
            {
                throw e;
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

        #endregion
    }
}
