namespace ProjektBlackjack
{
    public class Karta
    {
        public Kolor KolorKarty { get; set; }
        public Figura FiguraKarty { get; set; }

        public Karta(Kolor kolor, Figura figura)
        {
            KolorKarty = kolor;
            FiguraKarty = figura;
        }

        // Zwraca wartość punktową karty w Blackjacku
        public int PobierzWartosc()
        {
            // Najpierw sprawdzamy Asa. Domyślnie As to 11.
            if (FiguraKarty == Figura.As) return 11;

            int numer = (int)FiguraKarty;

            // Dopiero teraz sprawdzamy figury.
            // Walet (11), Dama (12), Król (13) mają wartość 10.
            // Ponieważ As (14) został obsłużony wyżej, ten warunek go nie "złapie".
            if (numer > 10) return 10;

            // Dla kart 2-10 zwracamy ich wartość nominalną
            return numer;
        }

        public override string ToString()
        {
            return $"{FiguraKarty} {KolorKarty}";
        }
    }
}