using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    public TMP_Text servingPlayerText;

    public TMP_Text winnerText;

    private static int player1Score = 0;
    private static int player2Score = 0;

    public static bool player1Serving = true;
    public static bool player2Serving = false;

    private float counter = 3f;

    private const int WINNING_SCORE = 10;


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (player1Score == WINNING_SCORE)
            {
                Debug.Log("Player 1 wins");

                player1ScoreText.text = player1Score.ToString();
                player2ScoreText.text = player2Score.ToString();
            }

            if (player2Score == WINNING_SCORE)
            {
                Debug.Log("Player 2 wins");
                player1ScoreText.text = player1Score.ToString();
                player2ScoreText.text = player2Score.ToString();
            }
        }
    }

    void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;

        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            counter -= Time.deltaTime;

            if (counter <= 0.01f)
            {
                servingPlayerText.alpha = 0;
            }
            else
            {
                servingPlayerText.alpha = 1;
            }


            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                ResetScore();
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            if (Input.GetKey(KeyCode.Return))
            {
                Debug.Log("Reutrn key pressed");
                Debug.Log(player1Score.ToString() + " | " + player2Score.ToString());
                if (player1Score == WINNING_SCORE)
                {
                    player1Serving = false;
                    player2Serving = true;

                    SceneManager.LoadScene(1);

                    ResetScore();
                }

                if (player2Score == WINNING_SCORE)
                {
                    player1Serving = true;
                    player2Serving = false;

                    SceneManager.LoadScene(1);

                    ResetScore();
                }

            }
        }
    }

    public void setPlayer1Score()
    {


        if (SceneManager.GetActiveScene().buildIndex != 2)
        {

            player1Score += 1;
            player1ScoreText.text = player1Score.ToString();

            player1Serving = false;
            player2Serving = true;


            counter = 3f;

            servingPlayerText.text = "Player 2 Serving";
        }


        if (player1Score == WINNING_SCORE)
        {
            SceneManager.LoadScene(2);

            winnerText.text = "player 1 wins";
        }
    }
    public void setPlayer2Score()
    {

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {

            player2Score += 1;
            player2ScoreText.text = player2Score.ToString();

            player1Serving = true;
            player2Serving = false;

            counter = 3f;

            servingPlayerText.text = "Player 1 Serving";
        }

        if (player2Score == WINNING_SCORE)
        {
            SceneManager.LoadScene(2);
            winnerText.text = "player 2 wins";
        }



    }


}
