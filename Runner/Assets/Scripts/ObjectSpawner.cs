using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Values")]
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float spawnInterval;

    private float x, y, z;

    private float spawnTimer;

    [Space]
    public int[] lanes;

    int spawnIndex;



    private void Start()
    {
        Init();
    }

    public void Init()
    {
        spawnTimer = 0;
        lanes = new int[] { -4, 0, 4 };
        spawnIndex = 0;

        z = 160;
    }

    private void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            Spawn();
            spawnTimer = 0;
        }

    }

    private void Spawn()
    {

        //get Z value
        int _z = 0;
        if (spawnIndex == 0)
        {
            _z = -4;
            spawnIndex++;
        }
        else if (spawnIndex == 1)
        {
            _z = 0;
            spawnIndex++;
        }
        else
        {
            _z = 4;
            spawnIndex = 0;
        }

        Vector3 _spawnpos = new Vector3(lanes[spawnIndex], y, z);
        GameObject _spawn = Instantiate(spawnObject, _spawnpos, Quaternion.identity);
    }
}
