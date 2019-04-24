using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoopManager : MonoBehaviour
{
    private ColliderTrigger _trigger;
    private GameManagerNew _gManager;

    // Start is called before the first frame update
    void Start()
    {
        _trigger = transform.GetChild(0).gameObject.GetComponent<ColliderTrigger>();
        _gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_gManager.gameStateCurrent == GameStates.WinState)
            _trigger.canTeleport = true;
        else
            _trigger.canTeleport = false;
    }
}
