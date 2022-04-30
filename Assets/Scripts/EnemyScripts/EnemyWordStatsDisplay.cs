using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyWordStatsDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar, levelDisplay, enemyName;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

        enemyName.GetComponent<TMP_Text>().text = this.transform.parent.GetComponent<EnemyAttributes>().name;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(GameManager.player.transform);
    }
}
