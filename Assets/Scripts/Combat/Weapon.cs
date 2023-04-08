using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SW.Combat
{
    public class Weapon : MonoBehaviour
    {
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float skillCoolDown = 1f;

    [SerializeField]private Arrow arrowPrefab;
    
    [SerializeField]private Transform spawnPoint;
    
    public float speed = 10f; // Projectile'ın hızı
    public float fireRate = 0.2f; // Projectile'ın oluşturulma hızı
    public int numberOfProjectiles = 10; // Oluşturulacak olan projectile sayısı
    public Arrow projectilePrefab;
    private float nextFire = 0f;
    private Arrow currentArrow;
    private Arrow projectile;
    
    private bool canFire = true;
    private bool canUseSkill = true;
    private string enemyTag;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }
    
    void Start()
    {
        
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
            currentArrow = Instantiate(arrowPrefab, spawnPoint);
            var force = spawnPoint.TransformDirection(Vector3.forward * firePower);

            currentArrow.Fly(force);

            canFire = false;
            StartCoroutine(ReloadArrow());

            
            

        }
        
        currentArrow.transform.parent = null;
    }
    

    public void SkillBehaviour(float firePower)
    {


       if (Time.time > nextFire)
        {
            // Bir sonraki projectile'ın ne zaman oluşacağını ayarla
            nextFire = Time.time + fireRate;

            // Projectile prefab'ından yeni bir nesne oluştur
            projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            // Projectile'ın yönünü ve pozisyonunu karaktere bağlı olarak ayarla
            float angleStep = 360f / numberOfProjectiles;
            float angle = 0f;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                // Projectile'ın yönünü hesapla
                float projectileDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float projectileDirZ = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180f);

                // Projectile'ın yönünü ve hızını ayarla
                Vector3 projectileDirection = new Vector3(projectileDirX, transform.position.y, projectileDirZ) - transform.position;
                Vector3 projectileVelocity = projectileDirection.normalized * speed;

                // Projectile'ı hareket ettir
                projectile.GetComponent<Rigidbody>().velocity = projectileVelocity;

                // Bir sonraki projectile'ın yönünü hesapla
                angle += angleStep;
            }
        }
        
    }

    
    

     

    
    }
}

