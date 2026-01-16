using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Intentos")]
    public int corazonesIniciales = 3;
    private int corazonesActuales;

    [Header("Referencias")]
    public Transform spawnPoint;
    public GameOverManager gameOverManager;

    private Personaje player;

    private Transform checkpointActual;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start()
    {
        corazonesActuales = corazonesIniciales;
        player = Personaje.singleton;

        UIManager.instance.ActualizarCorazones(corazonesActuales);
    }


    public void OnPlayerDeath()
    {
        corazonesActuales--;

        // Actualizar UI
        UIManager.instance.ActualizarCorazones(corazonesActuales);

        player.Morir();

        if (corazonesActuales > 0)
        {
            StartCoroutine(RespawnCoroutine());
        }
        else
        {
            ActivarGameOver();
        }
    }


    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(2f);

        // Reset vida
        player.vida.ReiniciarVida();

        // Posición
        Transform puntoRespawn = checkpointActual != null ? checkpointActual : spawnPoint;
        player.transform.position = puntoRespawn.position;
        player.transform.rotation = puntoRespawn.rotation;

        // Revivir (anim + control)
        player.Revivir();
    }


    void ActivarGameOver()
    {
        gameOverManager.MostrarGameOver();
    }

    public void SetCheckpoint(Transform nuevoCheckpoint)
    {
        checkpointActual = nuevoCheckpoint;
    }

}
