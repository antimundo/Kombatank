using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSelectionScreen : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    [SerializeField] TextMeshProUGUI text;
    public GameObject[] players { get; private set; } = new GameObject[4];

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

        DisplayInfo();
    }

    private void PlayerInputManager_onPlayerJoined(PlayerInput obj)
    {
        // What player is this?
        for (int i=0;i < players.Length;i++)
        {
            if (players[i] == null)
            {
                players[i] = obj.gameObject;
                players[i].GetComponent<PlayerId>().id = i;
                players[i].GetComponent<PlayerId>().setColor(i);
                obj.gameObject.name = "Player " + i;
                break;
            }
        }
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        string newText = "";
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                if (i > 0) newText += "\n";
                newText += "<b>" + players[i].name + "</b>";
                newText += "\nReady: " + players[i].GetComponent<PlayerId>().isReady;
            }
        }
        text.text = newText;
    }

    public void ChangeSkin(int id)
    {
        players[id].GetComponent<PlayerId>().setColor(players[id].GetComponent<PlayerId>().currentSkin + 1);
    }
}
