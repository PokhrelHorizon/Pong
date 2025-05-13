using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float addBallSpeedPercent;  //adds speed to ball(% of initial speed)

    [SerializeField] private GameObject ball; //to reference ball prefab, used to instantiate it

    private float ballSpawnRange = 13f; //15 width, 1 ball, 1 buffer space so that ball doesn't spawn too close to wall

    private GameObject spawnedBall; //to reference ball already spawned in game

    private Rigidbody2D rbSpawnedBall; //to reference Rigidbody2D of spawned ball

    private int ballMoveDirX, ballMoveDirY;   //assign move direction in X and Y randomly

    [SerializeField] private float initialBallSpeed;

    //used to spawn the ball
    public void BallSpawn()
    {
        //Spawn ball in horizontal center with random vertical positioning
        Instantiate(ball, new Vector2(0, Random.Range(-ballSpawnRange, ballSpawnRange)), Quaternion.identity);

    }



    //Provide velocity to move the ball
    public void MoveBall()
    {
        //Find already spawned ball and assign it and its rigidbody to variables
        spawnedBall = GameObject.Find("PongBall(Clone)");
        rbSpawnedBall = spawnedBall.GetComponent<Rigidbody2D>();

        //Assign random diagonal direction
        ballMoveDirX = Random.Range(0, 2) == 0 ? -1 : 1;
        ballMoveDirY = Random.Range(0, 2) == 0 ? -1 : 1;

        //Add force to ball at start, which gives it velocity which stays constant as no dampeners present
        rbSpawnedBall.AddForce(new Vector2(ballMoveDirX, ballMoveDirY).normalized * initialBallSpeed);
    }

    //used by ballcollisiondetector to add force/speed to ball
    public void AddForceWhenBallPaddleCollide()
    {
        //.normalized makes linear velocity mag 1
        rbSpawnedBall.AddForce(rbSpawnedBall.linearVelocity.normalized * initialBallSpeed * addBallSpeedPercent);

    }
}


