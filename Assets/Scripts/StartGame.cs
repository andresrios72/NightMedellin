using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public string startScene;
    private AsyncOperation preloadOp;

    void Start()
    {
        StartCoroutine(PreloadScene());

        // Asegura estado inicial correcto
        UnlockCursor();
    }

    IEnumerator PreloadScene()
    {
        preloadOp = SceneManager.LoadSceneAsync(startScene);
        preloadOp.allowSceneActivation = false;
        yield return null;
    }

    public void ChangeScene()
    {
        // 🔒 Bloquea ANTES de activar la escena
        LockCursor();

        preloadOp.allowSceneActivation = true;
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

