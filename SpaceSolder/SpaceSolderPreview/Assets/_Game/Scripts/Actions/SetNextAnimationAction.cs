using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextAnimationAction : ActionBase
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<InfoData> infoDatas;

    private float _maxHP;
    private bool _isInited = false;
    
    [System.Serializable]
    public struct InfoData
    {
        public AnimationClip animationClip;
        public float timeToSet;
       [HideInInspector] public bool isPlayed;
    }

    private void Init(float HP)
    {
        _maxHP = HP;
        Debug.Log(_maxHP);
        _isInited = true;
    }
    public override void ExecuteAction(params ActionParameter[] parametrs)
    {
        if (infoDatas.IsNullOrEmpty())
            return;

        foreach (var param in parametrs)
        {
            if (param is HPParameter hP)
            {
                if (_isInited == false)
                {
                    Init(hP.HP);
                }
                for(int i = 0; i < infoDatas.Count; i++)
                {
                    var infoData = infoDatas[i];
                    if (hP.HP <= _maxHP / 100 * infoData.timeToSet)
                    {
                        animator.Play(infoData.animationClip.name);
                        infoData.isPlayed = true;
                        infoDatas.RemoveAt(i);
                    }
                }
            }
        }
    }
}
