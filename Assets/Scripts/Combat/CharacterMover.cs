using UnityEngine;
public class CharacterMover : MonoBehaviour
{
    //private bool moveCharacter = true;
    //private float helpMe;
    //private GameObject player;
    //private Vector3 playerHexTransformPosition;
    //private Vector3 currentHexTransformPosition;
    //private TurnManager turnManager;
    //private Pathfinding pathfinding;
    //private InputManager inputManager;
    //private void Start()
    //{
    //    turnManager = GetComponent<TurnManager>();
    //    pathfinding = GetComponent<Pathfinding>();
    //    inputManager = GetComponent<InputManager>();
    //}
    //private void Update()
    //{
    //    if (moveCharacter)
    //    {
    //        Debug.Log("works?");
    //        Debug.Log(player.transform.position);
    //        player.transform.position = Vector3.Lerp(playerHexTransformPosition, currentHexTransformPosition, helpMe);
    //        helpMe += Time.deltaTime;
    //        if (player.transform.position == currentHexTransformPosition)
    //        {
    //            moveCharacter = false;
    //            helpMe = Time.deltaTime;
    //        }
    //    }
    //}
    //public void MoveCharacterUsingLerp(GameObject _player, GameObject startHex, GameObject goalHex)
    //{
    //    player = _player;
    //    playerHexTransformPosition = startHex.transform.position;
    //    currentHexTransformPosition = goalHex.transform.position;
    //    moveCharacter = true;
    //}
    //public void MoveToNewPosition()
    //{
    //    GameObject player = turnManager.GetCharacterInTurn();
    //    GameObject playerHex = pathfinding.CharacterToHexPosition(player);
    //    //moveCharacter
    //    MoveCharacterUsingLerp(player, playerHex, inputManager.currentHex);
    //    // player.transform.position = currentHex.transform.position;

    //}
}
