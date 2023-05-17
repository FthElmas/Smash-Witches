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
    [SerializeField]private Projectile arrowPrefab2;
    
    [SerializeField]private Transform spawnPoint;
    
    
    private float waitTime = 0.2f;
    private Vector3 currentAngle; // Başlangıç açısı
    
    private Projectile currentArrow;
    private Projectile skillArrow;
    public float radius = 1.0f; // Dairenin yarıçapı
    public int prefabCount = 5; // Oluşturulacak prefab sayısı
    public float prefabSpacing = 36.0f; // Prefab nesneleri arasındaki açı farkı
    public float spawnDelay = 0.2f;
    
    GameObject player;
    private bool canFire = true;
    private bool canUseSkill = true;
    private string enemyTag;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }
    
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");

       
        
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
        if(canFire)
        {
            currentArrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
            var force = spawnPoint.transform.forward * firePower;
            

            currentArrow.Fly(force);

            canFire = false;
            StartCoroutine(ReloadArrow());

            
            
            

        }
        
        currentArrow.transform.parent = null;
    }
    

    public void SkillBehaviour(float firePower)
    {

        float angleStep = prefabSpacing;
        float playerAngle = player.transform.eulerAngles.y;
        // Prefab nesnelerini oluştur
        for (int i = 0; i < prefabCount; i++)
        {
            // Prefab nesnesinin rotasyon açısını hesapla
            float angle = playerAngle + i * angleStep;
            
            // X ve Y koordinatlarını hesapla
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float z = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

            // Oluşturulacak prefab nesnesinin konumunu belirle
            Vector3 spawnPosition =  transform.position  + new Vector3(x, 0, z);

            // Oluşturulacak prefab nesnesinin rotasyonunu belirle
            Quaternion spawnRotation = Quaternion.Euler(0, angle - playerAngle - 90, 0);

            // Prefab nesnesini oluştur ve spawnDelay kadar bekle
            skillArrow = Instantiate(arrowPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);
            var force = spawnPoint.transform.forward * firePower;
            skillArrow.Fly(force);
            skillArrow.transform.parent = null;

            if (i < prefabCount - 1)
                StartCoroutine(WaitForSpawnDelay());
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

