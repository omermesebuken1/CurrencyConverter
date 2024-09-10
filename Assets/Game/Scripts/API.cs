using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Linq;
using TMPro;

[Serializable]
public class CurrencyData
{
    public string Update_Date;
    public Currency USD;
    public Currency EUR;
    public Currency GBP;
    public Currency CHF;
    public Currency CAD;
    public Currency RUB;
    public Currency AED;
    public Currency AUD;
    public Currency DKK;
    public Currency SEK;
    public Currency NOK;
    public Currency JPY;
    public Currency KWD;
    public Currency ZAR;
    public Currency BHD;
    public Currency LYD;
    public Currency SAR;
    public Currency IQD;
    public Currency ILS;
    public Currency IRR;
    public Currency INR;
    public Currency MXN;
    public Currency HUF;
    public Currency NZD;
    public Currency BRL;
    public Currency IDR;
    public Currency CZK;
    public Currency PLN;
    public Currency RON;
    public Currency CNY;
    public Currency ARS;
    public Currency ALL;
    public Currency AZN;
    public Currency BAM;
    public Currency CLP;
    public Currency COP;
    public Currency CRC;
    public Currency DZD;
    public Currency EGP;
    public Currency HKD;
    public Currency ISK;
    public Currency HRK;
    public Currency JOD;
    public Currency KRW;
    public Currency KZT;
    public Currency LBP;
    public Currency LKR;
    public Currency MAD;
    public Currency MDL;
    public Currency MKD;
    public Currency MYR;
    public Currency OMR;
    public Currency PEN;
    public Currency PHP;
    public Currency PKR;
    public Currency QAR;
    public Currency RSD;
    public Currency SGD;
    public Currency SYP;
    public Currency THB;
    public Currency TWD;
    public Currency UAH;
    public Currency UYU;
    public Currency GEL;
    public Currency TND;
    public Currency BGN;
    public Currency ONS;
    public Currency GRA;
    public Currency CEY;
    public Currency YAR;
    public Currency TAM;
    public Currency CUM;
    public Currency ATA;
    public Currency ODA;
    public Currency OSA;
    public Currency YIA;
    public Currency IKI;
    public Currency BES;
    public Currency GRE;
    public Currency RES;
    public Currency HAM;
    public Currency GUM;
}

[Serializable]
public class Currency
{
    public string Buying;
    public string Type;
    public string Selling;
    public string Change;
}

[Serializable]

