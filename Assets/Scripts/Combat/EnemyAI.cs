using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    private Pathfinding pathfinding;
    private void Awake()
    {
        pathfinding = GetComponent<Pathfinding>();
    }
    private GameObject[] GetAllPlayersInCombat()
    {
        GameObject[] allPlayersInCombat = GameObject.FindGameObjectsWithTag("Player");
        return allPlayersInCombat;
    }
    private GameObject GetClosestAttackablePlayer(GameObject[] allPlayersInCombat)
    {
        GameObject closestPlayer = null;
        foreach (GameObject playerInCombat in allPlayersInCombat)
        {
            GetClosestAttackableHexNextToPlayer(playerInCombat);
        }
        return closestPlayer;
    }
    private GameObject GetClosestAttackableHexNextToPlayer(GameObject player)
    {
        GameObject closestAvailableHex = null;
        GameObject playerHex = pathfinding.CharacterToHexPosition(player);

        return closestAvailableHex;
    }
    //private Pathfinding pathfinding;
    //private CharacterMover characterMover;
    //private TurnManager turnManager;
    //private InputManager inputManager;
    //private GameObject closestPlayer;
    //private CharacterPositioner characterPositioner;
    //private bool closeToPlayer;
    //public bool didAttackAnimation;
    //private void Start()
    //{
    //    characterMover = GetComponent<CharacterMover>();
    //    characterPositioner = GetComponent<CharacterPositioner>();
    //    pathfinding = GetComponent<Pathfinding>();
    //    turnManager = GetComponent<TurnManager>();
    //    inputManager = GetComponent<InputManager>();
    //}
    //private void Update()
    //{
    //    if (closeToPlayer && !didAttackAnimation)
    //    {
    //        didAttackAnimation = true;
    //        GameObject enemy = turnManager.GetCharacterInTurn();
    //        AttackPlayer(attacker: enemy, defender: closestPlayer);
    //    }
    //    if (!turnManager.IsPlayerTurn && ((closeToPlayer && turnManager.hasAttacked) || !closeToPlayer) && !characterMover.MoveCharacter && !characterPositioner.enabled)
    //    {
    //        didAttackAnimation = false;
    //        inputManager.FinishButton();
    //    }
    //}
    //public List<GameObject> ReturnClosestPlayerPath()
    //{
    //    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    //    GameObject enemy = turnManager.GetCharacterInTurn();
    //    GameObject closestAdjacentHex = null;
    //    List<GameObject> closestPlayerPath = new List<GameObject>();
    //    foreach (GameObject player in players)
    //    {
    //        List<GameObject> closestAdjacentHexPath = new List<GameObject>();
    //        GameObject enemyHex = pathfinding.CharacterToHexPosition(enemy);
    //        GameObject playerHex = pathfinding.CharacterToHexPosition(player);
    //        //find closest hex adjacent to player
    //        List<GameObject> playerAdjacentHexes = pathfinding.FindAdjacentHexes(playerHex, false);
    //        foreach (GameObject playerAdjacentHex in playerAdjacentHexes)
    //        {
    //            List<GameObject> path = pathfinding.ReturnShortestPathByBFS(enemyHex, playerAdjacentHex);
    //            if (closestAdjacentHex == null)
    //            {
    //                closestAdjacentHex = playerAdjacentHex;
    //                closestAdjacentHexPath = path;
    //            }
    //            else
    //            {
    //                if (closestAdjacentHexPath.Count > path.Count)
    //                {
    //                    closestAdjacentHexPath = path;
    //                }
    //            }
    //        }
    //        if (players[0] == player)//first iteration of foreach
    //        {
    //            closestPlayerPath = closestAdjacentHexPath;
    //            closestPlayer = player;
    //        }
    //        else if (closestPlayerPath.Count > closestAdjacentHexPath.Count)//se o menor caminho for maior que o caminho atual
    //        {
    //            closestPlayerPath = closestAdjacentHexPath;
    //            closestPlayer = player;
    //        }
    //        else if (closestPlayerPath.Count == closestAdjacentHexPath.Count)
    //        {
    //            int closestPlayerHp = closestPlayer.GetComponent<Stats>().currentHealthPoints;
    //            int playerHp = player.GetComponent<Stats>().currentHealthPoints;
    //            if (closestPlayerHp > playerHp)
    //            {
    //                closestPlayer = player;
    //            }
    //            else if (closestPlayerHp == playerHp)
    //            {
    //                int randomResult = Random.Range(1, 3);
    //                switch (randomResult)
    //                {
    //                    case 1:
    //                        closestPlayer = player;
    //                        break;
    //                    default:

    //                        break;
    //                }
    //            }
    //            else if (closestPlayerHp < playerHp)
    //            {
    //                //do nothing
    //            }
    //        }
    //        else if (closestPlayerPath.Count < closestAdjacentHexPath.Count)
    //        {
    //            //do nothing
    //        }
    //    }
    //    int currentMove = enemy.GetComponent<Stats>().currentMove;
    //    if (closestPlayerPath.Count > currentMove)
    //    {
    //        closestPlayerPath.RemoveRange(currentMove, closestPlayerPath.Count - currentMove);
    //    }
    //    return closestPlayerPath;
    //}
    //public void MoveToPlayer()
    //{
    //    CheckIfAdjacentToPlayer();
    //    if (!closeToPlayer)
    //    {
    //        characterMover.MoveToNewPosition();
    //    }
    //}
    //private void AttackPlayer(GameObject attacker, GameObject defender)
    //{
    //    inputManager.AttackCharacter(attacker, defender);
    //}
    //public void GenericAIBehaviour()
    //{
    //    MoveToPlayer();
    //}
    //private void CheckIfAdjacentToPlayer()
    //{
    //    ReturnClosestPlayerPath();
    //    GameObject closestPlayerHex = pathfinding.CharacterToHexPosition(closestPlayer);
    //    GameObject enemy = turnManager.GetCharacterInTurn();
    //    GameObject enemyHex = pathfinding.CharacterToHexPosition(enemy);
    //    Vector3 enemyHexPosition = enemyHex.transform.position;

    //    Vector3 northWestHexPosition = new Vector3(enemyHexPosition.x - 0.6f, enemyHexPosition.y + 0.525f, enemyHexPosition.z + 0.9f);
    //    Vector3 northEastHexPosition = new Vector3(enemyHexPosition.x + 0.6f, enemyHexPosition.y + 0.525f, enemyHexPosition.z + 0.9f);
    //    Vector3 westHexPosition = new Vector3(enemyHexPosition.x - 1.2f, enemyHexPosition.y, enemyHexPosition.z);
    //    Vector3 eastHexPosition = new Vector3(enemyHexPosition.x + 1.2f, enemyHexPosition.y, enemyHexPosition.z);
    //    Vector3 southWestHexPosition = new Vector3(enemyHexPosition.x - 0.6f, enemyHexPosition.y - 0.525f, enemyHexPosition.z - 0.9f);
    //    Vector3 southEastHexPosition = new Vector3(enemyHexPosition.x + 0.6f, enemyHexPosition.y - 0.525f, enemyHexPosition.z - 0.9f);

    //    Vector3 closestPlayerHexPosition = closestPlayerHex.transform.position;
    //    if (closestPlayerHexPosition == northWestHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else if (closestPlayerHexPosition == northEastHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else if (closestPlayerHexPosition == westHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else if (closestPlayerHexPosition == eastHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else if (closestPlayerHexPosition == southWestHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else if (closestPlayerHexPosition == southEastHexPosition)
    //    {
    //        closeToPlayer = true;
    //    }
    //    else
    //    {
    //        closeToPlayer = false;
    //    }
    //}
}