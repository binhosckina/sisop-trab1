namespace sisop_trab1
{
    
    public class VM
    {
        public int tamMem;
        public Word[] m;
        public CPU cpu;
        public int tamPag;
        public int tamFrame;
        public int nroFrames;
        public bool[] frameLivre;
        public VM()
        {   // vm deve ser configurada com endereço de tratamento de interrupcoes
            // memória
            tamMem = 1024;
            tamPag = tamFrame = 16;
            m = new Word[tamMem]; // m ee a memoria
            nroFrames = tamMem / tamPag;
            frameLivre = new bool[nroFrames];
            for (int j = 0; j < nroFrames; j++) { 
                frameLivre[j] = true;
            }
            for (int i = 0; i < tamMem; i++) { m[i] = new Word(Opcode.___, -1, -1, -1); };
            // cpu
            cpu = new CPU(m);
        }
    }
}
