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
    }
    void Update()
    {
        if (!isSpawning) return;

        time += Time.deltaTime;
        if (time > spawnRate)
        {
            SpawnColon();
            time = 0;
        }

    }

    private void OnEnable()
    {
        GameEvents.OnGameStart += StartSpawning;
        GameEvents.OnGameReset += ResetSpawning;
        GameEvents.OnGameEnd += StopSpawning;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= StartSpawning;
        GameEvents.OnGameReset -= ResetSpawning;
        GameEvents.OnGameEnd -= StopSpawning;
    }
    private void StartSpawning() => isSpawning = true;
    private void StopSpawning() => isSpawning = false;

    private void ResetSpawning()
    {
        isSpawning = false;
        ResetAllColons();
        time = spawnRate;
    }
    private void ResetAllColons()
    {
        foreach (GameObject colon in colonPool)
        {
            colon.SetActive(false);
        }
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
            colon.SetActive(true);

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