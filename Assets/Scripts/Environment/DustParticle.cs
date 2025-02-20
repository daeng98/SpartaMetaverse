using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreateDustParticle()        // 뭔가 애니메이션이 없어서 허전한 느낌이라 효과로 넣어볼려고 했음(근데 애니메이션 없으면 못쓰는 것 같음), 사용 안하는 중
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
