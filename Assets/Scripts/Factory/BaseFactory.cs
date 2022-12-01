using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory : MonoBehaviour
{
    [SerializeField] private protected List<GameObject> _prefabList;

    public virtual GameObject Create(Vector2 positionCreate)
    {
        GameObject go = Instantiate(GetRandomPrefabByList(_prefabList), positionCreate, Quaternion.identity);
        return go;
    }

    /// <summary>
    /// Получаем случайный префаб из списка
    /// </summary>
    private protected GameObject GetRandomPrefabByList(List<GameObject> prefabList)
    {

        if (prefabList.Count > 0)
        {
            int rndIndex = Random.Range(0, prefabList.Count);
            return prefabList[rndIndex];
        }

        return null;
    }
}
