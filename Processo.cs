using System;

namespace sisop_trab1
{
    public class Processo
    {
        private int id;

        private String name;
        private int[] paginasAlocadas;
        private Contexto contexto;

        public bool morto;
        public Processo(int id, int[] paginasAlocadas, Word ir){
            this.id= id;
            this.paginasAlocadas = paginasAlocadas;
            this.contexto = new Contexto(paginasAlocadas[0],paginasAlocadas[paginasAlocadas.Length-1]+16,paginasAlocadas,new int[8], paginasAlocadas[0], ir, new Interruption());
        }

        public int[] getAllocatedPages(){
            return this.paginasAlocadas;
        }

        public void setName(String name){
            this.name = name+'_'+id;
        }
        public void resetInterruption(){
            this.contexto.reset();
        }
        public String getName(){
            return this.name;
        }
        public int getId(){
            return id;
        }

        public void setVariaveisPrograma(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Contexto GetVariaveisPrograma(){
            return this.contexto;
        }
    }
}