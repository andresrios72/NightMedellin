using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Hearts (Intentos)")]
    [SerializeField] Image[] hearts;

    [Header("Player Data")]
    [SerializeField] PlayerData currentPlayerData;

    [Header("Player UI")]
    [SerializeField] Image playerPortrait;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text playerClassText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdatePlayerUI();
    }

    // -------------------------
    // HEARTS
    // -------------------------
    public void ActualizarCorazones(int corazonesRestantes)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < corazonesRestantes;
        }
    }

    // -------------------------
    // PLAYER DATA UI
    // -------------------------
    public void SetPlayerData(PlayerData newPlayerData)
    {
        currentPlayerData = newPlayerData;
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        if (currentPlayerData == null) return;

        if (playerPortrait != null)
            playerPortrait.sprite = currentPlayerData.playerPortrait;

        if (playerNameText != null)
            playerNameText.text = currentPlayerData.playerName;

        if (playerClassText != null)
            playerClassText.text = currentPlayerData.playerClass;
    }
}
