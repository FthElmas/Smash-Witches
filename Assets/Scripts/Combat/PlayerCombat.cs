using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Anim;
using SW.Control;
using System;

namespace SW.Combat
{

    public class PlayerCombat : MonoBehaviour
    {
      

    [SerializeField]
    private Weapon weapon;

   public float launchDelay = 0.17f;

    private float timer = Mathf.Infinity;
    

    [SerializeField] private Button basicAttack;
    [SerializeField] private Button skill1;
    [SerializeField] private Button skill2;
    PlayerAnimation anim;
    public float fireRate = 0.1f;

    private float nextFireTime = 0.0f;
    [SerializeField] private float firePower;
    private PlayerController control;
    
    public event Action<float> basicAttackAction;
    public event Action basicAnimAction;
    void Awake()
    {
        anim = GetComponent<PlayerAnimation>();
        Button btn = basicAttack.GetComponent<Button>();
        btn.onClick.AddListener(BasicAttack);
        
        Button btn1 = skill1.GetComponent<Button>();
        btn1.onClick.AddListener(Skill1);

        Button btn2 = skill2.GetComponent<Button>();
        btn2.onClick.AddListener(Skill2);

        control = GetComponent<PlayerController>();
    }
    

    void Update()
    {
        timer += Time.deltaTime;
    }


    void Skill1()
    {
        anim.SkillAnimation();
        weapon.SkillBehaviour(firePower);
    }
    void BasicAttack()
    {
        
        basicAnimAction?.Invoke();
        
    }

    public void Shoot()
    {
        basicAttackAction?.Invoke(firePower);
    }


    void Skill2()
    {
        control.SpeedCoroutine();
    }

    
       
        

        
    }
}
