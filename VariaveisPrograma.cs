using System;

namespace sisop_trab1
{
    public class VariaveisPrograma {
        private int min;
        private int max;
        private int[] paginasAlocadas;
        private int[] registradores;
        private int pc;
        private Word ir;
    
        public VariaveisPrograma(int min, int max, int[] paginasAlocadas, int[] registradores, int pc, Word ir) {
            this.min = min;
            this.max = max;
            this.paginasAlocadas = paginasAlocadas;
            this.registradores = registradores;
            this.pc = pc;
            this.ir = ir;
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
    
        public Word getir() {
            return ir;
        }
    
    }
}