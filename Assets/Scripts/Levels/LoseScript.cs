using UnityEngine;
using System.Collections;

public class LoseScript : MonoBehaviour 
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            Application.LoadLevel(2);
        }
    }
}