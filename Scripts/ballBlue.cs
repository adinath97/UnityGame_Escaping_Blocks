using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBlue : MonoBehaviour
{
    [SerializeField] paddleStandardRed paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 10f;
    [SerializeField] float randomFactor = 0.3f;
    [SerializeField] float increaseSpeed = 1f;
    float xVel, yVel;
    public float moveSpeed = 11f;

    private bool hasStarted;

    Vector2 paddleToBallVector;
    Vector2 velocityDesired;

    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
        velocityDesired = new Vector2(xVelocity, yVelocity);
        xVel = Mathf.Abs(xVelocity);
        yVel = Mathf.Abs(yVelocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hasStarted == false)
        {
            LockBallToPaddle();
        }
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
        LaunchOnKeyDown();
    }

    private void LaunchOnKeyDown()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity += new Vector2(xVelocity, yVelocity);
        }
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(-randomFactor, randomFactor), Random.Range(-randomFactor, randomFactor));
        myRigidbody2D.velocity += velocityTweak;
        if(ScoreManager.hits  % 10 == 0 && ScoreManager.hits > 0)
        {
            //Debug.Log("Velocity before tweak: " + myRigidbody2D.velocity);
            //Vector2 velocityTweak2 = new Vector2(Random.Range(0, increaseSpeed), Random.Range(0, increaseSpeed));
            Vector2 velocityTweak2 = new Vector2(increaseSpeed, increaseSpeed);
            //Debug.Log(velocityTweak2);
            myRigidbody2D.velocity += velocityTweak2;
            //Debug.Log("Velocity after tweak: " + myRigidbody2D.velocity);
        }
        if(other.gameObject.tag == "Diamond1" || other.gameObject.tag == "Diamond2" || other.gameObject.tag == "Untagged")
        {
            ScoreManager.hits++;
            //Debug.Log(ScoreManager.hits);
        }
    }
}
