using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss : MonoBehaviour
{
    // Start is called before the first frame update
    Stats stats;
    [SerializeField]
    GameObject PrefabAreaAttack;
    Animator AreaAttack;
    float maxLife;
    bool cooldown=false;
    void Start()
    {
        stats = GetComponent<Stats>();
        maxLife = stats.GetLife();
        GameObject go=Instantiate<GameObject>(PrefabAreaAttack, transform.position, Quaternion.identity);
        AreaAttack = go.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!cooldown)
        if (stats.GetLife() / maxLife * 100 >50)
        {
                AreaAttack.SetTrigger("SelfAttack");
                StartCoroutine(Cooldown(3));
        }else
        {
                AreaAttack.SetTrigger("Attack");
                StartCoroutine(Cooldown(0.75f));
        }
    }

    IEnumerator Cooldown(float timeCooldown)
    {
        cooldown = true;
        yield return new WaitForSeconds(timeCooldown);
        cooldown = false;
    }
}
