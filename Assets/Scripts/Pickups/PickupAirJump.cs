using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAirJump : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int numJumps = 1;
    #endregion

    #region Cached References
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                other.GetComponent<PlayerMovement>().IncreaseNumAirJumps(numJumps);
                StartCoroutine(DisablePickup(3f));
            }
        }
    }

    private IEnumerator DisablePickup(float timeToDisable)
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        yield return new WaitForSeconds(timeToDisable);
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }
}
