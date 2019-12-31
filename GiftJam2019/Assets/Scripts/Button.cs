using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string SceneName;
    public AudioSource AS;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        StartCoroutine(LoadYourAsyncScene());
        if(AS != null)
        {
            AS.Play();
        }
    }
    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
