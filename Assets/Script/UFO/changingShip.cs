using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingShip : MonoBehaviour
{
    [SerializeField] List<GameObject> ships;
    private int shipIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        shipIndex = 0;
        StartCoroutine(shiftShip());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shiftShip()
    {
        while (true)
        {
            ships[shipIndex].SetActive(false);
            shipIndex = ( (shipIndex+1) % ships.Count);
            ships[shipIndex].SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }
}
