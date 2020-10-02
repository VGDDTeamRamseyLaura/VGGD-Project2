using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMisc : MonoBehaviour
{
    #region Cached Components
    private PlayerMovement playerMovement;
    
    private Animator animator;
    #endregion

    #region Private Variables
    private bool isDead = false;
    #endregion

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    
    public void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        playerMovement.IsLocked = true;
        animator.SetTrigger("Death");
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
