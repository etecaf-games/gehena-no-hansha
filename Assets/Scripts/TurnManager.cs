using UnityEngine;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour
{
    private GameObject[] players;
    private GameObject[] enemies;
    private List<GameObject> turnOrder = new List<GameObject>();
    private List<KeyValuePair<GameObject, int>> agilitiesList = new List<KeyValuePair<GameObject, int>>();
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            int agility;
            for (int i = 0; i < players.Length; i++)
            {
                agility = players[i].GetComponent<Player>().agility;
                KeyValuePair<GameObject, int> playerAgility = new KeyValuePair<GameObject, int>(players[i], agility);
                agilitiesList.Add(playerAgility);
            }
        }
        else
        {
            Debug.Log("There are no players in the scene");
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            int agility;
            for (int i = 0; i < enemies.Length; i++)
            {
                agility = enemies[i].GetComponent<Hellhound>().agility;
                KeyValuePair<GameObject, int> enemyAgility = new KeyValuePair<GameObject, int>(enemies[i], agility);
                agilitiesList.Add(enemyAgility);
            }
        }
        else
        {
            Debug.Log("There are no enemies in the scene");
        }
    }
    private void DetermineTurnOrder()
    {
        for (int i = 0; i < agilitiesList.Count - 1; i++)
        {
            // traverse i+1 to array length 
            for (int j = i + 1; j < agilitiesList.Count; j++)
            {
                // compare array element with  
                // all next element 
                if (agilitiesList[i].Value < agilitiesList[j].Value)
                {
                    KeyValuePair<GameObject, int> temp = agilitiesList[i];
                    agilitiesList[i] = agilitiesList[j];
                    agilitiesList[j] = temp;
                }
            }
        }
        int k = 0;
        // print all element of array 
        foreach (var value in agilitiesList)
        {
            k++;
            Debug.Log(k + "º: " + value.Key.name + " : " + value.Value + " ");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DetermineTurnOrder();
        }
    }
}
