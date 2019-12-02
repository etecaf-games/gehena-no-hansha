using UnityEngine;
public class CombatButtons : MonoBehaviour
{
    private InputManager inputManager;
    private Pathfinding pathfinding;
    private FenrirSkill01 fenrirSkill01;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        pathfinding = GetComponent<Pathfinding>();
        fenrirSkill01 = GetComponent<FenrirSkill01>();
    }
    public void MoveButton()
    {
        inputManager.MoveButtonPressed = true;
        pathfinding.ClearAllHexes();
        pathfinding.DisplayAvailableHexesToMove();
    }
    public void AttackButton()  
    {
        inputManager.AttackButtonPressed = true;
        pathfinding.ClearAllHexes();
        pathfinding.DisplayAvailableHexesToAttack();
    }
    public void SkillButton()
    {
        pathfinding.ClearAllHexes();
        fenrirSkill01.DisplayAvailableHexesToSkill();
        fenrirSkill01.CheckIfPlayerClickOnSkillableHex();
    }
}