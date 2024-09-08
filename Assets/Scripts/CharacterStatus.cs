using UnityEngine;

[System.Serializable]
public class CharacterStatus : MonoBehaviour
{
    public string characterName;    // 캐릭터 이름 (플레이어, 파티원, 몬스터 모두 가능)
    public int maxHP;               // 최대 체력
    public int currentHP;           // 현재 체력
    
    public int maxMP; 

    public int currentMP; 


    public int attackPower;         // 공격력

    public int defense;             // 방어력
    public int speed;               // 속도 (턴 순서에 사용 가능)
    public string element;

    // 초기 스테이터스 설정
    public void InitializeStatus(string name, int hp, int attack, int def, int spd)
    {
        characterName = name;
        maxHP = hp;
        currentHP = hp;  // 시작 시 체력은 최대 체력과 동일
        attackPower = attack;
        defense = def;
        speed = spd;
    }

    // 데미지를 입었을 때 호출
    public void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - defense, 0);  // 방어력을 고려한 실제 데미지
        currentHP -= actualDamage;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();  // 체력이 0이 되면 사망 처리
        }
    }
    public void UseMP(int mpCost)
    {
        // 현재 마나가 충분할 경우 마나를 소모
        if (currentMP >= mpCost)
        {
            currentMP -= mpCost;
        }
        else
        {
            Debug.Log($"{characterName}의 마나가 부족합니다.");
        }
    }

    // 캐릭터가 사망했을 때 호출
    private void Die()
    {
        Debug.Log(characterName + "이(가) 전투에서 사망했습니다.");
        Destroy(gameObject);  // 사망한 캐릭터 제거
    }

    // 체력을 회복할 때 호출
    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);  // 체력을 최대 체력 이상으로 넘지 않게
    }
}
