namespace sisop_trab1
{
    public class Program
    {
        public Program(){
            this.progMinimo =  new Word[] {
                new Word(Opcode.LDI, 0, -1, 999),
                new Word(Opcode.STD, 0, -1, 10),
                new Word(Opcode.STD, 0, -1, 11),
                new Word(Opcode.STD, 0, -1, 12),
                new Word(Opcode.STD, 0, -1, 13),
                new Word(Opcode.STD, 0, -1, 14),
                new Word(Opcode.STOP, -1, -1, -1)
            };
            this.fibonacci10= new Word[] { // mesmo que prog exemplo, so que usa r0 no lugar de r8
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
            this.P3 = new Word[]{
            new Word(Opcode.LDI, 0, -1, 4), //salva o numero a ser calculado o fatorial.
            new Word(Opcode.LDI, 1, -1, 1),
            new Word(Opcode.LDI, 6, -1, 1),
            new Word(Opcode.LDI, 7, -1, 8),
            new Word(Opcode.JMPIE, 7, 0, 0),
            new Word(Opcode.MULT, 1, 0, -1),
            new Word(Opcode.SUB, 0, 6, -1),
            new Word(Opcode.JMP, -1, -1, 4),
            new Word(Opcode.STD, 1, 1, 10),
            new Word(Opcode.STOP, -1, -1, -1),
            new Word(Opcode.DATA, -1, -1, -1),
            };

            this.P4 = new Word[] {
            new Word(Opcode.DATA, -1, -1, 7), // 0 loop posição atual do array
            new Word(Opcode.DATA, -1, -1, 4), // 1 loop posição inicial do array
            new Word(Opcode.DATA, -1, -1, 20), // 2 guarda a posição inicia do array
            new Word(Opcode.LDI, 0, -1, 5), // 3 p = quantidade de valores para ordenar

            new Word(Opcode.LDI, 4, -1, 0), // 4
            new Word(Opcode.ADD, 4, 0, -1), // 5

            new Word(Opcode.LDD, 3, -1, 2), // 6 coloca r3 na posição inicial do array

            new Word(Opcode.SUBI, 4, -1, 1), // 7
            new Word(Opcode.JMPIEM, -1, 4, 2), // 8 

            new Word(Opcode.LDX, 1, 3, -1), // 9 carrega da memoria para os registradores
            new Word(Opcode.ADDI, 3, -1, 1), // 10
            new Word(Opcode.LDX, 2, 3, -1), // 11
            new Word(Opcode.SUB, 1, 2, -1), // 12

            new Word(Opcode.JMPILM, -1, 1, 0), // 13 se r1 < 0 próximo loop
            new Word(Opcode.SUBI, 3, -1, 1), // 14 /*
            new Word(Opcode.LDX, 1, 3, -1), // 15 
            new Word(Opcode.STX, 3, 2, -1), // 16  Swap na memória
            new Word(Opcode.ADDI, 3, -1, 1), // 17
            new Word(Opcode.STX, 3, 1, -1), // 18 */

            new Word(Opcode.JMPIGM, -1, 4, 1), // 19

            new Word(Opcode.DATA, -1, -1, 3), // 20
            new Word(Opcode.DATA, -1, -1, 1), // 21
            new Word(Opcode.DATA, -1, -1, 5), // 22 valores para ordenar
            new Word(Opcode.DATA, -1, -1, 4), // 23
            new Word(Opcode.DATA, -1, -1, 2), // 24

            new Word(Opcode.STOP, -1, -1, -1)
        };
        }
        public Word[] progMinimo;

        public Word[] fibonacci10;

        public Word[] P3;
        /*
            r0 = tamanho do array
            r1 = valor 1
            r2 = valor 2
            r3 = 
            r4 = 
        */
        public Word[] P4;

    }
}
