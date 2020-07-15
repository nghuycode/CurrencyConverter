using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextViewGeneral : MonoBehaviour
{
    public TextView Base, Target;
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
    public void SwapTextView() {
        Swap(ref Base.GetComponent<CountryModel>().CurMoney, ref Target.GetComponent<CountryModel>().CurMoney);
        Swap(ref Base.GetComponent<CountryModel>().CurrencyName, ref Target.GetComponent<CountryModel>().CurrencyName);
        Swap(ref Base.GetComponent<CountryModel>().CurrencyMultiplier, ref Target.GetComponent<CountryModel>().CurrencyMultiplier);
        Swap(ref Base.GetComponent<CountryModel>().Flag, ref Target.GetComponent<CountryModel>().Flag);
        Base.UpdateTextView();
        Target.UpdateTextView();
    }
    public static void Swap<T> (ref T lhs, ref T rhs) {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
}
