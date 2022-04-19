using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class CanvasUiHandler : MonoBehaviour
{
    public GameManager gameManager;

    public TMP_Text scoreText;
    public TMP_Text currentPlayer;
    public TMP_Text bestPlayer;
    public TMP_Text HighScoreText;


    public TMP_Text GameOverText;



    // Start is called before the first frame update
    void Start()
    {
        GameOverText.text = "";

        currentPlayer.text = SavingData.Instance._name;
        scoreText.text = "Score:";
        bestPlayer.text = SavingData.Instance._bestPlayer;
        HighScoreText.text = "HighScore: " + SavingData.Instance._highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.points;

        if (gameManager.isGameOver)
        {
            GameOverText.text = "Game Over";
        }
    }




}
