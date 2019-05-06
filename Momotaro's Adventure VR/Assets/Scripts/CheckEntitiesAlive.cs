using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEntitiesAlive : MonoBehaviour
{
    

    /// <summary>
    /// Checks the abount of alive entities by team in a list and returns the amount
    /// </summary>
    /// <param name="_pool"></param>
    /// <param name="_team"></param>
    /// <returns></returns>
    public int CheckAmountEntitiesAlive(List<GameObject> _pool, TeamTypes _team)
    {
        int _amount = 0;

        for (int _i = 0; _i < _pool.Count; _i++)
        {
            GameObject _obj = _pool[_i];

            if (_obj != null && _obj.GetComponent<Entity>() != null && _obj.GetComponent<Entity>().teamCurrent == _team && _obj.GetComponent<Entity>().entityStateCurrent == EntityStates.Alive)
            {
                //Increase the amount
                _amount++;
            }
        }

        print("Entities Alive: " + _amount.ToString());

        return _amount;
    }

}
