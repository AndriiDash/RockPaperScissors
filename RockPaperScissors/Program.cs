namespace RockPaperScissors;

internal class Program
{
    private static void Main(string[] args)
    {
        string computerAI;
        int roundsPlayed = 0;
        int wins = 0;
        Intro();
        string player = GetValidName();
        Console.WriteLine($"Nice to have you here: {player}!  One more step to proceed.");
        int age = CheckAge();
        UserStatistics(player, age, roundsPlayed, wins);
        Console.WriteLine("======================================");
        ReadyOr();
    }
// Introduction text for the player when open the game project
    private static void Intro()
    {
        Console.WriteLine("@@@@ Welcome to Rock Paper Scissors @@@@");
        Console.WriteLine("           !!!Attention!!! ");
        Console.WriteLine(" This game is only for 13-99 y.o players.");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Please enter your nickname: ");
    }
    //Checking players nickname
    private static string GetValidName()
    {
        string nickname;
        do
        {
            nickname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nickname))
                Console.WriteLine("Name cannot be empty! Try again.");
            else if (!nickname.All(char.IsLetter)) Console.WriteLine("The name must contain only letters. Try again");
        } while (string.IsNullOrWhiteSpace(nickname) || !nickname.All(char.IsLetter));

        return nickname;
    }

    //Checking players age
    private static int CheckAge()
    {
        int age;
        do
        {
            Console.WriteLine("Please enter your age: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out age))
            {
                Console.WriteLine("Sorry, you are unable to play.");
                Console.WriteLine("The minimal age is 12 years old ");
                continue;
            }

            if (age < 12 || age > 99) Console.WriteLine("Age must be between 12 and 99. Try again.");
        } while (age < 12 || age > 99);

        Console.WriteLine("User indentification complete!.");
        return age;
    }

    //Shows general statistic about the player, nickname, age, rounds with amount of victories
    private static void UserStatistics(string nickname, int age, int rounds, int wins)
    {
        Console.WriteLine("Your statistics for game session:");
        Console.WriteLine($"Your nickname: {nickname}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Rounds played: {rounds}");
        Console.WriteLine($"Victories: {wins}");
    }
    // Check if player is ready or not to start the game
    private static bool ReadyOr()
    {
        string input;
        do
        {
            Console.WriteLine("Are you ready start the game? Y/N: ");
            input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "Y")
                return true;
            else if (input == "N")
                return false;
            else 
                Console.WriteLine("Press enter Y(yes) or N(no) ");
        } while (true);
    }

}
