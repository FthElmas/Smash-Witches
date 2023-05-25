using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Anim;
using SW.Control;
using System;
using SW.Core;

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
    private bool canUseBasicAttack = true;
    
    [SerializeField] private float firePower;
    private PlayerController control;
    
    public event Action<float> basicAttackAction;
    public event Action basicAnimAction;
    public event Action skill2AnimAction;
    private bool canUseSkill1 = true;
    private bool canUseSkill2 = true;
    private float basicAttackCooldown;
    private float skill1CoolDown;
    private float skill2CoolDown;
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
    
    private void Start()
    {
        basicAttackCooldown = StatHolderSingleton.Instance.StatData.BasicAttackCooldown;
        skill1CoolDown = StatHolderSingleton.Instance.StatData.Skill1Cooldown;
        skill2CoolDown = StatHolderSingleton.Instance.StatData.Skill2Cooldown;
    }
    IEnumerator ReloadAttack()
    {
        yield return new WaitForSeconds(basicAttackCooldown);


        canUseBasicAttack = true;
    }
    IEnumerator Skill1CoolDown()
    {
            yield return new WaitForSeconds(skill1CoolDown);

            canUseSkill1 = true;
    }
    IEnumerator Skill2CoolDown()
    {
            yield return new WaitForSeconds(skill2CoolDown);

            canUseSkill2 = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
    }


    void Skill1()
    {
        if(canUseSkill1)
        {
            anim.SkillAnimation();
            weapon.SkillBehaviour(firePower);
            canUseSkill1 = false;
            StartCoroutine(Skill1CoolDown());
        }
    }
    void BasicAttack()
    {
        if(canUseBasicAttack)
        {
            basicAnimAction?.Invoke();
            basicAttackAction?.Invoke(firePower);
            canUseBasicAttack = false;
            StartCoroutine(ReloadAttack());
        }
    }



    void Skill2()
    {
        if(canUseSkill2)
        {
            control.SpeedCoroutine();
            skill2AnimAction?.Invoke();
            canUseSkill2 = false;
            StartCoroutine(Skill2CoolDown());
        }
    }


    public bool GetSkill1()
    {
        return canUseSkill1;
    }
    public bool GetSkill2()
    {
        return canUseSkill2;
    }
    public bool GetBasicAttack()
    {
        return canUseBasicAttack;
    }

    
       
        

        
    }
}
