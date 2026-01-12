using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    [SerializeField] PlayerData initialPlayerData;

    int hearts = 3;
    VisualElement pauseOverlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement characterInfoBox = uiDocument.rootVisualElement.Q<VisualElement>("CharacterInfo");
        characterInfoBox.dataSource = initialPlayerData;
        pauseOverlay = uiDocument.rootVisualElement.Q<VisualElement>("Pause");

        Button pauseButton = uiDocument.rootVisualElement.Q<Button>("PauseButton");
        Button resumeButton = uiDocument.rootVisualElement.Q<Button>("ResumeButton");

        pauseButton.clicked += OnPauseClicked;
        resumeButton.clicked += OnResumeClicked;
    }

    void OnPauseClicked()
    {
        pauseOverlay.visible = true;
        Time.timeScale = 0f;
    }

    void OnResumeClicked()
    {
        pauseOverlay.visible = false;
        Time.timeScale = 1f;
    }

    void OnPause()
    {
        if(pauseOverlay.visible)
        {
            OnResumeClicked();
        }
        else
        {
            OnPauseClicked();
        }
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null && keyboard.hKey.wasPressedThisFrame)
        {
            hearts -= 1;
            if (hearts < 0)
            {
                hearts = 0;
            }
            UpdateHearts();
        }

        if(keyboard != null && (keyboard.pKey.wasPressedThisFrame || keyboard.escapeKey.wasPressedThisFrame))
        {
            OnPause();
        }   
    }

    private void UpdateHearts()
    {
        VisualElement heartsContainer = uiDocument.rootVisualElement.Q<VisualElement>("HeartsInfo");
        for (int i = 0; i < heartsContainer.childCount; i++)
        {
            VisualElement hearImage = heartsContainer[i];
            bool visible = i < hearts;
            hearImage.visible = visible;

        }
    }
}
