using System;

namespace sisop_trab1
{
    public class CPU
    {
        // característica do processador: contexto da CPU ...
        private int pc;             // ... composto de program counter,
        private Word ir;            // instruction register,
        private int[] reg;          // registradores da CPU
        private Interruption interruption;
        string msg; // messagem da interrupção
        private Word[] m;   // CPU acessa MEMORIA, guarda referencia 'm' a ela. memoria nao muda. ee sempre a mesma.
        private int min;
        private int max;
	    //private Word[] memory;
	    private int[] paginasAlocadas;
        
        private int CicloEscalonador;
        public CPU(Word[] _m, Interruption interruption)
        {     // ref a MEMORIA e interrupt handler passada na criacao da CPU
            this.m = _m;                 // usa o atributo 'm' para acessar a memoria.
            this.reg = new int[8];       // aloca o espaço dos registradores
            this.CicloEscalonador = 0;
            this.interruption = interruption; 
        }

        public Contexto getContext() {
		    return new Contexto(min,max,paginasAlocadas,reg,pc,new Word(ir.opc,ir.r1,ir.r2,ir.p), this.interruption);
	    }

        public Interruption getCpuInterruption(){
            return this.interruption;
        }
        public void setInterruption(Interruption interruption){
            this.interruption = interruption;
        }
        public void setContext(Contexto vp)
        {  // no futuro esta funcao vai ter que ser 
            this.min = vp.getMin();
		    this.max = vp.getMax();
		    this.paginasAlocadas = vp.getPaginasAlocadas();
		    this.pc = vp.getpc();
		    this.reg = vp.getregistradores();
		    this.interruption = vp.getInterruption();
            this.ir = m[min];
        }

        private bool isLegal(int e) { // dar um nome melhor para este metodo
		    if ((e < min) || (e > max)) {
		    	this.interruption.setInterruption("Endereço invalido");
		    	return false;
		    }
		    return true;
	    }

