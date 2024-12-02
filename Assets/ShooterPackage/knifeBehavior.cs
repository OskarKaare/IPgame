using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeBehavior : MonoBehaviour
{
    public float damage = 50f;
    public float fireRate = 0.5f;
    public float inspRate = 1.5f;
    public Animator animator;
    public bool isStabbing = false;
    public bool isInsp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isStabbing && !isInsp)
        {
            StartCoroutine(stab());
        }
        if(Input.GetKeyDown(KeyCode.F) && !isInsp)
        {
            StartCoroutine(inspect());
        }
    }
    IEnumerator stab()
    {
        isStabbing = true;
        //ani here
        yield return new WaitForSeconds(fireRate);
        isStabbing = false;
    }
    IEnumerator inspect()
    {
        isInsp = true;
        //ani here
        yield return new WaitForSeconds(inspRate);
        isInsp = false;
    }
}
