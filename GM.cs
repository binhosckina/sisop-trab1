using System;
using System.Collections.Generic;

namespace sisop_trab1
{ 
    public class GM
	{
		private Word[] m;

        public int memoriaLivre;
		private int tamPag;
		private int frames;

        public List<Frame> frameList;

        private List<Frame> framesProc;
		public GM(Word[] m)
		{
			this.m = m;
			tamPag = 16;
			frames = m.Length / tamPag;
            frameList = new List<Frame>();
            for(int i = 0; i < frames; i++){
                Frame f = new Frame();
                f.inicio = 16*i;
                f.fim = f.inicio + 15;
                frameList.Add(f);
            }
            memoriaLivre = m.Length;
		}

        public int getMemoriaLivre(){
            return memoriaLivre;
        }
	

        public List<Frame> aloca(Word[] p)
        {
            
            int pages = p.Length / tamPag;
            if (p.Length % tamPag > 0) pages++;
            int[] memoriaAlocados = new int[pages];
            framesProc = new List<Frame>();


            int count = 0;
            for(int i = 0; i < frameList.Count-pages; i++){
                if(count == pages){
                    for(int j = count; j > 0; j--){
                        i--;
                        framesProc.Add(frameList[i]);
                        frameList[i].aloca();
                    }
                    break;
                }
                else{
                    if(frameList[i].getAlocado() == false ){
                        count++;
                    }else{
                        count = 0;
                    }
                }
            }

         
            int aux = framesProc[framesProc.Count-1].inicio;
            int aux2 = 0;
            foreach (Word item in p)
            {
                if( item.p > (framesProc[0].fim) || item.p < framesProc[framesProc.Count-1].inicio ){
                    item.p = (framesProc[0].fim) - aux2;
                    aux2 ++;
                }
                m[aux] = item;
                
                aux++;
            }
            
            Console.WriteLine("---------------------------------- frames alocados: "+(framesProc.Count));
            return framesProc;
        }


        public void desaloca(Processo p)
        {
            List<Frame> pages = p.getFrames();
            for (int i = 0; i < pages.Count; i++)
            {
                pages[i].desaloca();
            }
        }
    }
}
