using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float id;
    public float moveSpeed = 2f;

    private float pausedVelocity = 0;
    
    void Start()
    {
        GameManager.instance.pauseEvent += Pause;
    }

    void Update()
    {
        float moveDirection = ProcessInput();
        Move(moveDirection);
    }

    private float ProcessInput()
    {
        float movment = 0f;
        switch (id)
        {
            case 1:
                movment = Input.GetAxis("MovePlayer1");
                break;
            case 2:
                movment = Input.GetAxis("MovePlayer2");
                break;
        }

        return movment;
    }

    private void Move(float moveDirection)
    {
        rb2d.linearVelocityY = moveSpeed * moveDirection;

    }

    public void Pause(bool paused)
    {
        if (paused)
        {
            pausedVelocity = rb2d.linearVelocityY;
            rb2d.linearVelocityY = 0;
        } else
        {
            rb2d.linearVelocityY = pausedVelocity;
        }
    }
}
