using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private GameObject LifeEffect;

    [SerializeField]
    private GameObject UpScanEffect;

    [SerializeField]
    private GameObject DownScanEffect;

    private bool isScanning;
    private bool isScanningComplete;

    private float scanningSpeed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        LifeEffect.SetActive(false);
        UpScanEffect.SetActive(false);
        DownScanEffect.SetActive(false);
        isScanning = false;
        isScanningComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScanning && isScanningComplete == false)
        {
            Scan(true);
            UpScanEffect.transform.Translate(scanningSpeed * Vector3.up * Time.deltaTime);
            DownScanEffect.transform.Translate(scanningSpeed * Vector3.down * Time.deltaTime);
        }
        else
        {
            Scan(false);
        }

        if (DownScanEffect.transform.localPosition.y <= 0 || UpScanEffect.transform.localPosition.y >= 20)
        {
            isScanningComplete = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isScanning = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isScanning = false;
        UpScanEffect.transform.localPosition = Vector3.zero;
        DownScanEffect.transform.localPosition = new Vector3(0, 20, 0);
    }

    public void Scan(bool isScan)
    {
        LifeEffect.SetActive(isScan);
        UpScanEffect.SetActive(isScan);
        DownScanEffect.SetActive(isScan);
    }
}
