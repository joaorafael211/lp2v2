using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
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
        #endregion

        #region Functions
        /// <summary>
        /// Verifica se a vulnerabilidade ja se encontra na lista de vulnerabilidades
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool VerificaExisteVulnerabilidade(VulnerabilidadeDL v)
        {
            try
            {
                if (vulnerabilidades.Contains(v))
                {
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
        /// Adiciona vulnerabilidade a lista de vulnerabilidades
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool AdicionaVulnerabilidade(VulnerabilidadeDL v)
        {
            try
            { 
                if (!VerificaExisteVulnerabilidade(v))
                {
                    vulnerabilidades.Add(v);
                    totVulnerabilidades++;
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
        /// Altera o estado da vulnerabilidade
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeEstado(VulnerabilidadeDL v)
        {
            try
            {
                if (VerificaExisteVulnerabilidade(v))
                {
                    int i = vulnerabilidades.IndexOf(v);
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
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        /// <summary>
        /// Altera o nivel de impacto de uma vulnerabilidade
        /// </summary>
        /// <param name="v">Vulnerabilidade</param>
        /// <param name="n">Nivel de Impacto</param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeNivelImpacto(VulnerabilidadeDL v, string n)
        {
            try
            {
                if (VerificaExisteVulnerabilidade(v))
                {
                    int i = vulnerabilidades.IndexOf(v);
                    vulnerabilidades[i].Vulnerabilidade.NivelImpacto = n;
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
        /// Atera a descricao da vulnerabilidade
        /// </summary>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool AlteraVulnerabilidadeDescricao(VulnerabilidadeDL v, string n)
        {
            try
            {
                if (VerificaExisteVulnerabilidade(v))
                {
                    int i = vulnerabilidades.IndexOf(v);
                    vulnerabilidades[i].Vulnerabilidade.Descricao = n;
                }
            }
            catch (Exception e)
            {
                throw e;
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
        #endregion


    }
}
