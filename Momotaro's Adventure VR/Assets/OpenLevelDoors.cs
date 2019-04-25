using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelDoors : MonoBehaviour
{

    public List<ObjectAnimateTo> _doors = new List<ObjectAnimateTo>();


    public void OpenDoors(float _speed)
    {
        for (int _i = 0; _i < _doors.Count; _i++)
        {
            _doors[_i].AnimateToEndPoint(_speed);
        }
    }

    public void CloseDoors(float _speed)
    {
        for (int _i = 0; _i < _doors.Count; _i++)
        {
            _doors[_i].AnimateToStartPoint(_speed);
        }
    }

}
