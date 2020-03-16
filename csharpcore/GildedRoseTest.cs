using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private static void RunApp(IList<Item> items, int numberOfRuns = 1)
        {
            var app = new GildedRose(items);
            for (int i = 0; i < numberOfRuns; i++)
            {
                app.UpdateQuality();
            }
        }

        [Fact]
        public void GivenAnItemWithPositiveSellIn_TheSellInValueWillBeDecrementedBy1AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
            RunApp(Items);
            Assert.Equal(4, Items[0].SellIn);
        }

        [Fact]
        public void GivenAnItemWithPositiveSellInAndQuality_TheQualitiyValueWillBeDecrementedBy1AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 4 } };
            RunApp(Items);
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithZeroSellIn_TheSellInValueWillBeDecrementedBy1AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            RunApp(Items);
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellIn_TheSellInValueWillBeDecrementedBy1AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 0 } };
            RunApp(Items);
            Assert.Equal(-6, Items[0].SellIn);
        }

        [Fact]
        public void GivenAnItemWithZeroSellIn_TheQualityValueWillBeDecrementedBy2AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 6 } };
            RunApp(Items);
            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellIn_TheQualityValueWillBeDecrementedBy2AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 6 } };
            RunApp(Items);
            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellInAndQualityOf1_TheQualityValueWillNotDropBelowZeroAfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 1 } };
            RunApp(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithZeroQuality_TheQualitiyValueWillNotChangeAfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 0 } };
            RunApp(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithPositiveSellInAndQuality_TheQualitiyAndSellInValuesWillBeDecrementedByTwoAfterTwoUpdates()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 4 } };
            RunApp(Items, 2);
            Assert.Equal(3, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithPositiveSellInAndQuality_TheQualityWillNotDropBelowZeroAfterMultipleUpdates()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 50, Quality = 4 } };
            RunApp(Items, 5);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellInAndPositiveQuality_TheQualityWillNotDropBelowZeroAfterMultipleUpdates()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -50, Quality = 4 } };
            RunApp(Items, 3);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellInAndOddQuality_TheQualityWillNotDropBelowZeroAfterMultipleUpdates()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -50, Quality = 5 } };
            RunApp(Items, 3);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithSellInOf1_TheQualityWillCorrectlyDropBeforeAndAfterTheSellInHits0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 5 } };
            RunApp(Items, 2);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithNegativeSellInAndNonZeroQuality_TheSellInValuesWillBeDecrementedByTwoAndTheQualityByFourAfterTwoUpdates()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 4 } };
            RunApp(Items, 2);
            Assert.Equal(-7, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemWithPositiveSellInAndAnItemWithNegativeSellIn_TheQualityValueWillBeDecrementedCorrectlyForEachItemAfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item
            {
                Name = "foo", SellIn = 5, Quality = 10
            }, new Item { Name = "foo2", SellIn = -5, Quality = 10 }};
            RunApp(Items, 1);
            Assert.Equal(9, Items[0].Quality);
            Assert.Equal(8, Items[1].Quality);
        }

        [Fact]
        public void GivenAnItemCalledAgedBrie_TheQualityValueWillIncreaseAfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 6 } };
            RunApp(Items);
            Assert.Equal(7, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemCalledAgedBrieWithZeroSellIn_TheQualityValueWillIncreaseBy2AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 6 } };
            RunApp(Items);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemCalledAgedBrieWithNegativeSellIn_TheQualityValueWillIncreaseBy2AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 6 } };
            RunApp(Items);
            Assert.Equal(8, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAnItemCalledAgedBrieWithQuality50_TheQualityValueWillNotIncreaseAbove50AfterAnUpdate(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = 50 } };
            RunApp(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void GivenAnItemCalledAgedBrieWithNegativeSellInAndQuality49_TheQualityValueWillNotIncreaseAbove50AfterAnUpdate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 49 } };
            RunApp(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAnItemCalledAgedBrieWithQuality48_TheQualityValueWillNotIncreaseAbove50AfterAnRepeatingUpdates(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = 50 } };
            RunApp(Items);
            RunApp(Items);
            RunApp(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAnItemCalledSulfurasAndAnySellIn_TheSellInValueWillNeverChange(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 } };
            RunApp(Items);
            RunApp(Items);
            RunApp(Items);
            Assert.Equal(sellIn, Items[0].SellIn);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAnItemCalledSulfurasAndAnySellIn_TheQualityWillAlwaysStayAt80(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 } };
            RunApp(Items);
            RunApp(Items);
            RunApp(Items);
            Assert.Equal(80, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(99)]
        public void GivenAnItemCalledSulfurasAndAnySellIn_TheQualityAndSellInWillNoTChangeAfterMultipleUpdates(int numberOfUpdates)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -5, Quality = 80 } };
            RunApp(Items, numberOfUpdates);
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(-5, Items[0].SellIn);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(54)]
        [InlineData(99)]
        public void GivenABackStagePassItemSellInGreaterThan10_TheQualityValueWillIncreaseBy1(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(16, Items[0].Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void GivenABackStagePassItemSellInBetween5And10_TheQualityValueWillIncreaseBy2(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(17, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void GivenABackStagePassItemSellIn5DaysOrLess_TheQualityValueWillIncreaseBy3(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void GivenABackStagePassItemSellInOf0_TheQualityValueWillDropTo0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenABackStagePassItemSellInOf11_TheQualityValueWillIncreaseBy3WhenUpdatedTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 15 } };
            RunApp(Items, 2);
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void GivenABackStagePassItemSellInOf6_TheQualityValueWillIncreaseBy5WhenUpdatedTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 15 } };
            RunApp(Items, 2);
            Assert.Equal(20, Items[0].Quality);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(10)]
        [InlineData(5)]
        public void GivenABackStagePassItemWithQuality50_TheQualityValueWillNotIncrease(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 50 } };
            RunApp(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(5)]
        public void GivenABackStagePassItemWithQuality49_TheQualityValueWillNotIncreaseAbove50(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 49 } };
            RunApp(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Theory]
        [InlineData(15,1)]
        [InlineData(10,2)]
        [InlineData(5,3)] 
        public void GivenABackStagePassItemForSomethingThatIsntATAFKAL80ETCConcert_TheQualityValueWillCorrectlyIncrease(int sellIn, int expectedQualityIncrease)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a fashion show", SellIn = sellIn, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(15 + expectedQualityIncrease, Items[0].Quality);
        }

        [Theory]
        [InlineData("Potato")]
        [InlineData("Ham")]
        public void GivenAConjuredItemWithPositiveSellIn_TheQualityValueWillDecreaseBy2(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = $"Conjured {itemName}", SellIn = 5, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(13, Items[0].Quality);
        }

        [Theory]
        [InlineData("Potato")]
        [InlineData("Ham")]
        public void GivenAConjuredItemWith0SellIn_TheQualityValueWillDecreaseBy2(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = $"Conjured {itemName}", SellIn = 0, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(11, Items[0].Quality);
        }

        [Theory]
        [InlineData("Potato")]
        [InlineData("Ham")]
        public void GivenAConjuredItemWithNegativeSellIn_TheQualityValueWillDecreaseBy2(string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = $"Conjured {itemName}", SellIn = -5, Quality = 15 } };
            RunApp(Items);
            Assert.Equal(11, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAConjuredItemWithQualityZero_TheQualityWillNotDecreaseFurther(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured cheese", SellIn = sellIn, Quality = 0 } };
            RunApp(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void GivenAConjuredItemWithQualityOne_TheQualityWillNotDecreaseBelowZero(int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured cheese", SellIn = sellIn, Quality = 1 } };
            RunApp(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GivenAConjuredItemWithSellInOne_TheQualityWillDecreaseBySixAfterUpdatingTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured cheese", SellIn = 1, Quality = 15 } };
            RunApp(Items,2);
            Assert.Equal(9, Items[0].Quality);
        }
    }
}