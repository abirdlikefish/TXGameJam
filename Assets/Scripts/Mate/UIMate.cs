using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMate : Singleton<UIMate>, IInit
{
    public Button btDrag;
    public LineRenderer straightArrow;
    public LineRenderer straightArrowPureWhite;
    static Gradient redGradient;
    static Gradient pureWhiteGradient;

    public Image magnetX;
    public Image magnetZ;
    List<GameObject> disableUI;
    void DisableAllUI()
    {
        foreach (var it in disableUI)
            it.SetActive(false);
    }
    public void Initialize()
    {
        disableUI = new()
        {
            btDrag.gameObject,
            straightArrow.gameObject,
            straightArrowPureWhite.gameObject,
            magnetX.gameObject,
            magnetZ.gameObject,
        };
        redGradient = straightArrow.colorGradient;
        pureWhiteGradient = straightArrowPureWhite.colorGradient;
        HideStraightArrow();
        DisableAllUI();
    }
    public void OnSelect()
    {
        btDrag.gameObject.SetActive(true);
    }
    //public static void DrawStraightArrow(Vector3 from, Vector3 to)
    //{
    //    //»æÖÆline
    //    Vector3[] positions = new Vector3[2];
    //    positions[0] = new Vector3(from.x,from.y,0);
    //    positions[1] = new Vector3(to.x, to.y, 0);
    //    if(Vector3.Magnitude(positions[1] - positions[0]) / DeliConfig.DragMaxDistance >= 0.95f)
    //        Instance.straightArrow.colorGradient = redGradient;
    //    else
    //        Instance.straightArrow.colorGradient = pureWhiteGradient;
    //    Instance.straightArrow.positionCount = 2;
    //    Instance.straightArrow.SetPositions(positions);
    //}
    public static void HideStraightArrow()
    {
        Instance.straightArrow.positionCount = 0;
    }
}
