using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz , Istatisztika, IIdozito
    {
        public double JelenlegiHomerseklet { get; private set; } = 21.0;
        public double CelHomerseklet { get; private set; }
        private int idojefut = 0;
        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
           this.CelHomerseklet = celHomerseklet;
            
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string ertek = parancs.Split(':')[1];

                if (double.TryParse(ertek, out double homerseklet))
                {
                    this.CelHomerseklet = homerseklet;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {this.JelenlegiHomerseklet} °C, " +
                   $"Célhőmérséklet: {this.CelHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 &&
                   this.CelHomerseklet <= 35.0;
        }

        public string StatisztikatKeszit()
        {
            return $"A futes {this.idojefut}°C\n a jelenlegi hő: {this.CelHomerseklet}";

        }

        public void IdozitestBeallit(int perc)
        {

            this.idojefut = perc;
        }

        public int GetMaradtIdo()
        {
            return this.idojefut-10 ;
        }
    }
}
