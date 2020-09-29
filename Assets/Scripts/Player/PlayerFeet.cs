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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Environment"))
        {
            playerMovement.IsGrounded = true;
            playerMovement.ResetAirJumps();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Environment"))
        {
            StartCoroutine(SetNotGrounded());
        }
    }

    private IEnumerator SetNotGrounded()
    {
        // Lets the player make jumps they slightly shouldn't
        yield return new WaitForSeconds(forgiveTime);
        playerMovement.IsGrounded = false;
    }
}
