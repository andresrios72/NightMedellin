using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activado) return;

        if (other.CompareTag("Player"))
        {
            activado = true;
            GameManager.instance.SetCheckpoint(transform);

            // (Opcional) feedback visual
            Debug.Log("Checkpoint activado");
        }
    }
}
