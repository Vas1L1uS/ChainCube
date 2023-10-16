using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private Text _scoreValue;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager.Score_Changed += SetNewScoreValue;
        _gameManager.GameOver_notifier += ShowGameOverPanel;
    }

    private void SetNewScoreValue(int value)
    {
        _scoreValue.text = value.ToString();
    }

    private void ShowGameOverPanel()
    {
        _gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}