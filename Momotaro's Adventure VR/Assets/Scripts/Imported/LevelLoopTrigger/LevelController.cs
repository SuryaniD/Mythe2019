using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // active part
    public List<GameObject> partLst = new List<GameObject>();
    // random chunks
    public List<GameObject> allParts = new List<GameObject>();
    private float allPartSize = 0;

    // placeholders or object for instantiation of class and systems
    public GameObject temp1, temp2, temp3;


    void Start()
    {
        // get the curent ones in the list
        partLst.Add(temp1);
        partLst.Add(temp2);
        partLst.Add(temp3);
        // get the size of all chunks
        foreach (GameObject chunk in allParts)
        {
            allPartSize++;
        }
    }

    void Update()
    {

    }

    public void SpawnNextChunk()
    {
        // spawn the new chunk
        Vector3 nextSpawnPos = partLst[2].transform.position;
        nextSpawnPos.z += 64;
        partLst.Add(allParts[Mathf.FloorToInt(Random.value * allPartSize)]);
        partLst[3].transform.position = nextSpawnPos;
        Instantiate(partLst[3]);

        // delete previous chunk
        Destroy(partLst[0]);
        partLst.RemoveAt(0);
    }
}
