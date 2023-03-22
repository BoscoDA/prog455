using Factory;

var s = ArtifactFactory.CreateArtifact("Shield", "Iron Mail Shield", "Standard issue sheild", 73, 5);
var h = ArtifactFactory.CreateArtifact("Helmet", "Iron Mail Helmet", "Standard issue helmet", 54, 5);

List<IArtifact> artifacts = new List<IArtifact>();
artifacts.Add(s);
artifacts.Add(h);

foreach (var artifact in artifacts)
{
    Console.WriteLine(artifact.Name);
    Console.WriteLine(artifact.Description);
    Console.WriteLine(artifact.Durability);
    Console.WriteLine(artifact.LevelRequirement);
}

List<ArtifactBase> baseArtifacts = new List<ArtifactBase>();
baseArtifacts.Add(s as Shield);
baseArtifacts.Add(h as Helmet);

foreach (var baseArtifact in baseArtifacts)
{
    baseArtifact.PrintInfo();
}


