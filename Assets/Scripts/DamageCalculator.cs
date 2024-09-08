using UnityEngine;
public class DamageCalculator : MonoBehaviour
{
    public int CalculateDamage(int attackPower, int skillDamage, string attackElement, CharacterStatus attacker, CharacterStatus defender)
    {
        // 기본 데미지 = (공격력 × 스킬 데미지) ÷ 10
        float baseDamage = (attackPower * skillDamage) / 10f;

        // 방어력 공식
        float defenseFactor = 100f / (100f + defender.defense);
        float damageAfterDefense = baseDamage * defenseFactor;

        // 나중에 속성 상성 계산할 때 적용할 부분
        // 예시로 속성 비교 후 상성 반영할 수 있음
        if (attackElement == defender.element)
        {
            // 속성이 같을 때 (예: 상성을 고려한 로직을 나중에 추가)
        }

        int finalDamage = Mathf.RoundToInt(damageAfterDefense);

        // 최소 데미지 1 보장
        return Mathf.Max(finalDamage, 1);
    }
}
