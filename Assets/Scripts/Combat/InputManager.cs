using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedGoal;
    public Canvas canvas;
    public LayerMask hexLayer;
    public GameObject currentHex;
    private GameObject previousHex;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    private CombatManager combatManager;
    private CombatAnimationManager combatAnimationManager;
    private CharacterMover characterMover;
    public Text movementPointsText;
    public Image bigIconArea;
    public Image smallIconArea;
    public GameObject pauseBackground;
    public Button moveButton;
    public Button attackButton;
    public Button itemButton;
    public Button skillButton;
    public Button finishButton;
    private bool moveButtonPressed = false;
    private bool attackButtonPressed = false;
    public bool MoveButtonPressed
    {
        get
        {
            return moveButtonPressed;
        }
        set
        {
            moveButtonPressed = value;
            if (moveButtonPressed)
            {
                attackButtonPressed = false;
            }
        }
    }
    public bool AttackButtonPressed
    {
        get
        {
            return attackButtonPressed;
        }
        set
        {
            attackButtonPressed = value;
            if (attackButtonPressed)
            {
                moveButtonPressed = false;
            }
        }
    }
    private void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
        combatManager = GetComponent<CombatManager>();
        combatAnimationManager = GetComponent<CombatAnimationManager>();
        characterMover = GetComponent<CharacterMover>();
    }
    private void LateUpdate()
    {
        if (MoveButtonPressed)
        {
            HighlightHexToMove();
        }
        if (AttackButtonPressed)
        {
            HighlightHexToAttack();
        }
    }
    public RaycastHit MousePositionToRaycastHit(LayerMask hexLayer)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, hexLayer))
        {

        }
        return hit;
    }
    public RaycastHit MousePositionToRaycastHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, hexLayer))
        {

        }
        return hit;
    }
    private void HighlightHexToMove()
    {
        RaycastHit hit = MousePositionToRaycastHit(hexLayer);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Hex")
            {
                if (hit.collider.gameObject != currentHex)
                {
                    previousHex = currentHex;
                    currentHex = hit.collider.gameObject;
                }
                HexProperties currentHexProperties = currentHex.GetComponent<HexProperties>();
                if (currentHexProperties.canMove && currentHexProperties.CharacterInHex == null)
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    //combatAnimationManager.TurnTowardsTarget(turnManager.GetCharacterInTurn(), currentHex);
                    if (Input.GetMouseButtonDown(0))
                    {
                        characterMover.MoveToNewPosition();
                    }
                }
                else
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
                if (previousHex != null)
                {
                    if (previousHex.GetComponent<HexProperties>().canMove)
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    }
                    else
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    }
                }
            }
        }
    }
    private void HighlightHexToAttack()
    {
        RaycastHit hit = MousePositionToRaycastHit(hexLayer);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Hex")
            {
                if (hit.collider.gameObject != currentHex)
                {
                    previousHex = currentHex;
                    currentHex = hit.collider.gameObject;
                }
                if (currentHex.GetComponent<HexProperties>().canAttack)
                {
                    //combatAnimationManager.TurnTowardsTarget(turnManager.GetCharacterInTurn(), currentHex);
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                    if (currentHex.GetComponent<HexProperties>().CharacterInHex != null)
                    {
                        if (Input.GetMouseButtonDown(0) && !turnManager.HasAttacked)
                        {
                            GameObject defender = currentHex.GetComponent<HexProperties>().CharacterInHex;
                            if (defender.tag == "Enemy")
                            {
                                turnManager.HasAttacked = true;

                                GameObject attacker = turnManager.GetCharacterInTurn();

                                AttackCharacter(attacker, defender);
                            }
                        }
                    }
                }
                else
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
                if (previousHex != null)
                {
                    if (previousHex.GetComponent<HexProperties>().canAttack)
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    }
                }
            }
        }
    }
    
    public void FinishButton()
    {
        pathfinding.ClearAllHexes();
        turnManager.NextTurn();
        turnManager.UpdateCombatUIValues(true);
        turnManager.HasAttacked = false;
    }
    public void PauseButton()
    {
        pauseBackground.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        pauseBackground.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChangeCombatButtonsTo(bool value)
    {
        moveButton.interactable = value;
        attackButton.interactable = value;
        itemButton.interactable = value;
        skillButton.interactable = value;
        finishButton.interactable = value;
    }
    public void AttackCharacter(GameObject attacker, GameObject defender)
    {
        Stats attackerStats = attacker.GetComponent<Stats>();
        Stats defenderStats = defender.GetComponent<Stats>();
        attackerStats.currentActionPoints -= 2;
        combatManager.Combat(attacker, defender);
        Animator attackerAnimator = attacker.GetComponent<Animator>();
        Animator defenderAnimator = defender.GetComponent<Animator>();
        combatAnimationManager.AttackAnimation(attackerAnimator, defenderAnimator);
        if (defenderStats.currentHealthPoints > 0)
        {
            defenderStats.IsAlive = true;
        }
        else
        {
            defenderStats.IsAlive = false;
        }
    }
}