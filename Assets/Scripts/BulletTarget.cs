using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    public Vida vida;
    public Enemigo enemigo;

    private void Awake()
    {
        if (vida == null)
            vida = GetComponentInParent<Vida>();

        if (enemigo == null)
            enemigo = GetComponentInParent<Enemigo>();
    }

    public void RecibirDanio(int cantidad)
    {
        if (vida == null) return;

        vida.CausarDanio(cantidad);
    }
}
