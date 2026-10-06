using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        public double JelenlegiHomerseklet { get; private set; } = 21.0;
        public double CelHomerseklet { get; private set; }
        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            throw new NotImplementedException();
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

    }
}
