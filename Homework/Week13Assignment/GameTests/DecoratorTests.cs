using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Decorators;
using Week10DesignPatternII.Models;
using Week10DesignPatternII.Models.Items;

namespace DesignPatternsIITests
{
    public class DecoratorTests
    {
        [Fact]
        public void GemTypeAttribute_IsValid_False()
        {
            //arrange
            GemTypeAttribute gemTypeAttribute = new GemTypeAttribute();
            gemTypeAttribute.ValidGems = "ruby,sapphire,emerald";
            var input = "diamond";
            //act
            var result = gemTypeAttribute.IsValid(input);
            //assert

            Assert.False(result);
        }
        [Fact]
        public void GemTypeAttribute_IsValid_True()
        {
            //arrange
            GemTypeAttribute gemTypeAttribute = new GemTypeAttribute();
            gemTypeAttribute.ValidGems = "ruby,sapphire,emerald";
            var input = "ruby";
            //act
            var result = gemTypeAttribute.IsValid(input);
            //assert

            Assert.True(result);
        }
        [Fact]
        public void NameLengthAttribute_IsValid_False()
        {
            //arrange
            NameLengthAttribute nameLengthAttribute = new NameLengthAttribute();
            nameLengthAttribute.Max = 10;
            nameLengthAttribute.Min = 1;
            var input = "12345678910";
            //act
            var result = nameLengthAttribute.IsValid(input);
            //assert

            Assert.False(result);
        }
        [Fact]
        public void NameLengthAttribute_IsValid_True()
        {
            //arrange
            NameLengthAttribute nameLengthAttribute = new NameLengthAttribute();
            nameLengthAttribute.Max = 10;
            nameLengthAttribute.Min = 1;
            var input = "123456789";
            //act
            var result = nameLengthAttribute.IsValid(input);
            //assert

            Assert.True(result);
        }
        [Fact]
        public void InventorySizeAttribute_IsValid_False()
        {
            //arrange
            InventorySizeAttribute inventorySizeAttribute = new InventorySizeAttribute();
            inventorySizeAttribute.MaxItems = 2;

            Character character = new Character();
            character.Inventory.Add(new Item("Test", "Test", 25, "test"));
            character.Inventory.Add(new Item("Test", "Test", 25, "test"));
            character.Inventory.Add(new Item("Test", "Test", 25, "test"));
            //act
            var result = inventorySizeAttribute.IsValid(character.Inventory);
            //assert

            Assert.False(result);
        }
        [Fact]
        public void InventorySizeAttribute_IsValid_True()
        {
            //arrange
            InventorySizeAttribute inventorySizeAttribute = new InventorySizeAttribute();
            inventorySizeAttribute.MaxItems = 2;

            Character character = new Character();
            character.Inventory.Add(new Item("Test", "Test", 25, "test"));
            character.Inventory.Add(new Item("Test", "Test", 25, "test"));
            //act
            var result = inventorySizeAttribute.IsValid(character.Inventory);
            //assert

            Assert.True(result);
        }
        [Fact]
        public void RequiredAttribute_IsValid_False()
        {
            //arrange
            RequiredAttribute requiredAttribute = new RequiredAttribute();
            Character character = new Character();

            //act
            var result = requiredAttribute.IsValid(character.UniformColor);

            //assert
            Assert.False(result);

        }
        [Fact]
        public void RequiredAttribute_IsValid_True()
        {
            //arrange
            RequiredAttribute requiredAttribute = new RequiredAttribute();
            Character character = new Character();
            character.UniformColor = ConsoleColor.Red;
            //act
            var result = requiredAttribute.IsValid(character.UniformColor);

            //assert
            Assert.True(result);

        }
    }
}
