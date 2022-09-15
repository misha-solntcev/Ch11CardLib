using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Deck : ICloneable
    {
        public object Clone()
        {
            Deck newDesc = new Deck(cards.Clone() as Cards);
            return newDesc;
        }
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        private Cards cards = new Cards();
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        public Deck(bool isAceHigh) : this() // Конструктор тузы старшие.
        {
            Card.isAceHigh = isAceHigh;
        }
        public Deck(bool useTrumps, Suit trump) : this() // Конструктор с козырями.
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this() // Конструктор тузы старше и с козырями.
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                    "Value must be between 0 and 51."));
        }
        public void Shuffle()
        {
            Cards newDesc = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourseCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourseCard = sourceGen.Next(52);
                    if (assigned[sourseCard] == false)
                        foundCard = true;
                }
                assigned[sourseCard] = true;
                newDesc.Add(cards[sourseCard]);
            }
            newDesc.CopyTo(cards);
        }
    }
}
