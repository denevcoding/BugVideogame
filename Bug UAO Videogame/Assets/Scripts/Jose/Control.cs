using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour

{
    public float delay = 3;
    
    public Animator animator;



    public void NextScene()
    {
        animator.SetTrigger("FadeOut");

       StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

    public void PrevScene()
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(0);
    }

}