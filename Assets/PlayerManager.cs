using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager manager;
    public int spawnLocation = 0;

    private void Start()
    {
        manager = GetComponent<PlayerInputManager>(); //grab the player input manager component
    }

    void OnPlayerJoined()
    {
        switch (manager.playerCount) //grab the player count to set different spawn points accordingly
        {
            case 1:
                Debug.Log("First player spawn");
                spawnLocation = 1;
                break;
            case 2:
                Debug.Log("Second player spawn");
                spawnLocation = 2;
                break;
            case 3:
                spawnLocation = 3;
                break;
            case 4:
                spawnLocation = 4;
                break;
            default:
                break;

        }

    }

}
