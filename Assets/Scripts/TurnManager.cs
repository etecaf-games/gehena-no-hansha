﻿using UnityEngine;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour
{
    public List<KeyValuePair<GameObject, int>> turnOrder = new List<KeyValuePair<GameObject, int>>();
    public int turnIndex = 0;
    private UserInterfaceManager userInterfaceManager;
    private void Start()
    {
        turnOrder = DetermineTurnOrder();
    }
    public List<KeyValuePair<GameObject, int>> DetermineTurnOrder()
    {
        List<KeyValuePair<GameObject, int>> allAgilities = new List<KeyValuePair<GameObject, int>>();
        allAgilities = GetAllAgilitiesInScene();

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
        Debug.Log("Turn Order Calculated");
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
    private void DebugShowTurnOrder()
    {
        Debug.Log("Turn Order: ");
        int k = 0;
        // print all element of list 
        foreach (var value in turnOrder)
        {
            k++;
            Debug.Log(k + "º: " + value.Key.name + " : " + value.Value + " ");
        }
    }
    private void NextRound()
    {
        if (turnIndex == turnOrder.Count - 1)//se for a vez da ultima pessoa a agir
        {
            Debug.Log("Next Round");
            turnIndex = 0;
        }
        else if (turnIndex < turnOrder.Count)
        {
            Debug.Log("It is too soon to go to the next round");
        }
        else
        {
            Debug.Log("Something broke... the turn index is higher than the amount of playable characters in the scene");
        }
    }
    private void NextTurn()
    {
        if (turnIndex == turnOrder.Count - 1)
        {
            Debug.Log("It is already the last person's turn");
            NextRound();
        }
        else if (turnIndex < turnOrder.Count)
        {
            Debug.Log("Next Turn");
            turnIndex++;
        }
        else
        {
            Debug.Log("Something broke... the turn index is higher than the amount of playable characters in the scene");
        }
    }
    private void WhoseTurnIsIt()
    {
        Debug.Log("It is " + turnOrder[turnIndex].Key.name + "'s turn");
    }
}