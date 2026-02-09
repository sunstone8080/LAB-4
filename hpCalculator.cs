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

    private void Awake()
    {
        //class die
        classHitDice.Add("Barbarian", 12);
        classHitDice.Add("Fighter", 10);
        classHitDice.Add("Paladin", 10);
        classHitDice.Add("Ranger", 10);
        classHitDice.Add("Bard", 8);
        classHitDice.Add("Cleric", 8);
        classHitDice.Add("Druid", 8);
        classHitDice.Add("Monk", 8);
        classHitDice.Add("Rogue", 8);
        classHitDice.Add("Warlock", 8);
        classHitDice.Add("Sorcerer", 6);
        classHitDice.Add("Wizard", 6);
        //racial
        racialBonus.Add("Dwarf", 2);
        racialBonus.Add("Orc", 1);
        racialBonus.Add("Goliath", 1);
    }

    private void OnValidate()
    {
        CalculateHP();
    }

    public void CalculateHP()
    {
        //clamp
        if (level < 1) level = 1;
        if (level > 20) level = 20;

        //con mod
        int conMod = Mathf.FloorToInt((conScore - 10) / 2f);

        //total hitdie
        int hitDie = classHitDice.ContainsKey(characterClass) ? classHitDice[characterClass] : 8;

        //racial bonus
        int raceHP = racialBonus.ContainsKey(race) ? racialBonus[race] : 0;

        //feats
        int featHP = 0;
        if (tough) featHP += 2;
        if (stout) featHP += 1;

        int total = 0;

        //level 1
        total += hitDie + conMod + raceHP + featHP;

        //higher levels
        for (int i = 2; i <= level; i++)
        {
            int roll;

            if (average)
            {
                roll = Mathf.RoundToInt((hitDie + 1) / 2f);
            }
            else
            {
                roll = Random.Range(1, hitDie + 1);
            }

            finalHP = total + roll + conMod + raceHP + featHP;
        }
    }

    private string BuildSummary()
    {
        string toughText = tough ? "has" : "does not have";
        string stoutText = stout ? "has" : "does not have";
        string avgText = average ? "averaged" : "rolled";

        return $"My character {characterName} is a level {level} {characterClass} " +
               $"with a CON score of {conScore} and is of {race} race and {toughText} Tough feat " +
               $"and {stoutText} Stout feat. I want the HP {avgText}. Final HP = {finalHP}.";
    }
}
