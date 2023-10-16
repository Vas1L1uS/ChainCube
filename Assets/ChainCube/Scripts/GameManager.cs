using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<int> Score_Changed;
    public event Action GameOver_notifier;

    public int Score => _score;

    private int _score;

    public void AddScore(int value)
    {
        if (value <= 0) return;

        _score += value;

        Score_Changed?.Invoke(Score);
    }

    public void GameOver()
    {
        GameOver_notifier?.Invoke();
    }
}