using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="JumpCardData",menuName ="JumpCard")]
public class JumpCard : ScriptableObject
{ 
    public string cardName;
    public string cardType;
    public int cardNumber;
}
