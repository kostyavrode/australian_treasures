using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Base : MonoBehaviour
{
    public string type;
    public TMP_Text bText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item comp))
        {
            ArtistGame.onItemHandle(comp,type);
        }
    }
    public void SetText(string text)
    {

    bText.text = text; 
    }
}
