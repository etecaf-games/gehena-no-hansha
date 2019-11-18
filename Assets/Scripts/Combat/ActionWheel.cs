using UnityEngine;
public class ActionWheel : MonoBehaviour
{
    private InputManager inputManager;
    private Pathfinding pathfinding;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        pathfinding = GetComponent<Pathfinding>();
    }
    public void MoveButton()
    {
        inputManager.MoveButtonPressed = true;
        inputManager.AttackButtonPressed = false;
        pathfinding.ClearAllHexes();
        pathfinding.DisplayAvailableHexesToMove();
    }
    public void AttackButton()
    {
        inputManager.MoveButtonPressed = false;
        inputManager.AttackButtonPressed = true;
        pathfinding.ClearAllHexes();
        pathfinding.DisplayAvailableHexesToAttack();
    }
}