using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BL;
using Exc;

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
            Regras.showListVul();
            Regras.AlterarVulnerabilidadeEstado(Regras.Perfil.CHEFE, v1);
            Regras.showListVul();
            Regras.AlterarVulnerabilidadeNivelImpacto(Regras.Perfil.CHEFE, v1, "elevado");
            Regras.AlterarVulnerabilidadeDescricao(Regras.Perfil.COLABORADOR, v1, "ola");
            Regras.showListVul();

            //e1 = new EquipamentoInfBO(Regras.GetTotalEquipsInf(), "a", "b", "c", DateTime.Now);
            //Regras.AddEquipamentoInformatico(Regras.Perfil.COLABORADOR, e1);
            //e2 = new EquipamentoInfBO(Regras.GetTotalEquipsInf(), "d", "e", "f", DateTime.Now);
            //Regras.AddEquipamentoInformatico(Regras.Perfil.CHEFE, e2);

            //c1 = new colaboradorBO("Jose", Regras.GetTotalColab());
            //Regras.AddColab(Regras.Perfil.CHEFE, c1);
            //c2 = new colaboradorBO("Manuel", Regras.GetTotalColab());
            //Regras.AddColab(Regras.Perfil.CHEFE, c2);
            //c3 = new colaboradorBO("Joaquim", Regras.GetTotalColab());
            //Regras.AddColab(Regras.Perfil.CHEFE, c3);

            //a = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 12, c1);
            //Regras.AddAudit(Regras.Perfil.COLABORADOR, a);
            //b = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 12, c1);
            //Regras.AddAudit(Regras.Perfil.COLABORADOR, b);
            //c = new auditoriaBO(Regras.GetTotalAudit(), DateTime.Now, 15, c2);
            //Regras.AddAudit(Regras.Perfil.COLABORADOR, c);


            //Console.WriteLine(a.ToString());
            //Console.WriteLine("----------------------");
            //Console.WriteLine(b.ToString());
            //Console.WriteLine("----------------------");
            //Console.WriteLine(c.ToString());

            //Regras.showListAud();
            //Regras.EditarAuditoriaColaborador(Regras.Perfil.CHEFE, a, c3);
            //Regras.EditarAuditoriaData(Regras.Perfil.CHEFE, a, DateTime.Today);
            //Regras.EditarAuditoriaDuracao(Regras.Perfil.CHEFE, a, 25);
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
