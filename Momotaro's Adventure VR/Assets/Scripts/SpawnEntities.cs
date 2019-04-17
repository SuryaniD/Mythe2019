using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    
    /// <summary>
    /// Spawns an GameObject on a position
    /// </summary>
    /// <param name="_object"></param>
    /// <param name="_position"></param>
    /// <returns></returns>
    public GameObject SpawnEntity(GameObject _object, Vector3 _position)
    {
        GameObject _inst = Instantiate<GameObject>(_object);
        _inst.transform.position = _position;

        return _inst;
    }


}
