using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float forgiveTime;
    
    [SerializeField]
    private PlayerMovement playerMovement;
    #endregion

    private void OnColliderEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Environment"))
        {
            playerMovement.IsGrounded = true;
            playerMovement.ResetAirJumps();
        }
    }

    private void OnColliderExit2D(Collider2D other)
    {
        if (other.tag.Equals("Environment"))
        {
            StartCoroutine(SetNotGrounded());
        }
    }

    private IEnumerator SetNotGrounded()
    {
        // Lets the player make jumps they slightly shouldn't
        yield return new WaitForSeconds(forgiveTime);
        playerMovement.IsGrounded = false;
        // playerMovement.SetNumJumpsToZero();
        
    }
}
