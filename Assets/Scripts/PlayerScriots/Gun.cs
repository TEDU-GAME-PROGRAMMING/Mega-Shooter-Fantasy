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
    //public AudioSource ReloadingSound;
    private void Start()
    {
        shootingSound = GetComponents<AudioSource>();
        //ReloadingSound = GetComponent<AudioSource>(); 
        currentAmmo = maxAmmo;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo))
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
        //shootingSound.Play(1);
        
        isReloading = true;
        Debug.Log("Reload");
        animator.SetBool("Reloading", true);
        shootingSound[1].PlayOneShot(shootingSound[1].clip);
        yield return new WaitForSeconds(reloadTime - .25f);
        
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    public void Shoot()
    {
        shootingSound[0].PlayOneShot(shootingSound[0].clip);
        muzzleFlash.Play();

        currentAmmo--;

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
            Destroy(impactGO,2f);
        } 
        


    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

}
