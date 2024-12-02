using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 0.5f;
    public ParticleSystem muzzleFlash;
    public int maxAmmo = 150;
    public int maxClip = 30;
    public int currentAmmo = 30;
    public float reloadDelay= 2f;
    public bool isReloading = false;
    public Animator animator;
    private bool isShooting = false;



    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
       // if mousebutton 0 is pressed
        if (Input.GetMouseButton(0) && currentAmmo > 0 && !isReloading && !isShooting)
        {
            StartCoroutine(shoot());
        }
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxClip && !isReloading && maxAmmo < 0)
        {
            StartCoroutine(reload());
        }
    }
    public IEnumerator switchWeapon()
           {
            isReloading = true;
            yield return new WaitForSeconds(1.5f);
            isReloading = false;
           }
  
    IEnumerator reload()
    {
        isReloading = true;
        //ani here
        yield return new WaitForSeconds(reloadDelay);

        if (currentAmmo > 0)
        {
          
            maxAmmo += currentAmmo;
        }

        if (maxAmmo >= maxClip)
        {
            // animator.SetBool("Reloading", true);
            currentAmmo = maxClip;
            maxAmmo -= maxClip;
        }
        else if (maxAmmo < maxClip && maxAmmo > 0)
        {
            // animator.SetBool("Reloading", true);
            currentAmmo = maxAmmo;
            maxAmmo = 0;
        }
        else
        {
            currentAmmo = 0;

        }
        // animator.SetBool("Reloading", false);
        isReloading = false;
    }
    IEnumerator shoot()
    {
        //muzzleFlash.Play();
        currentAmmo--;
        if (currentAmmo <= 0 && maxAmmo>0)
        {
            StartCoroutine(reload());
        }
        else if(currentAmmo <= 0 && maxAmmo <= 0)
        {
        //play click sound /no ammo stuff
        Debug.Log("No Ammo");
        }
  
        isShooting = true;

        yield return new WaitForSeconds(fireRate);

        isShooting = false;
    }
  
   
}
