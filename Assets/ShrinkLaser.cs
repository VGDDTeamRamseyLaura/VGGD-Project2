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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(ShrinkObject(other.gameObject));
        }
    }

    private IEnumerator ShrinkObject(GameObject objectToShrink)
    {
        objectToShrink.transform.localScale = new Vector2(0.5f, 0.5f);
        yield return null;
    }
}
