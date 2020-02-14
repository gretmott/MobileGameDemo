using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLoading : MonoBehaviour
{

    private bool loadScene = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    public Text loadingText;


    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        // ...set the loadScene boolean to true to prevent loading a new scene more than once...
        loadScene = true;

        // ...change the instruction text to read "Loading..."
        loadingText.text = "Loading...";

        // ...and start a coroutine that will load the desired scene.
        StartCoroutine(LoadNewScene());

        // If the new scene has started loading...
        if (loadScene == true)
        {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));



        }
    }

    IEnumerator LoadNewScene()
        {

            // This line waits for 3 seconds before executing the next line in the coroutine.
            // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
            //yield return new WaitForSeconds(1);

            // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
            AsyncOperation async = Application.LoadLevelAsync(scene);

            // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
            while (!async.isDone)
            {
                yield return null;
            }

        }
    }

