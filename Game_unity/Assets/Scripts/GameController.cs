using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public Text scoreText;

    public static GameController instance;

    public GameObject gameOver;

    private int jogoScore;

    public static bool gameoverbool = false;

    int Counter = 0;

    void Start()
    {
        instance = this;

        //scoreText = GameObject.Find("score").GetComponent<Text>();

        //Past.text = PlayerPrefs.GetInt("score", 0).ToString();
        scoreText.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void UpdateScoreText()
    {
        if (Counter == 0)
        {
            totalScore = totalScore + PlayerPrefs.GetInt("score", 0);
        }

        scoreText.text = totalScore.ToString();
        PlayerPrefs.SetInt("score", totalScore);
        Counter++;
    }

    public void GameOver()
    {
        AudioManager.instance.StopPlaying("Air");
        AudioManager.instance.StopPlaying("Saw");
        gameOver.SetActive(true);
        gameoverbool = true;
    }

    public void RestartGame(string Levelname)
    {
        if (Levelname.Equals("Level_12") || Levelname.Equals("Level_1"))
        {
            Player.jetPack = false;
            //AudioManager.instance.StopPlaying("Momentum");
        }

        gameoverbool = false;
        SceneManager.LoadScene(Levelname);
    }

    public void LosePoints()
    {
        if (Counter > 0)
        {
            PlayerPrefs.SetInt("score", totalScore - (Counter * 10));
        }
    }
    public void ResetPoints()
    {
        PlayerPrefs.DeleteKey("score");
        scoreText.text = "00";
    }
}
