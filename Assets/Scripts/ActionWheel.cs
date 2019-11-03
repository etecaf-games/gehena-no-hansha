using UnityEngine;
using System.Collections.Generic;
public class ActionWheel : MonoBehaviour
{
    private List<KeyValuePair<GameObject, int>> turnOrder = new List<KeyValuePair<GameObject, int>>();
    private TurnManager turnManager;
    private Pathfinding pathfinding;
    private InputManager inputManager;
    private Stats stats;
    private int turnIndex;
    private void Start()
    {
        turnManager = GetComponent<TurnManager>();
        pathfinding = GetComponent<Pathfinding>();
        inputManager = GetComponent<InputManager>();
    }
    public void MoveButton()
    {
        Debug.Log("clicou no botao de mover");
        inputManager.moveButtonPressed = true;
        GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
        //currentCharacter.GetComponent<SpriteRenderer>().color = Color.red;
        pathfinding.movementLeft = currentCharacter.GetComponent<Stats>().move;
        pathfinding.DisplayAdjacentHexes();
    }
}