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

    [SerializeField]private Arrow arrowPrefab;
    
    [SerializeField]private Transform spawnPoint;
    
    public int numberOfPrefabs = 10; // Oluşturulacak prefab sayısı
    public float radius = 5f; // Yarıçap
    public float speed = 1f; // Prefabların oluşma hızı
    

    private float currentAngle = 0f; // Başlangıç açısı
    
    private Arrow currentArrow;
    private Arrow skillArrow;
    
    
    
    private bool canFire = true;
    private bool canUseSkill = true;
    private string enemyTag;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }
    
    void Start()
    {
        GetComponent<PlayerCombat>().basicAttackAction += Fire;
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

       
        StartCoroutine(CreatePrefabs(firePower));


        
    }

    IEnumerator CreatePrefabs(float firePower)
    {
        
       for (int i = 0; i < numberOfPrefabs; i++)
        {
            
            GetPositionOnCircle(currentAngle);

            Fire(firePower);
            
            
            currentAngle += 18;

            Mathf.Clamp(currentAngle, 0, 180);

            print(currentAngle);
            float waitTime = 1f / speed / (numberOfPrefabs - 1);
            yield return new WaitForSeconds(waitTime);
        }
        
    }

    private Vector3 GetPositionOnCircle(float angle)
    {
        float x = transform.position.x + radius * Mathf.Cos(angle);
        float y = transform.position.y;
        float z = transform.position.z + radius * Mathf.Sin(angle);
        
        return new Vector3(x, y, z);
    }
    

     

    
    }
}

