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
        // (キャスト開始位置, チェッカー半径, キャスト方向, 最大進行距離, 衝突するレイヤ(~なのでPlayer以外全部))
        return Physics2D.CircleCast((Vector2)transform.position + OffsetX*Vector2.right + OffsetY*Vector2.up, Radius, Vector2.down, Distance, ~LayerMask);
    }
}
