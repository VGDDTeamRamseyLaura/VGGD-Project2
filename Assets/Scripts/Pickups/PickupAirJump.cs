using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAirJump : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int numJumps = 1;
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                other.GetComponent<PlayerMovement>().IncreaseNumAirJumps(numJumps);
                Destroy(gameObject);
            }
        }
    }
}
