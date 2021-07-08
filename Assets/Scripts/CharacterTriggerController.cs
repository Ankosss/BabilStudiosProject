using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerController : MonoBehaviour
{
    public float RotateSec = 1.0f;
    int angley;

    private void Start() => angley = (int)transform.eulerAngles.y;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DonSag")
        {
            CharacterMoveController.cMove.isAutoMove = true;
            CharacterMoveController.cMove.canMouseMove = false;
        }
        if (other.gameObject.name == "DonSol")
        {
            CharacterMoveController.cMove.isAutoMove = true;
            CharacterMoveController.cMove.canMouseMove = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DonSag")
        {
            CharacterMoveController.cMove.isAutoMove = false;
            CharacterMoveController.cMove.canMouseMove = true;

        }
        if (other.gameObject.name == "DonSol")
        {
            CharacterMoveController.cMove.isAutoMove = false;
            CharacterMoveController.cMove.canMouseMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "DonSag")
        {
            CharacterMoveController.cMove.canMouseMove = false;
            CharacterMoveController.cMove.isAutoMove = true;
            StartCoroutine(SagDon());
        }
        else if (other.gameObject.name == "DonSol")
        {
            CharacterMoveController.cMove.canMouseMove = false;
            CharacterMoveController.cMove.isAutoMove = true;

            StartCoroutine(SolDon());
        }

        if (other.gameObject.name == "FinishZone")
        {
            ScenesManage.sManage.TekrarOyna();
        }
    }
    IEnumerator SagDon()
    {
        while (angley < 90)
        {
            angley = (int)transform.eulerAngles.y;
            transform.Rotate(new Vector3(0, 2.50f, 0));
            yield return new WaitForSeconds(RotateSec);
        }

        CharacterMoveController.cMove.canMouseMove = true;
        if (CharacterMoveController.cMove.isAutoMove)
        {
            CharacterMoveController.cMove.isAutoMove = false;
            CharacterMoveController.cMove.canMove = true;
        }

    }

    IEnumerator SolDon()
    {
        while (angley > 0)
        {
            angley = (int)transform.eulerAngles.y;
            transform.Rotate(new Vector3(0, -2.50f, 0));
            yield return new WaitForSeconds(RotateSec);
        }

        CharacterMoveController.cMove.canMouseMove = true;
        if (CharacterMoveController.cMove.isAutoMove)
        {
            CharacterMoveController.cMove.isAutoMove = false;
            CharacterMoveController.cMove.canMove = true;
        }
    }
}
