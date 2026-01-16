using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Hearts (Intentos)")]
    [SerializeField] Image[] hearts;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ActualizarCorazones(int corazonesRestantes)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < corazonesRestantes;
        }
    }
}
