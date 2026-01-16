using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personaje : MonoBehaviour
{
    public static Personaje singleton;
    public Vida vida;

    private Animator anim;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            DestroyImmediate(gameObject);

        anim = GetComponent<Animator>();
    }

    void Start()
    {
        var controller = GetComponent<ThirdPersonController>();

        controller.enabled = false;
        controller.enabled = true;
    }


    public void Morir()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Death");

        GetComponent<ThirdPersonController>().enabled = false;
        GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
    }


    public void Revivir()
    {
        vida.ReiniciarVida(); // o como lo llames

        Animator anim = GetComponent<Animator>();
        anim.Rebind();
        anim.Update(0f);

        GetComponent<ThirdPersonController>().enabled = true;

        PlayerInput input = GetComponent<PlayerInput>();
        input.SwitchCurrentActionMap("Player");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
