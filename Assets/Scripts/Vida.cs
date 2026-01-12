using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;

    public UnityEvent EventoMorir;

    private bool estaMuerto = false; 

    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void CausarDanio(int cantidad)
    {
        if (estaMuerto) return; 

        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }
    }

    private void Morir()
    {
        if (estaMuerto) return; 
        estaMuerto = true;
        EventoMorir?.Invoke();
    }

    public bool EstaMuerto()
    {
        return estaMuerto;
    }
}
