using UnityEngine;
public class ActionWheel : MonoBehaviour
{
    private Pathfinding pathfinding;
    private InputManager inputManager;
    private void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        inputManager = GetComponent<InputManager>();
    }
    public void MoveButton()
    {
        inputManager.moveButtonPressed = true;
        inputManager.attackButtonPressed = false;
        pathfinding.DisplayAvailableHexesToMove();
    }
    //public void AttackButton()
    //{
    //    inputManager.moveButtonPressed = false;
    //    inputManager.attackButtonPressed = true;
    //    pathfinding.DisplayAvailableHexesToAttack();
    //}
}