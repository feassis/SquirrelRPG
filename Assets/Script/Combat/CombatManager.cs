using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private ActionBarGraphics actionBarGraphics;

    private void Start()
    {
        actionBarGraphics.AddCharacterToQueue(new Character(10,10,10,10,10,10,10), Team.Player);
        actionBarGraphics.AddCharacterToQueue(new Character(100,20,20,20,20,20,20), Team.Enemy);
    }
}
