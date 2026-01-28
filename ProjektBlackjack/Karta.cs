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
            // Walet, Dama, Król mają wartość 10.
            if (numer > 10) return 10;

            return numer;
        }

        public override string ToString()
        {
            return $"{FiguraKarty} {KolorKarty}";
        }
    }
}