using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    public float vidaInicial;
    public float vidaActual;
    public UnityEvent eventoMorir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaInicial;
    }

    // Update is called once per frame
    public void CausarDanio(float cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            eventoMorir.Invoke();
        }
    }
}
