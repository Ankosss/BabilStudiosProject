using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerController : MonoBehaviour
{
    public CharacterMoveController cMove;
    public Camera cam;
    int angley;
    private void Awake()
    {
        cMove = GetComponent<CharacterMoveController>();
        angley = (int)transform.eulerAngles.y;
    }
    private void Start()
    {
        angley = (int)transform.eulerAngles.y;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DonSag")
        {
            cMove.isAutoMove = true;
        }
        if (other.gameObject.name == "DonSol")
        {
            cMove.isAutoMove = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "DonSag")
        {

            cMove.canMouseMove = false;


            StartCoroutine(SagDon());
        }
        if (other.gameObject.name == "DonSol")
        {
            cMove.canMouseMove = false;

            StartCoroutine(SolDon());
        }
    }



    IEnumerator SagDon()
    {

        while (angley < 90)
        {
            angley = (int)transform.eulerAngles.y;
            transform.Rotate(new Vector3(0, 1.00f, 0));

            yield return new WaitForSeconds(0.01f);
        }

        cMove.canMouseMove = true;
        if (cMove.isAutoMove)
        {
            cMove.isAutoMove = false;
            cMove.canMove = true;
        }

    }

    IEnumerator SolDon()
    {

        while (angley > 0)
        {
            angley = (int)transform.eulerAngles.y;
            transform.Rotate(new Vector3(0, -1.00f, 0));

            yield return new WaitForSeconds(0.01f);
        }
        cMove.canMouseMove = true;
        if (cMove.isAutoMove)
        {
            cMove.isAutoMove = false;
            cMove.canMove = true;
        }
    }
}
