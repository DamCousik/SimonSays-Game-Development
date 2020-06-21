using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform path_ground;
    private Vector3 nextTileSpawn;

    void Start()
    {
        nextTileSpawn.z = 24;
        nextTileSpawn.y = 3;
        StartCoroutine(spawnTile());
    }

    void Update()
    {

    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        Instantiate(path_ground, nextTileSpawn, path_ground.rotation);
        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }
}
