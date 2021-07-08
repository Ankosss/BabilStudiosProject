using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouseController : MonoBehaviour
{
    public bool isPC=false;
    public Vector3 konum;
    void Update()
    {
        konum = Input.mousePosition;
        konum = Camera.main.ScreenToViewportPoint(konum);
        if (CharacterMoveController.cMove.canMouseMove)
        {
            if (isPC)
            {
                if (konum.x < 0)
                {
                    konum.x = 0.0f;
                }
                if (konum.x > 1.0f)
                {
                    konum.x = 1.0f;
                }
                Move();
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (konum.x < 0)
                    {
                        konum.x = 0.0f;
                    }
                    if (konum.x > 1.0f)
                    {
                        konum.x = 1.0f;
                    }
                    Move();
                }
            }            
        }
    }
    /// <summary>
    /// Mouse hangi yöne yakýnsa yakýnlýðýna baðlý olarak o yöne doðru bir hareket saðlanýr.
    /// </summary>
    public void Move()
    {
        if (konum.x < 0.5)
        {
            CharacterMoveController.cMove.LeftMove(Mathf.Abs(konum.x - 0.5f)*2);
        }
        if (konum.x > 0.5)
        {
            CharacterMoveController.cMove.RightMove((konum.x - 0.5f)*2);
        }
    }
}
