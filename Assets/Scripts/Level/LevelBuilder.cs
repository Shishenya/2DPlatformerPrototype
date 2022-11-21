using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : Singleton<LevelBuilder>
{
    private Transform parentTransform;
    private float xLocal = -25;
    private float yLocal = 0;

    public LevelDetailsSO curentLevelDetails;

    protected override void Awake()
    {
        base.Awake();
        
        parentTransform = this.transform;

        BuildLevel();

    }

    /// <summary>
    /// Создание уровня
    /// </summary>
    private void BuildLevel()
    {

        for (int i = 0; i < curentLevelDetails.depthLevel; i++)
        {
            GameObject spawnSection = Instantiate(GetRandomLevelSection(), parentTransform);
            spawnSection.transform.localPosition = new Vector2(xLocal, yLocal);
            LevelSection levelSection = spawnSection.GetComponent<LevelSection>();
            xLocal += levelSection.levelSectionSO.widht;
        }

    }

    /// <summary>
    /// Достает случайную секцию
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomLevelSection()
    {
        if (curentLevelDetails!=null)
        {
            if (curentLevelDetails.levelSectionGOList.Count>0)
            {
                int rndIndex = Random.Range(0, curentLevelDetails.levelSectionGOList.Count);
                return curentLevelDetails.levelSectionGOList[rndIndex];
            }
        }

        return null;
    }

}
