using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : Death
{

    private float _secondRestart = 1f;

    public override void DeathCreature()
    {
        base.DeathCreature();
        StartCoroutine(RestartGameRoutine());
    }

    private IEnumerator RestartGameRoutine()
    {
        yield return new WaitForSeconds(_secondRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
