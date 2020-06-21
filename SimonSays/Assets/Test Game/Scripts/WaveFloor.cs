using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFloor : MonoBehaviour
{
    public Transform waveFloor;
    private Vector3 nextTileSpawn;

    void Start()
    {
        nextTileSpawn.z = 24;
        StartCoroutine(spawnTile());
    }

    void Update()
    {

    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(60);
        Instantiate(waveFloor, nextTileSpawn, waveFloor.rotation);
        nextTileSpawn.z += 400;
        StartCoroutine(spawnTile());
    }
}