        public void run()
        {       // execucao da CPU supoe que o contexto da CPU, vide acima, esta devidamente setado
            while (true)
            {           // ciclo de instrucoes. acaba cfe instrucao, veja cada caso.
                        // FETCH
                if(CicloEscalonador > 4){
                    this.interruption.setInterruption("proximo processo");
                    this.CicloEscalonador = 0;
                }
                if (isLegal(pc) && interruption.getstate() == false) {
                    ir = m[pc];     // busca posicao da memoria apontada por pc, guarda em ir
                                     // EXECUTA INSTRUCAO NO ir
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
                            if (isLegal(ir.p)) {
                                reg[ir.r1] = m[ir.p].p;
                                pc++;
                                break;
                            }
                            break;
                        case Opcode.LDX: // 19. Rd ← [Rs]
                            if (isLegal(reg[ir.r2])) {
                                reg[ir.r1] = m[reg[ir.r2]].p;
                            }
                            pc++;
                            break;

                        case Opcode.STD: // 18. [A] ← Rs
                            if (isLegal(ir.p)) {
                            m[ir.p].opc = Opcode.DATA;
                            m[ir.p].p = reg[ir.r1];
                            pc++;
                            }
                            break;

                        case Opcode.ADD: // 13. Rd ← Rd + Rs
                            try{
                                reg[ir.r1] = reg[ir.r1] + reg[ir.r2];
                            }
                            catch (OverflowException e){
                                ir.opc = Opcode.STOP; // 
                                msg = "Overflow"; // messagem da interrupção
                            }
                            pc++;
                            break;

                        case Opcode.ADDI: // 11. Rd ← Rd + k
                            try{
                                reg[ir.r1] = reg[ir.r1] + ir.p;
                            }
                            catch (OverflowException e){
                                ir.opc = Opcode.STOP; // 
                                msg = "Overflow"; // messagem da interrupção
                            }
                            pc++;
                            break;

                        case Opcode.SUBI: // 12. Rd ← Rd - k
                            try{
                                reg[ir.r1] = reg[ir.r1] - ir.p;
                            }
                            catch (OverflowException e){
                                ir.opc = Opcode.STOP; // 
                                msg = "Overflow"; // messagem da interrupção
                            }
                            pc++;
                            break;

                        case Opcode.STX: // 20. [Rd] ←Rs
                            m[reg[ir.r1]].opc = Opcode.DATA;
                            m[reg[ir.r1]].p = reg[ir.r2];
                            
                            pc++;
                            break;

                        case Opcode.SUB: // 14. Rd ← Rd - Rs
                            try{
                                reg[ir.r1] = reg[ir.r1] - reg[ir.r2];
                            }
                            catch (OverflowException e){
                                ir.opc = Opcode.STOP; // 
                                msg = "Overflow"; // messagem da interrupção
                            }
                            pc++;
                            break;

                        case Opcode.MULT: // 15. Rd ← Rd * Rs
                            try{
                                reg[ir.r1] = reg[ir.r1] * reg[ir.r2];
                            }
                            catch (OverflowException e){
                                ir.opc = Opcode.STOP; // 
                                msg = "Overflow"; // messagem da interrupção
                            }
                            pc++;
                            break;

                        case Opcode.JMPIG: // 3. If Rc > 0 Then PC ← Rs Else PC ← PC +1
                            if (reg[ir.r2] > 0)
                                pc = reg[ir.r1];
                            else
                                pc++;
                            break;

                        case Opcode.JMPIM: // 6. PC ← [A]
                            if (isLegal(ir.p)) {
                                pc = m[ir.p].p;
                            }
                            break;

                        case Opcode.JMPIGM: // 7. If Rc > 0 Then PC ← [A] Else PC ← PC +1
                            if (reg[ir.r2] > 0 && isLegal(ir.p))
                                pc = m[ir.p].p;
                            else
                                pc++;
                            break;

                        case Opcode.JMPILM: // 8. If Rc < 0 Then PC ← [A] Else PC ← PC +1
                            if (reg[ir.r2] < 0 && isLegal(ir.p))
                                pc = m[ir.p].p;
                            else
                                pc++;
                            break;

                        case Opcode.JMPIEM: // 8. If Rc = 0 Then PC ← [A] Else PC ← PC +1
                            if (reg[ir.r2] == 0 && isLegal(ir.p))
                                pc = m[ir.p].p;
                            else
                                pc++;
                            break;

                        // case Opcode.SWAP: // 21. T ← Ra, Ra ← Rb, Rb ← T
                        //     reg[0] = reg[1];
                        //     reg[1] = reg[2];
                        //     reg[2] = reg[0];
                        //     break;

                        case Opcode.STOP: // 10. por enquanto, para execucao
                            this.interruption.setInterruption("Fim de execução");
                            break;

                        case Opcode.DATA:
                            pc++; 
                            break;

                        case Opcode.TRAP:
                            int valor;
                            if (reg[7] == 1){
                                if (Int32.TryParse(Console.ReadLine(), out valor)){
                                    reg[8] = valor;
                                }else{
                                    ir.opc = Opcode.STOP; // 
                                    msg = "Tipo de entrada invalido"; // messagem da interrupção
                                }
                            }
                            if (reg[7] == 2){
                                Console.WriteLine(reg[8]);
                            }
                            pc++;
                            break;

                        default:
                            ir.opc = Opcode.STOP; // 
                            msg = "Instrução inválida: a instrução carregada é inválida"; // messagem da interrupção
                            pc++;
                            break;
                    }
                }
                // VERIFICA INTERRUPÇÃO !!! - TERCEIRA FASE DO CICLO DE INSTRUÇÕES
                if (interruption.getstate())
                {
                    Console.WriteLine(interruption.getmsg());
                    break; // break sai do loop da cpu
                }
                CicloEscalonador++;
            }
            
        }
    }
}

