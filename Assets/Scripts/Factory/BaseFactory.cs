using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public GameObject Create()
    {
        Vector3 position = new Vector3(2f,3f,0f);

        return Instantiate(_prefab, position, Quaternion.identity);
        
    }
}
