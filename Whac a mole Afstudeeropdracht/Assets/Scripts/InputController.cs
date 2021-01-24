using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject particles;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                Instantiate(particles, hit.point, Quaternion.identity);
                if (hit.collider.tag == "Mole")
                {
                    MoleController moleController = hit.collider.gameObject.GetComponent<MoleController>();
                    moleController.SetColliderOn(0);
                    moleController.animator.SetTrigger("Hit");
                }
            }
        }
    }
}
