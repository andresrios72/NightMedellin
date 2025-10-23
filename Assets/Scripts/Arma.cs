using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject armaActivar;
    public Animator animaciones;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            armaActivar.SetActive(true);
            gameObject.SetActive(false);
            animaciones.SetBool("Arma", true);
        }
    }
}
