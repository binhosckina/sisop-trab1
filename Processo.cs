using System;
using System.Collections.Generic;

namespace sisop_trab1
{
    public class Processo
    {
        private int id;

        private String name;
        private List<Frame> frames;
        private Contexto contexto;

        public Processo(int id, List<Frame> frames, Word ir){
            this.id= id;
            this.frames = frames;
            this.contexto = new Contexto(frames[frames.Count-1].inicio,frames[0].fim,frames.Count,new int[8], frames[frames.Count-1].inicio, ir, new Interruption());
        }

        public List<Frame> getFrames(){
            return this.frames;
        }

        public void setName(String name){
            this.name = name+'_'+id;
        }
        public void resetInterruption(){
            this.contexto.reset();
        }
        public String getName(){
            return this.name;
        }
        public int getId(){
            return id;
        }

        public void setVariaveisPrograma(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Contexto GetVariaveisPrograma(){
            return this.contexto;
        }
    }
}