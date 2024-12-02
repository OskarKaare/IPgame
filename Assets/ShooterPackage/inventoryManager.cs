using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject knife;
    public GameObject ak;
    public weaponBehavior weaponBehavior;
    public float switchdelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        ak.SetActive(true);
        knife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(inventory.Contains(knife))
            {
                weaponBehavior.StartCoroutine(weaponBehavior.switchWeapon());
                // play anis here
                StartCoroutine(switchDelay());
                knife.SetActive(true);
                ak.SetActive(false);
            }
            else
            {
                weaponBehavior.StartCoroutine(weaponBehavior.switchWeapon());
                // play anis here
                StartCoroutine(switchDelay());
                ak.SetActive(true);
                knife.SetActive(false);
            }
        }
    }

    IEnumerator switchDelay()
    {
        yield return new WaitForSeconds(switchdelay);
    }
}
