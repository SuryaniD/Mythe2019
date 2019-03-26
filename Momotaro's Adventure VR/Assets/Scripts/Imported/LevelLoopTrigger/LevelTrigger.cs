using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("ChunkController").GetComponent<LevelController>().SpawnNextChunk();
        Destroy(transform.parent.gameObject);
    }
}
