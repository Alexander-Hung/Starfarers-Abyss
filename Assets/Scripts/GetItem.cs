using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class GetItem : MonoBehaviour
{
    private GameObject daggerWeapon;
    private GameObject saberWeapon;
    private GameObject gunWeapon;

    int level = 0;
    public List<GameObject> WeaponUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        daggerWeapon = gameObject.GetComponent<PlayerAttack>().daggerWeapon;
        saberWeapon = gameObject.GetComponent<PlayerAttack>().saberWeapon;
        gunWeapon = gameObject.GetComponent<PlayerAttack>().gunWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "armorItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddArmor(); 
        }

        if(col.tag == "healthItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddHealth(); 
        }
        
        if((col.tag == "saberUpgradeItem") && (PlayerAttack.instance.currentWeapon == saberWeapon))
        {
            Destroy(col.gameObject);
            Destroy(col.gameObject);
            // set saber weapon as inactive, and set gun weapon as active
            saberWeapon.SetActive(false);
            gunWeapon.SetActive(true);
            level = 2;
            Upgrade(level);
            Upgrade(level + 1);
            // set the player's current weapon and update stats
            PlayerAttack.instance.currentWeapon = gunWeapon; 
            PlayerAttack.instance.UpdateStats();
        }

        if((col.tag == "daggerUpgradeItem") && (PlayerAttack.instance.currentWeapon == daggerWeapon))
        {
            Debug.Log("test");
            Destroy(col.gameObject);
            // set dagger weapon as inactive, and set saber weapon as active
            daggerWeapon.SetActive(false);
            saberWeapon.SetActive(true);
            level = 1;
            Upgrade(level);
            // set the player's current weapon and update stats
            PlayerAttack.instance.currentWeapon = saberWeapon;
            PlayerAttack.instance.UpdateStats();
        }

        if (col.tag == "keyItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddKey();
        }

        if (col.tag == "teleportItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddTeleportScrap(); 
        }
    }

    public void Upgrade(int level)
    {
        int fixLevel = level - 1;
        WeaponUpgrade[fixLevel].SetActive(true);
    }
}
