using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreateDustParticle()        // ���� �ִϸ��̼��� ��� ������ �����̶� ȿ���� �־���� ����(�ٵ� �ִϸ��̼� ������ ������ �� ����), ��� ���ϴ� ��
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
