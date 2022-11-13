using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMove, IPick, IRepair, IDownHP
{
    //�������̽� ����
    IMove move;
    IPick pick;
    IRepair repair;
    IDownHP downHP;

    //IMove ���� ����
    Vector3 PlayerPos;
    float MoveSpeed;

    //Player�� Ÿ�԰� Hand ������Ʈ, �ִ� ü��, ���� ü�� ����
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
            //Ÿ�� ��� �̹����� ��ũ��Ʈ �ٲ�
            //���� Ÿ�� ������Ʈ ��Ȱ��ȭ? ���ӿ� ���� ���� ���� �������� ��� �̵�?
            //Ÿ�� ��� ��Ȱ��ȭ, �ڽ����� ���
            //Ÿ���ȿ� �ֱ�
        }
    }

    void IRepair.Repair(GameObject TargetObject)
    {
        //if(resource >= �ʿ��)
        //TargetObject ���� ���? Collision �浹 or position or MouseCursor
        //TargetObject.HP = TargetObject.HPMAX
    }

    void IDownHP.DownHP(int AT)
    {
        this.HP -= AT; // ���ݷ¸�ŭ ü�� ����
    }

    void Update()
    {
        move.Move(PlayerPos);
    }
}
