using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public int bodyCount = 0;
    Spawn spawnScript;
    EnemyControllerScript eControlScript;
    int timeSinceStart = 0;
    float timeAtLevelLoad;
    public Texture2D image;
   
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        timeSinceStart = (int)(Time.realtimeSinceStartup - timeAtLevelLoad);
        if (Input.GetKeyDown(KeyCode.Return) && Application.loadedLevel == 0)
        {
            Application.LoadLevel(1);
        }
    }

    void OnGUI()
    {
        if (Application.loadedLevel == 0)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.ScaleAndCrop, true);
            if (GUI.Button(new Rect((Screen.width / 2)-50, (Screen.height / 2)-30, 100, 60), "Start Game"))
            {
                Application.LoadLevel(1);
            }
        }
        if (Application.loadedLevel == 1)
        {
            GUI.Label(new Rect(0, 25, 100, 20), "Score: " + bodyCount);
            GUI.Label(new Rect(0, 0, 100, 20), "Level: " + spawnScript.level);
            GUI.Label(new Rect(Screen.width - 150, 0, 150, 20), "Enemies remaining: " + eControlScript.enemiesAlive.Count);
            GUI.Label(new Rect(Screen.width - 150, 25, 150, 20), "Time passed: " + timeSinceStart + " s");
        }
        if (Application.loadedLevel == 2)
        {
            
        }
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevel == 1)
        {
            eControlScript = GameObject.Find("EnemyControl").GetComponent<EnemyControllerScript>();
            spawnScript = GameObject.Find("EnemyControl").GetComponent<Spawn>();
            timeAtLevelLoad = Time.timeSinceLevelLoad;
        }
    }

}
