using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns;
using Week8AssignmentDesignPatterns.Enums;
using Week8AssignmentDesignPatterns.Models;
using Week8AssignmentDesignPatterns.Models.Item;

namespace DesignPatternTests
{
    public class ItemTests
    {
        [Theory]
        [InlineData(ItemType.EYEBALL, typeof(Eyeball))]
        [InlineData(ItemType.POTION, typeof(Potion))]
        [InlineData(ItemType.KEY, typeof(Key))]
        public void ItemFactory_CreateItem_ReceiveProperObject(ItemType type, Type expected)
        {
            //arrange
            var Name = "Test";
            var Desc = "Desc Test";

            //act
            var result = ItemFactory.CreateItem(Name, Desc, type);

            //assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void Eyeball_Constructor_NotNull()
        {
            //arrange 

            //act
            var result = new Eyeball();

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Potion_Constructor_NotNull()
        {
            //arrange 

            //act
            var result = new Potion();

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Key_Constructor_NotNull()
        {
            //arrange 

            //act
            var result = new Key();

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void PotionReceiver_SetNextReceiver_NotNull()
        {
            //arrange
            var receiver = new PotionReceiver();
            var nextReceiver = new EyeballReceiver();

            var expected = typeof(EyeballReceiver);
            //act
            receiver.SetNextReceiver(nextReceiver);
            //assert
            Assert.IsType(expected, receiver.nextReceiver);
        }

        [Fact]
        public void PotionReceiver_ProcessRequestProperItem_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new PotionReceiver();
            var nextReceiver = new EyeballReceiver();
            IItem item = ItemFactory.CreateItem("Red Potion", "Description", ItemType.POTION);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item, player.Inventory);
        }

        [Fact]
        public void PotionReceiver_ProcessRequestNextReciever_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new EyeballReceiver();
            var nextReceiver = new PotionReceiver();
            IItem item = ItemFactory.CreateItem("Red Potion", "Description", ItemType.POTION);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item, player.Inventory);
        }

        [Fact]
        public void PotionReceiver_ProcessRequestExecption_Exception()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new PotionReceiver();
            IItem item = ItemFactory.CreateItem("Red Key", "Description", ItemType.KEY);

            //act

            //assert
            Assert.Throws<ArgumentException>(()=> receiver.ProcessRequest(item));
        }

        [Fact]
        public void EyeballReceiver_SetNextReceiver_NotNull()
        {
            //arrange
            var receiver = new EyeballReceiver();
            var nextReceiver = new EyeballReceiver();

            var expected = typeof(EyeballReceiver);
            //act
            receiver.SetNextReceiver(nextReceiver);
            //assert
            Assert.IsType(expected, receiver.nextReceiver);
        }

        [Fact]
        public void EyeballReceiver_ProcessRequestProperItem_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new EyeballReceiver();
            var nextReceiver = new KeyReceiver();
            IItem item = ItemFactory.CreateItem("Human Eyeball", "Description", ItemType.EYEBALL);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item,player.Inventory);
        }

        [Fact]
        public void EyeballReceiver_ProcessRequestNextReciever_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new EyeballReceiver();
            var nextReceiver = new PotionReceiver();
            IItem item = ItemFactory.CreateItem("Red Potion", "Description", ItemType.POTION);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item, player.Inventory);
        }

        [Fact]
        public void EyeballReceiver_ProcessRequestExecption_Exception()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new EyeballReceiver();
            IItem item = ItemFactory.CreateItem("Potion", "Description", ItemType.POTION);

            //act

            //assert
            Assert.Throws<ArgumentException>(() => receiver.ProcessRequest(item));
        }

        [Fact]
        public void KeyReceiver_SetNextReceiver_NotNull()
        {
            //arrange
            var receiver = new KeyReceiver();
            var nextReceiver = new EyeballReceiver();

            var expected = typeof(EyeballReceiver);
            //act
            receiver.SetNextReceiver(nextReceiver);
            //assert
            Assert.IsType(expected, receiver.nextReceiver);
        }

        [Fact]
        public void KeyReceiver_ProcessRequestProperItem_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new KeyReceiver();
            var nextReceiver = new PotionReceiver();
            IItem item = ItemFactory.CreateItem("Master Key", "Description", ItemType.KEY);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item, player.Inventory);
        }

        [Fact]
        public void KeyReceiver_ProcessRequestNextReciever_AddToInventory()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new KeyReceiver();
            var nextReceiver = new PotionReceiver();
            IItem item = ItemFactory.CreateItem("Red Potion", "Description", ItemType.KEY);
            receiver.SetNextReceiver(nextReceiver);

            //act
            receiver.ProcessRequest(item);

            //assert
            Assert.Contains(item, player.Inventory);
        }

        [Fact]
        public void KeyReceiver_ProcessRequestExecption_Exception()
        {
            //arrange
            var player = Player.Instance();
            var receiver = new KeyReceiver();
            IItem item = ItemFactory.CreateItem("Potion", "Description", ItemType.POTION);

            //act

            //assert
            Assert.Throws<ArgumentException>(() => receiver.ProcessRequest(item));
        }




    }
}
