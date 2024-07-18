using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text russiaGainedText;
    [SerializeField] private TMP_Text canadaGainedText;
    [SerializeField] private TMP_Text usaGainedText;
    [SerializeField] private TMP_Text franceGainedText;
    [SerializeField] private TMP_Text netherlandsGainedText;
    [SerializeField] private TMP_Text italyGainedText;
    [SerializeField] private TMP_Text spainGainedText;
    [SerializeField] private TMP_Text austriaGainedText;
    [SerializeField] private TMP_Text brazilGainedText;
    [SerializeField] private TMP_Text japanGainedText;
    private void OnEnable()
    {
        CheckGainedCountries();
    }
    private void CheckGainedCountries()
    {
        canadaGainedText.text = "+" + PlayerPrefs.GetInt("Canada").ToString();
        russiaGainedText.text = "+" + PlayerPrefs.GetInt("Russia").ToString();
        usaGainedText.text = "+" + PlayerPrefs.GetInt("USA").ToString();
        franceGainedText.text = "+" + PlayerPrefs.GetInt("France").ToString();
        netherlandsGainedText.text = "+" + PlayerPrefs.GetInt("Netherlands").ToString();
        italyGainedText.text = "+" + PlayerPrefs.GetInt("Italy").ToString();
        spainGainedText.text = "+" + PlayerPrefs.GetInt("Spain").ToString();
        italyGainedText.text = "+" + PlayerPrefs.GetInt("Austria").ToString();
        brazilGainedText.text = "+" + PlayerPrefs.GetInt("Brazil").ToString();
        japanGainedText.text = "+" + PlayerPrefs.GetInt("Japan").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
