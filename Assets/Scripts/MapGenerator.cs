using UnityEngine;
using System.Collections.Generic;
public class MapGenerator : MonoBehaviour
{
    //This script creates the hexes in the scene!
    public GameObject[,] gridHexesObjects = new GameObject[8, 9];
    public Vector3[,] gridHexesPositions = new Vector3[8, 9];
    public List<GameObject> idealGridHexesList = new List<GameObject>();
    public GameObject hexPrefab;
    private void Start()
    {
        GenerateCorridorGrid();
    }
    private void GenerateClassroomGrid()
    {
        float yPosition = 1.575f, zPosition = 2.7f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 0.525f, zDistance = 0.9f; //Distância entre o ponto central dos hexes
        for (int row = 0; row < 7; row++)
        {
            if (row == 0 || row == 6)
            {
                float xPosition = -3.0f;
                for (int column = 0; column < 6; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
            }
            else if (row == 1 || row == 5)
            {
                float xPosition = -3.6f;
                for (int column = 0; column < 7; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
            }
            else if (row == 2 || row == 4)
            {
                float xPosition = -4.2f;
                for (int column = 0; column < 8; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
            }
            else if (row == 3)
            {
                float xPosition = -4.8f;
                for (int column = 0; column < 9; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
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
            if (row == 0 || row == 2)
            {
                float xPosition = -3.6f;
                for (int column = 0; column < 7; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
            }
            else if (row == 1)
            {
                float xPosition = -4.2f;
                for (int column = 0; column < 8; column++)
                {
                    InstantiateHex(xPosition, yPosition, zPosition, row, column);
                    xPosition += xDistance;
                }
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void InstantiateHex(float xPosition, float yPosition, float zPosition, int row, int column)
    {
        Vector3 hexPosition = new Vector3(xPosition, yPosition, zPosition);
        Vector3 hexRotation = new Vector3(60f, 0f, 0f);

        GameObject hexObject = Instantiate(hexPrefab, hexPosition, Quaternion.Euler(hexRotation));

        gridHexesPositions[row, column] = hexPosition;
        gridHexesObjects[row, column] = hexObject;

        hexObject.name = "Hex (" + row + "," + column + ")";
    }
}