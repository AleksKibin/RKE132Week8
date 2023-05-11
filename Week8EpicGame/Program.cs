//string[] heroes = { "Superman", "Spiderman", "Batman", "Elastic Woman", "Miss Martian" };
//string[] villains = { "Joker", "Harley Quinn", "Catwoman", "Thanos", "Scarlet witch" };

string folderPath = @"C:\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));

string[] weapon = { "sword", "bow and arrow", "laser whip", "polearm", "claymore", "catalyst", "potato" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
Console.WriteLine($"Today {hero}({heroHP}HP) saves the day with a {heroWeapon}!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
Console.WriteLine($"Today {villain}({villainHP}HP) tries to take over the world with a {villainWeapon}.");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}

if(heroHP > 0)
{
    Console.WriteLine("Hero saves the day");
}
else if(villainHP > 0) 
{
    Console.WriteLine("Villain has taken over the world.");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomSrtingFromArray = someArray[randomIndex];
    return randomSrtingFromArray;
}

static int GetCharacterHP(string CharacterName)
{
    if (CharacterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return CharacterName.Length;
    }
}

static int Hit(string characterName,int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(characterHP);
    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target");
    }
    else if(strike == characterHP-1)
    {
        Console.WriteLine($"{characterName} made a critical hit");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");

    }
    return strike;
}