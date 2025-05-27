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
        Showstatistics(player, age, roundsPlayed, wins);
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
                Console.WriteLine("You chose not to play. Type 'Exit' to close the game.");
            string exitInput = Console.ReadLine()?.Trim(); 
            if (exitInput?.ToLower() == "exit")
                Environment.Exit(0);
            else
                Console.WriteLine("Press enter Y(yes) or N(no) ");
        } while (true);
    }
// Information about each weapon player can choose
    private static void WeaponsIntro()
    {
        Console.WriteLine("Please choose 0 of 2 weapons: ");
        Console.WriteLine("1.Rock");
        Console.WriteLine("2.Paper");
        Console.WriteLine("3.Scissors");
    }
    
    //Player is choosing the weapon to play agains AI
    private static Weapons ChooseWeapon()
    {
        int choice;
        do
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid choice. Try again. Please enter a number from 1 to 3.");
                continue;
            }

            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please choose 1, 2, or 3");
                continue;
            }

            Console.WriteLine($"You chose:{(Weapons)choice}");
            return (Weapons)choice;
        } while (true);
    }

    private static void DetermineRound(Weapons playerChoice, Weapons aiChoice)
        {
            if (playerChoice == aiChoice)
            {
                Console.WriteLine($"Draw! You both chose {playerChoice}.");
            }
            else if ((playerChoice == Weapons.Rock && aiChoice == Weapons.Scissors) ||
                     (playerChoice == Weapons.Scissors && aiChoice == Weapons.Paper) ||
                     (playerChoice == Weapons.Paper && aiChoice == Weapons.Rock))
            {
                Console.WriteLine($"{playerChoice} beats {aiChoice} — You win!");
            }
            else
            {
                Console.WriteLine($"{aiChoice} beats {playerChoice} — AI wins!");
            }
        }
    // Play a 3 battle between player and AI, print result and random encouragement
    private static (int playerWins, int aiWins) PlayBattle()
    {
        int playerWins = 0;
        int aiWins = 0;
        int totalRounds = 3;

        for (int i = 1; i <= totalRounds; i++)
        {
            Console.WriteLine($"\nRound {i}:");
            WeaponsIntro();
            Weapons playerChoice = ChooseWeapon();
            Weapons aiChoice = (Weapons)new Random().Next(1, 4);
            DetermineRound(playerChoice, aiChoice);

            if (playerChoice == aiChoice)
            {
                continue;
            }
            else if ((playerChoice == Weapons.Rock && aiChoice == Weapons.Scissors) ||
                     (playerChoice == Weapons.Scissors && aiChoice == Weapons.Paper) ||
                     (playerChoice == Weapons.Paper && aiChoice == Weapons.Rock))
            {
                playerWins++;
            }
            else
            {
                aiWins++;
            }
        }

        Console.WriteLine("\n==== Battle Result ====");

        if ((playerWins == 2 && aiWins == 1) || (playerWins == 3))
        {
            Console.WriteLine("You won the battle!");
            PrintRandomMessage(true);
        }
        else
        {
            Console.WriteLine("You lost the battle.");
            PrintRandomMessage(false);
        }
        return (playerWins, aiWins);
    }

    // Print a random encouragement message depending on whether the player won
    private static void PrintRandomMessage(bool playerWon)
    {
        string[] praise = { "Great job!", "You're a champion!", "That was amazing!" };
        string[] encouragement = { "Don't give up!", "You’ll get it next time!", "Keep trying!" };

        Random rand = new Random();
        if (playerWon)
        {
            Console.WriteLine(praise[rand.Next(praise.Length)]);
        }
        else
        {
            Console.WriteLine(encouragement[rand.Next(encouragement.Length)]);
        }
    }

    private static void Showstatistics(string player, int age, int roundsPlayed, int wins)
        {
            do
            {
                Console.WriteLine("======================================");
                UserStatistics(player, age, roundsPlayed, wins);

                if (!ReadyOr())
                    break;

                var result = PlayBattle();
                roundsPlayed += 3;
                wins += result.playerWins;
            }
            while (true);
        }
    }

