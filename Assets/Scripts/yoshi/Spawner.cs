using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    bool useObjectPool = true;
    [SerializeField]
    PoolManager poolManager;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int spawnCount;
    [SerializeField]
    float spawnInterval;
    [SerializeField]
    float destroyWaitTime;
    [SerializeField]
    List<Transform> pos = new List<Transform>();

    WaitForSeconds spawnIntervalWait;

    void Start()

    {
        spawnIntervalWait = new WaitForSeconds(spawnInterval);

        StartCoroutine(nameof(SpawnTimer));
    }

    IEnumerator SpawnTimer()
    {
        int i;

        while (true)
        {
            for (i = 0; i < spawnCount; i++)
            {
                Spawn(prefab);
            }

            yield return spawnIntervalWait;
        }
    }

    void Spawn(GameObject prefab)
    {
        Destroyer destroyer;

        for (int i = 0;i < spawnCount; i++)
        {
            if (useObjectPool)
            {
                destroyer = poolManager.GetGameObject(prefab, pos[i].localPosition, Quaternion.identity).GetComponent<Destroyer>();
                destroyer.PoolManager = poolManager;
            }
            else
            {
                destroyer = Instantiate(prefab).GetComponent<Destroyer>();
            }

            if (destroyer != null)
            {
                destroyer.StartDestroyTimer(destroyWaitTime);
            }
        }
    }
}
