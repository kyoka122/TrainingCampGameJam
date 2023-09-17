using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class PoolManager : MonoBehaviour
{
    ObjectPool<GameObject> pool;
    public GameObject Prefab { get; private set; }

    void Awake()
    {
        pool = new ObjectPool<GameObject>(OnCreatePooledObject, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
    }

    GameObject OnCreatePooledObject()
    {
        return Instantiate(Prefab);
    }


    public void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }    

    public void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);   
    }

    public GameObject GetGameObject(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        Prefab = prefab;
        GameObject obj=pool.Get();
        Transform tf = obj.transform;
        tf.position = position;
        tf.rotation = rotation;   

        return obj;
    }

    public void ReleaseGameObject(GameObject obj)
    {
        pool.Release(obj);
    }
}
