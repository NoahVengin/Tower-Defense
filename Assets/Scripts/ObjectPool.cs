using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.5f, 10.0f)] float spawnRate = 1.0f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            EnableObjectInPool();   
        }
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(objectToSpawn, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach(GameObject obj in pool)
        {
            if(!obj.activeSelf)
            {
                obj.SetActive(true);
                return;
            }
        }
    }
}
