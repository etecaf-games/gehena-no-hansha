using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour
{
    public bool hasAttacked = false;
    public int turnIndex = 0;
    public Text movementPointsText;
    public Text actionPointsText;
    public Text healthPointsText;
    public Text soulPointsText;
    public Image bigIconArea;
    public Image smallIconArea;
    public Image healthBar;
    public Image soulBar;
    public List<KeyValuePair<GameObject, int>> turnOrder = new List<KeyValuePair<GameObject, int>>();
    private void Start()
    {
        turnOrder = DetermineTurnOrder();
    }
    public List<KeyValuePair<GameObject, int>> DetermineTurnOrder()
    {
        List<KeyValuePair<GameObject, int>> allAgilities = GetAllAgilitiesInScene();

        for (int i = 0; i < allAgilities.Count - 1; i++)
        {
            // traverse i+1 to list length
            for (int j = i + 1; j < allAgilities.Count; j++)
            {
                // compare list element with  
                // all next element 
                if (allAgilities[i].Value < allAgilities[j].Value)
                {
                    KeyValuePair<GameObject, int> temp = allAgilities[i];
                    allAgilities[i] = allAgilities[j];
                    allAgilities[j] = temp;
                }
                else if (allAgilities[i].Value == allAgilities[j].Value)
                {
                    int random = Random.Range(1, 3);
                    switch (random)
                    {
                        case 1:
                            KeyValuePair<GameObject, int> temp = allAgilities[i];
                            allAgilities[i] = allAgilities[j];
                            allAgilities[j] = temp;
                            break;
                        case 2:
                            //do nothing
                            break;
                        default:
                            Debug.Log("Wrong random value");
                            break;
                    }
                }
            }
        }
        return allAgilities;
    }
    private List<KeyValuePair<GameObject, int>> GetAllAgilitiesInScene()
    {
        GameObject[] players;
        List<KeyValuePair<GameObject, int>> agilitiesList = new List<KeyValuePair<GameObject, int>>();
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            int agility;
            for (int i = 0; i < players.Length; i++)
            {
                agility = players[i].GetComponent<Stats>().agility;
                KeyValuePair<GameObject, int> playerAgility = new KeyValuePair<GameObject, int>(players[i], agility);
                agilitiesList.Add(playerAgility);
            }
        }
        else
        {
            Debug.Log("There are no players in the scene");
        }

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            int agility;
            for (int i = 0; i < enemies.Length; i++)
            {
                agility = enemies[i].GetComponent<Stats>().agility;
                KeyValuePair<GameObject, int> enemyAgility = new KeyValuePair<GameObject, int>(enemies[i], agility);
                agilitiesList.Add(enemyAgility);
            }
        }
        else
        {
            Debug.Log("There are no enemies in the scene");
            return null;
        }
        return agilitiesList;
    }
    private void NextRound()
    {
        if (turnIndex == turnOrder.Count - 1)//se for a vez da ultima pessoa a agir
        {
            turnIndex = 0;
        }
    }
    public void NextTurn()
    {
        hasAttacked = false;
        if (turnIndex == turnOrder.Count - 1)
        {
            NextRound();
        }
        else if (turnIndex < turnOrder.Count)
        {
            turnIndex++;
        }
    }
    public GameObject GetCharacterInTurn()
    {
        return turnOrder[turnIndex].Key;
    }
    public GameObject GetCharacterInNextTurn()
    {
        if (turnIndex == turnOrder.Count - 1)
        {
            return turnOrder[0].Key;
        }
        else
        {
            return turnOrder[turnIndex + 1].Key;
        }
    }
    public void UpdateCombatUIValues(bool nextTurn)
    {
        GameObject currentCharacter = GetCharacterInTurn();
        GameObject nextCharacter = GetCharacterInNextTurn();
        Stats currentCharacterStats = currentCharacter.GetComponent<Stats>();
        int movementLeft;
        int actionPointsLeft;
        int maxHealthPoints;
        int maxSoulPoints;
        int currentHealthPoints;
        int currentSoulPoints;
        if (nextTurn)
        {
            currentCharacterStats.currentMove = currentCharacterStats.maxMove;
            currentCharacterStats.currentActionPoints = currentCharacterStats.maxActionPoints;
            movementLeft = currentCharacterStats.maxMove;
            actionPointsLeft = currentCharacterStats.maxActionPoints;
        }
        else
        {
            movementLeft = currentCharacterStats.currentMove;
            actionPointsLeft = currentCharacterStats.currentActionPoints;
        }
        maxHealthPoints = currentCharacterStats.maxHealthPoints;
        maxSoulPoints = currentCharacterStats.maxSoulPoints;
        currentHealthPoints = currentCharacterStats.currentHealthPoints;
        currentSoulPoints = currentCharacterStats.currentSoulPoints;
        healthBar.fillAmount = float.Parse(currentHealthPoints.ToString()) / float.Parse(maxHealthPoints.ToString());
        movementPointsText.text = movementLeft.ToString();
        actionPointsText.text = actionPointsLeft.ToString();
        healthPointsText.text = "PV " + currentHealthPoints.ToString() + "/" + maxHealthPoints.ToString();
        soulPointsText.text = "SP " + currentSoulPoints.ToString() + "/" + maxSoulPoints.ToString();
        bigIconArea.sprite = currentCharacter.GetComponent<Icon>().bigIcon;
        smallIconArea.sprite = nextCharacter.GetComponent<Icon>().smallIcon;
    }
}