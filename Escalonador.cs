using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class Escalonador {

    	private LinkedList<Processo> processos;
    	private int pointer;
    	private Processo processoAtual;
    	private CPU cpu;

    	public Escalonador(LinkedList<Processo> processos, CPU cpu) { 
            this.processos = processos;
    		this.pointer = 0;
    		this.cpu = cpu;
        }

    	public void run() {
    		while(true){
    			try{
    				if(processos.Count == 0){
    					continue;
    				}
    				Processo proc;
                    foreach (Processo processo in processos)
                    {
                        if(processo.getId() == pointer){
                            proc = processo;
                            this.processoAtual = proc;
    				        int old = pointer;
    				        pointer = (pointer + 1) % processos.Count;
    				        processos.Remove(processo);
    				        cpu.setContext(processo.GetVariaveisPrograma());
							cpu.run();
                        }
                    }
    			} catch (Exception e) {
    				Console.WriteLine(e);
    			}
    		}
    	}

    	public Processo getPA() {
    		return processoAtual;
    	}

    	public void setPANull(){
    		this.processoAtual = null;
    	}

    	public LinkedList<Processo> getProntos() {
    		return processos;
    	}
    }
}