//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GameOverManager : MonoBehaviour
//{
//    public GameObject gameOverUI;

//    private bool gameOverActivo = false;

//    void Start()
//    {
//        gameOverUI.SetActive(false);
//    }

//    public void ActivarGameOver()
//    {
//        gameOverUI.SetActive(true);
//        Time.timeScale = 0f;
//        gameOverActivo = true;
//    }

//    void Update()
//    {
//        if (!gameOverActivo) return;

//        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
//        {
//            Time.timeScale = 1f;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//        }
//    }
//}


using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void MostrarGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
