using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class GetClick : MonoBehaviour
{
    [SerializeField]
    Spawner spawner;
    [SerializeField]
    int cardNum;

    public JumpObjectType? TryGetJumpObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                var isJumpCard =  hit2d.transform.gameObject.GetComponent<Destroyer>()?.jumpObjectType;
                if(isJumpCard == null) return null;

                foreach (List<Destroyer> spData in spawner.spawnedData.Values)
                {
                    foreach(Destroyer sp in spData)
                    {
                        sp.gameObject.SetActive(false);
                    }
                }
                Debug.Log(isJumpCard.Value);
                return isJumpCard;
            }
        }
        return null;
    }

    private void Update()
    {
        TryGetJumpObject();
    }
}
