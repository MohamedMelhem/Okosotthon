using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;


        public OkosEszkoz(string azonosito, string nev)
        {

            onlineE = false;
            utolsoFrissites = DateTime.Now;
        }


        public void Csatlakozas()
        {
            this.onlineE = true;
        }


        public void KapcsolatBontasa()
        {
            this.onlineE = false;
        }
        public bool DiagnosztikaFuttatasa()
        {
            bool eredmeny = false;
            if (this.onlineE)
            {
                return this.OnTesztFuttatasa();
            }
            else {

                return eredmeny;
                 }
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            onlineE = false;
            utolsoFrissites = DateTime.Now;
        }


        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
