using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : MonoBehaviour
{
    Transform OriginRay;
    public float Firerate; //check for the animation recoil
    public float Range;
    [SerializeField] public float Saved_Firerate;
    public int damage;
    public float PauseToShoot = .25f;
    public GameObject muzzle;
    public Transform place_Muzzle;
    public Animator shutgun;
    public LayerMask layer;
    bool Shooted = false;
    // Start is called before the first frame update
    void Start()
    {
        Saved_Firerate = Firerate;
        OriginRay = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Firerate >= 0)
        {
            Firerate -= Time.deltaTime;
            shutgun.SetBool("Shoot", false);
        }


        if (Input.GetMouseButton(0) && Firerate <= 0 && !Shooted)
        {
            Shooted = true;
            StartCoroutine(Shooting());

        }

    }
    IEnumerator Shooting()
    {
        Debug.Log("Shoot");
        yield return null;


        RaycastHit hit;

        if (Physics.Raycast(OriginRay.position, OriginRay.forward, out hit, Range, layer, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.gameObject.layer != 2)
            {
                if (shutgun.GetBool("Movin"))
                {
                    shutgun.SetBool("Movin", false);
                    yield return new WaitForSeconds(PauseToShoot);
                }
                shutgun.SetBool("Shoot", true);
                GameObject Muzzle = Instantiate(muzzle, place_Muzzle.position, OriginRay.rotation, place_Muzzle);
                Destroy(Muzzle, 2f);
                Firerate = Saved_Firerate;
            }




        }
        else
        {
            if (shutgun.GetBool("Movin"))
            {
                shutgun.SetBool("Movin", false);
                yield return new WaitForSeconds(PauseToShoot);
            }
            shutgun.SetBool("Shoot", true);
            GameObject Muzzle = Instantiate(muzzle, place_Muzzle.position, OriginRay.rotation, place_Muzzle);
            Destroy(Muzzle, 2f);
            Firerate = Saved_Firerate;
        }
        Shooted = false;


    }











}
