using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyTimer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
