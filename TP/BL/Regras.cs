using System;
using DL;
using BO;
using Exc;

namespace BL
{
    public class Regras
    {
        #region Auditorias
        /// <summary>
        /// Retorna o total de auditorias
        /// </summary>
        /// <returns></returns>
        public static int GetTotalAudit()
        {
            try
            {
                return Auditorias.TotalAuditorias;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adiciona uma auditoria a lista de auditorias
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="a">Auditoria</param>
        /// <returns></returns>
        public static bool AddAudit(Perfil p, auditoriaBO a)
        {
            if(p == Perfil.CHEFE || p == Perfil.COLABORADOR)
            {
                try
                {
                    AuditoriaDL aux = new AuditoriaDL(a);
                    Auditorias.AdicionaAuditoria(aux);
                    return true;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Edita o colaborador de uma auditoria 
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="a">Auditoria</param>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool EditarAuditoriaColaborador(Perfil p, auditoriaBO a, colaboradorBO c)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    AuditoriaDL aux = new AuditoriaDL(a);
                    Auditorias.EditarAuditoriaColaborador(aux, c);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return false;
        }

        /// <summary>
        /// Edita a data de uma auditoria
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="a">Auditoria</param>
        /// <param name="dt">Data</param>
        /// <returns></returns>
        public static bool EditarAuditoriaData(Perfil p, auditoriaBO a, DateTime dt)
        {
            if(p == Perfil.CHEFE)
            {
                try
                {
                    AuditoriaDL aux = new AuditoriaDL(a);
                    Auditorias.EditarAuditoriaData(aux, dt);
                    return true;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Editar a duracao de uma auditoria
        /// </summary>
        /// <param name="p"></param>
        /// <param name="a"></param>
        /// <param name="dur"></param>
        /// <returns></returns>
        public static bool EditarAuditoriaDuracao(Perfil p, auditoriaBO a, float dur)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    AuditoriaDL aux = new AuditoriaDL(a);
                    Auditorias.EditarAuditoriaDuracao(aux, dur);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Mostra todas as auditorias da lista de auditorias
        /// </summary>
        public static void showListAud()
        {
            Auditorias.showListAuditorias();
        }
        #endregion

        #region Colaboradores
        /// <summary>
        /// Total de colaboradores
        /// </summary>
        /// <returns></returns>
        public static int GetTotalColab()
        {
           
            try
            {
                return Colaboradores.totColaboradores;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        /// <summary>
        /// Adiciona colaborador a lista de colaboradores
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool AddColab(Perfil p, colaboradorBO c)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    ColaboradorDL aux = new ColaboradorDL(c);
                    Colaboradores.AdicionaColaborador(aux);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Edita o nome do colaborador
        /// </summary>
        /// <param name="p">Perfil </param>
        /// <param name="c">Colaborador</param>
        /// <param name="n">Nome</param>
        /// <returns></returns>
        public static bool EditarColaboradorNome(Perfil p, colaboradorBO c, string n)
        {
            if( p == Perfil.CHEFE)
            {
                try
                {
                    ColaboradorDL aux = new ColaboradorDL(c);
                    Colaboradores.EditarColaboradorNome(aux, n);
                    return true;
                }
                catch(Exception e)
                {
                    throw e;
                }
                
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os colaboradores da lista de colaboradores
        /// </summary>
        public static void showListCol()
        {
            Colaboradores.showListColaboradores();
        }

        /// <summary>
        /// Altera o estado do colaborador
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="c">Colaborador</param>
        /// <returns></returns>
        public static bool EditarColaboradorEstado(Perfil p, colaboradorBO c)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    ColaboradorDL aux = new ColaboradorDL(c);
                    Colaboradores.AlterarColaboradorEstado(aux);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return false;
        }
        #endregion

        #region Vulnerabilidades
        /// <summary>
        /// Total de Vulnerabilidades
        /// </summary>
        /// <returns></returns>
        public static int GetTotalVul()
        {
            try
            {
                return Vulnerabilidades.TotalVulnerabilidades;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adiciona uma vulnerabilidade a lista de vulnerabilidades
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="v">Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AddVul(Perfil p, vulnerabilidadeBO v)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    VulnerabilidadeDL aux = new VulnerabilidadeDL(v);
                    Vulnerabilidades.AdicionaVulnerabilidade(aux);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o estado da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="v">Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeEstado(Perfil p, vulnerabilidadeBO v)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    VulnerabilidadeDL aux = new VulnerabilidadeDL(v);
                    Vulnerabilidades.AlteraVulnerabilidadeEstado(aux);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera a descricao da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="v">Vulnerabilidade</param>
        /// <param name="desc">Descricao</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeDescricao(Perfil p, vulnerabilidadeBO v, string desc)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    VulnerabilidadeDL aux = new VulnerabilidadeDL(v);
                    Vulnerabilidades.AlteraVulnerabilidadeDescricao(aux, desc);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o nivel de impacto da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="v">Vulnerabilidade</param>
        /// <param name="n">Nivel de Impacto</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeNivelImpacto(Perfil p, vulnerabilidadeBO v, string n)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    VulnerabilidadeDL aux = new VulnerabilidadeDL(v);
                    Vulnerabilidades.AlteraVulnerabilidadeNivelImpacto(aux, n);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Mostra a lista de vulnerabilidadaes
        /// </summary>
        public static void showListVul()
        {
            Vulnerabilidades.showListVul();
        }

        #endregion

        #region Equipamentos Informaticos

        /// <summary>
        /// Total de Equipamentos Informaticos
        /// </summary>
        /// <returns></returns>
        public static int GetTotalEquipsInf()
        {

            try
            {
                return EquipamentosInf.TotalEquipamentos;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Adiciona um equipamento informatico a lista de equipamentos informaticos
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="equip">Equipamento Informatico</param>
        /// <returns></returns>
        public static bool AddEquipamentoInformatico(Perfil p, EquipamentoInfBO equip)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    EquipamentosInf.AdicionaEquipamento(aux);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Edita o tipo do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="t">Tipo</param>
        /// <returns></returns>
        public static bool EditarTipoEquip(Perfil p, EquipamentoInfBO equip, string t)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    EquipamentosInf.EditarEquipInfTipo(aux, t);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Editar o modelo do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="mod">Modelo</param>
        /// <returns></returns>
        public static bool EditarModeloEquip(Perfil p, EquipamentoInfBO equip, string mod)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    EquipamentosInf.EditarEquipInfModelo(aux, mod);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Editar a marca do equipamento informatico
        /// </summary>
        /// <param name="p"></param>
        /// <param name="equip"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool EditarMarcaEquip(Perfil p, EquipamentoInfBO equip, string m)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    EquipamentosInf.EditarEquipInfMarca(aux, m);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Editar a data de aquisicao do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="equip">Equipamento Informatico</param>
        /// <param name="dt">Data de Aquisicao</param>
        /// <returns></returns>
        public static bool EditarDataAquisicaoEquip(Perfil p, EquipamentoInfBO equip, DateTime dt)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    EquipamentosInf.EditarEquipInfData(aux, dt);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os equipamentos na lista de equipamentos informaticos
        /// </summary>
        public static void showListEquips()
        {
            EquipamentosInf.showListEquips();
        }
        #endregion

        #region Enums
        public enum Perfil
        {
            COLABORADOR = 1,
            CHEFE = 2
        }
        #endregion
    }
}
