using System.Collections.Generic;
using Character;
using InGameManagerStates;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class InGameData:MonoBehaviour
{
    public List<InGameStateData> stateData;
    public JumpCharacterHeightModel character;
    public BorderLine borderLine;
    public GameObject borderLineView;
    public float borderLineUnderLength;
    public float borderLineDisplayLength;
    public float jumpPower;
    public TimeCounter timer;
    public InGameUI inGameUI;
    public Spawner spawner;
    public GetClick getClick;
    public Image jumpObjectBase;
        
    public float gameTime;
    public CardData cardData;
}