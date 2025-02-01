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
        //canadaGainedText.text = "+" + PlayerPrefs.GetInt("Canada").ToString();
        //usaGainedText.text = "+" + PlayerPrefs.GetInt("USA").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
