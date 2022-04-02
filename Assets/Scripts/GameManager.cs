using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject player;
    public static PlayerMovement playerStats;
    // Start is called before the first frame update
    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerMovement>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
