using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConstructor : MonoBehaviour
{
    [SerializeField] private List<ConstructData> constructDatas;

    [System.Serializable]
    public struct ConstructData
    {
        public GameObject Prefab;
        public Vector3 TransPos;
        public Vector3 Rot;

        public ConstructData(GameObject prefab, Vector3 transPos, Vector3 rot)
        {
            Prefab = prefab;
            TransPos = transPos;
            Rot = rot;
        }
    }

    public void Init()
    {
        foreach (var item in constructDatas)
        {
            Instantiate(item.Prefab, item.TransPos, Quaternion.Euler(item.Rot));
        }
    }
}
