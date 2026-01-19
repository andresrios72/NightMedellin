using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverUI;
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        gameOverUI.SetActive(false);

        // Asignación de botones
        if (startButton != null)
            startButton.onClick.AddListener(RestartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    public void MostrarGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

        // Liberar cursor para UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
