using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameStates
{
    BeginState,
    InGameState,
    WinState,
    LoseState
}

public class GameManagerNew : MonoBehaviour
{
    public GameStates gameStateCurrent = GameStates.BeginState;

    public int levelCurrent = 1;

    public GameObject player;

    public int Score { get; set; }
    public Action ScoreUpdated;

    [SerializeField]
    private List<GameObject> enemyObjects = new List<GameObject>();

    [SerializeField]
    private List<Transform> enemySpawnPoints = new List<Transform>();

    //Components
    private SpawnEntities spawnEntities;
    private CheckEntitiesAlive entitiesAlive;

    //---------------------------------

    void Start()
    {
        //Get the components
        spawnEntities = GetComponent<SpawnEntities>();
        entitiesAlive = GetComponent<CheckEntitiesAlive>();

        //Get the gameobjects
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //Check the current state
        CheckCurrentGameState();
    }

    public void SetCurrentGameState(GameStates _value)
    {
        Debug.Log("Set current game state to: " + _value);
        gameStateCurrent = _value;
    }


    public GameStates CheckCurrentGameState()
    {
        switch(gameStateCurrent)
        {
            case GameStates.BeginState:

                //Spawn an Entity when the game begins
                GameObject _inst = spawnEntities.SpawnEntity(enemyObjects[0], enemySpawnPoints[0].position);
                //Add the instance as an child to this object for now (Make an pool object)
                _inst.transform.parent = transform;
                //Add a target to the Entity
                _inst.GetComponent<EntityBehaviour>().targetObject = player;
                _inst.GetComponent<AITurnTo>().target = player.transform;

                //Start the game
                SetCurrentGameState(GameStates.InGameState);


            break;

            case GameStates.InGameState:

                //if (entitiesAlive.CheckAmountEntitiesAlive(this.gameObject, teamTypes.Enemy) == 0)
                //{
                //    SetCurrentGameState(GameStates.WinState);
                //}

            break;

            case GameStates.WinState:



            break;

            case GameStates.LoseState:



            break;
        }


        return gameStateCurrent;
    }


}
