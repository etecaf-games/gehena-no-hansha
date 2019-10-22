using UnityEngine;
using UnityEngine.UI;
public class UserInterfaceManager : MonoBehaviour
{
    private Text movement;
    private Text turnOrderText;
    private TurnManager turnManager;
    private void Start()
    {
        // movement = GameObject.Find("MovementText").GetComponent<Text>();
        turnManager = GetComponent<TurnManager>();
        //ChangeValues();
        UpdateTurnOrder();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeValues();
        }
    }
    public void ChangeValues()
    {
        movement.text = "Movement: " + turnManager.turnOrder[turnManager.turnIndex].Key.GetComponent<Stats>().move;
    }
    private void UpdateTurnOrder()
    {
        Debug.Log("otario");
        int k = 0;
        turnOrderText = GameObject.Find("TurnOrderText").GetComponent<Text>();
        //Destroy(turnOrderText.gameObject);
        foreach (var value in turnManager.turnOrder)
        {
            //turnOrderText.text += k + "º: " + value.Key.name + " : " + value.Value + " \n";
            string turnOrderString;
            if (value.Key == turnManager.turnOrder[turnManager.turnIndex].Key)
            {
                turnOrderString = k + 1 + "º: " + value.Key.name + " !\n";
            }
            else
            {
                turnOrderString = k + 1 + "º: " + value.Key.name + " \n";
            }
            turnOrderText.text += turnOrderString;
            k++;
        }
    }
}