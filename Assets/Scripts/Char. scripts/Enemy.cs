using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    EnemyControllerScript parentScript;

    void Start()
    {
        parentScript = transform.parent.GetComponent<EnemyControllerScript>();
        Physics.IgnoreCollision(collider, GameObject.FindGameObjectWithTag("Player").collider);
    }

    void OnDestroy()
    {
        if(parentScript.enemiesAlive.Contains(gameObject))
        {
            parentScript.enemiesAlive.Remove(gameObject);
        }
    }

}
