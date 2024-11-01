using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected SkillData skillData;
    protected Vector2 fireDir;

    protected virtual void Awake()
    {
        if (skillData == null)
        {
            skillData = CreateDefaultSkillData();
        }
    }

    protected virtual SkillData CreateDefaultSkillData()
    {
        return new SkillData
        {
            metadata = new SkillMetadata
            {
                Name = "Default Skill",
                Description = "Default skill description",
                Type = SkillType.None,
                Element = ElementType.None,
                Tier = 1,
                Tags = new string[0]
            }
        };
    }

    // �⺻ ���� ������
    public virtual float Damage => skillData?.GetCurrentTypeStat()?.baseStat?.damage ?? 0f;
    public string SkillName => skillData?.metadata?.Name ?? "Unknown";
    public int SkillLevel => skillData?.GetCurrentTypeStat()?.baseStat?.skillLevel ?? 1;
    public int MaxSkillLevel => skillData?.GetCurrentTypeStat()?.baseStat?.maxSkillLevel ?? 1;
    public SkillID SkillID => skillData?.metadata?.ID ?? SkillID.None;

    // �߻� �޼���
    public abstract bool SkillLevelUpdate(int newLevel);

    // Ÿ�Ժ� ���� ��������
    protected T GetTypeStats<T>() where T : ISkillStat
    {
        if (skillData == null) return default(T);

        var currentStats = skillData.GetCurrentTypeStat();
        if (currentStats == null) return default(T);

        if (currentStats is T typedStats)
        {
            return typedStats;
        }
        Debug.LogWarning($"Current skill is not of type {typeof(T)}");
        return default(T);
    }

    // Unity �ν����Ϳ��� ���� ������ �� �ֵ��� �ϴ� �޼���
    public virtual void SetSkillData(SkillData data)
    {
        skillData = data;
    }

    // ���� ��ų ������ ��������
    public virtual SkillData GetSkillData()
    {
        return skillData;
    }
}
