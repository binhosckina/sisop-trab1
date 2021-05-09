using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class SO
    {
        public VM vm;
        public Interruption interruption;
        private static LinkedList<Processo> processos;
        private static GM gm;
        private static GP gp;
        private static Escalonador es;
        public SO()
        {
            processos = new LinkedList<Processo>();
            Interruption interruption = new Interruption();
            vm = new VM(interruption);
            gm = new GM(vm.m);
            gp = new GP(gm, vm, processos);
            es = new Escalonador(gp, vm.cpu);
        }

        static public void ShowProcessos(){
            foreach (Processo proc in processos)
            {
                Console.WriteLine(proc.getName()+"-------"+proc.getAllocatedPages());
            }
        }
        static public void EscalonadorRun(){
            es.run();
        }
        static public void runFibonacci(VM vm)
        {
            
            Program program = new Program();
            Word[] p = program.fibonacci10;
            Processo proc = gp.criaProcesso(p);
            proc.setName("fibonacci");
            //Utils.carga(p, vm.m);
            //processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.setContext(processos.First.Value.GetVariaveisPrograma()); 
            //vm.cpu.run();
            //gp.finalizaProcesso(proc);
            //Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
        }

        static public void runProgMinimo(VM vm)
        {
            Program program = new Program();
            Word[] p = program.progMinimo;
            Processo proc = gp.criaProcesso(p);
            proc.setName("progMinimo");
            //Utils.carga(p, vm.m);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
            Console.WriteLine("Memoria livre: "+ gm.getMemoriaLivre());
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.setContext(processos.First.Value.GetVariaveisPrograma()); 
            //vm.cpu.run();
            //gp.finalizaProcesso(proc);
            //Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
        }

        static public void runP3(VM vm)
        {
            Program program = new Program();
            Word[] p = program.P3;
            Processo proc = gp.criaProcesso(p);
            proc.setName("p3");
            //Utils.carga(p, vm.m);
            //proc.setVariaveisPrograma(vm.cpu.getContext());
            //processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
            Console.WriteLine("Memoria livre: "+ gm.getMemoriaLivre());
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
            //Utils.dump(vm.m, 0, 15);
        }

        static public void runP4(VM vm)
        {
            Program program = new Program();
            Word[] p = program.P4;
            Processo proc = gp.criaProcesso(p);
            proc.setName("p4");
            //Utils.carga(p, vm.m);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, proc.getAllocatedPages()[0], proc.getAllocatedPages()[proc.getAllocatedPages().Length-1]+16);
            Console.WriteLine("Memoria livre: "+ gm.getMemoriaLivre());
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
            //Utils.dump(vm.m, 0, 36);
        }

    }
    
}
