using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseNS;
using NUnit.Framework;

namespace KataGildedRose.Tests
{
    public class GildedRoseShould
    {

        [Test]
        public void decrease_by_one_sellIn_and_Quality_on_normal_item()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal item", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(9);
            Items.First().Quality.Should().Be(9);
        }

        [Test]
        public void decrease_by_twice_Quality_when_sellDate_has_passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal item", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(8);
        }

        [Test]
        public void dont_decrease_quality_when_it_is_0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal item", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(0);
        }

        [Test]
        public void increase_quality_everyday_in_aged_brie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(9);
            Items.First().Quality.Should().Be(21);
        }

        [Test]
        public void increase_by_one_when_sellIn_goes_to_0_in_aged_brie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 45 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(0);
            Items.First().Quality.Should().Be(46);
        }

        [Test]
        public void increase_twice_quality_when_sellDate_passed_in_aged_brie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(22);
        }

        [Test]
        public void dont_increase_quality_when_it_is_50_in_aged_brie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(9);
            Items.First().Quality.Should().Be(50);
        }

        [Test]
        public void dont_change_quality_and_sellIn_when_it_is_sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(10);
            Items.First().Quality.Should().Be(80);
        }

        [Test]
        public void increase_quality_by_2_when_sellIn_is_10_or_less_in_backstage_passes()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(9);
            Items.First().Quality.Should().Be(27);
        }

        [Test]
        public void increase_quality_by_3_when_sellIn_is_5_or_less_in_backstage_passes()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 25 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(4);
            Items.First().Quality.Should().Be(28);
        }

        [Test]
        public void drop_quality_to_0_when_sellIn_is_lower_than_0_in_backstage_passes()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 45 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(0);
        }

        [Test]
        public void drop_quality_by_two_in_conjured()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 15, Quality = 45 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(14);
            Items.First().Quality.Should().Be(43);
        }

        [Test]
        public void drop_quality_by_four_when_sellIn_passed_in_conjured()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 45 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(41);
        }

        [Test]
        public void drop_quality_to_zero_when_sellIn_passed_and_quality_is_lower_than_4_in_conjured()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 3 } };
            var app = new GildedRose(Items);

            app.UpdateQuality();

            Items.First().SellIn.Should().Be(-1);
            Items.First().Quality.Should().Be(0);
        }
    }
}