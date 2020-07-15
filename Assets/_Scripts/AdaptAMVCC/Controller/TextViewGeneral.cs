using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextViewGeneral : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        InputHandler.Instance.OnSwipeUp += SwipeUp;
        InputHandler.Instance.OnSwipeDown += SwipeDown;
    }
    void SwipeUp() {
        anim.SetTrigger("TextViewUnhide");
    }
    void SwipeDown() {
        anim.SetTrigger("TextViewHide");
    }
}
