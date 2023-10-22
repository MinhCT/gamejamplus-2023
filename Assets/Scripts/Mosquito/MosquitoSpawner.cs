using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mosquitos;
    [SerializeField] GameObject Player;
    [SerializeField] float OuterCircleSpawnRadius = 20f;
    [SerializeField] float InnerCircleSpawnRadius = 15f;

    private void Start()
    {
        StartCoroutine(SpawnByInterval());
    }

    private void OnDrawGizmos()
    {
        if (Player == null) return;
        Gizmos.DrawWireSphere(Player.transform.position, OuterCircleSpawnRadius);
        Gizmos.DrawWireSphere(Player.transform.position, InnerCircleSpawnRadius);
    }

    private IEnumerator SpawnByInterval()
    {
        while (true)
        {
            var randomNextSecond = Random.Range(1, 3);
            var randomEnemy = mosquitos[Random.Range(0, mosquitos.Count)];
            var randomCircleRad = (Random.value < 0.5f) ? OuterCircleSpawnRadius : InnerCircleSpawnRadius;
            var randomPoint = Random.onUnitSphere * randomCircleRad;
            randomPoint.z = 0;

            Instantiate(randomEnemy, randomPoint, Quaternion.identity);
            yield return new WaitForSeconds(randomNextSecond);
        }
    }
}

public enum MosquitoType
{
    Normal,
    Fast,
    Bomb,
    Muscular,
}