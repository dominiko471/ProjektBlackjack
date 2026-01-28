using System;
using System.Collections.Generic;

namespace ProjektBlackjack
{
    public class Talia
    {
        private List<Karta> karty;
        private Random random;

        public Talia()
        {
            random = new Random();
            NowaTalia();
        }

        public void NowaTalia()
        {
            karty = new List<Karta>();
            foreach (Kolor k in Enum.GetValues(typeof(Kolor)))
            {
                foreach (Figura f in Enum.GetValues(typeof(Figura)))
                {
                    karty.Add(new Karta(k, f));
                }
            }
            Tasuj();
        }

        public void Tasuj()
        {
            int n = karty.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Karta value = karty[k];
                karty[k] = karty[n];
                karty[n] = value;
            }
        }

        public Karta DobierzKarte()
        {
            if (karty.Count == 0) NowaTalia(); // Jak braknie kart, tasujemy nową

            Karta karta = karty[0];
            karty.RemoveAt(0);
            return karta;
        }
    }
}