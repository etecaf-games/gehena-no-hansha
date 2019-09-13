using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();
    IDictionary<Vector3, bool> walkablePositions = new Dictionary<Vector3, bool>();

    MapGenerator mapGenerator;
    private void Start()
    {
        walkablePositions = mapGenerator.walkablePositions;
        mapGenerator = GameObject.Find("GridSala").GetComponent<MapGenerator>();
    }
}
