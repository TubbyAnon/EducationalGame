using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScript : MonoBehaviour {
    public Sprite image;


    public void LoadLvl(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));        

    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerable LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while ( !operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            

           Color c = GetComponent<SpriteRenderer>().color;
            c.a = progress * 10;
            GetComponent<SpriteRenderer>().color = c;


        }




        yield return null;

    }
    

    
}
