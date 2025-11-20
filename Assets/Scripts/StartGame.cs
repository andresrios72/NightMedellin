using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string startScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(startScene);
    }
}
