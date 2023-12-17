using UnityEngine;

namespace Gameplay
{
    public class GameOverHandler : MonoBehaviour

    {
        public GameObject gameOverPanelParent;
        public GameObject gameOverSuccess;
        public GameObject gameOverFailure;

        private void Awake()
        {
            EventManager.OnGameOverFailure += ShowFailurePanel;
            EventManager.OnGameOverSuccess += ShowSuccessPanel;
        }

        private void ShowFailurePanel()
        {
            gameOverPanelParent.SetActive(true);
            gameOverFailure.SetActive(true);
        }

        private void ShowSuccessPanel()
        {
            gameOverPanelParent.SetActive(true);
            gameOverSuccess.SetActive(true);
        }
    }
}