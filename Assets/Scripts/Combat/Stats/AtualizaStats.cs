using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizaStats : MonoBehaviour
{
    public GameObject gameMaster;
    public AudioSource musica;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        musica = gameMaster.GetComponent<AudioSource>();
        musica.enabled = false;

        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player.GetComponent<Stats>().characterName == "Hanzo")
            {
                player.GetComponent<Stats>().maxHealthPoints = (GlobalControl.Instance.HPBaseHanzo * 5) + (GlobalControl.Instance.HPBaseHanzo * GlobalControl.Instance.vitalityHanzo);
                player.GetComponent<Stats>().currentHealthPoints = player.GetComponent<Stats>().maxHealthPoints;
                player.GetComponent<Stats>().maxSoulPoints = (GlobalControl.Instance.SPBaseHanzo * 5) + (GlobalControl.Instance.SPBaseHanzo * GlobalControl.Instance.spiritHanzo);
                player.GetComponent<Stats>().currentSoulPoints = player.GetComponent<Stats>().maxSoulPoints;
                player.GetComponent<Stats>().maxMove = GlobalControl.Instance.moveHanzo;
                player.GetComponent<Stats>().currentMove = player.GetComponent<Stats>().maxMove;
                player.GetComponent<Stats>().range = GlobalControl.Instance.rangeHanzo;
                player.GetComponent<Stats>().maxActionPoints = GlobalControl.Instance.actionPointsHanzo;
                player.GetComponent<Stats>().currentActionPoints = player.GetComponent<Stats>().maxActionPoints;

                player.GetComponent<Stats>().strength = GlobalControl.Instance.strengthHanzo;
                player.GetComponent<Stats>().attack = GlobalControl.Instance.attackHanzo;
                player.GetComponent<Stats>().resistance = GlobalControl.Instance.resistanceHanzo;
                player.GetComponent<Stats>().defense = GlobalControl.Instance.defenseHanzo;
                player.GetComponent<Stats>().agility = GlobalControl.Instance.agilityHanzo;
                player.GetComponent<Stats>().magic = GlobalControl.Instance.magicHanzo;
                player.GetComponent<Stats>().vitality = GlobalControl.Instance.vitalityHanzo;
                player.GetComponent<Stats>().spirit = GlobalControl.Instance.spiritHanzo;
            }

            if (player.GetComponent<Stats>().characterName == "Fenrir")
            {
                player.GetComponent<Stats>().maxHealthPoints = (GlobalControl.Instance.HPBaseFenrir * 5) + (GlobalControl.Instance.HPBaseFenrir * GlobalControl.Instance.vitalityFenrir);
                player.GetComponent<Stats>().currentHealthPoints = player.GetComponent<Stats>().maxHealthPoints;
                player.GetComponent<Stats>().maxSoulPoints = (GlobalControl.Instance.SPBaseFenrir * 5) + (GlobalControl.Instance.SPBaseFenrir * GlobalControl.Instance.spiritFenrir);
                player.GetComponent<Stats>().currentSoulPoints = player.GetComponent<Stats>().maxSoulPoints;
                player.GetComponent<Stats>().maxMove = GlobalControl.Instance.moveFenrir;
                player.GetComponent<Stats>().currentMove = player.GetComponent<Stats>().maxMove;
                player.GetComponent<Stats>().range = GlobalControl.Instance.rangeFenrir;
                player.GetComponent<Stats>().maxActionPoints = GlobalControl.Instance.actionPointsFenrir;
                player.GetComponent<Stats>().currentActionPoints = player.GetComponent<Stats>().maxActionPoints;

                player.GetComponent<Stats>().strength = GlobalControl.Instance.strengthFenrir;
                player.GetComponent<Stats>().attack = GlobalControl.Instance.attackFenrir;
                player.GetComponent<Stats>().resistance = GlobalControl.Instance.resistanceFenrir;
                player.GetComponent<Stats>().defense = GlobalControl.Instance.defenseFenrir;
                player.GetComponent<Stats>().agility = GlobalControl.Instance.agilityFenrir;
                player.GetComponent<Stats>().magic = GlobalControl.Instance.magicFenrir;
                player.GetComponent<Stats>().vitality = GlobalControl.Instance.vitalityFenrir;
                player.GetComponent<Stats>().spirit = GlobalControl.Instance.spiritFenrir;
            }

        }
        GameObject mainCamera = Camera.main.gameObject;
        MonoBehaviour[] allScripts = mainCamera.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in allScripts)
        {
            script.enabled = true;
        }
    }
}
