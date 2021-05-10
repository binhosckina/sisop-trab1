using System;

namespace sisop_trab1
{
    public class Frame
    {
        private bool alocado;

        public int inicio;
        public int fim;

        public Frame(){
            this.alocado = false;
        }

        public void aloca(){
            this.alocado = true;
        }

        public void desaloca(){
            this.alocado = false;
        }
        
        public bool getAlocado(){
            return this.alocado;
        }
        
    }
}