using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif


public enum Estados
{
    idle = 0,
    seguir = 1,
    atacar = 2,
    morir = 3
}

public class Enemigo : MonoBehaviour
{
    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float distanciaEscapar;

    public bool autoseleccionarTarget = true;
    public Transform target;
    public float distancia;

    public bool vivo = true;

    public void Awake()
    {
        if(autoseleccionarTarget) target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CalcularDistancia());
    }

    private void LateUpdate()
    {
        CheckEstado();
    }

    private void CheckEstado()
    {
        switch (estado)
        {
            case Estados.idle:
                EstadoIdle();
                break;
            case Estados.seguir:
                transform.LookAt(target, Vector3.up);
                EstadoSeguir();
                break;
            case Estados.atacar:
                transform.LookAt(target, Vector3.up);
                EstadoAtacar();
                break;
            case Estados.morir:
                EstadoMorir();
                break;
            default:
                break;
        }
    }

    public void CambiarEstado(Estados nuevoEstado)
    {
        switch(nuevoEstado)
        {
            case Estados.idle:
                break;
            case Estados.seguir:
                break;
            case Estados.atacar:
                break;
            case Estados.morir:
                vivo = false;
                break;
            default:
                break;
        }
        estado = nuevoEstado;
    }

    public virtual void EstadoIdle()
    {
        if(distancia > distanciaAtacar && distancia < distanciaEscapar) 
            CambiarEstado(Estados.seguir);
    }
    public virtual void EstadoSeguir()
    {
        if (distancia > distanciaEscapar)
            CambiarEstado(Estados.idle);

        if (distancia < distanciaAtacar)
            CambiarEstado(Estados.atacar);
    }
    public virtual void EstadoAtacar()
    {
        if (distancia > distanciaAtacar + 0.4f) 
            CambiarEstado(Estados.seguir);        
    }
    public virtual void EstadoMorir()
    {
        if (distancia > distanciaSeguir) 
            CambiarEstado(Estados.morir);
    }


    IEnumerator CalcularDistancia()
    {
        while (vivo)
        {
            yield return new WaitForSeconds(0.3f);
            if (target != null) 
                distancia = Vector3.Distance(transform.position, target.position);
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaAtacar);
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaSeguir);
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaEscapar);
    }

#endif

    private void OnDrawGizmos()
    {
        switch (estado)
        {
            case Estados.idle:
                Gizmos.DrawIcon(transform.position + Vector3.up * 2.4f, "detener.png");
                break;
            case Estados.seguir:
                Gizmos.DrawIcon(transform.position + Vector3.up * 2.4f, "caminar.png");
                break;
            case Estados.atacar:
                Gizmos.DrawIcon(transform.position + Vector3.up * 2.4f, "daño.png");
                break;
            case Estados.morir:
                Gizmos.DrawIcon(transform.position + Vector3.up * 2.4f, "muerto.png");
                break;
            default:
                break;
        }

    }

    
}
