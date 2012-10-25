using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
    public int level = 1;

    public GameObject ePrefab;
    public float spawnCD = 3f;
    public bool spawning;

    public IEnumerator spawnNewUnits()
    {
        spawning = true;
        yield return new WaitForSeconds(spawnCD);

        GameObject enemyCreated = null;

        for (int i = 0; i < 3; i++)
        {
            for (float f = -6; f < 4f; f += 1.5f)
            {
                enemyCreated = (GameObject)Instantiate(ePrefab, transform.position + new Vector3(f, i, 0), Quaternion.identity);
                enemyCreated.transform.parent = transform;
                GetComponent<EnemyControllerScript>().enemiesAlive.Add(enemyCreated);
            }
        }
        level++;
        spawning = false;
    }
}
