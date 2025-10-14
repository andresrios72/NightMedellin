using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoSandwich : Enemigo
{
    private NavMeshAgent agente;
    public Animator animaciones;

    private void Awake()
    {
        base.Awake();
        agente = GetComponent<NavMeshAgent>();
    }

    override public void EstadoIdle()
    {
        base.EstadoIdle();
        if (animaciones != null) animaciones.SetFloat("velocidad", 0f);
        if (animaciones != null) animaciones.SetBool("atacando", false);
        agente.SetDestination(transform.position);
    }

    override public void EstadoSeguir()
    {
        base.EstadoSeguir();
        if (animaciones != null) animaciones.SetFloat("velocidad", 1f);
        if (animaciones != null) animaciones.SetBool("atacando", false);
        agente.SetDestination(target.position);
    }

    override public void EstadoAtacar()
    {
        base.EstadoAtacar();
        if (animaciones != null) animaciones.SetBool("atacando", true);
        agente.SetDestination(target.position);
    }

    [ContextMenu("Matar")]
    override public void EstadoMorir()
    {
        base.EstadoMorir();
        if (animaciones != null) animaciones.SetBool("vivo", false);
        agente.enabled = false;
    }

    public void Atacar()
    {

    }
}
