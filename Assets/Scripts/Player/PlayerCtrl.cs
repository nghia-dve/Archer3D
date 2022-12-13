using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : NghiaMonoBehaviour
{
    protected bool isRestCombo;
    public bool IsRestCombo { get { return isRestCombo; } }

    [SerializeField]
    private PlayerAnim playerAnim;
    public PlayerAnim PlayerAnim { get { return playerAnim; } }
    #region Even animatoin
    protected void EvenRestCombo()
    {
        isRestCombo = !isRestCombo;

    }
    #endregion
}
