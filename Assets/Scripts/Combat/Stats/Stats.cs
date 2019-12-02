using UnityEngine;
public class Stats : MonoBehaviour
{
    public string characterName = null;

    public int maxHealthPoints;
    public int currentHealthPoints;
    public int maxSoulPoints;
    public int currentSoulPoints;
    public int maxMove;
    public int currentMove;
    public int range;
    public int maxActionPoints;
    public int currentActionPoints;

    public int strength;
    public int attack;
    public int resistance;
    public int defense;
    public int agility;
    public int magic;
    public int vitality;
    public int spirit;

    private bool isAlive = true;
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
            if (!value)
            {
                TurnManager turnManager = Camera.main.GetComponent<TurnManager>();
                turnManager.RemoveCharacterFromQueue(gameObject);
            }

        }
    }
}
public class Hanzo
{
    public int healthPoints = 15;
    public int soulPoints = 15;
    public int move = 3;
    public int range = 2;
    public int actionPoints = 4;

    public int strength = 2;
    public int attack = 3;
    public int resistance = 1;
    public int defense = 3;
    public int agility = 3;
    public int magic = 2;
    public int vitality = 1;
    public int spirit = 2;
}
public class Fenrir
{
    public int healthPoints = 25;
    public int soulPoints = 20;
    public int move = 2;
    public int range = 1;
    public int actionPoints = 3;

    public int strength = 3;
    public int attack = 4;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 2;
    public int magic = 1;
    public int vitality = 2;
    public int spirit = 1;
}
public class NeonDevilPink
{
    public int healthPoints = 10;
    public int soulPoints = 15;
    public int move = 2;
    public int range = 2;
    public int actionPoints = 3;

    public int strength = 2;
    public int attack = 3;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 2;
    public int magic = 3;
    public int vitality = 2;
    public int spirit = 1;
}
public class NeonDevilBlue
{
    public int healthPoints = 15;
    public int soulPoints = 15;
    public int move = 2;
    public int range = 2;
    public int actionPoints = 3;

    public int strength = 2;
    public int attack = 2;
    public int resistance = 3;
    public int defense = 3;
    public int agility = 1;
    public int magic = 2;
    public int vitality = 2;
    public int spirit = 2;
}
public class NeonDevilPurple
{
    public int healthPoints = 10;
    public int soulPoints = 15;
    public int move = 2;
    public int range = 2;
    public int actionPoints = 3;

    public int strength = 3;
    public int attack = 3;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 2;
    public int magic = 2;
    public int vitality = 1;
    public int spirit = 2;
}
public class NeonDevilGreen
{
    public int healthPoints = 10;
    public int soulPoints = 15;
    public int move = 2;
    public int range = 2;
    public int actionPoints = 3;

    public int strength = 2;
    public int attack = 3;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 2;
    public int magic = 3;
    public int vitality = 1;
    public int spirit = 2;
}
public class LabRat
{
    public int healthPoints = 20;
    public int soulPoints = 20;
    public int move = 2;
    public int range = 3;
    public int actionPoints = 4;

    public int strength = 3;
    public int attack = 3;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 4;
    public int magic = 3;
    public int vitality = 1;
    public int spirit = 2;
}
public class Torch
{
    public int healthPoints = 30;
    public int soulPoints = 20;
    public int move = 1;
    public int range = 1;
    public int actionPoints = 3;

    public int strength = 2;
    public int attack = 2;
    public int resistance = 3;
    public int defense = 4;
    public int agility = 1;
    public int magic = 2;
    public int vitality = 2;
    public int spirit = 2;
}
public class Hellhound
{
    public int healthPoints = 10;
    public int soulPoints = 10;
    public int move = 3;
    public int range = 1;
    public int actionPoints = 3;

    public int strength = 3;
    public int attack = 3;
    public int resistance = 2;
    public int defense = 2;
    public int agility = 3;
    public int magic = 1;
    public int vitality = 1;
    public int spirit = 1;
}
public class Gremlin
{
    public int healthPoints = 6;
    public int soulPoints = 15;
    public int move = 4;
    public int range = 1;
    public int actionPoints = 5;

    public int strength = 2;
    public int attack = 3;
    public int resistance = 1;
    public int defense = 2;
    public int agility = 3;
    public int magic = 3;
    public int vitality = 1;
    public int spirit = 3;
}
public class Aria
{
    public int healthPoints = 50;
    public int soulPoints = 50;
    public int move = 4;
    public int range = 2;
    public int actionPoints = 4;

    public int strength = 3;
    public int attack = 4;
    public int resistance = 3;
    public int defense = 2;
    public int agility = 3;
    public int magic = 3;
    public int vitality = 1;
    public int spirit = 4;
}