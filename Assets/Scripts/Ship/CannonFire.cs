using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public AudioClip Shot;
    AudioSource sound;
    
    public GameObject[] LCannon;
    public GameObject[] RCannon;
    public GameObject Cball;
    public GameObject Muzzle;
    public Camera RCam;
    public Camera LCam;

    public float Cooldown = 5f;
    public int pMin = 100;
    public int pMax = 350;
    private float LnextFire = 0f;
    private float RnextFire = 0f;


    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    void Update() {
        if(Time.time > LnextFire)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(LCam.enabled == true)
                {
                    for(int i = 0; i < LCannon.Length; i++)
                    {
                        float power = Random.Range(pMin, pMax);
                        GameObject Cannonball = Instantiate(Cball) as GameObject;
                        GameObject Smoke = Instantiate(Muzzle) as GameObject;
                        Cannonball.transform.position = LCannon[i].transform.position;
                        Cannonball.transform.rotation = LCannon[i].transform.rotation;
                        Smoke.transform.position = LCannon[i].transform.position + new Vector3(-0.25f, 0.5f, 0f);;
                        Cannonball.GetComponent<Rigidbody>().AddRelativeForce(Cannonball.transform.right * -power, ForceMode.Force);
                        Destroy(Cannonball, 5f);
                        Destroy(Smoke, 5f);
                        LnextFire = Time.time + Cooldown;
                        sound.PlayOneShot(Shot);
                    }
                }
            }
        }


        if(Time.time > RnextFire)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(RCam.enabled == true){
                    for(int i = 0; i < RCannon.Length; i++)
                    {
                        float power = Random.Range(pMin, pMax);
                        GameObject Cannonball = Instantiate(Cball) as GameObject;
                        GameObject Smoke = Instantiate(Muzzle) as GameObject;
                        Cannonball.transform.position = RCannon[i].transform.position;
                        Cannonball.transform.rotation = RCannon[i].transform.rotation;
                        Smoke.transform.position = RCannon[i].transform.position + new Vector3(0.25f, 0.5f, 0f);
                        Cannonball.GetComponent<Rigidbody>().AddRelativeForce(Cannonball.transform.right * power, ForceMode.Force);
                        Destroy(Cannonball, 5f);
                        Destroy(Smoke, 5f);
                        RnextFire = Time.time + Cooldown;
                        sound.PlayOneShot(Shot);
                    }
                }
            }
        }
        
        
    }
}
