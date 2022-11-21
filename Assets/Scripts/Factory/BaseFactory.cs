using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public virtual GameObject Create(Vector2 positionCreate)
    {
        GameObject go = Instantiate(_prefab, positionCreate, Quaternion.identity);
        // go.SetActive(false);
        return go;
    }
}
