using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/BackGroundController")]
public class BackGroundController : MonoBehaviour
{
    [Header("BackGround")]
    private Renderer[] backGrounds;
    public float speedBackGround;
    public float speedMidGround;
    public float speedForeGround;
    private Transform target;
    float startPosX;
    //
    // Start is called beforpube the first frame update
    void Start()
    {
        backGrounds = GetComponentsInChildren<Renderer>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("VitualCamera").transform;
        startPosX = target.position.x;
        foreach (Renderer r in backGrounds)
        {
            Debug.Log(r.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.position.x - startPosX;
        if(backGrounds!=null)
        {
            var offset = (x * speedBackGround) % 1;
            backGrounds[0].material.mainTextureOffset = new Vector2(offset, backGrounds[0].material.mainTextureOffset.y);
            //
            var offsettwo = (x * speedMidGround) % 1;
            backGrounds[1].material.mainTextureOffset = new Vector2(offsettwo, backGrounds[1].material.mainTextureOffset.y);
            var offsetthree = (x * speedForeGround) % 1;
            backGrounds[2].material.mainTextureOffset = new Vector2(offsetthree, backGrounds[2].material.mainTextureOffset.y);
        }
    }
}
