
using UnityEngine;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;
    public GameObject buttons;
    public GameObject weaponHolder;
    public GameObject SpeedText;
    public GameObject DamageText;
    public GameObject ArmorText;
    public GameObject Endurance;
    public GameObject warningMsg;
    public int maxHealth = 100;
    //public int currentHealth { get; private set; }
    public Stat Speed;//DONE
    public Stat strength;// partially DONE
    public Stat endurance;// partially DONE
    public Stat dexterity;// partially DONE
    public Stat intelligence;// partially DONE
    public Stat damage; //  DONE
    public Stat armor; //  DONE

    //float speed;
    public bool display = false;

    private void Awake()
    {
        instance = this;
        GameManager.playerStats.healthMax += maxHealth * 2;
        //currentHealth = maxHealth;
        /* GameManager.playerStats.healthMax += maxHealth * 2;

         SpeedText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().speed.ToString();
         ArmorText.GetComponent<TMP_Text>().text = armor.getValue().ToString();
         Endurance.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().healthMax.ToString();*/
    }
    private void Start()
    {
        
        
        SpeedText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().speed.ToString();
        ArmorText.GetComponent<TMP_Text>().text = armor.getValue().ToString();
        Endurance.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().healthMax.ToString();


    }
    private void Update()
    {
        //DamageText.GetComponent<TMP_Text>().text = weaponHolder.GetComponent<WeaponSwitching>().currentlySelectedGameObject.GetComponent<Gun>().damage.ToString();
        //SpeedIncrease();
        
        if(GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            warningMsg.SetActive(false);
        }
        else
        {
            warningMsg.SetActive(true);
        }
    }
    private void LateUpdate()
    {
        DamageText.GetComponent<TMP_Text>().text = weaponHolder.GetComponent<WeaponSwitching>().currentlySelectedGameObject.GetComponent<Gun>().damage.ToString();
    
    }
    public void TakeDamage(int damage)
    {
        //strength.setValue();
        damage -= (armor.getValue() * 10);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        GameManager.playerStats.healthCurrent -= damage;
    }
    public void SpeedIncrease()
    {
        
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0) 
        {
        //warningMsg.SetActive(false);
        Speed.setValue();
        GameManager.playerStats.speed += 1;
        SpeedText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().speed.ToString();
        GameManager.playerStats.GetComponent<Stamina>().OriginalSpeed = GameManager.playerStats.speed;
        GameManager.player.GetComponent<Player>().remaingSkillPoints--;
        GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
        }else
        {
            //warningMsg.SetActive(true) ; 
        }


    }
    public void DamageIncrease()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
           // warningMsg.SetActive(false);
            damage.setValue();
            weaponHolder.GetComponent<WeaponSwitching>().currentlySelectedGameObject.GetComponent<Gun>().damage += 1f;
            DamageText.GetComponent<TMP_Text>().text = weaponHolder.GetComponent<WeaponSwitching>().currentlySelectedGameObject.GetComponent<Gun>().damage.ToString();
            GameManager.player.GetComponent<Player>().remaingSkillPoints--;
            GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
        }
        
    }
    public void IncreaseArmor()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            armor.setValue();
            GameManager.player.GetComponent<Player>().remaingSkillPoints--;
            GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
            ArmorText.GetComponent<TMP_Text>().text = armor.getValue().ToString();
        }
    }
    public void IncreaseIntelligence()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            intelligence.getValue();



        }
       

    }
    public void IncreaseDexterity()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        
    }
    public void IncreaseEndurance()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {
            endurance.getValue();
            GameManager.player.GetComponent<PlayerMovement>().healthMax += 50;
            GameManager.player.GetComponent<PlayerMovement>().healthCurrent += 50;
            GameManager.player.GetComponent<Player>().remaingSkillPoints--;
            GameManager.player.GetComponent<Player>().remaingSkillPointText.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<Player>().remaingSkillPoints.ToString();
            Endurance.GetComponent<TMP_Text>().text = GameManager.player.GetComponent<PlayerMovement>().healthMax.ToString();
        }
       
    }
    public void IncreaseStrength()
    {
        if (GameManager.player.GetComponent<Player>().remaingSkillPoints > 0)
        {

        }
        
    }
}
