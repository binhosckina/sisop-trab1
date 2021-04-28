using System;

namespace sisop_trab1
{
    public class VariaveisPrograma {
        private int min;
        private int max;
        private int[] paginasAlocadas;
        private int[] registradores;
        private int pc;
        private Word p;
    
        public VariaveisPrograma(int min, int max, int[] paginasAlocadas, int[] registradores, int pc, Word p) {
            this.min = min;
            this.max = max;
            this.paginasAlocadas = paginasAlocadas;
            this.registradores = registradores;
            this.pc = pc;
            this.p = p;
        }
    
        public int getMin() {
            return min;
        }
    
        public int getMax() {
            return max;
        }
    
        public int[] getPaginasAlocadas() {
            return paginasAlocadas;
    ;
        }
    
        public int[] getregistradores() {
            return registradores;
        }
    
        public int getpc() {
            return pc;
        }
    
        public Word getp() {
            return p;
        }
    
    }
}