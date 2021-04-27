using System;

namespace sisop_trab1
{ 
    public class GM
	{
		private Word[] m;
		private int tamPag;
		private int frames;
		private bool[] frameLivre;

		public GM(Word[] m)
		{
			this.m = m;
			tamPag = 16;
			frames = m.Length / tamPag;
			frameLivre = criaFrames();
		}


		private bool[] criaFrames()
		{
			bool[] free = new bool[frames];
			for (int i = 0; i < frames; i++)
			{
				free[i] = true;
			}
			return free;
		}

        public int[] aloca(Word[] m)
        {
            int pages = m[m.Length - 1].r1 / tamPag;
            if (m.Length % tamPag > 0) pages++;
            int[] framesAlocados = new int[pages];
            int alocados = 0;
            int programa = 0;   //indice do programa

            for (int i = 0; i < frames; i++)
            {
                if (pages == 0) break;
                if (frameLivre[i])
                {
                    frameLivre[i] = false;
                    //Aqui implementamos o for para alocar o programa de acordo com a sua tabela de páginas (PaginasAlocadas)
                    //Esse for abaixo está errado
                    for (int j = tamPag * i; j < tamPag * (i + 1); j++)
                    {
                        if (programa >= m.Length)
                            break;
                        this.m[j].opc = m[programa].opc;
                        this.m[j].r1 = m[programa].r1;
                        this.m[j].r2 = m[programa].r2;
                        this.m[j].p = m[programa].p;
                        programa++;
                    }
                    framesAlocados[alocados] = i;
                    alocados++;
                    pages--;
                }
            }
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
