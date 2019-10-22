using UnityEngine;
using System.Collections.Generic;
public class MapGenerator : MonoBehaviour
{
    //This script creates the hexes in the scene!
    [HideInInspector]
    public List<Vector3> gridHexesPositions = new List<Vector3>();
    [HideInInspector]
    public List<GameObject> gridHexesObjects = new List<GameObject>();
    public GameObject hexPrefab;
    private void Start()
    {
        GenerateClassroomGrid();
        //GenerateCorridorGrid();
        //GenerateTerraceGrid();
    }
    private void GenerateClassroomGrid()
    {
        float yPosition = 1.575f, zPosition = 2.7f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 0.525f, zDistance = 0.9f; //Distância entre o ponto central dos hexes
        for (int row = 0; row < 7; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -3.0f;
                    for (int column = 0; column < 6; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 3:
                    xPosition = -4.8f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 4:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 5:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 6:
                    xPosition = -3.0f;
                    for (int column = 0; column < 6; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                default:
                    Debug.Log("Invalid row generation");
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void GenerateCorridorGrid()
    {
        float yPosition = 0.525f, zPosition = 0.9f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 0.525f, zDistance = 0.9f; //Distância entre o ponto central dos hexes

        for (int row = 0; row < 3; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void GenerateTerraceGrid()
    {
        float yPosition = 2.1f, zPosition = 3.6f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 0.525f, zDistance = 0.9f; //Distância entre o ponto central dos hexes
        for (int row = 0; row < 9; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -4.3f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -4.9f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 3:
                    xPosition = -6.1f;
                    for (int column = 0; column < 11; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 4:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 5:
                    xPosition = -6.1f;
                    for (int column = 0; column < 11; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 6:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 7:
                    xPosition = -4.9f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 8:
                    xPosition = -4.3f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void InstantiateHex(float xPosition, float yPosition, float zPosition, int row, int column, bool initialHex)
    {
        Vector3 hexPosition = new Vector3(xPosition, yPosition, zPosition);
        Vector3 hexRotation = new Vector3(60f, 0f, 0f);

        GameObject hexObject = Instantiate(hexPrefab, hexPosition, Quaternion.Euler(hexRotation));

        gridHexesPositions.Add(hexPosition);

        hexObject.name = "Hex (" + row + "," + column + ")" + " (" + gridHexesPositions.Count + ") ";

        hexObject.GetComponent<HexProperties>().initialHex = initialHex;

        //if (initialHex)
        //{
        //    hexObject.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.cyan;
        //}

        gridHexesObjects.Add(hexObject);
    }
}