using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class growflowers : MonoBehaviour
{
    public GameObject rose;
    public GameObject lotus;
    public GameObject jasmine;

    public float growAmount = 6f;  // scale multiplier (1.5x larger)

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
            rose.transform.localScale *= growAmount;
            roseGrown = true;
            Debug.Log("Rose grown!");
            CheckAllGrown();
        }
    }

    public void GrowLotus()
    {
        if (!lotusGrown)
        {
            lotus.transform.localScale *= growAmount;
            lotusGrown = true;
            Debug.Log("Lotus grown!");
            CheckAllGrown();
        }
    }

    public void GrowJasmine()
    {
        if (!jasmineGrown)
        {
            jasmine.transform.localScale *= growAmount;
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
            SceneManager.LoadScene("EndScene");
        }
    }
}
