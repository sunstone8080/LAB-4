using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    [Header("Inspector Input")]
    public string characterName;
    public int level;
    public int conScore;
    public string characterClass;
    public string race;
    public bool tough;
    public bool stout;
    // t average f roll
    public bool average;

    [Header("Output")]
    public int finalHP;

    //dictionary initialization
    private Dictionary<string, int> classHitDice = new Dictionary<string, int>();
    private Dictionary<string, int> racialBonus = new Dictionary<string, int>();

    private void InitializeDictionaries()
    {
        classHitDice = new Dictionary<string, int>()
    {
        {"Barbarian", 12},
        {"Fighter", 10},
        {"Paladin", 10},
        {"Ranger", 10},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Monk", 8},
        {"Rogue", 8},
        {"Warlock", 8},
        {"Sorcerer", 6},
        {"Wizard", 6}
    };

        racialBonus = new Dictionary<string, int>()
    {
        {"Dwarf", 2},
        {"Orc", 1},
        {"Goliath", 1}
    };
    }


    private void Start()
    {
        calculateHP();
        Debug.Log(printStats());
    }

    public void calculateHP()
    {
        // Make sure dictionaries exist (important for OnValidate)
        if (classHitDice == null || classHitDice.Count == 0)
            InitializeDictionaries();

        if (level < 1) level = 1;
        if (level > 20) level = 20;

        // SAFETY: prevent null keys
        int raceHP = 0;
        if (!string.IsNullOrEmpty(race) && racialBonus.ContainsKey(race))
            raceHP = racialBonus[race];

        int totalCon = conScore + raceHP;
        int conMod = Mathf.FloorToInt((totalCon - 10) / 2f);

        int hitDie = 8; // default
        if (!string.IsNullOrEmpty(characterClass) && classHitDice.ContainsKey(characterClass))
            hitDie = classHitDice[characterClass];

        int featHP = 0;
        if (tough) featHP += 2 * level;

        int total = 0;

        total += hitDie + conMod;

        for (int i = 2; i <= level; i++)
        {
            int roll = average ? (hitDie / 2) + 1
                               : Random.Range(1, hitDie + 1);

            total += roll + conMod;
        }

        finalHP = total + featHP;
    }


    private string printStats()
    {
        string toughText = tough ? "has" : "does not have";
        string stoutText = stout ? "has" : "does not have";
        string avgText = average ? "averaged" : "rolled";

        return $"My character {characterName} is a level {level} {characterClass} " +
               $"with a CON score of {conScore} and is of {race} race and {toughText} Tough feat " +
               $"and {stoutText} Stout feat. I want the HP {avgText}. Final HP = {finalHP}.";
    }
}
