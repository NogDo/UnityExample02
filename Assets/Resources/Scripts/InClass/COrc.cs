using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COrc : CMonster
{
    public string orcPassive = "��ũ�� �������� 10% �� �޽��ϴ�.";

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