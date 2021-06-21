using System;

namespace APP.NET
{
    public class Serie : EntidadeBase
    {
        private Genero genero {get; set;}
        private double nota {get; set;}
        private string titulo {get; set;}
        private string descricao {get; set;}
        private int ano {get; set;}
        private bool Excluido {get;set;}
        public Serie(int Id,Genero genero,double nota,string titulo,string descricao,int ano)
            {
                this.Id = Id;
                this.nota = nota;
                this.genero = genero;
                this.titulo = titulo;
                this.descricao = descricao;
                this.ano = ano;
                this.Excluido = false;
            }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "+this.genero + Environment.NewLine;
            retorno += "Nota: "+this.nota + Environment.NewLine;
            retorno += "Título: "+this.titulo + Environment.NewLine;
            retorno += "Descrição: "+this.descricao + Environment.NewLine;
            retorno += "Ano: "+this.ano + Environment.NewLine;
            retorno += "Excuido: "+this.Excluido + Environment.NewLine;
            return retorno;
        }
        public string retornaTitulo(){
            return this.titulo;
        }
        public int retornaId(){
            return this.Id;
        }

        public void excluir(){
            this.Excluido = true;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }
    }
}