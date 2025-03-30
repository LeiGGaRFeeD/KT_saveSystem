using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    void Update()
    {
        scoreText.text = $"Очки: {GameManager.Instance.gameData.score:F1}";
        timeText.text = $"Время: {GameManager.Instance.gameData.playTime:F1} сек";
    }
}
