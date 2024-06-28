using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CShooterPlayer : MonoBehaviour
{
    #region public 변수
    public CGun[] guns;
    public CTargetFollower subHandTarget;
    public CTargetFollower subHandHint;
    public AnimationClip reloadClip;
    public AnimationClip grenadeClip;
    public Rig rig;

    public float fWalkMoveSpeed;
    public float fRunMoveSpeed;
    #endregion

    #region private 변수
    Animator animator;

    int nCurrentGun;
    bool isReloading = false;
    bool isThrowGrenade = false;
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }


        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Move(moveDir);


        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        else if (Input.GetKeyDown(KeyCode.G))
        {
            Grenade();
        }
    }

    public void ChangeWeapon(int index)
    {
        guns[nCurrentGun].gameObject.SetActive(false);

        nCurrentGun = index;

        guns[nCurrentGun].gameObject.SetActive(true);

        subHandTarget.target = guns[nCurrentGun].subHandTarget;
        subHandHint.target = guns[nCurrentGun].subHandHint;
    }

    public void Move(Vector3 moveDir)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", moveDir.magnitude * 2);
            transform.Translate(moveDir * fRunMoveSpeed * Time.deltaTime);
        }

        else
        {
            animator.SetFloat("Speed", moveDir.magnitude);
            transform.Translate(moveDir * fWalkMoveSpeed * Time.deltaTime);
        }

        animator.SetFloat("XPosition", moveDir.x);
        animator.SetFloat("YPosition", moveDir.z);
    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }
        isReloading = true;

        animator.SetTrigger("Reload");

        StartCoroutine(RigWeightLerp(1.0f, 1.0f, 0.0f));
        StartCoroutine(ReloadCoroutine(reloadClip.length));
    }

    IEnumerator RigWeightLerp(float duration, float start, float end)
    {
        float fTime = 0.0f;

        while (fTime <= duration)
        {
            fTime += Time.deltaTime;
            rig.weight = Mathf.Lerp(start, end, fTime / duration);

            yield return null;
        }
    }

    IEnumerator ReloadCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        isReloading = false;

        StartCoroutine(RigWeightLerp(0.1f, 0.0f, 1.0f));
    }

    public void Grenade()
    {
        if (isThrowGrenade)
        {
            return;
        }
        isThrowGrenade = true;

        animator.SetTrigger("Grenade");
        guns[nCurrentGun].gameObject.SetActive(false);

        StartCoroutine(RigWeightLerp(1.0f, 1.0f, 0.0f));
        StartCoroutine(GrenadeCoroutine(grenadeClip.length));
    }

    IEnumerator GrenadeCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        isThrowGrenade = false;
        guns[nCurrentGun].gameObject.SetActive(true);

        StartCoroutine(RigWeightLerp(0.1f, 0.0f, 1.0f));
    }
}