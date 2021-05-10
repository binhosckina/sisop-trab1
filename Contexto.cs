using System;

namespace sisop_trab1
{
    public class Contexto {
        private int min;
        private int max;
        private int paginasAlocadas;
        private int[] registradores;
        private int pc;
        private Word ir;

        private Interruption interruption;
    
        public Contexto(int min, int max, int paginasAlocadas, int[] registradores, int pc, Word ir, Interruption interruption) {
            this.min = min;
            this.max = max;
            this.paginasAlocadas = paginasAlocadas;
            this.registradores = registradores;
            this.pc = pc;
            this.ir = ir;
            this.interruption = interruption;
        }
    
        public int getMin() {
            return min;
        }

        public Interruption getInterruption(){
            return interruption;
        }
    
        public int getMax() {
            return max;
        }

        public void reset(){
            this.interruption = new Interruption();
        }
    
        public int getPaginasAlocadas() {
            return paginasAlocadas;
    ;
        }
    
        public int[] getregistradores() {
            return registradores;
        }
    
        public int getpc() {
            return pc;
        }
    
        public Word getir() {
            return ir;
        }
    
    }
}