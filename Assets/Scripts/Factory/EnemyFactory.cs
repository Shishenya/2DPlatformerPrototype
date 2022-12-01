using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : BaseFactory
{

    [Range(0f,100f)]
    [SerializeField] private float chanceFollowPlayer = 30f;

    public override GameObject Create(Vector2 positionCreate)
    {
        GameObject go = Instantiate(GetRandomPrefabByList(_prefabList), positionCreate, Quaternion.identity);
        float rnd = Random.Range(0f, 100f);
        if (rnd < chanceFollowPlayer)
        {
            EnemyCreature enemyCreature = go.GetComponent<EnemyCreature>();
            if (enemyCreature!=null)
            {
                enemyCreature.enemyDetailsSO.isAlwaysFollowPlayer = true;
            }
        }

        return go;
    }
}
