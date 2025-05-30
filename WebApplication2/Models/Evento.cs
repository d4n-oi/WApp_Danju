﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Evento
    {
        public string Local { get; set; }
        public DateTime Data { get; set; }

        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                if (((List<Evento>)session["ListaEvento"]).Count > 0) ;
                {
                    return;
                }
                //tem uma lista, num preisa de ota naum, só tem que dar um jeito de puxar ela
            }
            var lista = new List<Evento>();
            lista.Add(new Evento { Local = "Pacífico", Data = new DateTime(2000, 07, 02) });
            lista.Add(new Evento { Local = "Atlântico", Data = new DateTime(2067, 01, 17) });
            lista.Add(new Evento { Local = "Indico", Data = new DateTime(2006, 10, 13) });
            lista.Add(new Evento { Local = "Ártico", Data = new DateTime(2030, 02, 24) });

            session.Remove("ListaEvento");
            session.Add("ListaEvento", lista);
        }

        public void Adicionar(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                (session["ListaEvento"] as List<Evento>).Add(this);
            }
        }

        public static Evento Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaEvento"] != null)
            {
                return (session["ListaEvento"] as List<Evento>).ElementAt(id);
            }

            return null;
        }
        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                (session["ListaEvento"] as List<Evento>).Remove(this);
            }
        }

        public void Editar(HttpSessionStateBase session, int id)
        {
            if (session["ListaEvento"] != null)
            {
                var evento = Evento.Procurar(session, id);
                evento.Local = this.Local;
                evento.Data = this.Data;
            }
        }
    }
}
