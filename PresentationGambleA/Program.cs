namespace PresentationGambleA;

public class Slots
{
    static void Main()
    {
        Random random = new Random();
        int balance = 100; // Startsaldo van de speler
        string[] symbols = { "🍒", "🍋", "🍊", "⭐", "💎" };

        Console.WriteLine("Welkom bij de Slot Machine!");
        Console.WriteLine($"Je begint met ${balance}.\n");

        while (balance > 0)
        {
            Console.WriteLine($"Huidig saldo: ${balance}");
            Console.Write("Voer je inzet in (of 0 om te stoppen): ");
            int bet;
            if (!int.TryParse(Console.ReadLine(), out bet) || bet < 0)
            {
                Console.WriteLine("Ongeldige inzet, probeer opnieuw.");
                continue;
            }

            if (bet == 0)
            {
                Console.WriteLine("Bedankt voor het spelen!");
                break;
            }

            if (bet > balance)
            {
                Console.WriteLine("Je hebt niet genoeg saldo!");
                continue;
            }

            // Ronde draaien
            string[] result = new string[3];
            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(symbols.Length);
                result[i] = symbols[index];
            }

            Console.WriteLine($"🎰 | {result[0]} | {result[1]} | {result[2]} | 🎰");

            // Wincheck
            if (result[0] == result[1] && result[1] == result[2])
            {
                int winAmount = bet * 5;
                balance += winAmount;
                Console.WriteLine($"Jackpot! Je wint ${winAmount}!");
            }
            else if (result[0] == result[1] || result[1] == result[2] || result[0] == result[2])
            {
                int winAmount = bet * 2;
                balance += winAmount;
                Console.WriteLine($"Goed gedaan! Je wint ${winAmount}!");
            }
            else
            {
                balance -= bet;
                Console.WriteLine("Helaas, je verliest deze ronde.");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Spel beëindigd. Eindsaldo: $" + balance);
    }
}

}
