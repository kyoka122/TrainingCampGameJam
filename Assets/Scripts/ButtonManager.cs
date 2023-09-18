using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject soundPanel;
    // Start is called before the first frame update

    void Start()
    {
        //startButton.onClick.AddListener(GameScene);
        //sound.onClick.AddListener(SoundScene);
    }

    public void GameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Sound()
    {
        soundPanel.SetActive(true);
    }

    public void Close()
    {
        soundPanel.SetActive(false);
    }

}
