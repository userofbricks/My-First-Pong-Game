using System;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject menuObject;
    public ScoreText scoreTextLeft, scoreTextRight;

    public Action onStartGame;

    public void UpdateScores(int scorePlayer1, int scorePlayer2)
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }

    public void OnStartGameButtonClicked()
    {
        menuObject.SetActive(false);
        //Debug.Log("Start Button Clicked");
        onStartGame?.Invoke();
    }
}
