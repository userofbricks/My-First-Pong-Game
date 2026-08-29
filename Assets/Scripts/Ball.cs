
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float startX = 0f;
    public float maxStartY = 2f;
    public float paddleHitMultiplier = 1.1f;

    void Start()
    {
        GameManager.instance.gameUI.onStartGame += ResetBall;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
            ResetBall();
            InitialPush();
        }
        Paddle paddle = collision.GetComponent<Paddle>();
        if (paddle)
        {
            Vector2 dir = rb2d.linearVelocity;
            rb2d.linearVelocity = dir * paddleHitMultiplier;
        }
    }

    private void InitialPush()
    {
        Vector2 dir = Vector2.left;

        if (Random.value < 0.5f)
            dir = Vector2.right;

        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }

    private void ResetBall()
    {
        transform.position = new Vector2(startX, Random.Range(-maxStartY, maxStartY));
        InitialPush();
    }
}
