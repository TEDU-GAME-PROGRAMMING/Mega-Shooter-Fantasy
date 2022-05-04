
using UnityEngine;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;
    public GameObject buttons;
    public GameObject weaponHolder;
    public GameObject SpeedText;
    public GameObject warningMsg;
    public int maxHealth = 100;
    //public int currentHealth { get; private set; }
    public Stat Speed;//DONE
    public Stat strength;// partially DONE
    public Stat endurance;// partially DONE
    public Stat dexterity;// partially DONE
    public Stat intelligence;// partially DONE
    public Stat damage; // text will be added DONE
    public Stat armor; // partially DONE

    //float speed;
    public bool display = false;

    private void Awake()
    {
        instance = this;
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
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0) 
        { 
        Speed.setValue();
        GameManager.playerStats.speed += 1;
        SpeedText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().speed.ToString();
        GameManager.playerStats.GetComponent<Stamina>().OriginalSpeed = GameManager.playerStats.speed;
        GameManager.player.GetComponent<Player>().remaingSkillPoints--;
        GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
        }else
        {
            warningMsg.GetComponent<TMP_Text>().IsActive() ; // it does not work.
        }


    }
    public void DamageIncrease()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            damage.setValue();
            weaponHolder.GetComponent<WeaponSwitching>().currentlySelectedGameObject.GetComponent<Gun>().damage += 1f;
            GameManager.player.GetComponent<Player>().remaingSkillPoints--;
            GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
        }
        else
        {
            warningMsg.GetComponent<TMP_Text>().IsActive() ;
        }
        
        //GameManager.playerStats.GetComponent<Stamina>(). = GameManager.playerStats.damage;
    }
    public void IncreaseArmor()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            armor.setValue();
            GameManager.player.GetComponent<PlayerMovement>().healthMax += 50;
            GameManager.player.GetComponent<PlayerMovement>().healthCurrent += 50;
            GameManager.player.GetComponent<Player>().remaingSkillPoints--;
        }
        else
        {

        }
    }
    public void IncreaseIntelligence()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        else
        {

        }

    }
    public void IncreaseDexterity()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        else
        {

        }
    }
    public void IncreaseEndurance()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        else
        {

        }
    }
    public void IncreaseStrength()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        else
        {

        }
    }
}
