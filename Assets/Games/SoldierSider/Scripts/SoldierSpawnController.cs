using UnityEngine;

public class SoldierSpawnController : MonoBehaviour
{
    public float SpawnTimer;
    private float _spawnTimer;

    public Transform[] SpawnPoints;

    public GameObject[] SpawnPrefab;
    void Start()
    {
        _spawnTimer = SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0)
        {
            int RandPoint = Random.Range(0, SpawnPoints.Length);

            int RandPrefab = Random.Range(0, SpawnPrefab.Length);

            Instantiate(SpawnPrefab[RandPrefab], SpawnPoints[RandPoint].position, Quaternion.identity);
            _spawnTimer = SpawnTimer;
        }
    }
}
