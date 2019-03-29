using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDies player; // this is just where you would put the script where the action for the playerdeath is
     
    private void Start()
    {
        player.Death += PlayerDeath;
    }
    public void PlayerDeath()
    {
        Debug.Log("player dies");
        Time.timeScale = 0; // should probably be done with lerp 
        // menu appears(menu exists currently)
        // player has a choice between restart and quit
        // quit closes application
        // restart loads scene and resets variables
    }

    public void QuitGame()
    {
        Debug.Log("quit");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Debug.Log("restart");    }
}
