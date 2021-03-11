using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -------------------------------------------------------------------------------------------------------
// --------------------- M E M O R I A -  definicoes de opcode e palavra de memoria ---------------------- 
// -------------------------------------------------------------------------------------------------------

namespace sisop_trab1
{
    public enum Opcode
    {
        DATA, ___,          // se memoria nesta posicao tem um dado, usa DATA, se nao usada ee NULO ___
        JMP, JMPI, JMPIG, JMPIL, JMPIE, JMPIM, JMPIGM, JMPILM, JMPIEM, STOP,   // desvios e parada
        ADDI, SUBI, ADD, SUB, MULT,         // matematicos
        LDI, LDD, STD, LDX, STX, SWAP        // movimentacao
    }
    public class Word
    {   // cada posicao da memoria tem uma instrucao (ou um dado)
        public Opcode opc;  //
        public int r1;      // indice do primeiro registrador da operacao (Rs ou Rd cfe opcode na tabela)
        public int r2;      // indice do segundo registrador da operacao (Rc ou Rs cfe operacao)
        public int p;       // parametro para instrucao (k ou A cfe operacao), ou o dado, se opcode = DADO

        public Word(Opcode _opc, int _r1, int _r2, int _p)
        {
            opc = _opc; r1 = _r1; r2 = _r2; p = _p;
        }
    }
}
