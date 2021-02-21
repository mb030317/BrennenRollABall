using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager manager;
    public int spawnLocation = 0;
    public bool playersReady = false;

    public PlayerController[] players;

    private void Start()
    {
        manager = GetComponent<PlayerInputManager>(); //grab the player input manager component
    }

    public void Update()
    {
        //Fill the player index with the player objects



        switch (manager.playerCount)
        {
            case 1:
                Debug.Log("Can't start the game with only one player");

                spawnLocation = 1;

                players[0] = GameObject.Find("Player1").GetComponent<PlayerController>();
                break;
            case 2:
                spawnLocation = 2;

                players[1] = GameObject.Find("Player2").GetComponent<PlayerController>();

                if (players[0].ready && players[1].ready)
                {
                    playersReady = true;
                }
                break;
            case 3:
                spawnLocation = 3;

                players[2] = GameObject.Find("Player3").GetComponent<PlayerController>();

                if (players[0].ready && players[1].ready && players[2].ready)
                {
                    playersReady = true;
                }
                break;
            case 4:
                spawnLocation = 4;

                players[3] = GameObject.Find("Player4").GetComponent<PlayerController>();

                if (players[0].ready && players[1].ready && players[2].ready && players[3].ready)
                {
                    playersReady = true;
                }
                break;
            default:
                break;
        }
    }

}
