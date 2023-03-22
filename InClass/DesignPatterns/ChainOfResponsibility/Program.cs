
using ChainOfResponsibility;

IReceiver potionReceiver = new PotionReciever();
IReceiver artifactReceiver = new ArtifactReciever();
IReceiver scrollReceiver = new ScrollReceiver();

potionReceiver.SetNextReceiver(artifactReceiver);
artifactReceiver.SetNextReceiver(scrollReceiver);

List<Item> items = new List<Item>();

items.Add(new Item("MP Potion", 20));
items.Add(new Item("Bamboo Sword Artifact",2));
items.Add(new Item("HP Potion",40));
items.Add(new Item("Return Home Scroll",5));
items.Add(new Item("Wooden Sheild Artifact",3));

foreach (Item item in items)
{
    potionReceiver.ProcessRequest(item);
}
