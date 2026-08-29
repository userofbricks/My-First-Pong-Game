using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUI gameUI;
    public int scorePlayer1, scorePlayer2;
    public bool paused = true;

    //event responsible for pausing and starting/resuming play
    public Action<bool> pauseEvent;
    private int pauseCoolDown = 0;
    public int pauseCoolDownMax = 10;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
        gameUI.onStartGame += UnPause;
    }

    void Update() {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetKey("space") && pauseCoolDown == 0)
        {
            paused = !paused;
            pauseEvent?.Invoke(paused);
            pauseCoolDown = pauseCoolDownMax;
        }
        if (pauseCoolDown > 0)
            pauseCoolDown--;
    }

    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
            scorePlayer1++;
        else if (id == 2)
            scorePlayer2++;
        else 
            Debug.LogError("Unknown Score Zone id: " + id.ToString());

        gameUI.UpdateScores(scorePlayer1, scorePlayer2);
    }

    public void UnPause()
    {
        paused = false;
        pauseEvent?.Invoke(paused);
    }
}
