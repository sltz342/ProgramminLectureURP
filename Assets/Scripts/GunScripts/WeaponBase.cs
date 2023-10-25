using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    [SerializeField] protected float timeBetweenAttacks;
    [SerializeField] protected float chargeUpTime;
    [SerializeField, Range(0,1)] protected float minChargePercent;

    [SerializeField] private bool isFullyAutomatic;
    private Coroutine currentFireTimer;


    private WaitForSeconds myCooldownTImer;
    private bool isOnCooldown;

    private float currentChargeTime;

    private WaitUntil myWaitFunc;



    private void Awake()
    {
        myCooldownTImer = new WaitForSeconds(timeBetweenAttacks);
        myWaitFunc = new WaitUntil(() => !isOnCooldown);
    }

    public void StartFiring()
    {
        currentFireTimer = StartCoroutine(RefireTimer());
    }

    public void StopFiring()
    {
        //Lets us do half charge attacks
        float p = currentChargeTime / chargeUpTime;
        if(p == 0)
        {
            TryAttack(p);
        }

        StopCoroutine(currentFireTimer);
    }



    protected virtual bool CanAttack(float percent)
    {
        return !isOnCooldown && minChargePercent <= percent;
    }

    private void TryAttack(float percent)
    {
        currentChargeTime = 0;
        if(!CanAttack(percent)) return;
        
        Attack(percent);

        StartCoroutine(CooldownTimer());

        if (isFullyAutomatic) currentFireTimer = StartCoroutine(RefireTimer());


    }


    protected abstract void Attack(float chargePercent);

    private IEnumerator RefireTimer()
    {
        Debug.Log("PreCoolDown");
        yield return myWaitFunc;
        Debug.Log("PostCoolDown");

        while(currentChargeTime < chargeUpTime)
        {
            currentChargeTime += Time.deltaTime;
            yield return null;
        }

        TryAttack(1);



        yield return null;
    }

    private IEnumerator CooldownTimer()
    {
        isOnCooldown = true;
        yield return myCooldownTImer;
        isOnCooldown = false;
    }
    











}
