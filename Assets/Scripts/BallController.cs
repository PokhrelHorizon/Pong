using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject ball; //to reference ball prefab, used to instantiate it

    private float ballSpawnRange = 13f; //15 width, 1 ball, 1 buffer space so that ball doesn't spawn too close to wall

    private GameObject spawnedBall; //to reference ball already spawned in game

    private Rigidbody2D rbSpawnedBall; //to reference Rigidbody2D of spawned ball

    private float ballMoveAngle; //to set move directions of ball


    [SerializeField] private float ballSpeed;

    private float ballAngleExtent = 30f; //angle extent from x to 90-x to vertical(both + -) on which ball can move

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

        //Assign random direction
        //first part gives positive or negative unit value to direction, second value used for angle in that direction
        ballMoveAngle = (Random.Range(-1, 2) == 0 ? -1 : 1) * Random.Range(ballAngleExtent, 90 - ballAngleExtent);
        Debug.Log("Move Angle from vertical = " + ballMoveAngle);

        //Add force to ball at start, which gives it velocity which stays constant as no dampeners present
        //cos,sin to calculate component of vector from angle, functions swapped to take vertical as 0 degree instead of horizontal
        rbSpawnedBall.AddForce(new Vector2(Mathf.Cos(ballMoveAngle), Mathf.Sin(ballMoveAngle)).normalized * ballSpeed);
    }
}


