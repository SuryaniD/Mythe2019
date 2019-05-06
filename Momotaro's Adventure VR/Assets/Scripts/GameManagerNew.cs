using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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

    public int Level { get; set; }
    public Action LevelUpdated;

    public GameObject player;

    public int Score { get; set; }
    public Action ScoreUpdated;

    [SerializeField]
    private List<GameObject> enemyObjects = new List<GameObject>();

    [SerializeField]
    private List<Transform> enemySpawnPoints = new List<Transform>();

    [Header("Alive Entity List")]
    [SerializeField]
    private List<GameObject> entityAliveObjects = new List<GameObject>();

    public MenuManager menuManager;

    [Header("Disable Object List")]
    [SerializeField]
    private List<GameObject> disableObjects = new List<GameObject>();

    //Components
    private SpawnEntities spawnEntities;
    private CheckEntitiesAlive checkEntitiesAlive;
    private OpenLevelDoors openLevelDoors;

    //---------------------------------

    void Start()
    {
        //Get the components
        spawnEntities = GetComponent<SpawnEntities>();
        checkEntitiesAlive = GetComponent<CheckEntitiesAlive>();
        openLevelDoors = GetComponent<OpenLevelDoors>();

        //Get the gameobjects
        player = GameObject.FindGameObjectWithTag("Player");
        entityAliveObjects.Add(player);
    }

    void Update()
    {
        if (Input.GetButtonUp("Escape"))
            GameQuit();

        if (Input.GetButtonUp("r"))
            GameRestart(0);
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

                Level++;
                LevelUpdated?.Invoke();

                menuManager.DeactivateMenu();

                DAObjects(true);


                //Close the doors fast
                openLevelDoors.CloseDoors(1000f);

                //Spawn an Entity when the game begins
                GameObject _inst = spawnEntities.SpawnEntity(enemyObjects[0], enemySpawnPoints[0].position);
                //Add the instance as an child to this object for now (Make an pool object)
                //_inst.transform.parent = transform;
                entityAliveObjects.Add(_inst);

                //Add a target to the Entity
                _inst.GetComponent<EntityBehaviour>().targetObject = player;
                _inst.GetComponent<AITurnTo>().target = player.transform;

                //Start the game
                SetCurrentGameState(GameStates.InGameState);


            break;

            case GameStates.InGameState:

                openLevelDoors.CloseDoors(1000f);

                //Check if there are any Enemy Entities alive
                if (checkEntitiesAlive.CheckAmountEntitiesAlive(entityAliveObjects, TeamTypes.Enemy) == 0)
                {
                    //If there arent any, The player has won this round
                    SetCurrentGameState(GameStates.WinState);
                }

                if (checkEntitiesAlive.CheckAmountEntitiesAlive(entityAliveObjects, TeamTypes.Friendly) == 0)
                {
                    //If there arent any, The player has won this round
                    SetCurrentGameState(GameStates.LoseState);
                }

                break;

            case GameStates.WinState:

                openLevelDoors.OpenDoors(2f);

            break;

            case GameStates.LoseState:

                menuManager.ActivateMenu();
                DAObjects(false);

            break;
        }


        return gameStateCurrent;
    }


    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameRestart(int _scene)
    {
        print("Restart Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void DAObjects(bool _value)
    {
        for (int _i = 0; _i < disableObjects.Count; _i++)
        {
            disableObjects[_i].gameObject.SetActive(_value);
        }
    }
}
