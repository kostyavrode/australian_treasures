using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Game", menuName = "Game2", order = 51)]
public class Game2 : ScriptableObject
{
    [SerializeField] private Item[] items;
    [SerializeField] private string locationName;
    [SerializeField] private string locationName2;
    public Item[] Items
    {
       get { return items; } 
    }
    public string LocationName
    {
       get { return locationName; } 
    }
    public string LocationName2
    {
        get { return locationName2; }
    }
}
