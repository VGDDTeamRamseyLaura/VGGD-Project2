using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkLaser : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float timeToShrink;

    [SerializeField]
    private float shrinkFactor;
    #endregion

    #region Private Variables
    private bool alreadyShrunk = false;
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !alreadyShrunk)
        {
            alreadyShrunk = true;
            StartCoroutine(ShrinkObject(other.gameObject));
        }
    }

    private IEnumerator ShrinkObject(GameObject objectToShrink)
    {
        int shrinkInstances = 50;
        Vector2 amountToShrinkPerInstance = shrinkFactor / shrinkInstances * objectToShrink.transform.localScale;
        for (int i = 0; i < shrinkInstances; i++) 
        {
            Vector2 currScale = objectToShrink.transform.localScale;
            objectToShrink.transform.localScale = currScale - amountToShrinkPerInstance;
            foreach (Transform child in objectToShrink.transform)
            {
                child.localScale = new Vector2(1f, 1f);
            }
            yield return new WaitForSeconds(timeToShrink / shrinkInstances);
        }
        
    }
}
