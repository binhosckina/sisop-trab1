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
        public VM getVM(){
            return vm;
        }
        public LinkedList<Processo> getProcList(){
            return proc;
        }
        public Processo criaProcesso(Word[] p){
            List<Frame> f = new List<Frame>();
            f = gm.aloca(p);
            Processo processo = new Processo(process_id, f, vm.m[f[0].inicio]);
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