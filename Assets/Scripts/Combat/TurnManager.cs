using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class TurnManager : MonoBehaviour
{
    private bool hasAttacked = false;
    public int turnIndex = 0;
    public Text movementPointsText;
    public Text actionPointsText;
    public Text healthPointsText;
    public Text soulPointsText;
    public Image healthBar;
    public Image soulBar;
    public List<KeyValuePair<GameObject, int>> turnOrder = new List<KeyValuePair<GameObject, int>>();

    public GameObject gameMaster;
    public AudioSource musica;
    public bool HasAttacked
    {
        get
        {
            return hasAttacked;
        }
        set
        {
            hasAttacked = value;
            if (hasAttacked)
            {
                InputManager inputManager = Camera.main.GetComponent<InputManager>();
                inputManager.AttackButtonPressed = false;
                Camera.main.GetComponent<Pathfinding>().ClearAllHexes();
            }
        }
    }

    private void Awake()
    {
        gameMaster = GameObject.Find("GameMaster");
    }
    private void Start()
    {
        turnOrder = DetermineTurnOrder();
    }
    public List<KeyValuePair<GameObject, int>> DetermineTurnOrder()
    {
        List<KeyValuePair<GameObject, int>> allAgilities = GetAllAgilitiesInScene();
        List<KeyValuePair<GameObject, int>> allAgilitiesFromAliveCharacters = new List<KeyValuePair<GameObject, int>>();
        foreach (KeyValuePair<GameObject, int> characterAndAgility in allAgilities)
        {
            GameObject character = characterAndAgility.Key;
            Stats characterStats = character.GetComponent<Stats>();
            if (characterStats.IsAlive)
            {
                allAgilitiesFromAliveCharacters.Add(characterAndAgility);
            }
        }
        Debug.Log(allAgilities);

        for (int i = 0; i < allAgilitiesFromAliveCharacters.Count - 1; i++)
        {
            Debug.Log("aaa");
            // traverse i+1 to list length
            for (int j = i + 1; j < allAgilitiesFromAliveCharacters.Count; j++)
            {
                // compare list element with  
                // all next element 
                if (allAgilitiesFromAliveCharacters[i].Value < allAgilitiesFromAliveCharacters[j].Value)
                {
                    KeyValuePair<GameObject, int> temp = allAgilitiesFromAliveCharacters[i];
                    allAgilitiesFromAliveCharacters[i] = allAgilitiesFromAliveCharacters[j];
                    allAgilitiesFromAliveCharacters[j] = temp;
                }
                //else if (allAgilitiesFromAliveCharacters[i].Value == allAgilitiesFromAliveCharacters[j].Value)
                //{
                //    int random = Random.Range(1, 3);
                //    switch (random)
                //    {
                //        case 1:
                //            KeyValuePair<GameObject, int> temp = allAgilitiesFromAliveCharacters[i];
                //            allAgilitiesFromAliveCharacters[i] = allAgilitiesFromAliveCharacters[j];
                //            allAgilitiesFromAliveCharacters[j] = temp;
                //            break;
                //        case 2:
                //            //do nothing
                //            break;
                //        default:
                //            Debug.Log("Wrong random value");
                //            break;
                //    }
                //}
            }
        }
        return allAgilitiesFromAliveCharacters;
    }
    private List<KeyValuePair<GameObject, int>> GetAllAgilitiesInScene()
    {
        GameObject[] players;
        List<GameObject> playersAlive = new List<GameObject>();
        List<KeyValuePair<GameObject, int>> agilitiesList = new List<KeyValuePair<GameObject, int>>();
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player.GetComponent<Stats>().IsAlive)
            {
                playersAlive.Add(player);
            }
        }
        if (playersAlive.Count > 0)
        {
            int agility;
            for (int i = 0; i < playersAlive.Count; i++)
            {
                agility = playersAlive[i].GetComponent<Stats>().agility;
                KeyValuePair<GameObject, int> playerAgility = new KeyValuePair<GameObject, int>(playersAlive[i], agility);
                agilitiesList.Add(playerAgility);
            }
        }
        else
        {
            Debug.Log("There are no players in the scene");
            StartCoroutine(SaiDoJogoPerdendo());
        }

        GameObject[] enemies;
        List<GameObject> enemiesAlive = new List<GameObject>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Stats>().IsAlive)
            {
                enemiesAlive.Add(enemy);
            }
        }
        if (enemiesAlive.Count > 0)
        {
            int agility;
            for (int i = 0; i < enemiesAlive.Count; i++)
            {
                agility = enemiesAlive[i].GetComponent<Stats>().agility;
                KeyValuePair<GameObject, int> enemyAgility = new KeyValuePair<GameObject, int>(enemiesAlive[i], agility);
                agilitiesList.Add(enemyAgility);
            }
        }
        else
        {
            Debug.Log("There are no enemies in the scene");
            StartCoroutine(SaiDoJogoGanhando());

        }
        return agilitiesList;
    }
    private IEnumerator SaiDoJogoGanhando()
    {
        GameObject.Find("Parabéns").GetComponent<Text>().text = "Vitória";
        yield return new WaitForSeconds(5f);
        Player.possoPausar = false;
        SceneManager.LoadScene("Corredor1", LoadSceneMode.Single);
        ganhouCombate();
    }
    private IEnumerator SaiDoJogoPerdendo()
    {
        GameObject.Find("Parabéns").GetComponent<Text>().text = "Derrota";
        yield return new WaitForSeconds(5f);
        Player.possoPausar = false;
        Destroy(gameMaster);
        Destroy(FindObjectOfType<Canvas>().GetComponent<CanvasScaler>());
        Destroy(FindObjectOfType<Canvas>().GetComponent<GraphicRaycaster>());
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void ganhouCombate()
    {
        if (GlobalControl.Instance.comecouLutaSala1 == true)
        {
            SceneManager.LoadScene("Classroom");
            GlobalControl.Instance.XpThiess += 40;
            GlobalControl.Instance.XpGlenn += 40;
            //GlobalControl.Instance.comecouLutaSala1 = false;
            GlobalControl.Instance.ganhouLutaSala1 = true;
            musica = gameMaster.GetComponent<AudioSource>();
            musica.enabled = true;
        }

        else if (GlobalControl.Instance.comecouLutaSala2 == true)
        {
            SceneManager.LoadScene("Classroom2");
            GlobalControl.Instance.XpThiess += 50;
            GlobalControl.Instance.XpGlenn += 50;
            //GlobalControl.Instance.comecouLutaSala2 = false;
            GlobalControl.Instance.ganhouLutaSala2 = true;
            musica = gameMaster.GetComponent<AudioSource>();
            musica.enabled = true;
        }

        else if (GlobalControl.Instance.comecouLutaCorredor == true)
        {
            SceneManager.LoadScene("Corredor1");
            GlobalControl.Instance.XpThiess += 30;
            GlobalControl.Instance.XpGlenn += 30;
            //GlobalControl.Instance.comecouLutaCorredor = false;
            GlobalControl.Instance.ganhouLutaCorredor = true;
            musica = gameMaster.GetComponent<AudioSource>();
            musica.enabled = true;
        }

        else if (GlobalControl.Instance.comecouLutaTerraco == true)
        {
            Destroy(FindObjectOfType<GlobalControl>().gameObject);
            Destroy(FindObjectOfType<Canvas>().gameObject);
            SceneManager.LoadScene("Creditos");
            GlobalControl.Instance.comecouJogo = false;
        }
        Player.possoPausar = true;
    }
    private void NextRound()
    {
        if (turnIndex == turnOrder.Count - 1)//se for a vez da ultima pessoa a agir
        {
            turnIndex = 0;
        }
    }
    public void NextTurn()
    {
        HasAttacked = false;
        if (turnIndex == turnOrder.Count - 1)
        {
            NextRound();
        }
        else if (turnIndex < turnOrder.Count)
        {
            turnIndex++;
        }
        if (GetCharacterInTurn().tag == "Enemy")
        {
            Debug.Log("Vez de um inimigo");
            EnemyAI enemyAI = Camera.main.GetComponent<EnemyAI>();
            enemyAI.InitiateAI();
            SetPlayerHUDActive(false);
        }
        else if (GetCharacterInTurn().tag == "Player")
        {
            SetPlayerHUDActive(true);
        }
    }
    public void SetPlayerHUDActive(bool value)
    {
        GameObject playerHUD = GameObject.Find("PlayerHUD");
        Image[] allImagesPlayerHUD = playerHUD.GetComponentsInChildren<Image>(true);
        Text[] allTextPlayerHUD = playerHUD.GetComponentsInChildren<Text>(true);
        foreach (Image image in allImagesPlayerHUD)
        {
            image.enabled = value;
        }
        foreach (Text text in allTextPlayerHUD)
        {
            text.enabled = value;
        }
    }
    public GameObject GetCharacterInTurn()
    {
        if (turnIndex >= turnOrder.Count)
        {
            turnIndex = turnOrder.Count - 1;
        }
        return turnOrder[turnIndex].Key;
    }
    public GameObject GetCharacterInNextTurn()
    {
        if (turnIndex == turnOrder.Count - 1)
        {
            return turnOrder[0].Key;
        }
        else
        {
            return turnOrder[turnIndex + 1].Key;
        }
    }
    public void UpdateCombatUIValues(bool nextTurn)
    {
        GameObject currentCharacter = GetCharacterInTurn();
        GameObject nextCharacter = GetCharacterInNextTurn();
        Stats currentCharacterStats = currentCharacter.GetComponent<Stats>();
        int movementLeft;
        int actionPointsLeft;
        int maxHealthPoints;
        int maxSoulPoints;
        int currentHealthPoints;
        int currentSoulPoints;
        if (nextTurn)
        {
            currentCharacterStats.currentMove = currentCharacterStats.maxMove;
            currentCharacterStats.currentActionPoints = currentCharacterStats.maxActionPoints;
            movementLeft = currentCharacterStats.maxMove;
            actionPointsLeft = currentCharacterStats.maxActionPoints;
        }
        else
        {
            movementLeft = currentCharacterStats.currentMove;
            actionPointsLeft = currentCharacterStats.currentActionPoints;
        }
        maxHealthPoints = currentCharacterStats.maxHealthPoints;
        maxSoulPoints = currentCharacterStats.maxSoulPoints;
        currentHealthPoints = currentCharacterStats.currentHealthPoints;
        currentSoulPoints = currentCharacterStats.currentSoulPoints;
        healthBar.fillAmount = float.Parse(currentHealthPoints.ToString()) / float.Parse(maxHealthPoints.ToString());
        soulBar.fillAmount = float.Parse(currentSoulPoints.ToString()) / float.Parse(maxSoulPoints.ToString());
        movementPointsText.text = movementLeft.ToString();
        actionPointsText.text = actionPointsLeft.ToString();
        healthPointsText.text = "PV " + currentHealthPoints.ToString() + "/" + maxHealthPoints.ToString();
        soulPointsText.text = "SP " + currentSoulPoints.ToString() + "/" + maxSoulPoints.ToString();
        UpdateTurnQueueIcons(currentCharacter: currentCharacter, nextCharacter: nextCharacter);
    }
    private void UpdateTurnQueueIcons(GameObject currentCharacter, GameObject nextCharacter)
    {
        InputManager inputManager = Camera.main.GetComponent<InputManager>();
        inputManager.bigIconArea.sprite = currentCharacter.GetComponent<Icon>().bigIcon;
        inputManager.smallIconArea.sprite = nextCharacter.GetComponent<Icon>().smallIcon;
    }
    public void RemoveCharacterFromQueue(GameObject characterToRemove)
    {
        foreach (KeyValuePair<GameObject, int> character in turnOrder)
        {
            if (character.Key == characterToRemove)
            {
                turnOrder.Remove(character);
                GameObject currentCharacter = GetCharacterInTurn();
                GameObject nextCharacter = GetCharacterInNextTurn();
                UpdateTurnQueueIcons(currentCharacter, nextCharacter);
                GetAllAgilitiesInScene();
                DetermineTurnOrder();
                break;
            }
        }
    }
}