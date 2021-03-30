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
        static void Main(string[] args)
        {
            SO s = new SO();
            SO.test1(s.vm);
            SO.test2(s.vm);
            SO.test3(s.vm);
            SO.test4(s.vm);
        }
    }
}
