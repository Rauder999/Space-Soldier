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
        public Quaternion Rotation;
    }

    public void Init()
    {
        foreach (var item in constructDatas)
        {
            Instantiate(item.Prefab, item.TransPos, item.Rotation);
        }
    }
}
