using System;

namespace ProjektBlackjack
{
    // Reka dziedziczy po klasie abstrakcyjnej Uczestnik
    public class Reka : Uczestnik
    {
        public Reka() : base() // Wywołanie konstruktora bazowego (inicjalizacja listy)
        {
        }

        // Nadpisujemy metodę abstrakcyjną (obowiązkowe!)
        public override void PokazKarty(string wlasciciel, bool ukryjPierwsza = false)
        {
            Console.WriteLine($"--- Ręka: {wlasciciel} ---");

            // Korzystamy z 'Karty' i 'ObliczPunkty()', które mamy dzięki dziedziczeniu
            if (ukryjPierwsza && Karty.Count > 0)
            {
                Console.WriteLine(" [Karta Zakryta]");
                for (int i = 1; i < Karty.Count; i++)
                    Console.WriteLine($" {Karty[i]}");
            }
            else
            {
                foreach (var k in Karty) Console.WriteLine($" {k}");
                Console.WriteLine($" SUMA: {ObliczPunkty()}");
            }
            Console.WriteLine();
        }
    }
}