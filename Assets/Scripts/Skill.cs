using UnityEngine;

[System.Serializable]
public class Skill
{
    public string skillName;    // 스킬 이름
    public int skillDamage;     // 스킬 데미지
    public int mpCost;          // MP 소모량
    public int hpCost;          // HP 소모량
    public string element;      // 속성 (예: 불, 물, 바람 등)

    // 생성자
    public Skill(string name, int dmg, int mp, int hp, string elem)
    {
        skillName = name;
        skillDamage = dmg;
        mpCost = mp;
        hpCost = hp;
        element = elem;
    }

    // 스킬 사용
    public void UseSkill(CharacterStatus user, CharacterStatus target, DamageCalculator damageCalculator)
    {
        // MP 소모
        if (user.currentMP >= mpCost)
        {
            user.UseMP(mpCost);  // 마나 소모
        }
        else
        {
            Debug.Log($"{user.characterName}은(는) MP가 부족합니다.");
            return;
        }

        // HP 소모
        user.TakeDamage(hpCost);  // 체력 소모

        // 데미지 계산
        int damage = damageCalculator.CalculateDamage(user.attackPower, skillDamage, element, user, target);

        // 타겟에게 데미지 적용
        target.TakeDamage(damage);

        // 스킬 사용 로그
        Debug.Log($"{user.characterName}이(가) {skillName}을(를) 사용하여 {target.characterName}에게 {damage} 데미지를 입혔습니다.");
    }
}
