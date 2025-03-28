using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string RA { get; set; }

        //publico significa que oura classe pode utilizar esse metodo

        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaAluno"] != null)
            {
                if(((List<Aluno>)session["ListaAluno"]).Count > 0);
                {
                    return;
                }
                //tem uma lista, num preisa de ota naum, só tem que dar um jeito de puxar ela
            }
            var lista = new List<Aluno>();
            lista.Add(new Aluno {Nome = "Dan",RA = "123456"});
            lista.Add(new Aluno {Nome = "Juh",RA = "654321"});
            lista.Add(new Aluno {Nome = "Danju",RA = "246810"});

            session.Remove("ListaAluno");
            session.Add("ListaAluno", lista);
        }
        public void Adicionar(HttpSessionStateBase session)
        {
            if(session ["ListaAluno"] != null)
            {
                (session["ListaAluno"] as List<Aluno>).Add(this);
            }
        }
        public static Aluno Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaAluno"] != null)
            {
                return (session["ListaAluno"] as List<Aluno>).ElementAt(id);
            }

            return null;
        }
        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaAluno"] != null)
            {
                (session["ListaAluno"] as List<Aluno>).Remove(this);
            }
        }

        public void Editar(HttpSessionStateBase session, int id)
        {
            if (session["ListaAluno"] != null)
            {
                var aluno = Aluno.Procurar(session, id);
                aluno.Nome = this.Nome;
                aluno.RA = this.RA;
            }
        }

    }
}