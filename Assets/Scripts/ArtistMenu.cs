using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArtistMenu : MonoBehaviour
{
    public Button[] buttons;
    private void OnEnable()
    {
        
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        CheckSavings();
    }
    private void CheckSavings()
    {
        int t = PlayerPrefs.GetInt("level");
        t =t+ 1;
        for (int i = 0; i < t; i++)
        {
            Debug.Log("T"+t);
            if (i<=buttons.Length)
            buttons[i].interactable = true;
        }
    }
}
