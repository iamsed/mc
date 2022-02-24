using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementT : MonoBehaviour
{

    public float speed = 5.0f;
    private Transform t;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        t = transform;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(movement.x, movement.y, 0.0f);
        var target = t.position + mov * speed * Time.deltaTime;
        target.x = Mathf.Clamp(target.x, -9.9f, 9.9f);
        target.y = Mathf.Clamp(target.y, -4.9f, 4.9f);

        t.position = target;
    }


}
