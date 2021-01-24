using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRespawner : MonoBehaviour
{

    public GameObject[] moles;
    public bool hasMole;

    void Start()
    {
        if (!hasMole)
        {
            Invoke("SpawnMole", Random.Range(0f, 7f));
        }
    }

    private void SpawnMole()
    {
        if (!hasMole)
        {
            int num = CalculateRarity();
            GameObject mole = Instantiate(moles[num], transform.position, Quaternion.identity) as GameObject;
            MoleController moleController = mole.GetComponent<MoleController>();
            moleController.parent = this.gameObject;
            //multiplies the score of each mole in the next level
            moleController.score = moleController.score * TimeController.currentLevel;
            hasMole = true;
        }
        Invoke("SpawnMole", Random.Range(3f, 7f));
        
    }

    private int CalculateRarity()
    {
        int randomMoles = (Random.Range(1, 101));
        if (randomMoles <= 3)
        {
            return 3;
        }
        else if(randomMoles <= 80)
        {
            return 1;
        }
        else if (randomMoles <= 60)
        {
            return 2;
        }
        return 0;
    }
}
