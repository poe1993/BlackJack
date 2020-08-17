using System;
using System.Collections.Generic;
using System.Linq;


namespace Blackjack

{

    class game

    {
        static void Main(string[] args)
        {
            while (playAgain == "Yes")
            {
                StartGame();
                CreateDeck();
                StartGameLoop();
                Console.WriteLine("Would you like to play again? Yes or No?");
                PlayAgain();
            }
        }
        public List<string> Deck = new List<string>();
        static string[] playerCards = new string[11];

        static string[] dealerCards = new string[11];

        static string playerChoice = "";

        static int playerTotal = 0;

        static int cardCount = 1;

        static int dealerTotal = 0;

        static Random cardRandomizer = new Random();

        static string playAgain = "Yes";

        static void StartGame()
        {
            playerCards[0] = DealCard();
            playerCards[1] = DealCard();
            dealerCards[0] = DealCard();
            dealerCards[1] = DealCard();
            DisplayWelcomeMessage();
        }

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Game start! You were dealt the cards : {0} and {1} ", playerCards[0], playerCards[1]);
            Console.WriteLine("Your Score is {0} ", playerTotal);
            Console.WriteLine("The dealer's first card is {0}.", dealerCards[0]);
        }

        static void StartGameLoop()

        {
            do
            {
                Console.WriteLine("Would you like to Hit or Stand?");
                playerChoice = Console.ReadLine();
            }
            while (!playerChoice.Equals("Hit") && !playerChoice.Equals("Stand"));
            if (playerChoice.Equals("Hit"))
            {
                Hit();
            }
            if (playerChoice.Equals("Stand"))
            {
                if (playerTotal > dealerTotal && playerTotal <= 21)
                {
                    Console.WriteLine("You Win!");
                }
                else if (playerTotal < dealerTotal)
                {
                    Console.WriteLine("You Lost.");
                }

            }

        }

        static void Hit()
        {
            cardCount += 1;
            playerCards[cardCount] = DealCard();
            dealerCards[cardCount] = DealCard();
            Console.WriteLine("You were dealt {0}. Your hand's score is {1}. ", playerCards[cardCount], playerTotal);
            if (playerTotal.Equals(21))
            {
                Console.WriteLine("Blackjack!");
            }
            else if (playerTotal > 21)
            {
                Console.WriteLine("Busted!");
            }
            else if (playerTotal < 21)
            {
                do
                {
                    Console.WriteLine("Hit or Stand?");
                    playerChoice = Console.ReadLine();
                }
                while (!playerChoice.Equals("Hit") && !playerChoice.Equals("Stand"));
                if (playerChoice == "Hit")
                {
                    Hit();
                }
                if (playerChoice == "Stand")
                {
                    dealerCards[2] = DealCard();
                    Console.WriteLine("The dealer was dealt: {0}.", dealerCards[2]);
                }
                if (dealerTotal < 17)
                {
                    dealerCards[4] = DealCard();
                }
                else if (playerTotal <= dealerTotal)
                {
                    Console.WriteLine("House Wins.");
                }
                else if (dealerTotal > 21)
                {
                    Console.WriteLine("House busted! You Win!");
                }
                else if (playerTotal > dealerTotal && playerTotal <= 21)
                {
                    Console.WriteLine("You Win!");
                }


            }
        }
        public void CreateDeck()
        {
            List<string> values = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            List<string> suits = new List<string>()
        { "Spades", "Diamonds", "Hearts","Clubs"};

            foreach (string value in values)
            {
                foreach (string suit in suits)
                {
                    Deck.Add($"{value} of {suit}");
                }
                int n = Deck.Count;
                for (int rightIndex = n - 1; rightIndex > 1; rightIndex--)
                {


                    int leftIndex = cardRandomizer.Next(rightIndex);
                    var leftCard = Deck[rightIndex];
                    var rightCard = Deck[leftIndex];
                    Deck[rightIndex] = rightCard;
                    Deck[leftIndex] = leftCard;

                }
            }
        }

        public int DealCard()
        {
            int value = 0;
            int randomCard = cardRandomizer.Next(Deck.Count);
            string card = Deck[randomCard];
            Deck.RemoveAt(randomCard);
            if (card[0] == '2' || card[0] == '3' || card[0] == '4' || card[0] == '5' ||
                card[0] == '6' || card[0] == '7' || card[0] == '8' || card[0] == '9')
            {
                value = int.Parse(card[0].ToString());
            }

            else if (card[0] == '1' || card[0] == 'J' || card[0] == 'Q' || card[0] == 'K')
            {
                value = 10;
            }

            else if (card[0] == 'A')
            {
                value = 11;
            }
            return value;

        }

        static void PlayAgain()
        {
            do
            {
                playAgain = Console.ReadLine();

            }
            while (!playAgain.Equals("Yes") && !playAgain.Equals("No"));
            if (playAgain.Equals("Yes"))
            {
                Console.WriteLine("Press enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                cardCount = 1;
                playerTotal = 0;
            }
            else if (playAgain.Equals("No"))
            {
                return;
            }
        }
    }
}






