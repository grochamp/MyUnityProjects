using UnityEngine;
using System.Collections;

public class EncounterController : MonoBehaviour
{
    public HeroKnight player;  // 플레이어 스크립트 제어
    public GameObject encounterUI;  // Encounter UI
    public GameObject encounterEffect;  // Encounter 이펙트 오브젝트 (Particle System 등)
    public Transform battlefieldPosition;  // 플레이어가 순간이동할 전장 위치
    public Transform enemyBattlefieldPosition;  // 적이 순간이동할 전장 위치
    public GameObject encounterText;  // "ENCOUNTER" 텍스트 오브젝트

    private bool inEncounter = false;

    // 플레이어가 몬스터와 충돌했을 때 호출
    public void TriggerEncounter()
    {
        if (inEncounter) return;

        inEncounter = true;
        player.canMove = false;  // 플레이어 움직임 비활성화
        encounterUI.SetActive(true);  // Encounter UI 활성화
        StartCoroutine(EncounterSequence());  // Encounter 시퀀스 시작
    }

    IEnumerator EncounterSequence()
    {
        

        // 1초 대기
        yield return new WaitForSeconds(1.0f);

        // Encounter UI 비활성화
        encounterUI.SetActive(false);

      

        // 플레이어와 적을 전장으로 순간이동
        player.transform.position = battlefieldPosition.position;
        // 적 오브젝트가 있다면 적도 전장으로 이동 (적 오브젝트의 참조가 필요함)
        GameObject enemy = GameObject.FindWithTag("Monster");
        if (enemy != null)
        {
            enemy.transform.position = enemyBattlefieldPosition.position;
        }

        

        // 전투 시작을 위한 추가 로직 (필요시 여기에 추가)
        Debug.Log("전투 시작 준비 완료");
    }
}
