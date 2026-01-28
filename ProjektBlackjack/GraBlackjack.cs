using System;

namespace ProjektBlackjack
{
    public class GraBlackjack
    {
        private Talia talia;
        private Reka gracz;
        private Reka krupier;
        private decimal portfel;

        public GraBlackjack(decimal poczatkoweFundusze)
        {
            portfel = poczatkoweFundusze;
            talia = new Talia();
            gracz = new Reka();
            krupier = new Reka();
        }

        public void Rozpocznij()
        {
            Console.WriteLine("Witaj w kasynie Blackjack!");

            while (portfel > 0)
            {
                Console.WriteLine($"\nTwoje środki: {portfel} PLN");
                decimal stawka = PobierzStawke();

                GrajRunde(stawka);

                if (portfel <= 0)
                {
                    Console.WriteLine("\nPrzegrałeś wszystkie pieniądze! Koniec gry.");
                    break;
                }

                Console.WriteLine("Naciśnij dowolny klawisz, aby zagrać kolejną rundę...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private decimal PobierzStawke()
        {
            while (true)
            {
                Console.Write("Podaj stawkę zakładu: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal stawka) && stawka > 0 && stawka <= portfel)
                {
                    return stawka;
                }
                Console.WriteLine("Błędna stawka! Masz za mało środków lub wpisałeś złą liczbę.");
            }
        }

        private void GrajRunde(decimal stawka)
        {
            gracz.Wyczysc();
            krupier.Wyczysc();

            // Rozdanie początkowe
            gracz.DodajKarte(talia.DobierzKarte());
            krupier.DodajKarte(talia.DobierzKarte());
            gracz.DodajKarte(talia.DobierzKarte());
            krupier.DodajKarte(talia.DobierzKarte());

            // Wyświetlenie stanu
            krupier.PokazKarty("Krupier", ukryjPierwsza: true);
            gracz.PokazKarty("Gracz");

            // Sprawdzenie Blackjacka na start (21 pkt z 2 kart)
            if (gracz.ObliczPunkty() == 21)
            {
                Console.WriteLine("BLACKJACK! Wygrywasz 1.5x stawki!");
                portfel += stawka * 1.5m;
                return;
            }

            // Tura Gracza
            while (gracz.ObliczPunkty() < 21)
            {
                Console.Write("Decyzja: (D)obierz czy (P)asuj? ");
                string decyzja = Console.ReadLine().ToUpper();

                if (decyzja == "D")
                {
                    Karta nowa = talia.DobierzKarte();
                    Console.WriteLine($"Dobrałeś: {nowa}");
                    gracz.DodajKarte(nowa);
                    Console.WriteLine($"Twoje punkty: {gracz.ObliczPunkty()}");
                }
                else if (decyzja == "P")
                {
                    break;
                }
            }

            int punktyGracza = gracz.ObliczPunkty();

            if (punktyGracza > 21)
            {
                Console.WriteLine("FURA (Bust)! Przekroczyłeś 21. Przegrywasz zakład.");
                portfel -= stawka;
                return;
            }

            // Tura Krupiera (Musi dobierać do 17)
            Console.WriteLine("\n--- Tura Krupiera ---");
            krupier.PokazKarty("Krupier", ukryjPierwsza: false);

            while (krupier.ObliczPunkty() < 17)
            {
                Console.WriteLine("Krupier dobiera...");
                System.Threading.Thread.Sleep(1000);
                krupier.DodajKarte(talia.DobierzKarte());
                krupier.PokazKarty("Krupier");
            }

            // Rozstrzygnięcie
            int punktyKrupiera = krupier.ObliczPunkty();
            Console.WriteLine($"\nWYNIK: Ty: {punktyGracza} vs Krupier: {punktyKrupiera}");

            if (punktyKrupiera > 21 || punktyGracza > punktyKrupiera)
            {
                Console.WriteLine("WYGRYWASZ!");
                portfel += stawka;
            }
            else if (punktyGracza < punktyKrupiera)
            {
                Console.WriteLine("PRZEGRYWASZ.");
                portfel -= stawka;
            }
            else
            {
                Console.WriteLine("REMIS (Push). Odzyskujesz stawkę.");
            }
        }
    }
}