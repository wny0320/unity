using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMove, IPick, IRepair, IDownHP
{
    //인터페이스 선언
    IMove move;
    IPick pick;
    IRepair repair;
    IDownHP downHP;

    //IMove 관련 변수
    Vector3 PlayerPos;
    float MoveSpeed;

    //Player의 타입과 Hand 오브젝트, 최대 체력, 현재 체력 설정
    string Type = "Player";
    GameObject Hand;
    int MaxHP = 4;
    int HP = 4;

    void Start()
    {
        PlayerPos = this.transform.position;
        move = GetComponent<IMove>();
        pick = GetComponent<IPick>();
        repair = GetComponent<IRepair>();
        downHP = GetComponent<IDownHP>();
        MoveSpeed = 0.07f;
    }
    void IMove.Move(Vector3 PlayerPos_)
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerPos_.x -= MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPos_.x += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerPos_.y -= MoveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            PlayerPos_.y += MoveSpeed;
        }
        this.transform.position = PlayerPos_;
        PlayerPos = PlayerPos_;
    }

    void IPick.Pick(GameObject DropItem)
    {
        /*Hand = DropItem;
        if(DropItem.Type == "Tower")
        {
            //타워 드는 이미지로 스크립트 바꿈
            //원래 타워 오브젝트 비활성화? 게임에 영향 없는 더미 구역으로 잠시 이동?
            //타워 잠시 비활성화, 자식으로 상속
            //타워안에 넣기
        }
    }

    void IRepair.Repair(GameObject TargetObject)
    {
        //if(resource >= 필요양)
        //TargetObject 설정 방식? Collision 충돌 or position or MouseCursor
        //TargetObject.HP = TargetObject.HPMAX
    }

    void IDownHP.DownHP(int AT)
    {
        this.HP -= AT; // 공격력만큼 체력 감소
    }

    void Update()
    {
        move.Move(PlayerPos);
    }
}
