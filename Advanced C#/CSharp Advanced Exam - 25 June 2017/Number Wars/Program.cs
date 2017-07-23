using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Wars
{
    class Card
    {
        public int num { get; set; }
        public int ch { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<Card> player1 = ParseCards();
            Queue<Card> player2 = ParseCards();

            player1.Enqueue(player2.Dequeue());

            bool gameEnd = false;
            string winnerName = string.Empty;
            int turns = 0;

            //turn
            do
            {
                Queue<Card> field = new Queue<Card>();

                // put cards on field
                int p1 = player1.Peek().num;
                int p2 = player2.Peek().num;

                field.Enqueue(player1.Dequeue());
                field.Enqueue(player2.Dequeue());

                if (p1 != p2)
                {
                    if (p1 > p2)
                    {
                        WinnerTakeCards(field, player1);
                    }
                    else
                    {
                        WinnerTakeCards(field, player2);
                    }
                }
                else //war
                {
                    int warSumP1 = 0;
                    int warSumP2 = 0;
                    bool winner = false;

                    do
                    {
                        // TODO: check for less than 3 cards
                        if (player2.Count < 3 || player1.Count < 3)
                        {
                            if (player2.Count < player1.Count)
                            {
                                gameEnd = true;
                                winnerName = "First player wins";
                                break;
                            }
                            else if (player1.Count < player2.Count)
                            {
                                gameEnd = true;
                                winnerName = "Second player wins";
                                break;
                            }
                        }


                        // put 3 more cards
                        for (int i = 0; i < 3; i++)
                        {
                            if (player1.Any())
                            {
                                warSumP1 += player1.Peek().ch;
                                warSumP2 += player2.Peek().ch;

                                field.Enqueue(player1.Dequeue());
                                field.Enqueue(player2.Dequeue());
                            }
                        }

                        //check for winner
                        if (warSumP1 != warSumP2)
                        {
                            //p1 wins
                            if (warSumP1 > warSumP2)
                            {
                                WinnerTakeCards(field, player1);
                            }
                            else // p2 wins
                            {
                                WinnerTakeCards(field, player2);
                            }
                            winner = true;
                        }

                    } while (!winner && player1.Any() && player2.Any());
                }

                //game end?

                if (!gameEnd)
                {
                    if (!player1.Any() && !player2.Any())
                    {
                        gameEnd = true;
                        winnerName = "Draw";
                    }
                    else if (!player2.Any())
                    {
                        gameEnd = true;
                        winnerName = "First player wins";
                    }
                    else if (!player1.Any())
                    {
                        gameEnd = true;
                        winnerName = "Second player wins";
                    }

                    turns++;
                    if (turns > 1000000)
                    {
                        gameEnd = true;
                        winnerName = "adadadfadfadfaf";
                    }
                }

            } while (!gameEnd);

            Console.WriteLine($"{winnerName} after {turns} turns");
        }

        private static void WinnerTakeCards(Queue<Card> field, Queue<Card> winningPlayer)
        {
            foreach (var card in field.OrderByDescending(x => x.num).ThenByDescending(x => x.ch))
            {
                winningPlayer.Enqueue(card);
            }
            field.Clear();
        }

        private static Queue<Card> ParseCards()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<Card> cards = new Queue<Card>();
            foreach (var card in input)
            {
                cards.Enqueue(ParseCard(card));
            }
            return cards;
        }

        private static Card ParseCard(string card)
        {
            Card parsedCard = new Card();

            parsedCard.ch = card[card.Length - 1] - 'a' + 1;
            parsedCard.num = int.Parse(card.Remove(card.Length - 1));

            return parsedCard;
        }
    }
}