using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    public int maxCurrentAmmo = 90;

    private int currentAmmo ;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public LayerMask layerMask ;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nexttimeToFire = 0f;

    public Animator animator;

    public AudioSource[] shootingSound;

    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }


    // public GameObject bulletFirePoint;


    //public AudioSource ReloadingSound;
    private void Start()
    {
        shootingSound = GetComponents<AudioSource>();
        //ReloadingSound = GetComponent<AudioSource>(); 
        CurrentAmmo = maxAmmo;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (isReloading)
        {
            return;
        }
        if (CurrentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && CurrentAmmo != maxAmmo))
        {
            //ReloadingSound.Play();
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nexttimeToFire) {

            nexttimeToFire = Time.time+1f/fireRate;
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        if (maxCurrentAmmo != 0)
        {
            isReloading = true;
            animator.SetBool("Reloading", true);
            shootingSound[1].PlayOneShot(shootingSound[1].clip);
            yield return new WaitForSeconds(reloadTime - .25f);

            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.25f);
            isReloading = false;

        }
        //shootingSound.Play(1);
        if (maxCurrentAmmo > currentAmmo)
        {
            if(maxCurrentAmmo >= maxAmmo)
            {
                maxCurrentAmmo -= maxAmmo - currentAmmo;
                currentAmmo = maxAmmo;
            }
            else
            {
                currentAmmo = maxCurrentAmmo;
                maxCurrentAmmo = 0;
            }
        }
        else
        {
            if(maxCurrentAmmo != 0)
            {
                if (maxCurrentAmmo <= currentAmmo)
                {
                    int needed = maxAmmo - currentAmmo;
                    if (needed < maxCurrentAmmo)
                    {
                        currentAmmo += needed;
                        maxCurrentAmmo -= needed;
                    }
                    else
                    {
                        currentAmmo += maxCurrentAmmo;
                        maxCurrentAmmo = 0;
                    }
                    /*                currentAmmo += maxCurrentAmmo;
                                    maxCurrentAmmo = 0;
                    */

                }
            } 
            else
            {
                //TODO Uyari versin. 
            }
            
        }
        


    }
    public void Shoot()
    {
        shootingSound[0].PlayOneShot(shootingSound[0].clip);
        muzzleFlash.Play();

        CurrentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask)) {

            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

           // Debug.Log(hit.collider.GetType().ToString());
            
            if (target != null)
            {
                //Headshot
                if (hit.collider.GetType().ToString().Equals("UnityEngine.SphereCollider"))
                {
                    //Debug.Log("HeadShoot");
                    target.TakeDamage(damage * 2);
                }
                else
                {
                    target.TakeDamage(damage);
                }
                
            }
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal* impactForce);

            }

            GameObject impactGO = Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
            // bulllet Instantiating
            // GameObject bullet = Instantiate(bulletFirePoint, hit.point, Quaternion.LookRotation(hit.normal));


            // Destroy(bullet, 2f);
        } 
        


    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

}
