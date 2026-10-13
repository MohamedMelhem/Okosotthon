using System;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, Istatisztika, IHangjelzo
    {
        public int pinKod { get; private set; }

        public bool Nyitva { get; private set; }

        private int sikeresNyitasok;
        private int hibasProbalkozasok;
        private int veszhivasok;

        public OkosZar(string azonosito, string nev, int pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            Nyitva = false;
            sikeresNyitasok = 0;
            hibasProbalkozasok = 0;
            veszhivasok = 0;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "nyit")
            {
                Console.Write("Add meg a PIN-kódot: ");

                if (int.TryParse(Console.ReadLine(), out int megadottPin))
                {
                    if (megadottPin == pinKod)
                    {
                        Nyitva = true;
                        sikeresNyitasok++;
                        Console.WriteLine("A zár kinyílt.");
                    }
                    else
                    {
                        hibasProbalkozasok++;
                        Console.WriteLine("Hibás PIN-kód!");
                        Csipog(1000);
                        VeszjelzesInditasa();
                    }
                }
                else
                {
                    hibasProbalkozasok++;
                    Console.WriteLine("Érvénytelen PIN-kód!");
                    Csipog(1000);
                    VeszjelzesInditasa();
                }
            }
            else if (parancs == "zar")
            {
                Nyitva = false;
                Console.WriteLine("A zár bezárult.");
            }
            else
            {
                Console.WriteLine("Ismeretlen parancs.");
            }
        }

        public override string AllapotJelentes()
        {
            return Nyitva
                ? "A zár nyitva van."
                : "A zár zárva van.";
        }

        protected override bool OnTesztFuttatasa()
        {
            return pinKod >= 0;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            Nyitva = false;
            sikeresNyitasok = 0;
            hibasProbalkozasok = 0;
            veszhivasok = 0;

            Console.WriteLine("A zár gyári beállításai visszaállítva.");
        }

        public string StatisztikatKeszit()
        {
            return
                $"Zár statisztika:\n" +
                $"Sikeres nyitások: {sikeresNyitasok}\n" +
                $"Hibás PIN-próbálkozások: {hibasProbalkozasok}\n" +
                $"Vészjelzések száma: {veszhivasok}\n" +
                $"Állapot: {(Nyitva ? "Nyitva" : "Zárva")}";
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"CSIPOGÁS! Időtartam: {hosszu} ms");

            try
            {
                Console.Beep(1000, hosszu);
            }
            catch (PlatformNotSupportedException)
            {
                // Egyes rendszereken a Console.Beep nem támogatott.
            }
        }

        public void VeszjelzesInditasa()
        {
            veszhivasok++;
            Console.WriteLine("RIASZTÁS! Illetéktelen nyitási kísérlet!");
        }
    }
}