using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUI gameUI;
    public int scorePlayer1, scorePlayer2;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    void Update() {
        if (Input.GetKey("escape"))
            Application.Quit();
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
}
