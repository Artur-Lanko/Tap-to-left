using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadlevel2 : MonoBehaviour
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
        AsyncOperation async = Application.LoadLevelAdditiveAsync(2);
        yield return async;

    }

}
