using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Week10DesignPatternII.Models.Items;

namespace DesignPatternsIITests
{
    public class ItemTests
    {
        [Theory]
        [InlineData("Test Boot", "Description", 25, "boot")]
        [InlineData("Test Vest", "Description", -25, "vest")]
        [InlineData("Test Suit", "Description", 50, "suit")]
        public void Item_DisplayOutputString_Equal(string name, string description, int statChange, string type)
        {
            //arrange
            var expected = $"\nName: {name}\n\nDescription: {description}\n";
            Item item = new Item(name, description, statChange, type);
            item.Name = name;
            item.Description = description;
            //act
            var result = item.Display();
            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Item_ConstructorSetName_Equal()
        {
            //arrange
            var expected = "Boot";
            //act
            Item item = new Item(expected, "Description", 20, "Type");
            //assert
            Assert.Equal(expected, item.Name);
        }

        [Fact]
        public void Item_ConstructorSetDescription_Equal()
        {
            //arrange
            var expected = "Description";
            //act
            Item item = new Item("Name", expected, 20, "Type");
            //assert
            Assert.Equal(expected, item.Description);
        }

        [Fact]
        public void Item_ConstructorSetStat_Equal()
        {
            //arrange
            var expected = 20;
            //act
            Item item = new Item("Name", "Description", expected, "Type");
            //assert
            Assert.Equal(expected, item.StatChange);
        }
        [Fact]
        public void Item_ConstructorSetType_Equal()
        {
            //arrange
            var expected = "Type";
            //act
            Item item = new Item("Name", "Description", 20, expected);
            //assert
            Assert.Equal(expected, item.Type);
        }
    }
}
