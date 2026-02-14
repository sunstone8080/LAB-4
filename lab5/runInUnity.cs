using UnityEngine;

public class runInUnity : MonoBehaviour
{
   void Start()
    {
        Character knight = new Paladin("Sammie", 3, 21, "Dwarf", true, false, true);
        Character wizard = new Wizard("Ashling", 5, 16, "Human", false, false, false);
        knight.PrintStats();
        wizard.PrintStats();
    }
}
