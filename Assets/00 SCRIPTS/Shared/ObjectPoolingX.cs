using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingX : MonoBehaviour
{
    private static ObjectPoolingX _instant;
    public static ObjectPoolingX instant => _instant;

    private void Awake()
    {
        if(_instant == null)
        {
            _instant = this;
        }
        if(_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    Dictionary<GameObject,List<GameObject>> _poolObject =
        new Dictionary<GameObject,List<GameObject>>();
    public GameObject GetObject(GameObject key)
    {
        List<GameObject> tmp = new List<GameObject>();
        if (!_poolObject.ContainsKey(key))
        {
            _poolObject.Add(key, tmp);
        }
        else
        {
            tmp = _poolObject[key]; 
        }
        foreach(GameObject g in tmp)
        {
            if (g.activeSelf)
            {
                continue;
            }
            return g;
        }
        GameObject g2 = Instantiate(key, this.transform.position, Quaternion.identity);
        _poolObject[key].Add(g2);
        return g2;
    }

}
