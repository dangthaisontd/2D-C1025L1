using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[AddComponentMenu("DangSon/ButtonAnimation")]
public class ButtonAnimation : MonoBehaviour,IPointerMoveHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{

    private Animator anim;
    private int isMoveId;
    //private Image image;
    private void Start()
    {
        anim = GetComponent<Animator>();
        isMoveId = Animator.StringToHash("IsMove");
        //image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool(isMoveId, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool(isMoveId,false);
        //image.color = Color.white;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
      //  image.color = Color.blue;
    }
}
