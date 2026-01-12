using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void RestartGame()
    {
        // Lógica para reiniciar el juego
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);


    }

    public void QuitGame()
    {
        // Lógica para salir del juego
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
