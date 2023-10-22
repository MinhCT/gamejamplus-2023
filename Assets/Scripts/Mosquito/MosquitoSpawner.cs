using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    public bool isDebug = false;

    [SerializeField]
    List<GameObject> mosquitos;
    [SerializeField] GameObject Player;
    [SerializeField] float OuterCircleSpawnRadius = 20f;
    [SerializeField] float InnerCircleSpawnRadius = 15f;
    [SerializeField] float NonCircleSpawnRadius = 5f;

    private void Start()
    {
        StartCoroutine(SpawnByInterval());
    }

    private void OnDrawGizmos()
    {
        if (!isDebug) return;
        if (Player == null) return;
        Gizmos.DrawWireSphere(Player.transform.position, OuterCircleSpawnRadius);
        Gizmos.DrawWireSphere(Player.transform.position, InnerCircleSpawnRadius);
        Gizmos.DrawWireSphere(Player.transform.position, NonCircleSpawnRadius);
    }

    private IEnumerator SpawnByInterval()
    {
        while (true)
        {
            var randomNextSecond = Random.Range(1, 3);
            var randomEnemy = mosquitos[Random.Range(0, mosquitos.Count)];
            var randomCircleRad = (Random.value < 0.5f) ? OuterCircleSpawnRadius : InnerCircleSpawnRadius;
            Vector3 pointNol = Random.onUnitSphere;
            var randomPoint = pointNol * (randomCircleRad - NonCircleSpawnRadius) + pointNol.normalized * NonCircleSpawnRadius;
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