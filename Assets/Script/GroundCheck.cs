using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float Radius;
    [SerializeField] private float OffsetX;
    [SerializeField] private float OffsetY;
    [SerializeField] private float Distance;
    [SerializeField] private int LayerMask;

    void Start(){
        LayerMask = 1 << LayerMask;
    }

    public bool CheckGround(){
        // (�L���X�g�J�n�ʒu, �`�F�b�J�[���a, �L���X�g����, �ő�i�s����, �Փ˂��郌�C��(~�Ȃ̂�Player�ȊO�S��))
        return Physics2D.CircleCast((Vector2)transform.position + OffsetX*Vector2.right + OffsetY*Vector2.up, Radius, Vector2.down, Distance, ~LayerMask);
    }
}
