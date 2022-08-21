using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorAnimationController : MonoBehaviour
{
    [SerializeField]
    private GameObject idleAnim;

    [SerializeField]
    private GameObject flourishAnim;

    [SerializeField]
    private float flourishAnimTime = 0.55f;

    private void Awake()
    {
        idleAnim.SetActive(true);
        flourishAnim.SetActive(false);
    }

    public void DoFlourishAnimation()
    {
        StopCoroutine(anim_());
        StartCoroutine(anim_());
        IEnumerator anim_()
        {
            idleAnim.SetActive(false);
            flourishAnim.SetActive(true);
            yield return new WaitForSeconds(flourishAnimTime);
            idleAnim.SetActive(true);
            flourishAnim.SetActive(false);
        }
    }
}
