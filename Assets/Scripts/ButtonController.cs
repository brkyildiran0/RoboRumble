using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController: MonoBehaviour
{
    public Button resetButton;
    public Button manualTickButton;
    public Button automatictickButton;

    private bool _isAutomatic = false;
    private void Awake()
    {
        automatictickButton.onClick.AddListener(OnAutomaticButtonClicked);
        manualTickButton.onClick.AddListener(OnManualButtonClicked);
        EventManager.OnTick += SetManualButtonInteractability;
        resetButton.onClick.AddListener(OnResetButtonClicked);
    }

    private void SetManualButtonInteractability()
    {
        manualTickButton.interactable = !_isAutomatic;
    }

    private void OnAutomaticButtonClicked()
    {
        _isAutomatic = !_isAutomatic;
        if (_isAutomatic)
        {
            automatictickButton.GetComponent<Image>().color = Color.green;
            manualTickButton.interactable = false;
        }
        else
        {
            automatictickButton.GetComponent<Image>().color = Color.white;
        }
        EventManager.AutomaticTickButtonPressed();
    }

    private void OnManualButtonClicked()
    {
        EventManager.ManualTickButtonPressed();
    }

    private void OnResetButtonClicked()
    {
        EventManager.ResetButtonPressed();
    }
    
    
    
    
}