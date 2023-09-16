using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "JumpObjectData", menuName = "JumpObject")]
public class JumpObject : ScriptableObject
{
    public string objectName;
    public float jumpHeight;
    public float timeToHighestPoint;
}
