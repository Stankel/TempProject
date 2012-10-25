using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float speed = 10;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            if (transform.position.x < -6f)
            {
                transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
	    {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            if (transform.position.x > 6f)
            {
                transform.position = new Vector3(6f, transform.position.y, transform.position.z);
            }
	    }
    }

}
