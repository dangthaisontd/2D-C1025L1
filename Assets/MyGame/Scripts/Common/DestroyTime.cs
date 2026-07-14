using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/DestroyTime")]
public class DestroyTime : MonoBehaviour
{
    [SerializeField] float timeDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeDelay);
    }
}
