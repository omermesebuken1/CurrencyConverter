using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CardUpdater : MonoBehaviour
{
    public string goName;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI value;
    [SerializeField] private Image changeImage;
    [SerializeField] private TextMeshProUGUI changeValue;
    [SerializeField] private Image star;
    [SerializeField] private TextMeshProUGUI descName;

    [SerializeField] private Color32 greenColor;
    [SerializeField] private Color32 redColor;
    [SerializeField] private Color32 starFav;
    [SerializeField] private Color32 starUnFav;

    [SerializeField] private Sprite greenArrow;
    [SerializeField] private Sprite redArrow;





    private API api;
    private NavBarController controller;

    private BottomHud bottomhud;
    private CurrencyManager currencyManager;
    private VibrationManager vibrationManager;

    private string sellingSTR;
    private string changeSTR;

    private float sellingFLO;
    private float changeFLO;

    public bool isFav;

    public bool cardStarted;

    private void Awake()
    {
        api = FindObjectOfType<API>();
        controller = FindObjectOfType<NavBarController>();
        bottomhud = FindObjectOfType<BottomHud>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        vibrationManager = FindObjectOfType<VibrationManager>();
    }

    private void Start()
    {
        cardStarted = false;
        StartCoroutine(SetAttributes());
    }


    private IEnumerator SetAttributes()
    {
        goName = this.gameObject.name;
        cardName.text = goName;

        PrepareFavAttributes();

        while (!api.dataFetched)
        {
            yield return null;
        }

        sellingFLO = float.Parse(api.GetYourSelling(goName), new CultureInfo("tr-TR"));
        sellingSTR = sellingFLO.ToString("F2", new CultureInfo("tr-TR"));

        if(sellingSTR == "0,00")
        {
            sellingSTR = "<0,00";
        }

        changeFLO = float.Parse(api.GetYourChange(goName), new CultureInfo("tr-TR"));
        changeSTR = changeFLO.ToString("F2", new CultureInfo("tr-TR"));

        value.text = sellingSTR;
        changeValue.text = changeSTR;

        if (changeFLO >= 0)
        {
            changeImage.sprite = greenArrow;
            changeValue.color = greenColor;
        }
        else
        {
            changeImage.sprite = redArrow;
            changeValue.color = redColor;
        }

        // Update the descName TextMeshPro with the currency name
        string currencyName = GetCurrencyName(goName);
        descName.text = currencyName;

        
        cardStarted = true;
    }

    private string GetCurrencyName(string currencyCode)
    {
        // Dictionary to map currency codes to names
        Dictionary<string, string> currencyNameMap = new Dictionary<string, string>
    {
        {"USD", "Amerikan Doları"},
        {"EUR", "Avro"},
        {"GBP", "Ingiliz Sterlini"},
        {"CHF", "Isviçre Frangı"},
        {"CAD", "Kanada Doları"},
        {"RUB", "Rus Rublesi"},
        {"AED", "BAE Dirhemi"},
        {"AUD", "Avustralya Doları"},
        {"DKK", "Danimarka Kronu"},
        {"SEK", "Isveç Kronu"},
        {"NOK", "Norveç Kronu"},
        {"JPY", "Japon Yeni"},
        {"KWD", "Kuveyt Dinarı"},
        {"ZAR", "Güney Afrika Randı"},
        {"BHD", "Bahreyn Dinarı"},
        {"LYD", "Libya Dinarı"},
        {"SAR", "Suudi Riyali"},
        {"IQD", "Irak Dinarı"},
        {"ILS", "Israil Yeni Sekeli"},
        {"IRR", "Iran Riyali"},
        {"INR", "Hindistan Rupisi"},
        {"MXN", "Meksika Pezosu"},
        {"HUF", "Macar Forinti"},
        {"NZD", "Yeni Zelanda Doları"},
        {"BRL", "Brezilya Reali"},
        {"IDR", "Endonezya Rupisi"},
        {"CZK", "Çek Korunası"},
        {"PLN", "Polonya Zlotisi"},
        {"RON", "Rumen Leyi"},
        {"CNY", "Çin Yuanı"},
        {"ARS", "Arjantin Pezosu"},
        {"ALL", "Arnavut Leki"},
        {"AZN", "Azerbaycan Manatı"},
        {"BAM", "Bosna Hersek Markı"},
        {"CLP", "Sili Pezosu"},
        {"COP", "Kolombiya Pezosu"},
        {"CRC", "Kosta Rika Kolonu"},
        {"DZD", "Cezayir Dinarı"},
        {"EGP", "Mısır Lirası"},
        {"HKD", "Hong Kong Doları"},
        {"ISK", "Izlanda Kronası"},
        {"HRK", "Hırvatistan Kunası"},
        {"JOD", "Ürdün Dinarı"},
        {"KRW", "Güney Kore Wonu"},
        {"KZT", "Kazakistan Tengesi"},
        {"LBP", "Lübnan Lirası"},
        {"LKR", "Sri Lanka Rupisi"},
        {"MAD", "Fas Dirhemi"},
        {"MDL", "Moldova Leyi"},
        {"MKD", "Makedonya Dinarı"},
        {"MYR", "Malezya Ringgiti"},
        {"OMR", "Umman Riyali"},
        {"PEN", "Peru Nuevo Solu"},
        {"PHP", "Filipinler Pezosu"},
        {"PKR", "Pakistan Rupisi"},
        {"QAR", "Katar Riyali"},
        {"RSD", "Sırp Dinarı"},
        {"SGD", "Singapur Doları"},
        {"SYP", "Suriye Lirası"},
        {"THB", "Tayland Bahtı"},
        {"TWD", "Yeni Tayvan Doları"},
        {"UAH", "Ukrayna Grivnası"},
        {"UYU", "Uruguay Pezosu"},
        {"GEL", "Gürcistan Larisi"},
        {"TND", "Tunus Dinarı"},
        {"BGN", "Bulgar Levası"},
        {"ONS", "Ons Altın"},
        {"GRA", "Gram Altın"},
        {"CEY", "Çeyrek Altın"},
        {"YAR", "Yarım Altın"},
        {"TAM", "Tam Altın"},
        {"CUM", "Cumhuriyet Altını"},
        {"ATA", "Ata Altın"},
        {"ODA", "14 Ayar Altın"},
        {"OSA", "18 Ayar Altın"},
        {"YIA", "22 Ayar Bilezik"},
        {"IKI", "Ikibuçuk Altın"},
        {"BES", "Besli Altın"},
        {"GRE", "Gremse Altın"},
        {"RES", "Resat Altın"},
        {"HAM", "Hamit Altın"},
        {"GUM", "Gümüs"}
    };

        if (currencyNameMap.ContainsKey(currencyCode))
        {
            return currencyNameMap[currencyCode];
        }
        else
        {
            return currencyCode;
        }
    }

    public void ChangeToMathState()
    {
        vibrationManager.Vibrate("soft");
        controller.canvasAnimator.SetInteger("State", 1);
        bottomhud.currencyName = goName;
        bottomhud.exchangeRate = sellingFLO.ToString("F2", new CultureInfo("tr-TR"));
        bottomhud.ChangeNames();

    }

    public void PrepareFavAttributes()
    {
        if(PlayerPrefs.HasKey(goName+"fav"))
        {
            if(PlayerPrefs.GetInt(goName+"fav") == 1)
            {
                isFav = true;
            }
            else
            {
                isFav = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt(goName+"fav",0);
            isFav = false;
        }


        ChangeStarAttribute();
    }
    
    public void RemoveFromFav()
    {
        PlayerPrefs.SetInt(goName+"fav",0);
        var tmpItem1 = currencyManager.currencies.Find(currency => currency.GetComponent<CardUpdater>().goName == goName);
        tmpItem1.GetComponent<CardUpdater>().isFav = false;
        tmpItem1.GetComponent<CardUpdater>().PrepareFavAttributes();
    }

    public void AddToFavs()
    {
        PlayerPrefs.SetInt(goName+"fav",1);
        PrepareFavAttributes();
    }

    public void StarButton()
    {
        if(isFav)
        {
            RemoveFromFav();
            ChangeStarAttribute();
            currencyManager.PrepareFavourites();
        }
        else
        {
            AddToFavs();
            ChangeStarAttribute();
            currencyManager.PrepareFavourites();
        }
    }

    private void ChangeStarAttribute()
    {
        if(isFav)
        {
            star.color = starFav;
        }
        else
        {
            star.color = starUnFav;
        }
    }



}
