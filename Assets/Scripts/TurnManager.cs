using UnityEngine;
using System.Collections.Generic;
public class TurnManager : MonoBehaviour
{
    private GameObject player;
    private GlennTalbot playerStats;
    private int playerAgility;

    private GameObject enemy;
    private Hellhound enemyStats;
    private int enemyAgility;

    private SortedList<int, GameObject> agilitiesList = new SortedList<int, GameObject>();
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<GlennTalbot>();
        playerAgility = playerStats.agility;
        Debug.Log("Glenn Agility:" + playerAgility);

        enemy = GameObject.FindWithTag("Enemy");
        enemyStats = enemy.GetComponent<Hellhound>();
        enemyAgility = enemyStats.agility;

        Debug.Log("Hellhound Agility: " + enemyAgility);
    }
    private void DetermineTurnOrder()
    {
        if (playerAgility > enemyAgility)
        {
            Debug.Log("Player starts");
        }
        else if (playerAgility < enemyAgility)
        {
            Debug.Log("Enemy starts");
        }
        else
        {
            int randomResult;
            randomResult = Random.Range(1, 3);
            switch(randomResult)
            {
                case 1:
                    Debug.Log("Player starts");
                    break;
                case 2:
                    Debug.Log("Enemy starts");
                    break;
                default:
                    Debug.Log("You suck");
                    break;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            DetermineTurnOrder();
        }
    }
}
