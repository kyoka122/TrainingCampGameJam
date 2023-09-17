using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornSounds2 : MonoBehaviour
{
    //hornsoundは任意の名前でOKです、それ以外は変えないでください。
    private AudioSource hornsound;

    void Start()
    {
        hornsound = GetComponent<AudioSource>();
    }
    //ボタンをクリックした時のスクリプトです。
    public void OnClick()
    {
        hornsound.PlayOneShot(hornsound.clip);
    }
}