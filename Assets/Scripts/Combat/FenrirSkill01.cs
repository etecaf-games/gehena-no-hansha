using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FenrirSkill01 : MonoBehaviour
{
    private CombatAnimationManager combatAnimationManager;
    private MapGenerator mapGenerator;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    private InputManager inputManager;
    private List<GameObject> hexesToTheLeftOfPlayer = new List<GameObject>();
    private List<GameObject> hexesToTheRightOfPlayer = new List<GameObject>();
    private void Awake()
    {
        combatAnimationManager = GetComponent<CombatAnimationManager>();
        mapGenerator = GetComponent<MapGenerator>();
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
        inputManager = GetComponent<InputManager>();
    }
    private void DoTheSkill(bool toTheRight)
    {
        List<GameObject> hexesTargetedByThisSkill = FindHexesAvailableForSkill();
        GameObject fenrir = turnManager.GetCharacterInTurn();
        Stats fenrirStats = fenrir.GetComponent<Stats>();
        SpriteRenderer fenrirSprite = fenrir.GetComponent<SpriteRenderer>();
        Animator fenrirAnimator = fenrir.GetComponent<Animator>();
        fenrirStats.currentSoulPoints -= 8;
        fenrirStats.currentActionPoints -= 2;
        turnManager.UpdateCombatUIValues(nextTurn: false);

        foreach (GameObject hexTargeted in hexesTargetedByThisSkill)
        {
            if (toTheRight)
            {
                fenrirSprite.flipX = false;
                if (hexTargeted.transform.position.x > fenrir.transform.position.x)
                {
                    HexProperties hexProperties = hexTargeted.GetComponent<HexProperties>();
                    if (hexProperties.CharacterInHex != null)
                    {
                        if (hexProperties.CharacterInHex.tag == "Enemy")
                        {
                            Stats enemyStats = hexProperties.CharacterInHex.GetComponent<Stats>();

                            int damage = Random.Range(1, 5);
                            damage += fenrirStats.strength;
                            enemyStats.currentHealthPoints -= damage;
                            combatAnimationManager.TakeDamage(enemyStats.gameObject.GetComponent<Animator>());
                        }
                    }
                }
            }
            else
            {
                fenrirSprite.flipX = true;
                if (hexTargeted.transform.position.x < fenrir.transform.position.x)
                {
                    HexProperties hexProperties = hexTargeted.GetComponent<HexProperties>();
                    if (hexProperties.CharacterInHex != null)
                    {
                        if (hexProperties.CharacterInHex.tag == "Enemy")
                        {
                            Stats enemyStats = hexProperties.CharacterInHex.GetComponent<Stats>();

                            int damage = Random.Range(1, 5);
                            damage += fenrirStats.strength;
                            enemyStats.currentHealthPoints -= damage;
                            combatAnimationManager.TakeDamage(enemyStats.gameObject.GetComponent<Animator>());
                        }
                    }
                }
            }

        }
        combatAnimationManager.FenrirSkill01Animation(fenrirAnimator);
    }
    private IEnumerator HighlightHexToSkill()
    {
        GameObject currentHex = null;
        GameObject previousHex = null;
        GameObject fenrir = turnManager.GetCharacterInTurn();
        while (true)
        {
            Debug.Log("Ainda");
            RaycastHit hit = inputManager.MousePositionToRaycastHit(inputManager.hexLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Hex")
                {
                    if (hit.collider.gameObject != currentHex)
                    {
                        previousHex = currentHex;
                        currentHex = hit.collider.gameObject;
                    }
                    if (currentHex.GetComponent<HexProperties>().canSkill)
                    {

                        if (currentHex.transform.position.x > fenrir.transform.position.x)
                        {
                            foreach (GameObject hex in hexesToTheRightOfPlayer)
                            {
                                hex.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                            }
                        }
                        else if (currentHex.transform.position.x < fenrir.transform.position.x)
                        {
                            foreach (GameObject hex in hexesToTheLeftOfPlayer)
                            {
                                hex.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                            }
                        }
                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Clicou para usar a skill...");
                            GameObject player = turnManager.GetCharacterInTurn();
                            Stats playerStats = player.GetComponent<Stats>();
                            string characterName = playerStats.characterName;
                            if (characterName == "Fenrir")
                            {
                                bool hasEnoughSoulPoints;
                                if (playerStats.currentSoulPoints >= 8)
                                {
                                    hasEnoughSoulPoints = true;
                                }
                                else
                                {
                                    hasEnoughSoulPoints = false;
                                    Debug.Log("Não consegui usar a skill porque: não tenho pontos de alma suficientes");
                                }
                                bool hasEnoughActionPoints;
                                if (playerStats.currentActionPoints >= 2)
                                {
                                    hasEnoughActionPoints = true;
                                }
                                else
                                {
                                    hasEnoughActionPoints = false;
                                    Debug.Log("Não consegui usar a skill porque: não tenho pontos de ação suficientes");
                                }
                                if (hasEnoughSoulPoints && hasEnoughActionPoints)
                                {
                                    GameObject currentPlayer = turnManager.GetCharacterInTurn();
                                    Stats currentPlayerStats = currentPlayer.GetComponent<Stats>();

                                    if (currentPlayerStats.characterName == "Fenrir")
                                    {
                                        bool toTheRight = false;
                                        if (currentHex.transform.position.x > player.transform.position.x)
                                        {
                                            toTheRight = true;
                                            Debug.Log(toTheRight);
                                            DoTheSkill(toTheRight);
                                        }
                                        else if (currentHex.transform.position.x < player.transform.position.x)
                                        {
                                            toTheRight = false;
                                            Debug.Log(toTheRight);
                                            DoTheSkill(toTheRight);
                                        }

                                        pathfinding.ClearAllHexes();
                                        yield break;
                                    }
                                }
                            }
                            else if (characterName == "Hanzo")
                            {
                                Debug.Log("Skill do Hanzo");
                            }
                        }
                    }
                    else
                    {
                        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    }
                    //if (previousHex != null)
                    //{
                    //    if (previousHex.GetComponent<HexProperties>().canSkill)
                    //    {
                    //        if (previousHex.transform.position.x > fenrir.transform.position.x)
                    //        {
                    //            foreach (GameObject hex in hexesToTheRightOfPlayer)
                    //            {
                    //                hex.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
                    //            }
                    //        }
                    //        else if (previousHex.transform.position.x < fenrir.transform.position.x)
                    //        {
                    //            foreach (GameObject hex in hexesToTheLeftOfPlayer)
                    //            {
                    //                hex.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    //    }
                    //}
                }
            }
            else
            {
                if (previousHex != null)
                {
                    if (previousHex.GetComponent<HexProperties>().canSkill)
                    {
                        if (previousHex.transform.position.x > fenrir.transform.position.x)
                        {
                            foreach (GameObject hex in hexesToTheRightOfPlayer)
                            {
                                hex.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
                            }
                        }
                        else if (previousHex.transform.position.x < fenrir.transform.position.x)
                        {
                            foreach (GameObject hex in hexesToTheLeftOfPlayer)
                            {
                                hex.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
                            }
                        }
                    }
                }
            }
            yield return null;
        }
    }
    public void DisplayAvailableHexesToSkill()
    {
        List<GameObject> skillableHexes = FindHexesAvailableForSkill();
        foreach (GameObject item in skillableHexes)
        {
            item.GetComponent<HexProperties>().canSkill = true;
            item.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
        }
    }
    public void CheckIfPlayerClickOnSkillableHex()
    {
        StartCoroutine(HighlightHexToSkill());
    }
    public List<GameObject> FindHexesAvailableForSkill()
    {
        List<GameObject> skillableHexes = new List<GameObject>();
        GameObject fenrir = turnManager.GetCharacterInTurn();
        float xDistance = mapGenerator.xDistance;
        GameObject fenrirHex = pathfinding.CharacterToHexPosition(fenrir);
        Vector3 fenrirHexPosition = fenrirHex.transform.position;
        List<Vector3> allPossiblePositions = new List<Vector3>();

        for (int i = 1; i <= 3; i++)
        {
            Vector3 possibleSkillPosition = new Vector3(fenrirHexPosition.x + xDistance * i, fenrirHexPosition.y, fenrirHexPosition.z);
            allPossiblePositions.Add(possibleSkillPosition);
        }
        for (int i = 1; i <= 3; i++)
        {
            Vector3 possibleSkillPosition = new Vector3(fenrirHexPosition.x - xDistance * i, fenrirHexPosition.y, fenrirHexPosition.z);
            allPossiblePositions.Add(possibleSkillPosition);
        }
        if(hexesToTheRightOfPlayer.Count>0)
        {
            pathfinding.ClearAllHexes();
            hexesToTheRightOfPlayer.Clear();
        }
        if (hexesToTheLeftOfPlayer.Count>0)
        {
            pathfinding.ClearAllHexes();
            hexesToTheLeftOfPlayer.Clear();
        }
        foreach (GameObject hex in mapGenerator.gridHexesObjects)
        {
            foreach (Vector3 possiblePosition in allPossiblePositions)
            {
                if (possiblePosition == hex.transform.position)
                {
                    if (hex.transform.position.x > fenrir.transform.position.x)
                    {
                        hexesToTheRightOfPlayer.Add(hex);
                    }
                    else if (hex.transform.position.x < fenrir.transform.position.x)
                    {
                        hexesToTheLeftOfPlayer.Add(hex);
                    }
                    skillableHexes.Add(hex);
                    break;
                }
            }
            if (skillableHexes.Count == 6)
            {
                break;
            }
        }
        return skillableHexes;
    }
}