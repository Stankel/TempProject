using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControllerScript : MonoBehaviour 
{
    Vector3 startPosition;
    public float XSpeed = 3f;
    public float YSpeed = 0.05f;
    const float YSpeedModifier = 0.1f;
    public bool movingRight;
    [HideInInspector]
    public List<GameObject> enemiesAlive;

    Transform leftMostAlien;
    Transform rightMostAlien;

    void Start()
    {
        startPosition = transform.position;

        enemiesAlive = new List<GameObject>();
        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            enemiesAlive.Add(transform.GetChild(i).gameObject);
        }
        movingRight = true;

        leftMostAlien = enemiesAlive[0].transform;
        rightMostAlien = enemiesAlive[0].transform;
        
    }
    void Update()
    {
        if (enemiesAlive.Count < 1 && !GetComponent<Spawn>().spawning)
            {
                transform.position = startPosition;
                StartCoroutine(GetComponent<Spawn>().spawnNewUnits());
                YSpeed = YSpeedModifier * GetComponent<Spawn>().level;
                print(YSpeed);
            }
        if (enemiesAlive.Count >= 1)
        {
            if (rightMostAlien == null)
                rightMostAlien = enemiesAlive[0].transform;
            if (leftMostAlien == null)
                leftMostAlien = enemiesAlive[0].transform;

            foreach (GameObject e in enemiesAlive)
            {
                if (e != null)
                {
                    if (e.transform.position.x > rightMostAlien.position.x)
                    {
                        rightMostAlien = e.transform;
                    }
                    if (e.transform.position.x < leftMostAlien.position.x)
                    {
                        leftMostAlien = e.transform;
                    }
                }
            }
            if (leftMostAlien.position.x < -6f)
            {
                movingRight = true;
            }
            if (rightMostAlien.position.x > 6f)
            {
                movingRight = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (movingRight && !GetComponent<Spawn>().spawning)
        {
            transform.Translate(new Vector3(1 * XSpeed * Time.fixedDeltaTime, -1 * YSpeed * Time.fixedDeltaTime, 0));
        }
        else if (!movingRight && !GetComponent<Spawn>().spawning)
        {
            transform.Translate(new Vector3(-1 * XSpeed * Time.fixedDeltaTime, -1 * YSpeed * Time.fixedDeltaTime, 0));
        }
    }
}
