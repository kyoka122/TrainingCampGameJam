using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "JumpObjectData", menuName = "JumpObject")]
public class JumpObject : ScriptableObject
{
    public string objectName;
    public float jumpHeight;
    public float timeToHighestPoint;
    public List<int>id = new List<int>();
    public Sprite icon;
    public Sprite jumpObjectSprite;
}
