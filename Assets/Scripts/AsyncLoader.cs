using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    void Start()
    {
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;
        yield return new WaitForSeconds(3);
        async.allowSceneActivation = true;

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
