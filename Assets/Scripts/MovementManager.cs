using UnityEngine;
using System.Collections.Generic;
public class MovementManager : MonoBehaviour
{
    private bool canMove;
    private GameObject currentCharacter, selectedGoal, jogadorDaVez;
    private TurnManager turnManager;
    private Pathfinding pathfinding;
    private List<GameObject> path = new List<GameObject>();
    private void Start()
    {
        turnManager = GetComponent<TurnManager>();
    }
    private void MoveToNextHex(GameObject characterToMove, List<GameObject> hexesInPath)
    {
        if (characterToMove.transform.position != selectedGoal.transform.position)
        {
            characterToMove.transform.position = hexesInPath[0].transform.position;
        }
    }
}