using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //상호작용 가능한 모든 오브젝트
    //ex)캐릭터, 파괴 가능한 오브젝트, 상호작용을 통한 이벤트가 있는 오브젝트

    #region Status enabled or not
    private bool isDeath;
    private bool isHit;
    #endregion


    #region Properties
    public bool IsDeath { get { return isDeath; } set { isDeath = value; } }

    public bool IsHit { get { return isHit; } set { isHit = value; } }
    #endregion
}
