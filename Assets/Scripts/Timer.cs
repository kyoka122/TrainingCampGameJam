using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countTime { get; private set; }
    
    [SerializeField] private Text timerText;

    private float _timeValue;
    
    public void Init(float timeValue)
    {
        _timeValue = timeValue;
    }
    
    public void UpdateTimer()
    {
        // countTimeに、ゲームが開始してからの秒数を格納
        countTime += Time.deltaTime;

        // 小数2桁にして表示
        GetComponent<Text>().text = countTime.ToString("F2");
    }

    public bool IsTimeOver()
    {
        return countTime > _timeValue;
    }
}