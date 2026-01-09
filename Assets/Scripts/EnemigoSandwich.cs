using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoSandwich : Enemigo
{
    private NavMeshAgent agente;
    public Animator animaciones;
    public int damageAmount = 10;

    private void Awake()
    {
        base.Awake();
        agente = GetComponent<NavMeshAgent>();
    }

    override public void EstadoIdle()
    {
        base.EstadoIdle();
        if (animaciones != null) animaciones.SetFloat("Velocidad", 0f);
        if (animaciones != null) animaciones.SetBool("Atacando", false);
        agente.SetDestination(transform.position);
    }

    override public void EstadoSeguir()
    {
        base.EstadoSeguir();
        if (animaciones != null) animaciones.SetFloat("Velocidad", 1f);
        if (animaciones != null) animaciones.SetBool("Atacando", false);
        agente.SetDestination(target.position);
    }

    override public void EstadoAtacar()
    {
        base.EstadoAtacar();
        if (animaciones != null) animaciones.SetBool("Atacando", true);
        agente.SetDestination(target.position);
    }

    [ContextMenu("Matar")]
    override public void EstadoMorir()
    {
        base.EstadoMorir();
        if (animaciones != null) animaciones.SetBool("Vivo", false);
        agente.enabled = false;
    }

    public void AplicarDanio()
    {
        if (target == null) return;

        Vida vidaObjetivo = target.GetComponent<Vida>();
        if (vidaObjetivo == null) return;

        //Debug.Log("DAÑO APLICADO POR ANIMACION");
        vidaObjetivo.CausarDanio(damageAmount);
    }
}
