using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace SW.Core
{

   
    public class ObjectPooler : MonoBehaviour
    {
    public GameObject prefab; // Oluşturulacak prefab objesi
    public int poolSize; // Havuzdaki prefab sayısı
    public List<GameObject> pooledObjects; // Havuzda saklanacak prefab listesi
    public GameObject parentObject; // Havuzdaki prefab'ların parent GameObject'i
    NavMeshHit hit;

	[SerializeField] private float waitingTime;

    // İlk çalıştırıldığında havuz oluşturulur
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, parentObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

	void Update()
	{
        
		StartCoroutine(Spawner());
	}

	IEnumerator Spawner()
	{
		yield return new WaitForSeconds(waitingTime);

		SpawnObject();
	}

    // Havuzdaki ilk uygun prefab'ı çağırır ve random pozisyonda spawn eder
    public void SpawnObject()
    {
        
        for (int i = 0; i < poolSize; i++)
        {

            if(pooledObjects[i] == null) return ;
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                pooledObjects[i].transform.position = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(0, -20f)); // Rastgele pozisyon belirleme
                return;
                
            }

            
        }
    }

    
}
}
