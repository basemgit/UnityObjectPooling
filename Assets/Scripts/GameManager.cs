using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            // instead of instantiating a prefab, we get it from the pool
            GameObject pooledObject = ObjectPooler.Instance.GetPooledObject();
            if (pooledObject != null)
            {
                pooledObject.SetActive(true);
            }
        }
    }

}
