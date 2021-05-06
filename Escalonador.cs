using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class Escalonador {

    	private LinkedList<Processo> processos;
    	private Processo processoAtual;
    	private CPU cpu;

		private List<Processo> processosMortos;
		private GP gp;

    	public Escalonador(GP gp, CPU cpu) { 
			this.gp = gp;
            this.processos = gp.getProcList();
    		this.cpu = cpu;
			processosMortos = new List<Processo>();
        }

    	public void run() {
    		while(true){
    			try{
    				if(processos.Count == 0){
    					continue;
    				}
                    foreach (Processo processo in processos)
                    {
                        this.processoAtual = processo;
    				    cpu.setContext(processoAtual.GetVariaveisPrograma());
						cpu.run();
						if(cpu.getMSG() == "proximo processo" ){
							processoAtual.setVariaveisPrograma(cpu.getContext());
							break;
						}
						else{
							processosMortos.Add(processoAtual);
							Console.WriteLine("---------------------------------- após execucao ");
							Utils.dump(gp.getVM().m, processoAtual.getAllocatedPages()[0], processoAtual.getAllocatedPages()[processoAtual.getAllocatedPages().Length-1]+16);
						}
                    }
                    for(int i = 0; i < processosMortos.Count; i++){
						processos.Remove(processosMortos[i]);
					}
					processosMortos = new List<Processo>();
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