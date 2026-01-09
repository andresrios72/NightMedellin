using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public static Personaje singleton;
    //public Animator animaciones;

    public Vida vida;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void Morir()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Death");

        GetComponent<ThirdPersonController>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
    }


}
