using System;

namespace sisop_trab1
{
    public class Processo
    {
        private int id;
        private int[] paginasAlocadas;
        private VariaveisPrograma contexto;
        public Processo(int id, int[] paginasAlocadas){
            this.id= id;
            this.paginasAlocadas = paginasAlocadas;
            this.contexto = new VariaveisPrograma(0,paginasAlocadas.Length*16,paginasAlocadas,new int[8], 0, new Word(Opcode.___,-1,-1,-1));
        }

        public int[] getAllocatedPages(){
            return this.paginasAlocadas;
        }

        public int getId(){
            return id;
        }

        public void setVariaveisPrograma(VariaveisPrograma contexto)
        {
            this.contexto = contexto;
        }

        public VariaveisPrograma GetVariaveisPrograma(){
            return this.contexto;
        }
    }
}