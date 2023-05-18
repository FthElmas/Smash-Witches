using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace SW.Combat
{
    public class Weapon : MonoBehaviour
    {
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float skillCoolDown = 1f;

    [SerializeField]private Projectile arrowPrefab;
    
    
    [SerializeField]private Transform spawnPoint;
    
    
    
    
    private Projectile currentArrow;
    private Projectile skillArrow;
    public float radius = 5.0f; // Dairenin yarıçapı
    public int prefabCount = 10; // Oluşturulacak prefab sayısı
    public float prefabSpacing = 36.0f; // Prefab nesneleri arasındaki açı farkı
    public float spawnDelay = 0.2f;
    
    GameObject player;
    private bool canFire = true;
    private bool canUseSkill = true;
    
    
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerCombat>().basicAttackAction += Fire;
       
        
    }


    IEnumerator ReloadArrow()
    {
        yield return new WaitForSeconds(reloadTime);


        canFire = true;
    }

    IEnumerator SkillCooldown()
    {
        yield return new WaitForSeconds(skillCoolDown);

        canUseSkill = true;
    }

    
    public void Fire(float firePower)
    {
        
        currentArrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        var force = spawnPoint.transform.forward * firePower;
            

        currentArrow.Fly(force);

            

        currentArrow.transform.parent = null;
    }
    

    public void SkillBehaviour(float firePower)
    {

        float angleStep = prefabSpacing;
        float playerAngle = player.transform.eulerAngles.y;
        // Prefab nesnelerini oluştur
        for (int i = 0; i < prefabCount; i++)
        {
            
            float angle = playerAngle + i * angleStep;
            
            
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float z = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

            
            Vector3 spawnPosition =  spawnPoint.transform.position  + new Vector3(x, 0, z);

            
            Quaternion spawnRotation = spawnPoint.transform.rotation;

            
            skillArrow = Instantiate(arrowPrefab, spawnPosition, spawnRotation);
            var force = spawnPoint.transform.forward * firePower;
            skillArrow.Fly(force);
            skillArrow.transform.parent = null;

            
        }
       
        

        
    }

     IEnumerator WaitForSpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
    }

    private Vector3 GetPositionOnCircle(Vector3 angle)
    {
        float x = player.transform.rotation.x;
        float y = player.transform.position.y - 90f;
        float z = player.transform.position.z;
        
        return new Vector3(x, y, z);
    }
    

     

    
    }
}

