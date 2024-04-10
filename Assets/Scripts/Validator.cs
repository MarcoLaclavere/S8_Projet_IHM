using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Validator : MonoBehaviour
{
    //private static bool animationComplete = false;
    public Animator animator;
    public string nextSceneName; // Ajoutez le nom de la scène à charger

    public void ValidateAnimation()
    {

        animator.enabled = true;
        StartCoroutine(WaitForAnimationToEnd());
    }

    private IEnumerator WaitForAnimationToEnd()
    {
        GlobalCustomization.UpdateMoney(-10);
        animator.SetTrigger("ValidateTrigger");

        // Attendez que l'animation soit terminée
        yield return new WaitForSeconds(3.5f);

        // Une fois l'animation terminée, chargez la nouvelle scène

        SceneManager.LoadScene(nextSceneName);
    }
}
