using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//change classname
public class MoleController : MonoBehaviour
{
    Collider collider;
    [HideInInspector] public Animator animator;

    //this variable arranges the hits for destroying the moles.
    public int getHit = 1;
    [HideInInspector] public GameObject parent;
    public int score = 1;
    public GameObject floatingText;
    public static MoleController colliderController;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        collider.enabled = false;
    }

    /// <summary>
    /// This function is called in the animationmole as an event, 
    /// when the mole is down and destroy the moles. 
    /// </summary>
    public void DestroyMole()
    {
        parent.GetComponent<HoleRespawner>().hasMole = false;
        Destroy(this.gameObject);
    }

    /// <summary>
    /// if num is null, the collider will be disabled
    /// </summary>
    /// <param name="num"></param>
    public void SetColliderOn(int num)
    {
        //if num is equal to 0 return false, otherwise return true         
        collider.enabled = (num==0)?false:true;
    }

    /// <summary>
    /// this function handles the amount of hits to the mole, 
    /// which is accesible in the inspector for each mole
    /// </summary>
    public void GotHit()
    {

        getHit--;
        if (getHit >= 0)
        {
            collider.enabled = true;
        }
        else
        {
            parent.GetComponent<HoleRespawner>().hasMole = false;
            ScoreController.AddScore(score);
            GameObject pop = Instantiate(floatingText, transform.position, Quaternion.identity) as GameObject;
            // set the position of the floating text on the right position
            pop.transform.SetParent(UiController.instance.transform,false);
            pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            FloatingTextScript popText = pop.GetComponent<FloatingTextScript>(); 
            Destroy(gameObject);
            popText.ShowFloatingText(score);
        }
    }
}
