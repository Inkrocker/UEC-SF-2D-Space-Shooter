using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomBombExploding : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2.10f);
    }
}
