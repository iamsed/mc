using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        Vector2 runAway = new Vector2();
        runAway.x = transform.position.x - player.position.x;
        runAway.y = transform.position.y - player.position.y;

        Vector2 goal = new Vector2();

        Vector2 runTo = new Vector2();
        runTo.x = goal.x - transform.position.x;
        runTo.y = goal.y - transform.position.y;




        Vector2 random = Random.insideUnitCircle;
        random.Normalize();


        var runAwayPower = 0.0f;
        var runToPower = 0.3f;
        if(runAway.magnitude < 3)
        {
            runAwayPower = 1.0f;
        }

        runAway.Normalize();

        if (rb.position.x > 8.0f || rb.position.x < -8.0f)
        {
            runToPower = 1.6f;
        }
        runTo.Normalize();

        movement = runAway * runAwayPower + runTo * runToPower + random * 0.4f;

        movement.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var target = rb.position + movement * speed * Time.fixedDeltaTime;
        target.x = Mathf.Clamp(target.x, -9.9f, 9.9f);
        target.y = Mathf.Clamp(target.y, -4.9f, 4.9f);

        rb.MovePosition(target);
    }
}
