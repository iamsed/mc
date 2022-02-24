using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSystemTransform : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public Transform[] rb;

    public float touchDistance;

    Vector2[] movement;
    bool[] moving;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2[rb.Length];
        moving = new bool[rb.Length];

        for (int i = 0; i < rb.Length; i++)
        {
            moving[i] = true;
        }
    }

    void Update()
    {
        var playerPosition = player.position;
        for (int i = 0; i < rb.Length; i++)
        {
            if (!moving[i]) continue;

            var posX = rb[i].position.x;
            var posY = rb[i].position.y;
            Vector2 runAway = new Vector2();
            runAway.x = posX - playerPosition.x;
            runAway.y = posY - playerPosition.y;

            Vector2 goal = new Vector2();

            Vector2 runTo = new Vector2();
            runTo.x = goal.x - posX;
            runTo.y = goal.y - posY;


            Vector2 random = Random.insideUnitCircle;
            random.Normalize();


            var runAwayPower = 0.0f;
            var runToPower = 0.3f;

            if (runAway.magnitude < touchDistance)
            {
                moving[i] = false;
            }

            if (runAway.magnitude < 3)
            {
                runAwayPower = 1.0f;
            }

            runAway.Normalize();

            if (posX > 8.0f || posX < -8.0f)
            {
                runToPower = 1.6f;
            }
            runTo.Normalize();

            movement[i] = runAway * runAwayPower + runTo * runToPower + random * 0.4f;

            movement[i].Normalize();

            Vector3 mov = new Vector3(movement[i].x, movement[i].y, 0.0f);
            var target = rb[i].position + mov * speed * Time.deltaTime;
            target.x = Mathf.Clamp(target.x, -9.9f, 9.9f);
            target.y = Mathf.Clamp(target.y, -4.9f, 4.9f);

            rb[i].position = target;
        }


    }
}
