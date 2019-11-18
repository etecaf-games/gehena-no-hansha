using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private InputManager inputManager;
    private TurnManager turnManager;
    private void Start()
    {
        mapGenerator = GetComponent<MapGenerator>();
        inputManager = GetComponent<InputManager>();
        turnManager = GetComponent<TurnManager>();
    }
    public List<GameObject> FindHexesAvailableForMovement(int movementLeft)
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        List<GameObject> adjacentHexes = new List<GameObject>();
        List<GameObject> allHexes = new List<GameObject>();
        for (int i = 0; i < movementLeft; i++)
        {
            if (i == 0)
            {
                adjacentHexes = FindAdjacentHexes(currentHex,false);
            }
            else
            {
                foreach (GameObject adjacentHex in adjacentHexes)
                {
                    List<GameObject> tempHexes = new List<GameObject>();
                    tempHexes = FindAdjacentHexes(adjacentHex,false);
                    foreach (GameObject tempHex in tempHexes)
                    {
                        if (!adjacentHexes.Contains(tempHex) && tempHex != currentHex)
                        {
                            allHexes.Add(tempHex);
                        }
                    }
                }
            }
            adjacentHexes.AddRange(allHexes);
        }
        return adjacentHexes;
    }
    public List<GameObject> FindHexesAvailableForAttack(int range)
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        List<GameObject> adjacentHexes = new List<GameObject>();
        List<GameObject> allHexes = new List<GameObject>();
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        bool hasNorthWestSight = true;
        bool hasNorthEastSight = true;
        bool hasWestSight = true;
        bool hasEastSight = true;
        bool hasSouthWestSight = true;
        bool hasSouthEastSight = true;
        for (int i = 1; i <= range; i++)
        {
            Vector3 currentHexPosition = currentHex.transform.position;
            Vector3 northWestHexPosition = new Vector3(currentHexPosition.x - (0.6f * i), currentHexPosition.y + (0.525f * i), currentHexPosition.z + (0.9f * i));
            Vector3 northEastHexPosition = new Vector3(currentHexPosition.x + (0.6f * i), currentHexPosition.y + (0.525f * i), currentHexPosition.z + (0.9f * i));
            Vector3 westHexPosition = new Vector3(currentHexPosition.x - (1.2f * i), currentHexPosition.y, currentHexPosition.z);
            Vector3 eastHexPosition = new Vector3(currentHexPosition.x + (1.2f * i), currentHexPosition.y, currentHexPosition.z);
            Vector3 southWestHexPosition = new Vector3(currentHexPosition.x - (0.6f * i), currentHexPosition.y - (0.525f * i), currentHexPosition.z - (0.9f * i));
            Vector3 southEastHexPosition = new Vector3(currentHexPosition.x + (0.6f * i), currentHexPosition.y - (0.525f * i), currentHexPosition.z - (0.9f * i));
            foreach (GameObject hex in gridHexesObjects)
            {
                Vector3 hexPosition = hex.transform.position;
                if (hex != currentHex)
                {
                    if (hexPosition == northWestHexPosition && hasNorthWestSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasNorthWestSight = false;
                        }
                        allHexes.Add(hex);
                    }
                    else if (hexPosition == northEastHexPosition && hasNorthEastSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasNorthEastSight = false;
                        }
                        allHexes.Add(hex);
                    }
                    else if (hexPosition == westHexPosition && hasWestSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasWestSight = false;
                        }
                        allHexes.Add(hex);
                    }
                    else if (hexPosition == eastHexPosition && hasEastSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasEastSight = false;
                        }
                        allHexes.Add(hex);
                    }
                    else if (hexPosition == southWestHexPosition && hasSouthWestSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasSouthWestSight = false;
                        }
                        allHexes.Add(hex);
                    }
                    else if (hexPosition == southEastHexPosition && hasSouthEastSight)
                    {
                        if (hex.gameObject.GetComponent<HexProperties>().characterInHex != null)
                        {
                            hasSouthEastSight = false;
                        }
                        allHexes.Add(hex);
                    }
                }
                adjacentHexes.AddRange(allHexes);
            }
        }
        return adjacentHexes;
    }
    public void DisplayAvailableHexesToMove()
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        Stats currentCharacterStats = currentCharacter.GetComponent<Stats>();
        List<GameObject> moveableHexes = FindHexesAvailableForMovement(currentCharacterStats.currentMove);
        foreach (GameObject item in moveableHexes)
        {
            item.GetComponent<HexProperties>().canMove = true;
            item.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    public void DisplayAvailableHexesToAttack()
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        Stats currentCharacterStats = currentCharacter.GetComponent<Stats>();
        List<GameObject> attackableHexes = FindHexesAvailableForAttack(currentCharacterStats.range);
        foreach (GameObject item in attackableHexes)
        {
            item.GetComponent<HexProperties>().canAttack = true;
            item.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    public List<GameObject> ReturnShortestPathByBFS(GameObject startHex, GameObject goalHex)
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
            List<GameObject> adjacentHexes = FindAdjacentHexes(currentHex,false);
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
    //Finds each hex adjacent to originHex
    public List<GameObject> FindAdjacentHexes(GameObject currentHex, bool ignoreCharacterInHex)
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
            if (hex.GetComponent<HexProperties>().characterInHex == null || ignoreCharacterInHex)
            {
                if (hexPosition == northWestHexPosition || hexPosition == northEastHexPosition || hexPosition == westHexPosition || hexPosition == eastHexPosition || hexPosition == southWestHexPosition || hexPosition == southEastHexPosition)
                {
                    adjacentHexesList.Add(hex);
                }
            }
        }
        return adjacentHexesList;
    }
    public GameObject CharacterToHexPosition(GameObject character)
    {
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        GameObject returnHex = null;
        foreach (GameObject hex in gridHexesObjects)
        {
            Vector3 hexPosition = hex.transform.position;
            if (hexPosition == character.transform.position)
            {
                returnHex = hex;
            }
        }
        //this should never happen
        if (returnHex == null)
        {
            Debug.Log("Deu Merda no Pathfinding pra converter o personagem pra hexPosition");
        }
        return returnHex;
    }
    public void ClearAllHexes()
    {
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        foreach (GameObject hex in gridHexesObjects)
        {
            hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
            HexProperties hexProperties = hex.GetComponent<HexProperties>();
            hexProperties.canMove = false;
            hexProperties.canAttack = false;
        }
    }
}