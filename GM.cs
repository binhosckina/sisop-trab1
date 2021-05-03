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


		public GM(Word[] m)
		{
			this.m = m;
			tamPag = 16;
			frames = m.Length / tamPag;
            memoriaLivre = m.Length;
		}

        public int getMemoriaLivre(){
            return memoriaLivre;
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
            Console.WriteLine("Frames alocados: "+(framesAlocados.Length+1));
            return framesAlocados;
        }


        public void desaloca(Processo p)
        {
            int[] pages = p.getAllocatedPages();
            for (int i = 0; i < pages.Length; i++)
            {
                memoriaLivre = memoriaLivre + tamPag;
            }
        }
    }
}
