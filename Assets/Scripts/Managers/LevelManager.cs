using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator == null)
        {
            animator.enabled = false;
        }
    }

    // Memulai proses transisi ke scene lain (Main)
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Mengatur transisi animasi dan membuat scene baru
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f); 

        // Trigger untuk mengakhiri transisi animasi
        animator.SetTrigger("EndTransition");
        SceneManager.LoadScene(sceneName);
        
    }
}
