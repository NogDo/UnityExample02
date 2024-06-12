using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COrc : CMonster
{
    public string orcPassive = "오크는 데미지를 10% 덜 받습니다.";

    void Start()
    {
        maxHP = currentHP = 150.0f;
    }

    public override void Hit(float damage)
    {
        damage *= .9f;

        base.Hit(damage);
    }
}