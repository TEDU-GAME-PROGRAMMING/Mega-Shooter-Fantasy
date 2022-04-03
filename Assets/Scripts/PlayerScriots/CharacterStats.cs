
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public GameObject buttons;
    public int maxHealth = 100;
    //public int currentHealth { get; private set; }
    public Stat Speed;
    public Stat strength;
    public Stat endurance;
    public Stat dexterity;
    public Stat intelligence;
    public Stat damage;
    public Stat armor ;

    //float speed;
    public bool display = false;

    private void Awake()
    {
       
        //currentHealth = maxHealth;
       GameManager.playerStats.healthMax += maxHealth * 2;
    }
    private void Start()
    {
        
       

    }
    private void Update()
    {
        //SpeedIncrease();
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(30);
            //max health improve
           // Start();
        }
    }
    public void TakeDamage(int damage)
    {
        strength.setValue();
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        GameManager.playerStats.healthCurrent -= damage;
    }
    public void SpeedIncrease()
    {
        Speed.setValue();
        GameManager.playerStats.speed += 1;
        GameManager.playerStats.GetComponent<Stamina>().OriginalSpeed = GameManager.playerStats.speed;
    }
}
