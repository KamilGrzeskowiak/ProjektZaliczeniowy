using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class DoorInteraction : MonoBehaviour
{
    public string sceneToLoad;
    public string animationTriggerName;

    private Animator Maincharacter;
    private Running playerMovement;
    private bool isInteracting = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            Maincharacter = other.GetComponent<Animator>();
            playerMovement = other.GetComponent<Running>();

            if (Maincharacter != null && playerMovement != null)
            {
                isInteracting = true;
                playerMovement.enabled = false;
                Maincharacter.SetTrigger(animationTriggerName);
                StartCoroutine(WaitForAnimationAndLoadScene(Maincharacter));
            }
        }
    }

    private IEnumerator WaitForAnimationAndLoadScene(Animator animator)
    {
        yield return null;

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 4.0f)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
