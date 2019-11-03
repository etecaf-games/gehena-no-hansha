using UnityEngine;
public class MovementManager : MonoBehaviour
{
    private TurnManager turnManager;
    public GameObject actionWheel;
    private void Start()
    {
        turnManager = GetComponent<TurnManager>();
        OpenActionWheel();
    }
    private void OpenActionWheel()
    {
        actionWheel.SetActive(false);
    }
    private void MarkCurrentCharacter()
    {
        GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
        currentCharacter.GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}