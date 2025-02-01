using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class FootballQuiz : MonoBehaviour
{
    [System.Serializable]
    public class Club
    {
        public string name;
        public Sprite emblem;
    }

    public GameObject endGameMenu;

    public List<Club> clubs;
    public Image emblemImage;
    public List<Button> answerButtons;
    public TMP_Text scoreText;

    public TMP_Text endScore;

    private int score = 0;
    private int rounds = 0;
    private Club correctClub;

    void Start()
    {
        NextRound();
    }

    void NextRound()
    {
        if (rounds >= 6)
        {
            Debug.Log("Game Over! Final Score: " + score);
            EndGame();
            return;
        }

        rounds++;
        List<Club> shuffledClubs = clubs.OrderBy(x => Random.value).ToList();
        correctClub = shuffledClubs[0];
        emblemImage.sprite = correctClub.emblem;

        List<string> usedNames = new List<string> { correctClub.name };
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = correctClub.name;
        answerButtons[0].onClick.RemoveAllListeners();
        answerButtons[0].onClick.AddListener(() => CheckAnswer(correctClub.name));

        for (int i = 1; i < answerButtons.Count; i++)
        {
            Club randomClub;
            do
            {
                randomClub = shuffledClubs[Random.Range(1, shuffledClubs.Count)];
            } while (usedNames.Contains(randomClub.name));

            usedNames.Add(randomClub.name);
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = randomClub.name;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(randomClub.name));
        }

        ShuffleButtons();
    }

    void CheckAnswer(string selectedName)
    {
        if (selectedName == correctClub.name)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        NextRound();
    }

    void ShuffleButtons()
    {
        answerButtons = answerButtons.OrderBy(x => Random.value).ToList();
    }
    void EndGame()
    {
        endScore.text = scoreText.text;
        score = 0;
        rounds= 0;
        endGameMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
