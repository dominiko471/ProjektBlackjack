namespace ProjektBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ustawienie tytułu okna
            System.Console.Title = "Blackjack - Projekt Zaliczeniowy";

            // Startujemy z budżetem 500 PLN
            GraBlackjack gra = new GraBlackjack(500);

            gra.Rozpocznij();
        }
    }
}