using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool suddenDeath;
    public GameObject gameOver;
    public GameObject victory;

    private WaveSpawner ws;

    [Header("Winning conditions")]
    public int pointsToWin;
    public float score = 0;
    public TMP_Text scoreTxt;

    private void Start()
    {
        Time.timeScale = 1;
        ws = GetComponent<WaveSpawner>();
        pointsToWin = ws.numberOfEnemies * ws.numberOfWaves;
    }

    private void Update()
    {
        if(pointsToWin <= 0)
        {
            Victory();
        }

        score += Time.deltaTime;
    }

    public void GameOver()
    {
        Debug.Log("You lost");
        Time.timeScale = 0;
        ActivateGameOverCanvas();
    }

    public void Victory()
    {
        Debug.Log("You won!");
        double scoreD = System.Math.Round(score, 2);
        scoreTxt.text = "Your score was: " +  scoreD;
        Time.timeScale = 0;
        ActivateVictoryCanvas();
    }

    void ActivateVictoryCanvas()
    {
        victory.SetActive(true);
    }

    void ActivateGameOverCanvas()
    {
        gameOver.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
