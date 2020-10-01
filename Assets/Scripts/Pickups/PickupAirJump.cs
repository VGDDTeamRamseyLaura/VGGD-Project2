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
            other.GetComponent<PlayerMovement>().IncreaseNumAirJumps(numJumps);
            Destroy(gameObject);
        }
    }
}
