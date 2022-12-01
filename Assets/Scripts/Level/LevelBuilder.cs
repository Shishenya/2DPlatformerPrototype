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

        if (curentLevelDetails.depthLevel < 2) Application.Quit();

        for (int i = 0; i < curentLevelDetails.depthLevel; i++)
        {

            GameObject spawnSection;

            // Start Sections
            if (i == 0)
            {
                spawnSection = Instantiate(GetRandomLevelSection(curentLevelDetails.startLevelSectionList), parentTransform);
            }
            // End section
            else if (i == curentLevelDetails.depthLevel - 1)
            {
                spawnSection = Instantiate(GetRandomLevelSection(curentLevelDetails.endLevelSectionList), parentTransform);
            }
            // Middle section
            else
            {
                spawnSection = Instantiate(GetRandomLevelSection(curentLevelDetails.levelSectionGOList), parentTransform);

            }

            spawnSection.transform.localPosition = new Vector2(xLocal, yLocal);
            LevelSection levelSection = spawnSection.GetComponent<LevelSection>();
            xLocal += levelSection.levelSectionSO.widht;
        }

    }

    /// <summary>
    /// Достает случайную секцию
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomLevelSection(List<GameObject> sectionSpawn)
    {
        if (curentLevelDetails != null)
        {
            if (curentLevelDetails.levelSectionGOList.Count > 0)
            {
                int rndIndex = Random.Range(0, sectionSpawn.Count);
                return sectionSpawn[rndIndex];
            }
        }

        return null;
    }

}
