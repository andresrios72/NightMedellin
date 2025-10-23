using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoTrash : Enemigo
{
    private NavMeshAgent agente;
    public Animator animaciones;
    public float damageAmount = 4f;
    public Transform[] checkPoints;    
    private int indiceCP;
    public float distanciaMinimaCP = 1f;
    private float distanciaCP2;

    private void Awake()
    {
        base.Awake();
        agente = GetComponent<NavMeshAgent>();
        distanciaCP2 = distanciaMinimaCP * distanciaMinimaCP;
    }

    override public void EstadoIdle()
    {
        base.EstadoIdle();
        if (animaciones != null) animaciones.SetFloat("velocidad", 1f);
        if (animaciones != null) animaciones.SetBool("atacando", false);
        agente.SetDestination(checkPoints[indiceCP].position);
        if ((checkPoints[indiceCP].position - transform.position).sqrMagnitude < distanciaCP2)
        {
            indiceCP = (indiceCP + 1) % checkPoints.Length;
        }
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
        Personaje.singleton.vida.CausarDanio(damageAmount);
    }
}
