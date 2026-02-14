using System;
using UnityEngine;

//base class
public class Character
{
    public string characterName;
    public int level;
    public int conScore;
    public string race;
    public bool hasTough;
    public bool hasStout;
    public bool useAverage;

    public int hitPoints;

    protected int conModifier => (conScore - 10) / 2;




    public Character(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
    {
        characterName = name;
        this.level = level;
        this.conScore = conScore;
        this.race = race;
        hasTough = tough;
        hasStout = stout;
        useAverage = averaged;

        hitPoints = calculateHP();



    }

    //default
    protected virtual int hitDie()
    {
        return 8;
    }

    //Hp Calculation
    protected int calculateHP()
    {
        int hp = 0;

        for (int i = 1; i <= level; i++)
        {
            if (i == 1)
                hp += hitDie() + conModifier; //Level 1 max hit die val
            else
                hp += (useAverage ? (hitDie() / 2 + 1) : UnityEngine.Random.Range(1, hitDie() + 1)) + conModifier;

            hp += raceBonusPerLevel();
            hp += featBonusPerLevel();



        }

        return hp;




    }

    protected virtual int raceBonusPerLevel()
    {
        switch (race.ToLower())
        {
            case "dwarf": return 2;
            case "orc": return 1;
            case "goliath": return 1;
            default: return 0;
        }
    }

    protected int featBonusPerLevel()
    {
        int bonus = 0;
        if (hasTough) bonus += 2;
        if (hasStout) bonus += 1;
        return bonus;
    }

    public virtual void PrintStats()
    {
        string toughText = hasTough ? "has the" : "does not have the";
        string stoutText = hasStout ? "has the" : "does not have the";
        string avgText = useAverage ? "using average HP per level" : "rolling HP per level";

        Debug.Log($"My character {characterName} is a level {level} {GetType().Name} " +
                  $"with a CON score of {conScore} and is of {race} race and {toughText} Tough feat " +
                  $"and {stoutText} Stout feat. I want the HP {avgText}. Final HP = {hitPoints}.");


    }
}
public class Barbarian:Character
{
    public Barbarian(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 12;
    }
}


public class Bard:Character
{
    public Bard(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 8;
    }
}


public class Cleric:Character
{
    public Cleric(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 8;
    }
}


public class Druid:Character
{
    public Druid(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 8; 
    }
}


public class Fighter:Character
{
    public Fighter(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 10;
    }
}


public class Monk:Character
{
    public Monk(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }

    protected override int hitDie()
    {
        return 8; 
    }
}

public class Paladin:Character
{
    public Paladin(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 10;
    }
}


public class Ranger:Character
{
    public Ranger(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 10;
    }
}


public class Rogue:Character
{
    public Rogue(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 8; 
    }
}


public class Sorcerer:Character
{
    public Sorcerer(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 6; 
    }
}


public class Warlock:Character
{
    public Warlock(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 8; 
    }
}
public class Wizard:Character
{
    public Wizard(string name, int level, int conScore, string race, bool tough, bool stout, bool averaged)
        : base(name, level, conScore, race, tough, stout, averaged)
    {
    }
    protected override int hitDie()
    {
        return 6;
    }
}

