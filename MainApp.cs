// PUCRS - Escola Politécnica - Sistemas Operacionais
// Prof. Fernando Dotti
// Código fornecido como parte da solução do projeto de Sistemas Operacionais
//
// Fase 1 - máquina virtual (vide enunciado correspondente)
//
using System;

namespace sisop_trab1
{

    class MainApp
    {
        public static void Main(string[] args)
        {
            SO s = new SO();
        
            SO.runFibonacci(s.vm);
            SO.runFibonacci(s.vm);
            //SO.runP3(s.vm);
            
            SO.runProgMinimo(s.vm);
            SO.runProgMinimo(s.vm);
            SO.runProgMinimo(s.vm);
            SO.runProgMinimo(s.vm);
            SO.runFibonacci(s.vm);
            SO.runFibonacci(s.vm);
            SO.runFibonacci(s.vm);
            SO.runFibonacci(s.vm);
            SO.runProgMinimo(s.vm);
            SO.ShowProcessos();
            SO.EscalonadorRun();
            //SO.ShowProcessos();
            
        }
    }
}
