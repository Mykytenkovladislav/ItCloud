using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21game
{
    struct Cards
    {
        public string Name;
        public Face Face;
        public int Value;
        public Cards(string Name, Face Face, int Value)
        {
            this.Name = Name;
            this.Face = Face;
            this.Value = Value;
        }
    }
    enum Face
    {
        Heart,
        Diamond,
        Spade,
        Club
    }
    class Program
    {
        static public string CardValue(int value)
        {
            switch (value)
            {
                case 2:
                    return ("Jack");
                case 3:
                    return ("Lady");
                case 4:
                    return ("King");
                case 6:
                    return ("Six");
                case 7:
                    return ("Seven");
                case 8:
                    return ("Eight");
                case 9:
                    return ("Nine");
                case 10:
                    return ("Ten");
                case 11:
                    return ("Ace");
                default:
                    return ("empty");
            }
        }

        public static List<Cards> ComCards = new List<Cards>();
        public static List<Cards> PlayerCards = new List<Cards>();
        public static List<int> RandN = new List<int>();
        private static int PlayerScore = 0;
        private static int ComScore = 0;

        static void Main(string[] args)
        {
            int[] WinCount = new int[2];
            string YesNo = "";
            do
            {
                Console.WriteLine("Вы хотите взять карту первым? Да/Нет");
                string yn = Console.ReadLine();
                if (yn == "Да")
                {
                    WinCount = StartExec();
                }
                if (yn == "Нет")
                {
                    WinCount = StartExec();
                }

                Console.WriteLine("Ещё одну?(Да/Нет)");
                YesNo = Console.ReadLine();

            } while (YesNo == "Да" || YesNo == "да");
            Console.WriteLine("Ваши очки: {0}", WinCount[0]);
            Console.WriteLine("Очки соперника: {0}", WinCount[1]);
            Console.ReadLine();
        }

        static public int[] StartExec()
        {
            Cards card;
            int[] WinPoints = new int[2];
            PlayerCards.Add(CardsDeck(Randomizer()));
            PlayerCards.Add(CardsDeck(Randomizer()));
            Console.WriteLine($"Вытянутые карты: {CardOutput(PlayerCards[0])} и {CardOutput(PlayerCards[1])}");
            PlayerScore = PlayerCards[0].Value + PlayerCards[1].Value;
            ComCards.Add(CardsDeck(Randomizer()));
            ComCards.Add(CardsDeck(Randomizer()));
            ComScore = ComCards[0].Value + ComCards[1].Value;
            FromFirst2Win(PlayerScore);
            FromFirst2Win(ComScore);
            if (PlayerScore != 22)
            {
                Console.WriteLine("Вы хотите взять карту? Да/Нет");
                string yesorno = Console.ReadLine();
                if (yesorno == "Да")
                {

                    for (string YesOrNo = ""; YesOrNo != "Нет";)
                    {
                        card = CardsDeck(Randomizer());
                        PlayerCards.Add(card);
                        PlayerScore += card.Value;
                        if (PlayerScore == 21)
                        {
                            break;
                        }
                        Console.WriteLine($"Вытянутая карта:{CardOutput(card)}");
                        Console.WriteLine("Ваша рука:");
                        for (int i = 0; i < PlayerCards.Count; i++)
                        {
                            Console.WriteLine(CardOutput(PlayerCards[i]) + " ");
                        }
                        Console.WriteLine("Вы хотите взять карту? Да/Нет");
                        YesOrNo = Console.ReadLine();
                    }
                }
                if (PlayerScore == 21)
                {
                    Console.WriteLine("Вы набрали 21! Это досрочная победа!");
                    return WinPoints;
                }
                else
                {
                    for (; ComScore < 16;)
                    {
                        card = CardsDeck(Randomizer());
                        ComCards.Add(card);
                        ComScore += card.Value;
                    }
                    if (ComScore == 21)
                    {
                        Console.WriteLine("Соперник заработал 21! Досрочная победа противника!");
                        ResultsOutput(PlayerCards, ComCards, PlayerScore, ComScore);
                        WinPoints[1] += 1;
                        return WinPoints;
                    }
                    Console.WriteLine("Раунд окончен. Результаты:");
                    if (PlayerScore < 21 && PlayerScore > ComScore)
                    {
                        Console.WriteLine("You are Winner, DUDE!!!");
                        WinPoints[0] = WinPoints[0] + 1;
                    }
                    if (PlayerScore < 21 && ComScore < 21 && PlayerScore < ComScore)
                    {
                        Console.WriteLine("Вы проиграли!");
                        WinPoints[1] = WinPoints[1] + 1;
                    }
                    if (PlayerScore < 21 && ComScore > 21 && PlayerScore < ComScore)
                    {
                        Console.WriteLine("You are Winner, DUDE!!!");
                        WinPoints[0] = WinPoints[0] + 1;
                    }
                    if (PlayerScore > 21 && ComScore > 21 && PlayerScore < ComScore)
                    {
                        Console.WriteLine("You are Winner, DUDE!!!");
                        WinPoints[0] = WinPoints[0] + 1;
                    }
                    if (PlayerScore > 21 && PlayerScore > ComScore)
                    {
                        Console.WriteLine("Вы проиграли!");
                        WinPoints[1] = WinPoints[1] + 1;
                    }
                    ResultsOutput(PlayerCards, ComCards, PlayerScore, ComScore);
                }
            }
            return WinPoints;
        }

        private static void ResultsOutput(List<Cards> playerCards, List<Cards> comCards, int playerScore, int comScore)
        {
            Console.WriteLine("Ваши карты: ");
            for (int i = 0; i < PlayerCards.Count; i++)
            {
                CardOutput(PlayerCards[i]);
            }
            Console.WriteLine("Ваш счёт очки: " + playerScore);
            Console.WriteLine("Карты противника: ");
            for (int i = 0; i < ComCards.Count; i++)
            {
                CardOutput(ComCards[i]);
            }
            Console.WriteLine("Счёт противника: " + ComScore);
        }

        private static void FromFirst2Win(int Score)
        {
            if (Score == 22)
            {
                Console.WriteLine("Досрочная победа с первых карт! Два туза!");
                ResultsOutput(PlayerCards, ComCards, PlayerScore, ComScore);
            }
            if (Score == 21)
            {
                Console.WriteLine("21! Досрочная победа с первых карт!");
                ResultsOutput(PlayerCards, ComCards, PlayerScore, ComScore);
            }
        }

        static public string CardOutput(Cards value)
        {
            Console.Write(value.Name);
            Console.WriteLine(" " + value.Face);
            return value.Name;
        }

        static public Cards CardsDeck(int A)
        {

            Cards[] CardsDeck = new Cards[35];
            int b = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 12; j++)
                {
                    if (j == 5)
                        continue;
                    if (i == 3 && j == 11)
                        continue;
                    CardsDeck[b] = new Cards(CardValue(j), (Face)i, j);
                    b++;
                }
            }
            return CardsDeck[A];
        }
        static public int Randomizer()
        {
            Random random = new Random();
            int Random = random.Next(35);
            for (int i = 0; i < RandN.Count; i++)
            {
                if (Random == RandN[i])
                {
                    i = 0;
                    Random = random.Next(35);
                    continue;
                }
            }
            RandN.Add(Random);
            return Random;
        }
    }

}
