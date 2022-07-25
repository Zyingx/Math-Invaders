using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equations : MonoBehaviour
{
    [Header("Equation")]
    public int FirstNumber;
    public int SecondNumber;
    public int HighestNumberGenerated = 99;
    public int LowestNumberGenerated = 1;
    int Op;
    int Op1 = 0;
    public int FinalAnswer;
    [HideInInspector]
    public bool AchieveAnswer;
    public EnemySpawn ES;

    [Header("Scoring Stuff")]
    public int Score;
    public int AmountOfScoreToBeAdded = 1;
    public int Lives = 3;

    [Header("UI")]
    public Text EquationUI;
    public Text ScoreUI;
    public Text OverScoreUI;
    public Text LivesUI;
    public GameObject GameOver;

    [HideInInspector]
    public int EnemyKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        OverScoreUI.text = "Score: " + Score;
        ScoreUI.text = "Score: " + Score;
        LivesUI.text = "Lifes: " + Lives;
        if (Lives <= 0)
        {
            GameOver.SetActive(true);
            ES.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }

        if (AchieveAnswer)
        {
            Score += AmountOfScoreToBeAdded;
            AchieveAnswer = false;
            Generate();
        }
    }

    void Generate()
    {
        FirstNumber = Random.Range(LowestNumberGenerated, HighestNumberGenerated + 1);
        SecondNumber = Random.Range(LowestNumberGenerated, HighestNumberGenerated + 1);
        Op = Random.Range(0, 101);
        if(Op > 50)
        {
            Op1 = 0;
            FinalAnswer = FirstNumber + SecondNumber;
            EquationUI.text = FirstNumber + " + " + SecondNumber + " = ?";
        }
        else
        {
            Op1 = 1;
            FinalAnswer = FirstNumber - SecondNumber;
            EquationUI.text = FirstNumber + " - " + SecondNumber + " = ?";
        }
    }
}