using System.Collections.Generic;
using UnityEngine;



public class ColonSpawner : MonoBehaviour
{

    [SerializeField] private GameObject colonPrefab;
    [SerializeField] private float minHeight = 2;
    [SerializeField] private float maxHeight = 2;
    [SerializeField] private float spawnRate = 1.2f;
    [SerializeField] private int poolSize = 8;
    private float time;

    private List<GameObject> colonPool = new List<GameObject>();
    
    private bool isSpawning = false;


    void Start()
    {
        CreatePool();
        time = spawnRate; //early spawn first colon
    }
    void Update()
    {
       
        time += Time.deltaTime;
        if (time > spawnRate)
        {
            SpawnColon();
            time = 0;
        }

    }

    private void OnEnable()
    {
        
        
    }

    

    private void OnDisable()
    {
       

    }


    private void OnGameStart()
    {

        
    }
    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++) { 
        
            GameObject colon = Instantiate(colonPrefab);
            colon.SetActive(false);
            colonPool.Add(colon);
        }
    }

    

    void SpawnColon()
    {
        GameObject colon = GetInactiveColon();
        
        if (colon != null)
        {
            // Turn it on (make it visible)
            colon.SetActive(true);

            // Move it to the spawn position
            colon.transform.position = new Vector3(12, RandomGenerator(), 0);
        }

    }
    GameObject GetInactiveColon()
    {
        foreach (GameObject colon in colonPool)
        {
            if (!colon.activeInHierarchy)
            {
                return colon;
            }
        }
        return null;
    }   

    float RandomGenerator()
    {
        float randomY = Random.Range(-minHeight, maxHeight);
        return randomY;

    }


}