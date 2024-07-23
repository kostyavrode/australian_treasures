using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WonderMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text jordanGainedText;
    [SerializeField] private TMP_Text peruGainedText;
    [SerializeField] private TMP_Text usaGainedText;
    [SerializeField] private TMP_Text franceGainedText;
    private void OnEnable()
    {
        CheckGainedCountries();
    }
    private void CheckGainedCountries()
    {
        peruGainedText.text = "+" + PlayerPrefs.GetInt("Peru").ToString();
        jordanGainedText.text = "+" + PlayerPrefs.GetInt("Jordan").ToString();
        //usaGainedText.text = "+" + PlayerPrefs.GetInt("USA").ToString();
        //franceGainedText.text = "+" + PlayerPrefs.GetInt("France").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
