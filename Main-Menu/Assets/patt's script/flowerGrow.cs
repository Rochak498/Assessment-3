using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flowerGrow : MonoBehaviour
{
    public GameObject rose;
    public GameObject lotus;
    public GameObject jasmine;

    public float growAmount = 15f;  // how much to move upward

    private bool roseGrown = false;
    private bool lotusGrown = false;
    private bool jasmineGrown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GrowRose()
    {
        if (!roseGrown)
        {
            rose.transform.position += new Vector3(0f, growAmount, 0f);
            roseGrown = true;
            Debug.Log("Rose grown!");
            CheckAllGrown();
        }
    }

    public void GrowLotus()
    {
        if (!lotusGrown)
        {
            lotus.transform.position += new Vector3(0f, growAmount, 0f);
            lotusGrown = true;
            Debug.Log("Lotus grown!");
            CheckAllGrown();
        }
    }

    public void GrowJasmine()
    {
        if (!jasmineGrown)
        {
            jasmine.transform.position += new Vector3(0f, growAmount, 0f);
            jasmineGrown = true;
            Debug.Log("Jasmine grown!");
            CheckAllGrown();
        }
    }

    void CheckAllGrown()
    {
        Debug.Log($"CheckAllGrown called: roseGrown={roseGrown}, lotusGrown={lotusGrown}, jasmineGrown={jasmineGrown}");

        if (roseGrown && lotusGrown && jasmineGrown)
        {
            Debug.Log("✅ All flowers grown. Loading End Scene...");
            SceneManager.LoadScene("BloomingFlowerEndScene"); 

        }
    }
}
