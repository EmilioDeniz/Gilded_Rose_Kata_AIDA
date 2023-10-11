using System;
using System.Collections.Generic;

namespace GildedRoseNS
{
    public class GildedRose
    {
        public IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {

            foreach (Item item in Items)
            {
                if (!isSulfuras(item.Name))
                {
                    item.SellIn = item.SellIn - 1;

                    if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        decreaseQuality(item, 1);
                    }
                    else
                    {
                        increaseQuality(item, 1);

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn <= 10)
                            {
                                increaseQuality(item, 1);   
                                if (item.SellIn <= 5)
                                {
                                    increaseQuality(item,1);
                                }
                            }
                        }
                    }

                    if (item.SellIn < 0)
                    {
                        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            decreaseQuality(item, 1);
                        }
                        else
                        {
                            if (item.Name == "Backstage passes to a TAFKAL80ETC concert") { decreaseQuality(item, item.Quality); }
                            else if (item.Name == "Aged Brie") { increaseQuality(item, 1); }
                        }
                    }
                }
            }
        }

        private bool isSulfuras(string name)
        {
            if (name == "Sulfuras, Hand of Ragnaros") { return true; }
            return false;
        }

        private void decreaseQuality(Item item, int ammount)
        {
            if (item.Quality > 0)
            {
                item.Quality -= ammount;
            }
        }

        private void increaseQuality(Item item, int ammount)
        {
            if (item.Quality < 50)
            {
                item.Quality += ammount;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}