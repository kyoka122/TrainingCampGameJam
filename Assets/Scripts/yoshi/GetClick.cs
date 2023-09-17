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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                foreach (List<Destroyer> spData in spawner.spawnedData.Values)
                {
                    foreach(Destroyer sp in spData)
                    {
                        sp.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
