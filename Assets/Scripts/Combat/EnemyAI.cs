using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    private CombatAnimationManager combatAnimationManager;
    private InputManager inputManager;
    private MapGenerator mapGenerator;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    private List<GameObject> gameObjects = new List<GameObject>();
    private bool isMoving = false;
    private bool isAttacking = false;
    private void Awake()
    {
        combatAnimationManager = GetComponent<CombatAnimationManager>();
        inputManager = GetComponent<InputManager>();
        mapGenerator = GetComponent<MapGenerator>();
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //StartCoroutine(GenericBehaviour());
            GameObject player = null;
            GameObject enemy = turnManager.GetCharacterInTurn();
            Stats enemyStats = enemy.GetComponent<Stats>();
            bool adjacentToPlayer = CheckIfAdjacentToAPlayer(out player);
            if (adjacentToPlayer)
            {
                if (!turnManager.hasAttacked)
                {

                    int actionPoints = enemyStats.currentActionPoints;
                    if (actionPoints >= 2)
                    {
                        if (!isAttacking)
                        {
                            StartCoroutine(AttackCharacter(player));
                            isAttacking = true;
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
                if (enemyStats.currentMove > 0)
                {
                    if (!isMoving)
                    {
                        StartCoroutine(MoveCharacter());
                        isMoving = true;
                    }
                }
                else
                {
                }
            }

        }
    }
    private List<GameObject> ReturnShortestPathByBFS(GameObject startHex, GameObject goalHex)
    {
        Queue<GameObject> Q = new Queue<GameObject>();
        List<GameObject> discoveredNodes = new List<GameObject>();
        Dictionary<GameObject, GameObject> nodeParents = new Dictionary<GameObject, GameObject>();//a key é o filho, o value é o pai
        List<GameObject> shortestPath = new List<GameObject>();
        discoveredNodes.Add(startHex);
        Q.Enqueue(startHex);
        while (Q != null)
        {
            GameObject currentHex = Q.Dequeue();//tira o primeiro da fila
            if (currentHex.transform.position == goalHex.transform.position)//aqui encontrou o caminho final
            {
                shortestPath.Add(currentHex);//goal hex
                while (nodeParents.ContainsKey(currentHex))//se o filho tem um pai
                {
                    shortestPath.Add(nodeParents[currentHex]);
                    currentHex = nodeParents[currentHex];//the new currentHex is the parent of the current currentHex
                }
                shortestPath.Reverse();
                shortestPath.RemoveAt(0);
                return shortestPath;
            }
            List<GameObject> adjacentHexes = FindAdjacentHexes(currentHex);
            foreach (GameObject adjacentHex in adjacentHexes)
            {
                if (!discoveredNodes.Contains(adjacentHex))
                {
                    discoveredNodes.Add(adjacentHex);
                    nodeParents.Add(adjacentHex, currentHex);
                    Q.Enqueue(adjacentHex);
                }
            }
        }
        //This part should never happen
        shortestPath.Add(startHex);
        return shortestPath;
    }
    private GameObject[] GetAllPlayersInCombat()
    {
        GameObject[] allPlayersInCombat = GameObject.FindGameObjectsWithTag("Player");
        return allPlayersInCombat;
    }//ok
    private bool CheckIfAdjacentToAPlayer(out GameObject adjacentPlayer)
    {
        adjacentPlayer = null;
        GameObject enemy = turnManager.GetCharacterInTurn();
        GameObject[] allPlayers = GetAllPlayersInCombat();
        bool closeToAPlayer = false;
        GameObject enemyHex = pathfinding.CharacterToHexPosition(enemy);
        foreach (GameObject player in allPlayers)
        {
            GameObject playerHex = pathfinding.CharacterToHexPosition(player);

            Vector3 playerHexPosition = playerHex.transform.position;
            Vector3 enemyHexPosition = enemyHex.transform.position;

            Vector3 northWestHexPosition = new Vector3(enemyHexPosition.x - 0.6f, enemyHexPosition.y + 0.525f, enemyHexPosition.z + 0.9f);
            Vector3 northEastHexPosition = new Vector3(enemyHexPosition.x + 0.6f, enemyHexPosition.y + 0.525f, enemyHexPosition.z + 0.9f);
            Vector3 westHexPosition = new Vector3(enemyHexPosition.x - 1.2f, enemyHexPosition.y, enemyHexPosition.z);
            Vector3 eastHexPosition = new Vector3(enemyHexPosition.x + 1.2f, enemyHexPosition.y, enemyHexPosition.z);
            Vector3 southWestHexPosition = new Vector3(enemyHexPosition.x - 0.6f, enemyHexPosition.y - 0.525f, enemyHexPosition.z - 0.9f);
            Vector3 southEastHexPosition = new Vector3(enemyHexPosition.x + 0.6f, enemyHexPosition.y - 0.525f, enemyHexPosition.z - 0.9f);
            if (playerHexPosition == northWestHexPosition || playerHexPosition == northEastHexPosition || playerHexPosition == westHexPosition || enemyHexPosition == eastHexPosition || playerHexPosition == southWestHexPosition || playerHexPosition == southEastHexPosition)
            {
                adjacentPlayer = player;
                closeToAPlayer = true;
                break;
            }
            else
            {
                closeToAPlayer = false;
            }
        }
        return closeToAPlayer;
    }//ok
    private void AttackPlayer()
    {

    }
    //private IEnumerator GenericBehaviour()
    //{
    //    GameObject player = null;
    //    GameObject enemy = turnManager.GetCharacterInTurn();
    //    Stats enemyStats = enemy.GetComponent<Stats>();
    //    while (true)
    //    {
    //        bool adjacentToPlayer = CheckIfAdjacentToAPlayer(out player);
    //        Debug.Log(player);
    //        if (!adjacentToPlayer)
    //        {
    //            if (enemyStats.currentMove > 0)
    //            {
    //                if (!isMoving)
    //                {
    //                    StartCoroutine(MoveCharacter());
    //                    isMoving = true;
    //                    yield return new WaitWhile(() => isMoving);
    //                }
    //            }
    //            else
    //            {
    //                if (!isMoving && !isAttacking)
    //                {
    //                    turnManager.NextTurn();
    //                    StopCoroutine(GenericBehaviour());
    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (!turnManager.hasAttacked)
    //            {

    //                int actionPoints = enemyStats.currentActionPoints;
    //                if (actionPoints >= 2)
    //                {
    //                    if (!isAttacking)
    //                    {
    //                        StartCoroutine(AttackCharacter(player));
    //                        isAttacking = true;
    //                        yield return new WaitWhile(() => isAttacking);
    //                    }
    //                }
    //                else
    //                {
    //                    if (!isMoving && !isAttacking)
    //                    {
    //                        turnManager.NextTurn();
    //                        StopCoroutine(GenericBehaviour());
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                if (!isMoving && !isAttacking)
    //                {
    //                    turnManager.NextTurn();
    //                    StopCoroutine(GenericBehaviour());
    //                }
    //            }
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
    private GameObject GetClosestAttackablePlayer(GameObject[] allPlayersInCombat, out List<GameObject> shortestPathToAPlayer)
    {
        GameObject closestPlayer = null;
        List<GameObject> currentPathToAPlayer = new List<GameObject>();
        shortestPathToAPlayer = currentPathToAPlayer;
        foreach (GameObject playerInCombat in allPlayersInCombat)
        {
            currentPathToAPlayer = GetClosestAdjacentHexPath(playerInCombat);
            if (shortestPathToAPlayer.Count == 0)
            {
                shortestPathToAPlayer = currentPathToAPlayer;
                closestPlayer = playerInCombat;
            }
            else
            {
                if (shortestPathToAPlayer.Count > currentPathToAPlayer.Count)
                {
                    shortestPathToAPlayer = currentPathToAPlayer;
                    closestPlayer = playerInCombat;
                }
                else if (shortestPathToAPlayer.Count == currentPathToAPlayer.Count)
                {
                }
            }
        }
        return closestPlayer;
    }
    private List<GameObject> GetClosestAdjacentHexPath(GameObject player)
    {
        GameObject enemy = turnManager.GetCharacterInTurn();
        GameObject playerHex = pathfinding.CharacterToHexPosition(player);
        GameObject enemyHex = pathfinding.CharacterToHexPosition(enemy);
        List<GameObject> availableAdjacentHexesToPlayer = FindAdjacentHexes(playerHex);

        List<GameObject> closestPath = new List<GameObject>();

        foreach (GameObject hex in availableAdjacentHexesToPlayer)
        {
            List<GameObject> currentPath = GetShortestPathToHexByBFS(enemyHex, hex);
            if (closestPath.Count == 0)
            {
                closestPath = currentPath;
            }
            else
            {
                if (closestPath.Count > currentPath.Count)
                {
                    closestPath = currentPath;
                }
            }
        }
        return closestPath;
    }
    private List<GameObject> GetShortestPathToHexByBFS(GameObject startHex, GameObject goalHex)
    {
        Queue<GameObject> Q = new Queue<GameObject>();
        List<GameObject> discoveredNodes = new List<GameObject>();
        Dictionary<GameObject, GameObject> nodeParents = new Dictionary<GameObject, GameObject>();//a key é o filho, o value é o pai
        List<GameObject> shortestPath = new List<GameObject>();
        discoveredNodes.Add(startHex);
        Q.Enqueue(startHex);
        while (Q != null)
        {
            GameObject currentHex = Q.Dequeue();//tira o primeiro da fila
            if (currentHex.transform.position == goalHex.transform.position)//aqui encontrou o caminho final
            {
                shortestPath.Add(currentHex);//goal hex
                while (nodeParents.ContainsKey(currentHex))//se o filho tem um pai
                {
                    shortestPath.Add(nodeParents[currentHex]);
                    currentHex = nodeParents[currentHex];//the new currentHex is the parent of the current currentHex
                }
                shortestPath.Reverse();
                shortestPath.RemoveAt(0);
                return shortestPath;
            }
            List<GameObject> adjacentHexes = FindAdjacentHexes(currentHex);
            foreach (GameObject adjacentHex in adjacentHexes)
            {
                if (!discoveredNodes.Contains(adjacentHex))
                {
                    discoveredNodes.Add(adjacentHex);
                    nodeParents.Add(adjacentHex, currentHex);
                    Q.Enqueue(adjacentHex);
                }
            }
        }
        //This part should never happen
        //shortestPath.Add(startHex);
        return shortestPath;
    }
    private List<GameObject> FindAdjacentHexes(GameObject currentHex)
    {
        Vector3 currentHexPosition = currentHex.transform.position;
        List<GameObject> adjacentHexesList = new List<GameObject>();
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        Vector3 northWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 northEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 westHexPosition = new Vector3(currentHexPosition.x - 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 eastHexPosition = new Vector3(currentHexPosition.x + 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 southWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);
        Vector3 southEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);

        foreach (GameObject hex in gridHexesObjects)
        {
            Vector3 hexPosition = hex.transform.position;
            if (hex.GetComponent<HexProperties>().characterInHex == null)
            {
                if (hexPosition == northWestHexPosition || hexPosition == northEastHexPosition || hexPosition == westHexPosition || hexPosition == eastHexPosition || hexPosition == southWestHexPosition || hexPosition == southEastHexPosition)
                {
                    adjacentHexesList.Add(hex);
                }
            }
        }
        return adjacentHexesList;
    }

    private IEnumerator MoveCharacter()
    {
        bool moveCharacter = true;
        float interpolationAmount = 0.0f;
        float speed = 3.0f;
        GameObject enemy = turnManager.GetCharacterInTurn();
        enemy = turnManager.GetCharacterInTurn();
        GameObject enemyHex = pathfinding.CharacterToHexPosition(enemy);
        Stats enemyStats = enemy.GetComponent<Stats>();
        GameObject[] allPlayers = GetAllPlayersInCombat();
        List<GameObject> shortestPathToAPlayer = new List<GameObject>();// shortestPathToAPlayer;
        GameObject closestPlayer = GetClosestAttackablePlayer(allPlayers, out shortestPathToAPlayer);
        GameObject nextHex;
        if (shortestPathToAPlayer.Count > 0)
        {
            nextHex = shortestPathToAPlayer[0];
        }
        else
        {
            nextHex = null;
        }
        while (moveCharacter)
        {
            combatAnimationManager.MoveAnimation(enemy.GetComponent<Animator>(), true);
            enemy.transform.position = Vector3.Lerp(enemyHex.transform.position, nextHex.transform.position, interpolationAmount);
            interpolationAmount += Time.deltaTime * speed;
            if (enemy.transform.position == nextHex.transform.position)//chegou ao proximo hex
            {
                enemyStats.currentMove -= 1;
                enemyHex.GetComponent<HexProperties>().characterInHex = null;
                nextHex.GetComponent<HexProperties>().characterInHex = enemy;
                interpolationAmount = 0;
                enemyHex = shortestPathToAPlayer[0];
                shortestPathToAPlayer.RemoveAt(0);
                if (shortestPathToAPlayer.Count == 0 || enemyStats.currentMove == 0)
                {
                    moveCharacter = false;
                    combatAnimationManager.MoveAnimation(enemy.GetComponent<Animator>(), false);
                }
                else
                {
                    nextHex = shortestPathToAPlayer[0];
                    combatAnimationManager.TurnTowardsTarget(enemy, nextHex);
                }
            }
            yield return null;
        }
        isMoving = false;
        StopCoroutine(MoveCharacter());
    }
    private IEnumerator AttackCharacter(GameObject target)
    {
        GameObject enemy = turnManager.GetCharacterInTurn();
        inputManager.AttackCharacter(enemy, target);
        while (isAttacking)
        {
            if (turnManager.hasAttacked)
            {
                isAttacking = false;
                StopCoroutine(AttackCharacter(target));
            }
            yield return null;
        }
    }
}