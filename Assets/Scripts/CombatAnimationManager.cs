using UnityEngine;
public class CombatAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;
    private void Start()
    {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        playerAnimator.SetBool("Parado", true);
        playerAnimator.SetBool("Movendo", false);
    }
    public void Move()
    {
        playerAnimator.SetBool("Parado", false);
        playerAnimator.SetBool("Movendo", true);
    }
}