public class API : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lastUpdate;
    public CurrencyData currencyData;

    public bool dataFetched;
    private void Start()
    {
        Application.targetFrameRate = 60;
        dataFetched = false;
        StartCoroutine(GetCurrentCurrencies());
    }
    public IEnumerator GetCurrentCurrencies()
    {
        dataFetched = false;

        string url = "https://finans.truncgil.com/v4/today.json";

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {

            string jsonResponse = www.downloadHandler.text;
            Debug.Log("JSON Response: " + jsonResponse); // Log the JSON response

            currencyData = JsonUtility.FromJson<CurrencyData>(jsonResponse);

            // Debug logs to check if currencyData is populated correctly
            if (currencyData == null)
            {
                Debug.LogError("Failed to deserialize JSON into CurrencyData");
            }
            else
            {
                Debug.Log("Deserialization successful");
                Debug.Log("Update date after deserialization: " + currencyData.Update_Date);
            }
            string updateDate = currencyData.Update_Date;
            Debug.Log("update date: " + updateDate);
            lastUpdate.text = "Son Güncelleme: \n" + updateDate;
            dataFetched = true;
        }
    }


    public string GetYourSelling(string name)
    {
        string tmpSelling = "";

        switch (name)
        {
            case "USD":
                tmpSelling = currencyData.USD.Selling;
                break;
            case "EUR":
                tmpSelling = currencyData.EUR.Selling;
                break;
            case "GBP":
                tmpSelling = currencyData.GBP.Selling;
                break;
            case "CHF":
                tmpSelling = currencyData.CHF.Selling;
                break;
            case "CAD":
                tmpSelling = currencyData.CAD.Selling;
                break;
            case "RUB":
                tmpSelling = currencyData.RUB.Selling;
                break;
            case "AED":
                tmpSelling = currencyData.AED.Selling;
                break;
            case "AUD":
                tmpSelling = currencyData.AUD.Selling;
                break;
            case "DKK":
                tmpSelling = currencyData.DKK.Selling;
                break;
            case "SEK":
                tmpSelling = currencyData.SEK.Selling;
                break;
            case "NOK":
                tmpSelling = currencyData.NOK.Selling;
                break;
            case "JPY":
                tmpSelling = currencyData.JPY.Selling;
                break;
            case "KWD":
                tmpSelling = currencyData.KWD.Selling;
                break;
            case "ZAR":
                tmpSelling = currencyData.ZAR.Selling;
                break;
            case "BHD":
                tmpSelling = currencyData.BHD.Selling;
                break;
            case "LYD":
                tmpSelling = currencyData.LYD.Selling;
                break;
            case "SAR":
                tmpSelling = currencyData.SAR.Selling;
                break;
            case "IQD":
                tmpSelling = currencyData.IQD.Selling;
                break;
            case "ILS":
                tmpSelling = currencyData.ILS.Selling;
                break;
            case "IRR":
                tmpSelling = currencyData.IRR.Selling;
                break;
            case "INR":
                tmpSelling = currencyData.INR.Selling;
                break;
            case "MXN":
                tmpSelling = currencyData.MXN.Selling;
                break;
            case "HUF":
                tmpSelling = currencyData.HUF.Selling;
                break;
            case "NZD":
                tmpSelling = currencyData.NZD.Selling;
                break;
            case "BRL":
                tmpSelling = currencyData.BRL.Selling;
                break;
            case "IDR":
                tmpSelling = currencyData.IDR.Selling;
                break;
            case "CZK":
                tmpSelling = currencyData.CZK.Selling;
                break;
            case "PLN":
                tmpSelling = currencyData.PLN.Selling;
                break;
            case "RON":
                tmpSelling = currencyData.RON.Selling;
                break;
            case "CNY":
                tmpSelling = currencyData.CNY.Selling;
                break;
            case "ARS":
                tmpSelling = currencyData.ARS.Selling;
                break;
            case "ALL":
                tmpSelling = currencyData.ALL.Selling;
                break;
            case "AZN":
                tmpSelling = currencyData.AZN.Selling;
                break;
            case "BAM":
                tmpSelling = currencyData.BAM.Selling;
                break;
            case "CLP":
                tmpSelling = currencyData.CLP.Selling;
                break;
            case "COP":
                tmpSelling = currencyData.COP.Selling;
                break;
            case "CRC":
                tmpSelling = currencyData.CRC.Selling;
                break;
            case "DZD":
                tmpSelling = currencyData.DZD.Selling;
                break;
            case "EGP":
                tmpSelling = currencyData.EGP.Selling;
                break;
            case "HKD":
                tmpSelling = currencyData.HKD.Selling;
                break;
            case "ISK":
                tmpSelling = currencyData.ISK.Selling;
                break;
            case "HRK":
                tmpSelling = currencyData.HRK.Selling;
                break;
            case "JOD":
                tmpSelling = currencyData.JOD.Selling;
                break;
            case "KRW":
                tmpSelling = currencyData.KRW.Selling;
                break;
            case "KZT":
                tmpSelling = currencyData.KZT.Selling;
                break;
            case "LBP":
                tmpSelling = currencyData.LBP.Selling;
                break;
            case "LKR":
                tmpSelling = currencyData.LKR.Selling;
                break;
            case "MAD":
                tmpSelling = currencyData.MAD.Selling;
                break;
            case "MDL":
                tmpSelling = currencyData.MDL.Selling;
                break;
            case "MKD":
                tmpSelling = currencyData.MKD.Selling;
                break;
            case "MYR":
                tmpSelling = currencyData.MYR.Selling;
                break;
            case "OMR":
                tmpSelling = currencyData.OMR.Selling;
                break;
            case "PEN":
                tmpSelling = currencyData.PEN.Selling;
                break;
            case "PHP":
                tmpSelling = currencyData.PHP.Selling;
                break;
            case "PKR":
                tmpSelling = currencyData.PKR.Selling;
                break;
            case "QAR":
                tmpSelling = currencyData.QAR.Selling;
                break;
            case "RSD":
                tmpSelling = currencyData.RSD.Selling;
                break;
            case "SGD":
                tmpSelling = currencyData.SGD.Selling;
                break;
            case "SYP":
                tmpSelling = currencyData.SYP.Selling;
                break;
            case "THB":
                tmpSelling = currencyData.THB.Selling;
                break;
            case "TWD":
                tmpSelling = currencyData.TWD.Selling;
                break;
            case "UAH":
                tmpSelling = currencyData.UAH.Selling;
                break;
            case "UYU":
                tmpSelling = currencyData.UYU.Selling;
                break;
            case "GEL":
                tmpSelling = currencyData.GEL.Selling;
                break;
            case "TND":
                tmpSelling = currencyData.TND.Selling;
                break;
            case "BGN":
                tmpSelling = currencyData.BGN.Selling;
                break;
            case "ONS":
                tmpSelling = currencyData.ONS.Selling;
                break;
            case "GRA":
                tmpSelling = currencyData.GRA.Selling;
                break;
            case "CEY":
                tmpSelling = currencyData.CEY.Selling;
                break;
            case "YAR":
                tmpSelling = currencyData.YAR.Selling;
                break;
            case "TAM":
                tmpSelling = currencyData.TAM.Selling;
                break;
            case "CUM":
                tmpSelling = currencyData.CUM.Selling;
                break;
            case "ATA":
                tmpSelling = currencyData.ATA.Selling;
                break;
            case "ODA":
                tmpSelling = currencyData.ODA.Selling;
                break;
            case "OSA":
                tmpSelling = currencyData.OSA.Selling;
                break;
            case "YIA":
                tmpSelling = currencyData.YIA.Selling;
                break;
            case "IKI":
                tmpSelling = currencyData.IKI.Selling;
                break;
            case "BES":
                tmpSelling = currencyData.BES.Selling;
                break;
            case "GRE":
                tmpSelling = currencyData.GRE.Selling;
                break;
            case "RES":
                tmpSelling = currencyData.RES.Selling;
                break;
            case "HAM":
                tmpSelling = currencyData.HAM.Selling;
                break;
            case "GUM":
                tmpSelling = currencyData.GUM.Selling;
                break;
        }

        tmpSelling = tmpSelling.Replace(".", ",");
        return tmpSelling;
    }

    public string GetYourChange(string name)
    {
        string tmpChange = "";

        switch (name)
        {
            case "USD":
                tmpChange = currencyData.USD.Change;
                break;
            case "EUR":
                tmpChange = currencyData.EUR.Change;
                break;
            case "GBP":
                tmpChange = currencyData.GBP.Change;
                break;
            case "CHF":
                tmpChange = currencyData.CHF.Change;
                break;
            case "CAD":
                tmpChange = currencyData.CAD.Change;
                break;
            case "RUB":
                tmpChange = currencyData.RUB.Change;
                break;
            case "AED":
                tmpChange = currencyData.AED.Change;
                break;
            case "AUD":
                tmpChange = currencyData.AUD.Change;
                break;
            case "DKK":
                tmpChange = currencyData.DKK.Change;
                break;
            case "SEK":
                tmpChange = currencyData.SEK.Change;
                break;
            case "NOK":
                tmpChange = currencyData.NOK.Change;
                break;
            case "JPY":
                tmpChange = currencyData.JPY.Change;
                break;
            case "KWD":
                tmpChange = currencyData.KWD.Change;
                break;
            case "ZAR":
                tmpChange = currencyData.ZAR.Change;
                break;
            case "BHD":
                tmpChange = currencyData.BHD.Change;
                break;
            case "LYD":
                tmpChange = currencyData.LYD.Change;
                break;
            case "SAR":
                tmpChange = currencyData.SAR.Change;
                break;
            case "IQD":
                tmpChange = currencyData.IQD.Change;
                break;
            case "ILS":
                tmpChange = currencyData.ILS.Change;
                break;
            case "IRR":
                tmpChange = currencyData.IRR.Change;
                break;
            case "INR":
                tmpChange = currencyData.INR.Change;
                break;
            case "MXN":
                tmpChange = currencyData.MXN.Change;
                break;
            case "HUF":
                tmpChange = currencyData.HUF.Change;
                break;
            case "NZD":
                tmpChange = currencyData.NZD.Change;
                break;
            case "BRL":
                tmpChange = currencyData.BRL.Change;
                break;
            case "IDR":
                tmpChange = currencyData.IDR.Change;
                break;
            case "CZK":
                tmpChange = currencyData.CZK.Change;
                break;
            case "PLN":
                tmpChange = currencyData.PLN.Change;
                break;
            case "RON":
                tmpChange = currencyData.RON.Change;
                break;
            case "CNY":
                tmpChange = currencyData.CNY.Change;
                break;
            case "ARS":
                tmpChange = currencyData.ARS.Change;
                break;
            case "ALL":
                tmpChange = currencyData.ALL.Change;
                break;
            case "AZN":
                tmpChange = currencyData.AZN.Change;
                break;
            case "BAM":
                tmpChange = currencyData.BAM.Change;
                break;
            case "CLP":
                tmpChange = currencyData.CLP.Change;
                break;
            case "COP":
                tmpChange = currencyData.COP.Change;
                break;
            case "CRC":
                tmpChange = currencyData.CRC.Change;
                break;
            case "DZD":
                tmpChange = currencyData.DZD.Change;
                break;
            case "EGP":
                tmpChange = currencyData.EGP.Change;
                break;
            case "HKD":
                tmpChange = currencyData.HKD.Change;
                break;
            case "ISK":
                tmpChange = currencyData.ISK.Change;
                break;
            case "HRK":
                tmpChange = currencyData.HRK.Change;
                break;
            case "JOD":
                tmpChange = currencyData.JOD.Change;
                break;
            case "KRW":
                tmpChange = currencyData.KRW.Change;
                break;
            case "KZT":
                tmpChange = currencyData.KZT.Change;
                break;
            case "LBP":
                tmpChange = currencyData.LBP.Change;
                break;
            case "LKR":
                tmpChange = currencyData.LKR.Change;
                break;
            case "MAD":
                tmpChange = currencyData.MAD.Change;
                break;
            case "MDL":
                tmpChange = currencyData.MDL.Change;
                break;
            case "MKD":
                tmpChange = currencyData.MKD.Change;
                break;
            case "MYR":
                tmpChange = currencyData.MYR.Change;
                break;
            case "OMR":
                tmpChange = currencyData.OMR.Change;
                break;
            case "PEN":
                tmpChange = currencyData.PEN.Change;
                break;
            case "PHP":
                tmpChange = currencyData.PHP.Change;
                break;
            case "PKR":
                tmpChange = currencyData.PKR.Change;
                break;
            case "QAR":
                tmpChange = currencyData.QAR.Change;
                break;
            case "RSD":
                tmpChange = currencyData.RSD.Change;
                break;
            case "SGD":
                tmpChange = currencyData.SGD.Change;
                break;
            case "SYP":
                tmpChange = currencyData.SYP.Change;
                break;
            case "THB":
                tmpChange = currencyData.THB.Change;
                break;
            case "TWD":
                tmpChange = currencyData.TWD.Change;
                break;
            case "UAH":
                tmpChange = currencyData.UAH.Change;
                break;
            case "UYU":
                tmpChange = currencyData.UYU.Change;
                break;
            case "GEL":
                tmpChange = currencyData.GEL.Change;
                break;
            case "TND":
                tmpChange = currencyData.TND.Change;
                break;
            case "BGN":
                tmpChange = currencyData.BGN.Change;
                break;
            case "ONS":
                tmpChange = currencyData.ONS.Change;
                break;
            case "GRA":
                tmpChange = currencyData.GRA.Change;
                break;
            case "CEY":
                tmpChange = currencyData.CEY.Change;
                break;
            case "YAR":
                tmpChange = currencyData.YAR.Change;
                break;
            case "TAM":
                tmpChange = currencyData.TAM.Change;
                break;
            case "CUM":
                tmpChange = currencyData.CUM.Change;
                break;
            case "ATA":
                tmpChange = currencyData.ATA.Change;
                break;
            case "ODA":
                tmpChange = currencyData.ODA.Change;
                break;
            case "OSA":
                tmpChange = currencyData.OSA.Change;
                break;
            case "YIA":
                tmpChange = currencyData.YIA.Change;
                break;
            case "IKI":
                tmpChange = currencyData.IKI.Change;
                break;
            case "BES":
                tmpChange = currencyData.BES.Change;
                break;
            case "GRE":
                tmpChange = currencyData.GRE.Change;
                break;
            case "RES":
                tmpChange = currencyData.RES.Change;
                break;
            case "HAM":
                tmpChange = currencyData.HAM.Change;
                break;
            case "GUM":
                tmpChange = currencyData.GUM.Change;
                break;
        }

        tmpChange = tmpChange.Replace(".", ",");
        return tmpChange;
    }



}

