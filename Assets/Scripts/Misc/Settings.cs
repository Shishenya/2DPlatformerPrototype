using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    #region Animator Parameters
    public static int aimLeft = Animator.StringToHash("aimLeft");
    public static int aimRight = Animator.StringToHash("aimRight");
    public static int isIdle = Animator.StringToHash("isIdle");
    public static int isWalk = Animator.StringToHash("isWalk");
    #endregion

    #region Default parameters
    public static float defaultSpeedCreature = 1f;
    public static Vector2 startPositionPlayer = new Vector2(0f, 3f);
    #endregion
}
