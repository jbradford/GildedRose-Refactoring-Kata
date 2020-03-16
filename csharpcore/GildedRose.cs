using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                item.SellIn = item.SellIn - 1;

                int qualityChange = -1;

                if (item.Name.StartsWith("Backstage passes"))
                {
                    if (item.SellIn >= 10)
                    {
                        qualityChange = 1;
                    }
                    else if (item.SellIn >= 5)
                    {
                        qualityChange = 2;
                    }
                    else if (item.SellIn >= 0)
                    {
                        qualityChange = 3;
                    }
                    else
                    {
                        qualityChange = -1 * item.Quality;
                    }
                }
                else
                {
                    if (item.SellIn < 0)
                    {
                        qualityChange = -2;
                    }

                    if (item.Name.StartsWith("Conjured"))
                    {
                        qualityChange *= 2;
                    }

                    if (item.Name == "Aged Brie")
                    {
                        qualityChange *= -1;
                    }
                }

                item.Quality += qualityChange;

                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}