using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Cards : CollectionBase, ICloneable
    {
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourseCard in List)
            {
                newCards.Add(sourseCard.Clone() as Card);
            }
            return newCards;
        }
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }
        public Cards()
        {

        }
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }

        // Вспомогательный метод
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        // Проверка
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }
    }
}