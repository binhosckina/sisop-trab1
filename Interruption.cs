using System;

namespace sisop_trab1
{
    public class Interruption
    {
        private String msg;
        private bool state;

        public Interruption(){
            this.msg = null;
            this.state = false;
        }

        public String getmsg(){
            return this.msg;
        }

        public bool getstate(){
            return this.state;
        }

        public void setInterruption(String msg)
        {
            this.state = true;
            this.msg = msg;
        }

        
    }
}