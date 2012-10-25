using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour 
{
    public float speed = 30;


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag == "Enemies")
        {
            GameObject.Find("BackGround").GetComponent<GameManager>().bodyCount++;
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}