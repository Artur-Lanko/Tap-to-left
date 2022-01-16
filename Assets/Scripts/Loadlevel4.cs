using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadlevel4 : MonoBehaviour
{
    public bool enter, isLoad;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadingLevel());
    }

    IEnumerator LoadingLevel()
    {
        isLoad = true;
        AsyncOperation async = Application.LoadLevelAdditiveAsync(4);
        yield return async;

    }
}
