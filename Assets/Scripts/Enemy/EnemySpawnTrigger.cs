using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    private bool _isTriggerEnter = false;
    private float _offsetX = 20f;
    private float offsetY = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerCharacter>()== null) return;

        if (!_isTriggerEnter)
        {
            _isTriggerEnter = true;
            Vector2 positiontSpawn = transform.position + new Vector3(_offsetX, offsetY, 0f);
            GameObject enemy = GameManager.Instance.enemyFactory.Create(positiontSpawn);
            Destroy(gameObject);
        } 
    }
}
