using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    Coroutine _deactiveWait = null;

    private void OnEnable()
    {
        _deactiveWait = StartCoroutine(DeactiviAfterTime());
    }
    private void OnDisable()
    {
        if(_deactiveWait != null)
        {
            StopCoroutine(_deactiveWait);
            _deactiveWait = null;
        }
    }

    IEnumerator DeactiviAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
