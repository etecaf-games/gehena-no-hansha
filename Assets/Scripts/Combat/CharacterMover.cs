using UnityEngine;
using System.Collections.Generic;
public class CharacterMover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float interpolationAmount;
    private GameObject character;
    private GameObject starterHex;
    private GameObject nextHex;
    private GameObject endHex;
    private CombatAnimationManager combatAnimationManager;
    private InputManager inputManager;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    public bool MoveCharacter { get; set; }
    public List<GameObject> MovementPath { get; set; }
    private void Awake()
    {
        combatAnimationManager = GetComponent<CombatAnimationManager>();
        inputManager = GetComponent<InputManager>();
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
    }
    private void Update()
    {
        if (MoveCharacter)
        {
            character = turnManager.GetCharacterInTurn();
            character.transform.position = Vector3.Lerp(starterHex.transform.position, nextHex.transform.position, interpolationAmount);
            interpolationAmount += Time.deltaTime * speed;
            if (character.transform.position == nextHex.transform.position)
            {
                starterHex.GetComponent<HexProperties>().characterInHex = null;
                nextHex.GetComponent<HexProperties>().characterInHex = character;
                interpolationAmount = 0;
                starterHex = MovementPath[0];
                MovementPath.RemoveAt(0);
                if (MovementPath.Count != 0)
                {
                    nextHex = MovementPath[0];
                    combatAnimationManager.TurnTowardsTarget(character, nextHex);
                }
                else
                {
                    MoveCharacter = false;
                    inputManager.ChangeCombatButtonsTo(true);
                    combatAnimationManager.MoveAnimation(character.GetComponent<Animator>(), false);
                }
            }
        }
    }
    public void MoveToNewPosition()
    {
        MoveCharacter = true;
        inputManager.ChangeCombatButtonsTo(false);
        character = turnManager.GetCharacterInTurn();
        CalculatePath();
        ChangeMovementValues(character);
        combatAnimationManager.MoveAnimation(character.GetComponent<Animator>(), true);
        combatAnimationManager.TurnTowardsTarget(character, nextHex);
        GameObject previousHex = pathfinding.CharacterToHexPosition(character);
        previousHex.GetComponent<HexProperties>().characterInHex = null;
        nextHex.GetComponent<HexProperties>().characterInHex = character;
        pathfinding.ClearAllHexes();
        pathfinding.CharacterToHexPosition(nextHex).GetComponentInChildren<SpriteRenderer>().color = Color.white; //deixa o hex em que o personagem está ,branco
        inputManager.MoveButtonPressed = false;
    }
    private void CalculatePath()
    {
        character = turnManager.GetCharacterInTurn();
        starterHex = pathfinding.CharacterToHexPosition(character);
        endHex = inputManager.currentHex;
        MovementPath = pathfinding.ReturnShortestPathByBFS(starterHex, endHex);
        nextHex = MovementPath[0];
    }
    private void ChangeMovementValues(GameObject character)
    {
        Stats characterStats = character.GetComponent<Stats>();
        characterStats.currentMove -= MovementPath.Count;
        inputManager.movementPointsText.text = characterStats.currentMove.ToString();
    }
}