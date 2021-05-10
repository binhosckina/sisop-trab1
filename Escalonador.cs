using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class Escalonador {

    	private LinkedList<Processo> processos;
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
    					break;
    				}
                    foreach (Processo processo in processos)
                    {
    				    cpu.setContext(processo.GetVariaveisPrograma());
						cpu.run();
						if(cpu.getCpuInterruption().getmsg() == "proximo processo" ){
							cpu.setInterruption(new Interruption());
							processo.setVariaveisPrograma(cpu.getContext());
							//processo.resetInterruption();
							continue;
						}
						else{
							processosMortos.Add(processo);
							Console.WriteLine("---------------------------------- após execucao ");
							Utils.dump(gp.getVM().m, processo.getFrames()[0].inicio, processo.getFrames()[processo.getFrames().Count-1].fim);
							cpu.setInterruption(new Interruption());
						}
                    }
                    for(int i = 0; i < processosMortos.Count; i++){
						gp.finalizaProcesso(processosMortos[i]);
					}
					processosMortos = new List<Processo>();
    			} catch (Exception e) {
    				Console.WriteLine(e);
    			}
    		}
    	}

    	public LinkedList<Processo> getProntos() {
    		return processos;
    	}
    }
}