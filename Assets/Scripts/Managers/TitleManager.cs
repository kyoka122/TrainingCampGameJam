using System;
using KanKikuchi.AudioManager;
using UnityEngine;

namespace Managers
{
    public class TitleManager : MonoBehaviour
    {
        private void Start()
        {
            BGMManager.Instance.Play(BGMPath.TITLE_BGM,0.6f);
        }





    }
}
