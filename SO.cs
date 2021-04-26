using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class SO
    {
        public VM vm;
        private LinkedList<Processo> processos;
        private static GM gm;
        private static GP gp;
        public SO()
        {
            vm = new VM();
            
            gm = new GM(vm.m);
            gp = new GP(gm, vm, processos = new LinkedList<Processo>());
        }

        static public void test1(VM vm)
        {
            Word[] p = Program.fibonacci10;
            int[] allocatedPages = gm.aloca(p);
            Processo proc = gp.criaProcesso(p);
            // VariaveisPrograma = new VariaveisPrograma();
            Utils.carga(p, vm.m);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 33);
            Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.setContext( ); 
            vm.cpu.run();
            gp.finalizaProcesso(proc);
            Utils.dump(vm.m, 0, 33);

        }

        static public void test2(VM vm)
        {
            Word[] p = Program.progMinimo;
            int[] allocatedPages = gm.aloca(p);
            Utils.carga(p, vm.m);
            //vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 15);
        }

        static public void test3(VM vm)
        {
            Word[] p = Program.P3;
            int[] allocatedPages = gm.aloca(p);
            Utils.carga(p, vm.m);
            //vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 15);
        }

        static public void test4(VM vm)
        {
            Word[] p = Program.P4;
            int[] allocatedPages = gm.aloca(p);
            Utils.carga(p, vm.m);
            //vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 36);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 36);
        }
    }

}
