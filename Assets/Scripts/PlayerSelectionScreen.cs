using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSelectionScreen : MonoBehaviour
{
    //https://www.code-helper.com/answers/get-all-devices-connected-using-player-input-manager-unity

    [SerializeField] PlayerInputManager playerInputManager;
    [SerializeField] TextMeshProUGUI text;
    GameObject[] players = new GameObject[4];

    void Start()
    {
        playerInputManager.onPlayerJoined += PlayerInputManager_onPlayerJoined;
        playerInputManager.onPlayerLeft += PlayerInputManager_onPlayerLeft;
    }

    private void PlayerInputManager_onPlayerLeft(PlayerInput obj)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == obj.gameObject)
            {
                players[i] = null;
                break;
            }
        }

        // Display text
        string newText = "";
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                newText += "\n" + players[i].name;
            }
        }
        text.text = newText;
    }

    private void PlayerInputManager_onPlayerJoined(PlayerInput obj)
    {
        // What player is this?
        for (int i=0;i < players.Length;i++)
        {
            if (players[i] == null)
            {
                players[i] = obj.gameObject;
                obj.gameObject.name = "Player " + i;
                break;
            }
        }

        // Display text
        string newText = "";
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                if (i > 0) newText += "\n";
                newText += players[i].name;
            }
        }
        text.text = newText;
    }

}
