using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace DL
{
    public class Auditorias
    {
        #region Member Variables
        private const int MAXAUDITORIAS = 200;
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
        /// <param name="a">Auditoria</param>
        /// <returns></returns>
        public static bool VerificaExisteAuditoria(AuditoriaDL a)
        {
            try
            {
                if (auditorias.Contains(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
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
                if (!VerificaExisteAuditoria(a))
                {
                    auditorias.Add(a);
                    totAuditorias++;
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
        /// Edita o colaborador de uma auditoria
        /// </summary>
        /// <param name="a">Auditoria</param>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool EditarAuditoriaColaborador(AuditoriaDL a, colaboradorBO c)
        {
            try
            {
                if (VerificaExisteAuditoria(a))
                {
                    int i = auditorias.IndexOf(a);
                    auditorias[i].Auditoria.colaborador = c;
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
        /// Edita a data de uma auditoria
        /// </summary>
        /// <param name="a">Auditoria</param>
        /// <param name="dt">Data</param>
        /// <returns></returns>
        public static bool EditarAuditoriaData(AuditoriaDL a, DateTime dt)
        {
            try
            {
                if (VerificaExisteAuditoria(a))
                {
                    int i = auditorias.IndexOf(a);
                    auditorias[i].Auditoria.data = dt;
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
        /// Edita a duracao de uma auditoria
        /// </summary>
        /// <param name="a">Auditoria</param>
        /// <param name="duracao">Duracao</param>
        /// <returns></returns>
        public static bool EditarAuditoriaDuracao(AuditoriaDL a, float duracao)
        {
            try
            {
                if (VerificaExisteAuditoria(a))
                {
                    int i = auditorias.IndexOf(a);
                    auditorias[i].Auditoria.duracao = duracao;
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
        /// Mostra todas as auditorias da lista de auditorias
        /// </summary>
        public static void showListAuditorias()
        {
            auditorias.ForEach(Console.WriteLine);
        }
        #endregion



    }
}
