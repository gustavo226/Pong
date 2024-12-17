using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player1Paddle;
    public Transform player2Paddle;

    public BallController ballController;

    public int player1Score = 0;
    public int player2Score = 0;

    public TextMeshProUGUI textPointsPlayer1;
    public TextMeshProUGUI textPointsPlayer2;

    public int winPoints = 7;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    void Start() 
    {
        ResetGame();
    }

    public void ResetGame()
    {
        player1Paddle.position = new Vector3(-7f, 0f, 0f);
        player2Paddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();

        player1Score = 0;
        player2Score = 0;

        textPointsPlayer1.text = player1Score.ToString();
        textPointsPlayer2.text = player2Score.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer1()
    {
        player1Score++;
        textPointsPlayer1.text = player1Score.ToString();
        CheckWin();
    }

    public void ScorePlayer2()
    {
        player2Score++;
        textPointsPlayer2.text = player2Score.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (player1Score >= winPoints || player2Score >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(player1Score > player2Score);
        textEndGame.text = winner + " Wins";
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
