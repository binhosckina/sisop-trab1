﻿using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class SO
    {
        public VM vm;
        private static LinkedList<Processo> processos;
        private static GM gm;
        private static GP gp;
        private static Escalonador es;
        public SO()
        {
            processos = new LinkedList<Processo>();
            vm = new VM();
            gm = new GM(vm.m);
            gp = new GP(gm, vm, processos);
            es = new Escalonador(gp.getProcList(), vm.cpu);
        }

        static public void runFibonacci(VM vm)
        {
            Word[] p = Program.fibonacci10;
            Processo proc = gp.criaProcesso(p);
            Utils.carga(p, vm.m);
            processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 33);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.setContext(processos.First.Value.GetVariaveisPrograma()); 
            //vm.cpu.run();
            //gp.finalizaProcesso(proc);
            //Utils.dump(vm.m, 0, 33);

        }

        static public void runProgMinimo(VM vm)
        {
            Word[] p = Program.progMinimo;
            Processo proc = gp.criaProcesso(p);
            Utils.carga(p, vm.m);
            proc.setVariaveisPrograma(vm.cpu.getContext());
            processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
           // Utils.dump(vm.m, 0, 15);
        }

        static public void runP3(VM vm)
        {
            Word[] p = Program.P3;
            Processo proc = gp.criaProcesso(p);
            Utils.carga(p, vm.m);
            proc.setVariaveisPrograma(vm.cpu.getContext());
            processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
            //Utils.dump(vm.m, 0, 15);
        }

        static public void runP4(VM vm)
        {
            Word[] p = Program.P4;
            Processo proc = gp.criaProcesso(p);
            Utils.carga(p, vm.m);
            proc.setVariaveisPrograma(vm.cpu.getContext());
            processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 36);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
            //Utils.dump(vm.m, 0, 36);
        }

        static public void runP(VM vm)
        {
            Word[] p = Program.progMinimo;
            Processo proc = gp.criaProcesso(p);
            Utils.carga(p, vm.m);
            proc.setVariaveisPrograma(vm.cpu.getContext());
            processos.AddLast(proc);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            //Console.WriteLine("---------------------------------- após execucao ");
            //vm.cpu.run();
            //Utils.dump(vm.m, 0, 15);
        }
    }

}
