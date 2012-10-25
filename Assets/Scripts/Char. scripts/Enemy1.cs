using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour 
{
    public float speed = 5;
    bool movingRight = true;

    void FixedUpdate()
    {
        if (transform.position.x >= 6.4f)
        {
            movingRight = false;
        }
        if (transform.position.x <= -6.4f)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
    }
}
