using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    Animator anim;
    private void Awake() {
        anim = this.GetComponent<Animator>();
        //InputHandler.Instance.OnSwipeUp += SwipeUp;
        //InputHandler.Instance.OnSwipeDown += SwipeDown;
    }
    private void Start() {
        InputHandler.Instance.OnSwipeUp += SwipeUp;
        InputHandler.Instance.OnSwipeDown += SwipeDown;
    }
    public void SwipeUp() {
        anim.SetTrigger("KeypadUnhide");
    }
    public void SwipeDown() {
        anim.SetTrigger("KeypadHide");
    }
}
