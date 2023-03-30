using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crossheir : MonoBehaviour
{
    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private Parts[] parts;
    
    [SerializeField] private float speedSpread;

    public float currentSpread;

    private float _curSpread;

    void Update()
    {
        CrossheirUpdate();
    }

    public void CrossheirUpdate()
    {
        float t = 0.005f * speedSpread;
        _curSpread = Mathf.Lerp(_curSpread, currentSpread, t);

        for (int i = 0; i < parts.Length; i++)
        {
            Parts p = parts[i];
            p.trans.anchoredPosition = p.pos * _curSpread;
        }
    }
    [System.Serializable]
    public class Parts
    {
        public RectTransform trans;
        public Vector2 pos;
    }
}
