using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyWordStatsDisplay : MonoBehaviour
{
    /*
     
    Preplace the healtbar, leveldisplay and enemyname onto the Main Canvas.
    Whenever the ray hits any object with target class, then pull the attributes from Target class 
    of that enemy instance, and, display them.
     
    Use global player ray for optimization purposes. 

     */
    [SerializeField]
    private GameObject healthBar, levelDisplay, enemyName;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

        //enemyName.GetComponent<TMP_Text>().text = this.transform.parent.GetComponent<EnemyAttributes>().name;
    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.LookAt(GameManager.player.transform);
    }
}
