using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float speed = 10;
    public GameObject bullet;
    bool shotCD = false;

    const int gameBorder = 6;
    const float shotCDTime = 0.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shotCD == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            shotCD = true;
            StartCoroutine(shotCoolDown());
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            if (transform.position.x < -gameBorder)
            {
                transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
	    {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            if (transform.position.x > gameBorder)
            {
                transform.position = new Vector3(6f, transform.position.y, transform.position.z);
            }
	    }
    }

    IEnumerator shotCoolDown()
    {
        yield return new WaitForSeconds(shotCDTime);
        shotCD = false;
    }
}
