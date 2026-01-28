using System.Collections.Generic;

namespace ProjektBlackjack
{
    // TO JEST TWOJA KLASA ABSTRAKCYJNA
    public abstract class Uczestnik
    {
        // Właściwość jest dziedziczona
        public List<Karta> Karty { get; protected set; }

        public Uczestnik()
        {
            Karty = new List<Karta>();
        }

        public void DodajKarte(Karta karta)
        {
            Karty.Add(karta);
        }

        public void Wyczysc()
        {
            Karty.Clear();
        }

        // Metoda wirtualna - logika liczenia jest ta sama dla wszystkich,
        // ale pozwalamy na nadpisanie jej w przyszłości (dlatego virtual)
        public virtual int ObliczPunkty()
        {
            int suma = 0;
            int liczbaAsow = 0;

            foreach (var karta in Karty)
            {
                suma += karta.PobierzWartosc();
                if (karta.FiguraKarty == Figura.As) liczbaAsow++;
            }

            while (suma > 21 && liczbaAsow > 0)
            {
                suma -= 10;
                liczbaAsow--;
            }

            return suma;
        }

        // Metoda abstrakcyjna - wymuszamy na klasach pochodnych,
        // aby zdefiniowały, jak chcą się pokazać.
        public abstract void PokazKarty(string wlasciciel, bool ukryjPierwsza = false);
    }
}