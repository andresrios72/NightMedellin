using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public string startScene;
    private AsyncOperation preloadOp;

    void Start()
    {
        //Carga la escena en segundo plano.
        StartCoroutine(PreloadScene());
    }

    IEnumerator PreloadScene()
    {
        preloadOp = SceneManager.LoadSceneAsync(startScene);
        preloadOp.allowSceneActivation = false; // NO la activa, solo la precarga.
        yield return null;
    }

    public void ChangeScene()
    {
        // Aquí ya está precargada.
        preloadOp.allowSceneActivation = true;
    }
}
