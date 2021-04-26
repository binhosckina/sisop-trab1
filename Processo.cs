using System;

namespace sisop_trab1
{
    public class Processo
    {
        private int id;
        private int[] paginasAlocadas;
        public Processo(int id, int[] paginasAlocadas){
            this.id= id;
            this.paginasAlocadas = paginasAlocadas;
        }

        public int[] getAllocatedPages(){
            return this.paginasAlocadas;
        }

        public int getId(){
            return id;
        }
    }
}