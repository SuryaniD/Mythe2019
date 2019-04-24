using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public Transform resetPos;
    public bool canTeleport = false;

    private GameManagerNew _gManager;

    void Start()
    {
        _gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport && other.gameObject.tag == playerTag)
        {
            other.transform.position = resetPos.position;
            _gManager.SetCurrentGameState(GameStates.BeginState);
        }
    }
}
