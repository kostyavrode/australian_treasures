using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Game", menuName = "Game", order = 51)]
public class Game1 : ScriptableObject
{
    [SerializeField] private Item[] items;
    [SerializeField] private string locationName;
    public Item[] Items
    {
       get { return items; } 
    }
    public string LocationName
    {
       get { return locationName; } 
    }
}
