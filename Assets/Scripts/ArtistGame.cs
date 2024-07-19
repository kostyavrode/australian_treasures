using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class ArtistGame : MonoBehaviour
{
    public static Action<Item,string> onItemHandle;
    public Transform itemsSpawnTranfrom;
    //public Item[] itemsPrefabs;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private Game2 gameAsset;
    [SerializeField] private TMP_Text location;
    [SerializeField] private TMP_Text answersText;
    [SerializeField] private TMP_Text results;
    [SerializeField] private Base basse;
    [SerializeField] private Base bassse2;
    private int rightAnswers;
    private int answers;
    private int totalQuestions;
    private List<Item> items;
    private void OnEnable()
    {
        onItemHandle += HandleItem;
        InitItems();
    }
    private void OnDisable()
    {
        rightAnswers = 0; answers=0;
        closeButton.gameObject.SetActive(false);
        onItemHandle -= HandleItem;
        InitItems();
    }
    public void SetGameAsset(Game2 game)
    {
        gameAsset=game;
    }
    private void InitItems()
    {
        items = new List<Item>();
        foreach (Item item in gameAsset.Items)
        {
            Item newItem= Instantiate(item);
            newItem.transform.position=itemsSpawnTranfrom.position;
            newItem.transform.parent = itemsSpawnTranfrom;
            items.Add(newItem);
            newItem.transform.localScale = Vector3.one*2;
            newItem.gameObject.SetActive(false);
        }
        items[items.Count-1].gameObject.SetActive(true);
        location.text = gameAsset.LocationName.ToUpper();
        basse.type = gameAsset.LocationName;
        basse.SetText(gameAsset.LocationName);
        bassse2.type = gameAsset.LocationName2;
        bassse2.SetText(gameAsset.LocationName2);
        totalQuestions=items.Count;
        answersText.text = answers.ToString() + "/" + totalQuestions;
    }
    private void HandleItem(Item item,string baseType)
    {
        if (item.type==baseType)
        {
            rightAnswers+=1;
            Debug.Log("Right Answers" + rightAnswers);
        }
        else if (item.type!=gameAsset.LocationName && baseType=="")
        {
            rightAnswers += 1;
            Debug.Log("Right Answers" + rightAnswers);
        }
        //else if (item.type != gameAsset.LocationName && baseType != item.type)
        else
        {
            //rightAnswers += 1;
            Debug.Log("Wrong Answers" + rightAnswers);
        }
        items.Remove(item);
        item.gameObject.SetActive(false);
        if (items.Count == 0 )
        {
            EndGame();
            return;
        }
        items[items.Count - 1].gameObject.SetActive(true);
        answers += 1;
        answersText.text = answers.ToString()+"/"+totalQuestions;
    }
    private void EndGame()
    {
        Debug.Log("End Game");
        results.text=rightAnswers.ToString()+"/"+totalQuestions;
        closeButton.gameObject.SetActive(true);    
        answersText.text = totalQuestions + "/" + totalQuestions;
        if (rightAnswers>3)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") + rightAnswers * 10);
            PlayerPrefs.SetInt(gameAsset.LocationName, rightAnswers * 10);
            PlayerPrefs.Save();
            Debug.Log(gameAsset.LocationName);
        }
    }
}
