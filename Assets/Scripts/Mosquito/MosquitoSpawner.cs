using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mosquitos;

    public void SpawnMosquitos(Dictionary<MosquitoType, int> mapData)
    {

    }

}

public enum MosquitoType
{
    Normal,
    Fast,
    Bomb,
    Muscular,
}