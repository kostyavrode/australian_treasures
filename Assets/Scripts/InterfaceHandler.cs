using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class InterfaceHandler : MonoBehaviour
{
    public static InterfaceHandler Instance;
    [SerializeField] private TMP_Text moneyText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateMoney();
    }
    public void UpdateMoney()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
