using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class StartButtonManager : MonoBehaviour
{
    [SerializeField]private Button start;
    // Start is called before the first frame update

    void Start()
    {
        start.onClick.AddListener(MoveScean);
    }

    // Update is called once per frame

    void MoveScean()
    {
        SceneManager.LoadScene("New Scene(1)");
    }

}
