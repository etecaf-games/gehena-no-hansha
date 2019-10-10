using UnityEngine;
using UnityEngine.UI;
public class UserInterfaceManager : MonoBehaviour
{
    private Text movement;
    private TurnManager turnManager;
    private void Start()
    {
        movement = GameObject.Find("MovementText").GetComponent<Text>();
        turnManager = GetComponent<TurnManager>();
        ChangeValues();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ChangeValues();
        }
    }
    public void ChangeValues()
    {
        movement.text = "Movement: " + turnManager.turnOrder[turnManager.turnIndex].Key.GetComponent<Stats>().move;
    }
}