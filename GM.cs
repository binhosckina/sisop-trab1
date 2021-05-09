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
	

        public int[] aloca(Word[] p)
        {
            
            int pages = p.Length / tamPag;
            if (p.Length % tamPag > 0) pages++;
            int[] framesAlocados = new int[pages];
            
            if(pages*tamPag > memoriaLivre || pages == 0){
                throw new Exception("Memoria cheia");
            }else{
                for (int i = 0; i < pages; i++)
                {
                  memoriaLivre = memoriaLivre - tamPag;
                  framesAlocados[i] = this.m.Length - memoriaLivre - tamPag;
                }
                int aux = framesAlocados[0];
                int aux2 = 0;
                foreach (Word item in p)
                {
                    if( item.p > (framesAlocados[framesAlocados.Length-1]+16) || item.p < framesAlocados[0] ){
                        item.p = (framesAlocados[framesAlocados.Length-1]+15) - aux2;
                        aux2 ++;
                    }
                    m[aux] = item;
                    
                    aux++;
                }
            }
            Console.WriteLine("---------------------------------- frames alocados: "+(framesAlocados.Length));
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
