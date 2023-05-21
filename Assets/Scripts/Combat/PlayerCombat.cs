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
    
    private float reloadTime = 2f;
    [SerializeField] private Button basicAttack;
    [SerializeField] private Button skill1;
    [SerializeField] private Button skill2;
    PlayerAnimation anim;
    private bool canFire = true;
    
    [SerializeField] private float firePower;
    private PlayerController control;
    
    public event Action<float> basicAttackAction;
    public event Action basicAnimAction;
    public event Action skill2AnimAction;
    private bool canUseSkill = true;
    [SerializeField] private float skillCoolDown;
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
    
    IEnumerator ReloadAttack()
    {
        yield return new WaitForSeconds(reloadTime);


        canFire = true;
    }
    IEnumerator SkillCoolDown()
    {
            yield return new WaitForSeconds(skillCoolDown);

            canUseSkill = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
    }


    void Skill1()
    {
        if(canUseSkill)
        {
            anim.SkillAnimation();
            weapon.SkillBehaviour(firePower);
            canUseSkill = false;
            StartCoroutine(SkillCoolDown());
        }
    }
    void BasicAttack()
    {
        if(canFire)
        {
            basicAnimAction?.Invoke();
            basicAttackAction?.Invoke(firePower);
            canFire = false;
            StartCoroutine(ReloadAttack());
        }
    }



    void Skill2()
    {
        if(canUseSkill)
        {
            control.SpeedCoroutine();
            skill2AnimAction?.Invoke();
        }
    }

    
       
        

        
    }
}
