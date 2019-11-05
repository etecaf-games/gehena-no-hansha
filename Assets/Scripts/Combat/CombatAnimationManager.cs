using UnityEngine;
using System.Collections.Generic;
public class CombatAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;
    private void Start()
    {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerAnimator = item.GetComponent<Animator>();
            playerAnimator.SetBool("Parado", true);
            playerAnimator.SetBool("Movendo", false);
        }
    }
    public void Move()
    {
        playerAnimator.SetBool("Parado", false);
        playerAnimator.SetBool("Movendo", true);
    }
}
