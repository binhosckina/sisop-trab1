using System;

namespace sisop_trab1
{
    public class CPU
    {
        // característica do processador: contexto da CPU ...
        private int pc;             // ... composto de program counter,
        private Word ir;            // instruction register,
        private int[] reg;          // registradores da CPU
        string msg; // messagem da interrupção

        private Word[] m;   // CPU acessa MEMORIA, guarda referencia 'm' a ela. memoria nao muda. ee sempre a mesma.

        public CPU(Word[] _m)
        {     // ref a MEMORIA e interrupt handler passada na criacao da CPU
            m = _m;                 // usa o atributo 'm' para acessar a memoria.
            reg = new int[8];       // aloca o espaço dos registradores
        }

        public void setContext(int _pc)
        {  // no futuro esta funcao vai ter que ser 
            pc = _pc;                                              // limite e pc (deve ser zero nesta versao)
        }

        public void run()
        {       // execucao da CPU supoe que o contexto da CPU, vide acima, esta devidamente setado
            while (true)
            {           // ciclo de instrucoes. acaba cfe instrucao, veja cada caso.
                        // FETCH
                if (pc > new VM().tamMem)
                {
                    msg = "Endereço inválido: programa do usuário acessando endereço fora de limites permitidos"; // messagem da interrupção 
                    ir.opc = Opcode.STOP;
                }
                else
                {
                    ir = m[pc];     // busca posicao da memoria apontada por pc, guarda em ir
                }                   // EXECUTA INSTRUCAO NO ir
                switch (ir.opc)
                { // para cada opcode, sua execução

                    case Opcode.JMP: // 1. PC ← k
                        pc = ir.p;
                        break;

                    case Opcode.JMPI: // 2. PC ← k
                        pc = ir.r1;
                        break;

                    case Opcode.LDI: // 16. Rd ← k
                        reg[ir.r1] = ir.p;
                        pc++;
                        break;

                    case Opcode.LDD: // 17. Rd ← k
                        reg[ir.r1] = m[ir.p].p;
                        pc++;
                        break;

                    case Opcode.STD: // 18. [A] ← Rs
                        m[ir.p].opc = Opcode.DATA;
                        m[ir.p].p = reg[ir.r1];
                        pc++;
                        break;

                    case Opcode.ADD: // 13. Rd ← Rd + Rs
                        reg[ir.r1] = reg[ir.r1] + reg[ir.r2];
                        pc++;
                        break;

                    case Opcode.ADDI: // 11. Rd ← Rd + k
                        reg[ir.r1] = reg[ir.r1] + ir.p;
                        pc++;
                        break;

                    case Opcode.SUBI: // 12. Rd ← Rd - k
                        reg[ir.r1] = reg[ir.r1] - ir.p;
                        pc++;
                        break;

                    case Opcode.STX: // 20. [Rd] ←Rs
                        m[reg[ir.r1]].opc = Opcode.DATA;
                        m[reg[ir.r1]].p = reg[ir.r2];
                        pc++;
                        break;

                    case Opcode.SUB: // 14. Rd ← Rd - Rs
                        reg[ir.r1] = reg[ir.r1] - reg[ir.r2];
                        pc++;
                        break;

                    case Opcode.MULT: // 15. Rd ← Rd * Rs
                        reg[ir.r1] = reg[ir.r1] * reg[ir.r2];
                        pc++;
                        break;

                    case Opcode.JMPIG: // 3. If Rc > 0 Then PC ← Rs Else PC ← PC +1
                        if (reg[ir.r2] > 0)
                            pc = reg[ir.r1];
                        else
                            pc++;
                        break;

                    case Opcode.JMPIM: // 6. PC ← [A]
                        pc = m[ir.p].p;
                        break;

                    case Opcode.JMPIGM: // 7. If Rc > 0 Then PC ← [A] Else PC ← PC +1
                        if (reg[ir.r2] > 0)
                            pc = m[ir.p].p;
                        else
                            pc++;
                        break;

                    case Opcode.JMPILM: // 8. If Rc < 0 Then PC ← [A] Else PC ← PC +1
                        if (reg[ir.r2] < 0)
                            pc = m[ir.p].p;
                        else
                            pc++;
                        break;

                    case Opcode.JMPIEM: // 8. If Rc = 0 Then PC ← [A] Else PC ← PC +1
                        if (reg[ir.r2] == 0)
                            pc = m[ir.p].p;
                        else
                            pc++;
                        break;

                    case Opcode.STOP: // 10. por enquanto, para execucao
                        break;

                    case Opcode.DATA:
                        pc++; //precisa ser implementado
                        break;

                    default:
                        ir.opc = Opcode.STOP; // 
                        msg = "Instrução inválida: a instrução carregada é inválida"; // messagem da interrupção
                        pc++;
                        break;
                }

                // VERIFICA INTERRUPÇÃO !!! - TERCEIRA FASE DO CICLO DE INSTRUÇÕES
                if (ir.opc == Opcode.STOP)
                {
                    Console.WriteLine(msg);
                    break; // break sai do loop da cpu
                }
            }
        }
    }
}
