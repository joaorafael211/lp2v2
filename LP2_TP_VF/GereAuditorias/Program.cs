/*Trabalho Pratico LP2
 * Fase 2
 * Tema: Gestao de auditorias
 * Autores: Joao Fernandes 18838
 *          Nuno Rodrigues 18846

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BL;


namespace GereAuditorias
{
    class Program
    {
        static void Main(string[] args)
        {
            auditoriaBO a, b, c;
            colaboradorBO c1, c2, c3;
            EquipamentoInfBO e1, e2;
            vulnerabilidadeBO v1, v2;

            v1 = new vulnerabilidadeBO(Regras.GetTotalVul(), "asd", "baixo");
            Regras.AddVul(Regras.Perfil.CHEFE, v1);
            v2 = new vulnerabilidadeBO(Regras.GetTotalVul(), "lkl", "alto");
            Regras.AddVul(Regras.Perfil.COLABORADOR, v2);

            //Regras.showListVul();
            //Regras.AlterarVulnerabilidadeEstado(Regras.Perfil.CHEFE, v1);
            //Regras.showListVul();
            //Regras.AlterarVulnerabilidadeNivelImpacto(Regras.Perfil.CHEFE, v1, "elevado");
            //Regras.AlterarVulnerabilidadeDescricao(Regras.Perfil.COLABORADOR, v1, "ola");
            //Regras.showListVul();

            //e1 = new EquipamentoInfBO(Regras.GetTotalEquipsInf(), "a", "b", "c", DateTime.Now);
            //Regras.AddEquipamentoInformatico(Regras.Perfil.COLABORADOR, e1);
            //e2 = new EquipamentoInfBO(Regras.GetTotalEquipsInf(), "d", "e", "f", DateTime.Now);
            //Regras.AddEquipamentoInformatico(Regras.Perfil.CHEFE, e2);
            //Regras.showListEquips();

            //Regras.AdicionarVulnerabilidadeEquipamento(e1.codigo, v1.codigo);
            //Regras.AdicionarVulnerabilidadeEquipamento(e1.codigo, v1.codigo);
            //Regras.showListEquips();

            //Regras.LoadAuditorias("auditorias.bin");

            c1 = new colaboradorBO("Jose", Regras.GetTotalColab());
            Regras.AddColab(Regras.Perfil.CHEFE, c1);
            c2 = new colaboradorBO("Manuel", Regras.GetTotalColab());
            Regras.AddColab(Regras.Perfil.CHEFE, c2);
            c3 = new colaboradorBO("Joaquim", Regras.GetTotalColab());
            Regras.AddColab(Regras.Perfil.CHEFE, c3);

            a = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 12, c1.codigo);
            Regras.AddAudit(Regras.Perfil.COLABORADOR, a);
            b = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 12, c1.codigo);
            Regras.AddAudit(Regras.Perfil.COLABORADOR, b);
            c = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 15, c2.codigo);
            Regras.AddAudit(Regras.Perfil.COLABORADOR, c);

            //Regras.showListAud();

            Regras.AdicionarVulnerabilidadeAuditoria(c.codigo, v1.codigo);
            Regras.AdicionarVulnerabilidadeAuditoria(b.codigo, v1.codigo);
            Regras.AdicionarVulnerabilidadeAuditoria(b.codigo, v2.codigo);

            //Regras.showListAud();

            //Console.WriteLine("Codigo Auditoria Menos vul: " + Regras.AuditoriaMenosVul());
            //Console.WriteLine("Codigo Auditoria Mais vul: " + Regras.AuditoriaMaisVul());

            Regras.OrdenarAudVulCresc();
            Regras.showListAud();

            Regras.OrdenarAudVulDec();
            Regras.showListAud();
            //Regras.SaveAuditorias("auditorias.bin");
            //Console.WriteLine("lista guardada");
            //Regras.ClearAuditorias();
            //Console.WriteLine("Lista de auditorias vazia.");6
            //Regras.showListAud();
            //Regras.LoadAuditorias("auditorias.bin");
            //Console.WriteLine("Lista carregada.");
            //Regras.showListAud();

            //Console.WriteLine(a.ToString());
            //Console.WriteLine("----------------------");
            //Console.WriteLine(b.ToString());
            //Console.WriteLine("----------------------");
            //Console.WriteLine(c.ToString());

            //Regras.showListAud();
            //Regras.EditarAuditoriaData(Regras.Perfil.CHEFE, 1, DateTime.Today);
            //Regras.EditarAuditoriaDuracao(Regras.Perfil.CHEFE, 4, 25);
            //Regras.showListAud();

            //Regras.showListCol();
            //Regras.EditarColaboradorNome(Regras.Perfil.CHEFE, c2, "Joao");
            //Regras.showListCol();
            //Regras.EditarColaboradorEstado(Regras.Perfil.CHEFE, c3);
            //Regras.EditarColaboradorNome(Regras.Perfil.CHEFE, c3, "Josefino");
            //Regras.showListCol();

            Console.ReadKey();

        }
    }
}
