using System;
using System.Collections.Generic;

namespace sisop_trab1
{ 
    public class GP {
        private GM gm;
        private VM vm;
        private LinkedList<Processo> proc;
        private static int process_id = 0;

        public GP(GM gm, VM vm, LinkedList<Processo> proc) {
            this.gm = gm;
            this.vm = vm;
            this.proc = proc;
        }

        public LinkedList<Processo> getProcList(){
            return proc;
        }
        public Processo criaProcesso(Word[] p){
            int[] paginasAlocadas = gm.aloca(p);
            Processo processo = new Processo(process_id, paginasAlocadas);
            process_id++;
            proc.AddLast(processo);
            return processo;
        }
        
        public void finalizaProcesso(Processo processo){
            gm.desaloca(processo);
            proc.Remove(processo);
        }

    }
}