using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WeaponUI : MonoBehaviour
{
    
    public GameObject remainingBullet, weaponManager;
    private TMP_Text remainingBulletText;
    private WeaponSwitching weaponSwitching;
    // Start is called before the first frame update
    void Start()
    {
        remainingBulletText = remainingBullet.GetComponent<TMP_Text>();
        weaponSwitching = weaponManager.GetComponent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingBulletText.text = weaponSwitching.currentlySelectedGameObject.GetComponent<Gun>().CurrentAmmo.ToString() + " / " + weaponSwitching.currentlySelectedGameObject.GetComponent<Gun>().maxAmmo.ToString();
    }
}
