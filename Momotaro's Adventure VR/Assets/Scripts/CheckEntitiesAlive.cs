using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEntitiesAlive : MonoBehaviour
{
    

    /// <summary>
    /// Checks the abount of alive entities by team in a pool
    /// </summary>
    /// <param name="_pool"></param>
    /// <param name="_team"></param>
    /// <returns></returns>
    public int CheckAmountEntitiesAlive(GameObject _pool, teamTypes _team)
    {
        int _amount = 0;

        foreach (GameObject _object in _pool.transform)
        {
            if (_object.GetComponent<Entity>() != null && _object.GetComponent<Entity>().teamCurrent == _team && _object.GetComponent<Entity>().entityStateCurrent == entityStates.Alive)
            {
                _amount++;
            }
        }
            _amount++;


        return _amount;
    }

}
