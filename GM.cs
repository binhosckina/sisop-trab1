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
		private List<bool> frameLivre;

		public GM(Word[] m)
		{
			this.m = m;
			tamPag = 16;
			frames = m.Length / tamPag;
            memoriaLivre = m.Length;
			criaFrames();
		}

        public int getMemoriaLivre(){
            return memoriaLivre;
        }
		private void criaFrames()
		{
            frameLivre = new List<bool>();
			bool[] free = new bool[frames];
			for (int i = 0; i < frames; i++)
			{
				frameLivre.Add(true);
			}
		}

        public int[] aloca(Word[] m)
        {
            
            int pages = m.Length / tamPag;
            if (m.Length % tamPag > 0) pages++;
            int[] framesAlocados = new int[pages];
            
            if(pages*tamPag > memoriaLivre || pages == 0){
                throw new Exception("Memoria cheia");
            }else{
                for (int i = 0; i < pages; i++)
                {
                  memoriaLivre = memoriaLivre - tamPag;
                  framesAlocados[i] = this.m.Length - memoriaLivre - tamPag;
                }
            }
            Console.WriteLine("Frames alocados: "+framesAlocados.Length+1);
            return framesAlocados;
        }


        public void desaloca(Processo p)
        {
            int[] pages = p.getAllocatedPages();
            for (int i = 0; i < pages.Length; i++)
            {
                frameLivre[pages[i]] = true;
                for (int j = tamPag * pages[i]; j < tamPag * (pages[i] + 1); j++)
                {
                    m[j].opc = Opcode.___;
                    m[j].r1 = -1;
                    m[j].r2 = -1;
                    m[j].p = -1;
                }
            }
        }
    }
}
