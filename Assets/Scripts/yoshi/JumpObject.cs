using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpCard", menuName = "JumpCard")]
public class JumpObject : ScriptableObject
{
    public JumpObjectType objectName;
    public float jumpHeight;
    //public float timeToHighestPoint;
    //public Sprite icon;
    public Sprite jumpObjectSprite;
}
