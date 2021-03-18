﻿namespace sisop_trab1
{
    public class Program
    {

        public static Word[] progMinimo = new Word[] {
                new Word(Opcode.LDI, 0, -1, 999),
                new Word(Opcode.STD, 0, -1, 10),
                new Word(Opcode.STD, 0, -1, 11),
                new Word(Opcode.STD, 0, -1, 12),
                new Word(Opcode.STD, 0, -1, 13),
                new Word(Opcode.STD, 0, -1, 14),
                new Word(Opcode.STOP, -1, -1, -1)
            };

        public static Word[] fibonacci10 = new Word[] { // mesmo que prog exemplo, so que usa r0 no lugar de r8
                new Word(Opcode.LDI, 1, -1, 0),
                new Word(Opcode.STD, 1, -1, 20), //50 
                new Word(Opcode.LDI, 2, -1, 1),
                new Word(Opcode.STD, 2, -1, 21), //51
                new Word(Opcode.LDI, 0, -1, 22), //52
                new Word(Opcode.LDI, 6, -1, 6),
                new Word(Opcode.LDI, 7, -1, 31), //61
                new Word(Opcode.LDI, 3, -1, 0),
                new Word(Opcode.ADD, 3, 1, -1),
                new Word(Opcode.LDI, 1, -1, 0),
                new Word(Opcode.ADD, 1, 2, -1),
                new Word(Opcode.ADD, 2, 3, -1),
                new Word(Opcode.STX, 0, 2, -1),
                new Word(Opcode.ADDI, 0, -1, 1),
                new Word(Opcode.SUB, 7, 0, -1),
                new Word(Opcode.JMPIG, 6, 7, -1),
                new Word(Opcode.STOP, -1, -1, -1)
            };

        public static Word[] P3 = new Word[] {
            new Word(Opcode.LDI, 0, -1, -1),
            new Word(Opcode.STD, 0, -1, 10),

            new Word(Opcode.LDI, 0, -1, -5),
            // new Word(Opcode.STD, 0, -1, 20),
            new Word(Opcode.LDI, 1, -1, 5),
            // new Word(Opcode.STD, 1, -1, 21),

            // new Word(Opcode.JMP, -1, -1, 12),

            new Word(Opcode.JMPILM, -1, 0, 10),
            new Word(Opcode.STOP, -1, -1, -1)
        };
    }
}
