using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewTimeCounter : MonoBehaviour
{
    public float totalTimeInSeconds = 90.0f; // 制限時間を1分30秒（90秒）に設定
    private float currentTime;

    public TextMeshProUGUI timeText;

    private void Start()
    {
        currentTime = totalTimeInSeconds;
        UpdateTimeText();
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }

        // 制限時間が0になったときの処理
        timeText.text = "終了です";
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int milliseconds = Mathf.FloorToInt((currentTime * 100) % 100);
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timeText.text = timeString;
    }
}




