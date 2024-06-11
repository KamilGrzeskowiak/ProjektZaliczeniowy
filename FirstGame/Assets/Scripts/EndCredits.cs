using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public Animator animator;
    public string nextSceneName;

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CreditsAnimation") ||
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
