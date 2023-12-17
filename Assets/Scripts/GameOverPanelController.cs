    using System;
    using UnityEngine;

    public class GameOverPanelController: MonoBehaviour
    {
        public GameObject gameOverFailurePanel;
        public GameObject gameOverSuccessPanel;
        private void Awake()
        {
            EventManager.OnGameOverFailure += ShowGameOverFailurePanel;
            EventManager.OnGameOverSuccess += ShowGameOverSuccessPanel;
        }

        private void ShowGameOverFailurePanel()
        {
            gameOverFailurePanel.SetActive(true);
        }

        private void ShowGameOverSuccessPanel()
        {
            gameOverSuccessPanel.SetActive(true);
        }
        
        
    }