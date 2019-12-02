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
    public void InitiateAI()
    {
        StartCoroutine(GenericBehaviour());
    }
    private bool CheckIfAdjacentToAPlayer(out GameObject adjacentPlayer)
    {
        adjacentPlayer = null;
        GameObject enemy = turnManager.GetCharacterInTurn();
        List<GameObject> allPlayers = GetAllPlayersInCombat();
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
    private bool CheckIfIAmAdjacentToTarget(GameObject me, GameObject target)
    {
        bool closeToAPlayer;
        GameObject targetHex = pathfinding.CharacterToHexPosition(target);
        GameObject myHex = pathfinding.CharacterToHexPosition(me);
        Vector3 targetHexPosition = targetHex.transform.position;
        Vector3 myHexPosition = myHex.transform.position;

        Vector3 northWestHexPosition = new Vector3(myHexPosition.x - 0.6f, myHexPosition.y + 0.525f, myHexPosition.z + 0.9f);
        Vector3 northEastHexPosition = new Vector3(myHexPosition.x + 0.6f, myHexPosition.y + 0.525f, myHexPosition.z + 0.9f);
        Vector3 westHexPosition = new Vector3(myHexPosition.x - 1.2f, myHexPosition.y, myHexPosition.z);
        Vector3 eastHexPosition = new Vector3(myHexPosition.x + 1.2f, myHexPosition.y, myHexPosition.z);
        Vector3 southWestHexPosition = new Vector3(myHexPosition.x - 0.6f, myHexPosition.y - 0.525f, myHexPosition.z - 0.9f);
        Vector3 southEastHexPosition = new Vector3(myHexPosition.x + 0.6f, myHexPosition.y - 0.525f, myHexPosition.z - 0.9f);
        if (targetHexPosition == northWestHexPosition || targetHexPosition == northEastHexPosition || targetHexPosition == westHexPosition || targetHexPosition == eastHexPosition || targetHexPosition == southWestHexPosition || targetHexPosition == southEastHexPosition)
        {
            closeToAPlayer = true;
        }
        else
        {
            closeToAPlayer = false;
        }
        return closeToAPlayer;
    }
    private IEnumerator AttackCharacter(GameObject target)
    {
        GameObject enemy = turnManager.GetCharacterInTurn();
        inputManager.AttackCharacter(enemy, target);
        while (isAttacking)
        {
            if (turnManager.HasAttacked)
            {
                isAttacking = false;
            }
            yield return null;
        }
        yield break;
    }
    private IEnumerator GenericBehaviour()
    {
        GameObject enemy = turnManager.GetCharacterInTurn();
        Stats enemyStats = enemy.GetComponent<Stats>();
        bool targetFound = false;
        GameObject target = null;
        isMoving = false;
        while (true)
        {
            if (targetFound)
            {
                Debug.Log("Found Target");
                if (isMoving)
                {
                    Debug.Log("Moving to Player");
                }
                else
                {
                    bool adjacentToPlayer = CheckIfIAmAdjacentToTarget(enemy, target);
                    if (adjacentToPlayer)
                    {
                        Debug.Log("Close To Player");
                        if (isAttacking)
                        {
                            Debug.Log("Attacking Player");
                        }
                        else
                        {
                            if (turnManager.HasAttacked)
                            {
                                Debug.Log("I cant't attack Player: I already did that!");
                                inputManager.FinishButton();
                                yield break;
                            }
                            else
                            {
                                if (enemyStats.currentActionPoints >= 2)
                                {
                                    Debug.Log("Attacking Player!");
                                    isAttacking = true;
                                    StartCoroutine(AttackCharacter(target));
                                }
                                else
                                {
                                    Debug.Log("I cant't attack Player: I have no action Points!");
                                    inputManager.FinishButton();
                                    yield break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Far from Player");
                        if (enemyStats.currentMove > 0)
                        {
                            List<GameObject> allPlayers = GetAllPlayersInCombat();
                            List<GameObject> shortestPathToAPlayer = new List<GameObject>();// shortestPathToAPlayer;
                            GameObject closestPlayer = GetClosestAttackablePlayer(allPlayers, out shortestPathToAPlayer);
                            if (shortestPathToAPlayer.Count==0)
                            {
                                Debug.Log("I Can't reach player: no path found");
                                inputManager.FinishButton();
                                StopCoroutine(GenericBehaviour());
                                yield break;
                            }
                            else
                            {
                                Debug.Log("Starting to move to Player");
                                isMoving = true;
                                StartCoroutine(MoveCharacter());
                            }
                        }
                        else
                        {
                            Debug.Log("I can't reach player: No More Movement Points");
                            inputManager.FinishButton();
                            StopCoroutine(GenericBehaviour());
                            yield break;
                        }
                    }
                }
            }
            else
            {
                List<GameObject> allPlayers = GetAllPlayersInCombat();
                target = GetClosestAttackablePlayer(allPlayers);
                if (target != null)
                {
                    Debug.Log("Found Target: " + target);
                    targetFound = true;
                }
                else
                {
                    Debug.Log("No Target Found pls end game");
                }
            }
            yield return new WaitForSeconds(1f);
        }
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
        List<GameObject> allPlayers = GetAllPlayersInCombat();
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
            moveCharacter = false;
        }
        combatAnimationManager.TurnTowardsTarget(enemy, closestPlayer);
        while (moveCharacter)
        {
            combatAnimationManager.MoveAnimation(enemy.GetComponent<Animator>(), true);
            enemy.transform.position = Vector3.Lerp(enemyHex.transform.position, nextHex.transform.position, interpolationAmount);
            interpolationAmount += Time.deltaTime * speed;
            if (enemy.transform.position == nextHex.transform.position)//chegou ao proximo hex
            {
                enemyStats.currentMove -= 1;
                enemyHex.GetComponent<HexProperties>().CharacterInHex = null;
                nextHex.GetComponent<HexProperties>().CharacterInHex = enemy;
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
        yield break;
    }
    private GameObject GetClosestAttackablePlayer(List<GameObject> allPlayersInCombat)
    {
        GameObject closestPlayer = null;
        List<GameObject> shortestPathToAPlayer = new List<GameObject>();
        List<GameObject> currentPathToAPlayer = new List<GameObject>();
        shortestPathToAPlayer = currentPathToAPlayer;
        GameObject me = turnManager.GetCharacterInTurn();
        foreach (GameObject playerInCombat in allPlayersInCombat)
        {
            bool adjacent = CheckIfIAmAdjacentToTarget(me, playerInCombat);
            if (adjacent)
            {
                return playerInCombat;
            }
        }
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
    private GameObject GetClosestAttackablePlayer(List<GameObject> allPlayersInCombat, out List<GameObject> shortestPathToAPlayer)
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
    private List<GameObject> GetAllPlayersInCombat()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> allPlayersInCombat = new List<GameObject>();
        foreach (GameObject player in allPlayers)
        {
            if (player.GetComponent<Stats>().IsAlive)
            {
                allPlayersInCombat.Add(player);
            }
        }

        return allPlayersInCombat;
    }//ok
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
        while (Q.Count != 0)
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
            if (hex.GetComponent<HexProperties>().CharacterInHex == null)
            {
                if (hexPosition == northWestHexPosition || hexPosition == northEastHexPosition || hexPosition == westHexPosition || hexPosition == eastHexPosition || hexPosition == southWestHexPosition || hexPosition == southEastHexPosition)
                {
                    adjacentHexesList.Add(hex);
                }
            }
        }
        return adjacentHexesList;
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
}