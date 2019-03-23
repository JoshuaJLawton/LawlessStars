using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroySmoke());
    }

    IEnumerator DestroySmoke()
    {
        yield return new WaitForSeconds(0.31f);
        Destroy(this.gameObject);
    }
}
