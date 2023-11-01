using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    public List<GameObject> pooledOjbects;
    public List<GameObject> objectsToPool;
    public int amountToPool;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPooledObjects();
    }

    void SetPooledObjects()
    {
        pooledOjbects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Count)]);
            obj.SetActive(false);
            pooledOjbects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledOjbects.Count; i++)
        {
            if (!pooledOjbects[i].activeInHierarchy)
            {
                return pooledOjbects[i];
            }

        }
        return null;
    }

}
