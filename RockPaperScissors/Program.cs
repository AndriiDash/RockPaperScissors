namespace RockPaperScissors;

class Program
{
    static void Main(string[] args)
    {
        int roundsAmount;
        int score;
        string computerAI;
        Intro();
        string player = GetValidName();
        Console.WriteLine($"Nice to have you here: {player}!  One more step to proceed.");
        CheckAge();
    }

    static void Intro()
    {
        Console.WriteLine("@@@@ Welcome to Rock Paper Scissors @@@@");
        Console.WriteLine("           !!!Attention!!! ");
        Console.WriteLine(" This game is only for 13-99 y.o players.");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Please enter your nickname: ");
    }

    static string GetValidName()
    {
        string nickname;
        do
        {

            nickname = (Console.ReadLine());
            if (string.IsNullOrWhiteSpace(nickname))
            {
                Console.WriteLine("Name cannot be empty! Try again.");
            }
            else if (!nickname.All(char.IsLetter))
            {
                Console.WriteLine("The name must contain only letters. Try again");
            }
        } while (string.IsNullOrWhiteSpace(nickname) || !nickname.All(char.IsLetter));
        return nickname;
    }
    
    
    static int CheckAge()
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

            if (age < 12 || age > 99)
            {
                Console.WriteLine("Age must be between 12 and 99. Try again.");
            }
        } while (age < 12 || age > 99);

        Console.WriteLine("User indentification complete!.");
        return age;
    }
}