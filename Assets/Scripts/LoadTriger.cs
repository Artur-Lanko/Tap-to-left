using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTriger : MonoBehaviour
{
    public string SceneName;

    [System.Obsolete]
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevelAdditive(SceneName); 
        }
    }

}
