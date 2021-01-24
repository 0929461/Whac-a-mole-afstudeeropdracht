using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextScript : MonoBehaviour
{
    public Text floatingText;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        AnimatorClipInfo[] info = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, info[0].clip.length);
    }

    /// <summary>
    /// This function handles the floatingnr when killing the mole.
    /// </summary>
    /// <param name="inComingAmount"></param>
    public void ShowFloatingText(int inComingAmount)
    {
        floatingText.text = (inComingAmount > 0) ? "+" + inComingAmount : inComingAmount.ToString();
    }
}
