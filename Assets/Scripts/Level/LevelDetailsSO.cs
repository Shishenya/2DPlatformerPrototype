using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDetails_", menuName = "Scriptable Objects/Level/Level Details")]
public class LevelDetailsSO : ScriptableObject
{
    public int depthLevel;
    public List<GameObject> levelSectionGOList;
    public List<GameObject> startLevelSectionList;
    public List<GameObject> endLevelSectionList;
}
