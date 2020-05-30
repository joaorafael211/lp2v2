using System;
using DL;
using BO;
using System.IO;

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
            return Auditorias.TotalAuditorias;
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
                    bool b;
                    AuditoriaDL aux = new AuditoriaDL(a);
                    b = Auditorias.AdicionaAuditoria(aux);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("A auditoria ja se encontra na lista de auditorias.\n");
                        return false;
                    }
                }
                catch(ArgumentNullException e)
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

        /// <summary>
        /// Edita a data de uma auditoria
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="dt">Data</param>
        /// <returns></returns>
        public static bool EditarAuditoriaData(Perfil p, int codigoAud, DateTime dt)
        {
            if(p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Auditorias.EditarAuditoriaData(codigoAud, dt);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.\n");
                        return false;
                    }
                }
                catch(ArgumentNullException e)
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

        /// <summary>
        /// Editar a duracao de uma auditoria
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="dur">Duracao</param>
        /// <returns></returns>
        public static bool EditarAuditoriaDuracao(Perfil p, int codigoAud, float dur)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Auditorias.EditarAuditoriaDuracao(codigoAud, dur);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.\n");
                        return false;
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

        /// <summary>
        /// Remove todos os elementos da lista de auditorias
        /// </summary>
        public static void ClearAuditorias()
        {
            Auditorias.ClearAuditorias();
        }

        /// <summary>
        /// Guarda todas as auditorias da lista de auditorias
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveAuditorias(string fileName)
        {
            try
            {
                Auditorias.SaveAuditorias(fileName);

            }
            catch(IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch(Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;
            
        }

        /// <summary>
        /// Carrega todas as auditorias para a lista de auditorias
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadAuditorias(string fileName)
        {
            try
            {
                Auditorias.LoadAuditorias(fileName);
            }
            catch(IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Associar vulnerabilidade a uma auditoria
        /// </summary>
        /// <param name="codigoAud">Codigo da Auditoria</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AdicionarVulnerabilidadeAuditoria(int codigoAud, int codigoVul)
        {
            try
            {
                bool b;
                b = Auditorias.AdicionarVulnerabilidadeAuditoria(codigoAud, codigoVul);
                if (b) return true;
                else
                {
                    Console.WriteLine("Falha ao adicionar vulnerabilidade.");
                    return false;
                }
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Codigo da auditoria com menos vulnerabilidades 
        /// </summary>
        /// <returns></returns>
        public static int AuditoriaMenosVul()
        {
            return Auditorias.AuditoriaMenorVulnerabilidades();
        }

        /// <summary>
        /// Codigo da auditoria com mais vulnerabilidades 
        /// </summary>
        /// <returns></returns>
        public static int AuditoriaMaisVul()
        {
            return Auditorias.AuditoriaMaiorVulnerabilidades();
        }

        /// <summary>
        /// Ordena a lista de auditorias pelo numero de vulnerabilidades crescente
        /// </summary>
        public static void OrdenarAudVulCresc()
        {
            Auditorias.AudNumeroVulCresc();
        }

        /// <summary>
        /// Ordena a lista de auditorias pelo numero de vulnerabilidades decrescente
        /// </summary>
        public static void OrdenarAudVulDec()
        {
            Auditorias.AudNumeroVulDec();
        }
        #endregion

        #region Colaboradores
        /// <summary>
        /// Total de colaboradores
        /// </summary>
        /// <returns></returns>
        public static int GetTotalColab()
        {
            return Colaboradores.totColaboradores;
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
                    bool b;
                    ColaboradorDL aux = new ColaboradorDL(c);
                    b = Colaboradores.AdicionaColaborador(aux);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("O Colaborador ja se encontra na lista de colaboradores.\n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Edita o nome do colaborador
        /// </summary>
        /// <param name="p">Perfil </param>
        /// <param name="codigoCol">Codigo Colaborador</param>
        /// <param name="n">Nome</param>
        /// <returns></returns>
        public static bool EditarColaboradorNome(Perfil p, int codigoCol, string n)
        {
            if( p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Colaboradores.EditarColaboradorNome(codigoCol, n);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.\n");
                        return false;
                    }
                }
                catch(ArgumentNullException e)
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
        /// <param name="codigoCol">Colaborador</param>
        /// <returns></returns>
        public static bool EditarColaboradorEstado(Perfil p, int codigoCol)
        {
            if (p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Colaboradores.AlterarColaboradorEstado(codigoCol);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido. \n");
                        return false;
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

            }
            return false;
        }

        /// <summary>
        /// Guarda todos os colaboradores da lista de colaboradores
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveColaboradores(string fileName)
        {
            try
            {
                Colaboradores.SaveColaboradores(fileName);

            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Carrega todos os colaboradores para a lista de colaboradores
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadColaboradores(string fileName)
        {
            try
            {
                Colaboradores.LoadColaboradores(fileName);
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Remove todos os elementos da lista de colaboradores
        /// </summary>
        public static void ClearColaboradores()
        {
            Colaboradores.ClearColaboradores();
        }
        #endregion

        #region Vulnerabilidades
        /// <summary>
        /// Total de Vulnerabilidades
        /// </summary>
        /// <returns></returns>
        public static int GetTotalVul()
        {
            return Vulnerabilidades.TotalVulnerabilidades;
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
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o estado da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeEstado(Perfil p, int codigoVul)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Vulnerabilidades.AlteraVulnerabilidadeEstado(codigoVul);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido. \n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Altera a descricao da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <param name="desc">Descricao</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeDescricao(Perfil p, int codigoVul, string desc)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Vulnerabilidades.AlteraVulnerabilidadeDescricao(codigoVul, desc);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido. \n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Altera o nivel de impacto da vulnerabilidade
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <param name="n">Nivel de Impacto</param>
        /// <returns></returns>
        public static bool AlterarVulnerabilidadeNivelImpacto(Perfil p, int codigoVul, string n)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = Vulnerabilidades.AlteraVulnerabilidadeNivelImpacto(codigoVul, n);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido. \n");
                        return false;
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

        /// <summary>
        /// Guarda todas as vulnerabilidades da lista de vulnerabilidades
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveVulnerabilidades(string fileName)
        {
            try
            {
                Auditorias.SaveAuditorias(fileName);

            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Carrega todas as vulnerabilidades para a lista de vulnerabilidades
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadVulnerabilidades(string fileName)
        {
            try
            {
                Auditorias.LoadAuditorias(fileName);
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Remove todos os elementos da lista de vulnerabilidades
        /// </summary>
        public static void ClearVulnerabilidades()
        {
            Vulnerabilidades.ClearVulnerabilidades();
        }
        #endregion

        #region Equipamentos Informaticos

        /// <summary>
        /// Total de Equipamentos Informaticos
        /// </summary>
        /// <returns></returns>
        public static int GetTotalEquipsInf()
        {
            return EquipamentosInf.TotalEquipamentos;
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
                    bool b;
                    EquipamentoInfDL aux = new EquipamentoInfDL(equip);
                    b = EquipamentosInf.AdicionaEquipamento(aux);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("O equipamento informatico ja se encontra na lista de Equipamentos informaticos.\n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Edita o tipo do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="t">Tipo</param>
        /// <returns></returns>
        public static bool EditarTipoEquip(Perfil p, int codigoEquip, string t)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = EquipamentosInf.EditarEquipInfTipo(codigoEquip, t);
                    if (b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.\n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Editar o modelo do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="mod">Modelo</param>
        /// <returns></returns>
        public static bool EditarModeloEquip(Perfil p, int codigoEquip, string mod)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = EquipamentosInf.EditarEquipInfModelo(codigoEquip, mod);
                    if(b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.\n");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Editar a marca do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="m">Marca</param>
        /// <returns></returns>
        public static bool EditarMarcaEquip(Perfil p, int codigoEquip, string m)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = EquipamentosInf.EditarEquipInfMarca(codigoEquip, m);
                    if(b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.");
                        return false;
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
            }
            return false;
        }

        /// <summary>
        /// Editar a data de aquisicao do equipamento informatico
        /// </summary>
        /// <param name="p">Perfil</param>
        /// <param name="codigoEquip">Equipamento Informatico</param>
        /// <param name="dt">Data de Aquisicao</param>
        /// <returns></returns>
        public static bool EditarDataAquisicaoEquip(Perfil p, int codigoEquip, DateTime dt)
        {
            if (p == Perfil.COLABORADOR || p == Perfil.CHEFE)
            {
                try
                {
                    bool b;
                    b = EquipamentosInf.EditarEquipInfData(codigoEquip, dt);
                    if(b) return true;
                    else
                    {
                        Console.WriteLine("Insira um codigo valido.");
                        return false;
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

        /// <summary>
        /// Guarda todos os equipamentos informaticos da lista de equipamentos informaticos
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool SaveEquipamentos(string fileName)
        {
            try
            {
                EquipamentosInf.SaveEquipamentosInformaticos(fileName);
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;

        }

        /// <summary>
        /// Carrega todos os equipamentos informaticos para a lista de equipamentos informaticos
        /// </summary>
        /// <param name="fileName">Ficheiro</param>
        /// <returns></returns>
        public static bool LoadEquipamentos(string fileName)
        {
            try
            {
                EquipamentosInf.LoadEquipamentosInformaticos(fileName);
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
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
            EquipamentosInf.ClearEquipamentos();
        }

        /// <summary>
        /// Associar vulnerabilidade a equipamento informatico
        /// </summary>
        /// <param name="codigoEquip">Codigo do Equipamento Informatico</param>
        /// <param name="codigoVul">Codigo da Vulnerabilidade</param>
        /// <returns></returns>
        public static bool AdicionarVulnerabilidadeEquipamento(int codigoEquip, int codigoVul)
        {
            try
            {
                bool b;
                b = EquipamentosInf.AdicionarVulnerabilidadeEquip(codigoEquip, codigoVul);
                if (b) return true;
                else
                {
                    Console.WriteLine("Falha ao adicionar vulnerabilidade.");
                    return false;
                }
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Ordena a lista de equipamentos informaticos pelo numero de vulnerabilidades crescente
        /// </summary>
        public static void OrdenarEquipVulCresc()
        {
            EquipamentosInf.EquipNumeroVulCresc();
        }

        /// <summary>
        /// Ordena a lista de equipamentos informaticos pelo numero de vulnerabilidades decrescente
        /// </summary>
        public static void OrdenarEquipVulDec()
        {
            EquipamentosInf.EquipNumeroVulDec();
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
