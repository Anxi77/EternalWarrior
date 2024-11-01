using UnityEngine;

public class BindEffect : MonoBehaviour, IPoolable
{
    private ParticleSystem[] particleSystems;

    private void Awake()
    {
        // ��� ��ƼŬ �ý����� �� ���� ������ (�ڽŰ� �ڽĵ��� ��ƼŬ �ý���)
        particleSystems = GetComponentsInChildren<ParticleSystem>(true);
    }

    public void OnSpawnFromPool()
    {
        Debug.Log($"BindEffect spawned: {gameObject.name}, Particle count: {particleSystems.Length}");

        // ��� ��ƼŬ �ý��� ���
        foreach (var ps in particleSystems)
        {
            if (ps != null)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                ps.Play(true);  // withChildren = true�� ����
            }
        }

        // Transform �ʱ�ȭ
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public void OnReturnToPool()
    {
        // ��� ��ƼŬ �ý��� ����
        foreach (var ps in particleSystems)
        {
            if (ps != null)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }

        transform.SetParent(null);
    }

    // ����׿� �޼���
    private void OnEnable()
    {
        Debug.Log($"BindEffect enabled: {gameObject.name}");
    }
}