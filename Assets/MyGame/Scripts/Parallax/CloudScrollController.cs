using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/CloudScrollController")]
public class CloudScrollController : MonoBehaviour
{
    public float speedCloud;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var offset = (speedCloud * Time.time) % 1;
        renderer.material.mainTextureOffset = new Vector2(offset, renderer.material.mainTextureOffset.y);
    }
}
