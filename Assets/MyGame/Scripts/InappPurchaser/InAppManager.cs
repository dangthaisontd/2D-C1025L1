using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Rendering;

public class InAppManager : MonoBehaviour
{
    private static InAppManager instance;
    public static InAppManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<InAppManager>();
            }
            return instance;
        }
    }
    //
    StoreController m_StoreController;

    public string productId50 = "com.yourcompany.yourgame.productid50";
    public string productId100 = "com.yourcompany.yourgame.productid100";
    public string productId500 = "com.yourcompany.yourgame.productid500";
    public string productId1000 = "com.yourcompany.yourgame.productid1000";
    public string productId2000 = "com.yourcompany.yourgame.productid2000";
    public string productId5000 = "com.yourcompany.yourgame.productid5000";
    public string productRemoveAds = "com.yourcompany.yourgame.removeads";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeIAP();
    }
    async void InitializeIAP()
    {
        m_StoreController = UnityIAPServices.StoreController();
        m_StoreController.OnPurchasePending += OnPurchasePending;
        m_StoreController.OnPurchaseConfirmed += OnPurchaseConfirmed;
        m_StoreController.OnPurchaseFailed += OnPurchaseFailed;
        m_StoreController.OnCheckEntitlement += OnCheckEntitlement;
        m_StoreController.OnStoreConnected += OnStoreConnected;
        m_StoreController.OnStoreDisconnected += OnStoreDisconnected;
        m_StoreController.OnProductsFetchFailed += OnProductsFetchFailed;
        m_StoreController.OnProductsFetched += OnProductsFetched;
        Debug.Log("IAP Initialized");
        await m_StoreController.Connect();
    }
    void FetchProduct()
    {
        var initialProductsToFetch = new List<ProductDefinition>()
        {
            new ProductDefinition(productId50, ProductType.Consumable),
            new ProductDefinition(productId100, ProductType.Consumable),
            new ProductDefinition(productId500, ProductType.Consumable),
            new ProductDefinition(productId1000, ProductType.Consumable),
            new ProductDefinition(productId2000, ProductType.Consumable),
            new ProductDefinition(productId5000, ProductType.Consumable),
            new ProductDefinition(productRemoveAds, ProductType.NonConsumable)
        };
        m_StoreController.FetchProducts(initialProductsToFetch);
    }
    private void OnProductsFetched(List<Product> list)
    {
        Debug.Log("Products Fetched: " + list.Count);
    }

    private void OnProductsFetchFailed(ProductFetchFailed failed)
    {
        Debug.Log("Products Fetch Failed: " + failed);
    }

    private void OnStoreDisconnected(StoreConnectionFailureDescription description)
    {
        Debug.Log("Store Disconnected:" + description);
    }

    private void OnStoreConnected()
    {
        Debug.Log("Store Connected");
        FetchProduct();
    }

    private void OnCheckEntitlement(Entitlement entitlement)
    {
        if(entitlement.Product.definition.id == productRemoveAds)
        {
            Debug.Log("Entitlement Check: Remove Ads");
        }
    }

    private void OnPurchaseFailed(FailedOrder order)
    {
        var product = GetFirstProductInOrder(order);
        if (product == null)
        {
            Debug.Log("Purchase Failed: No product found in order");
            return;
        }
        Debug.Log("Purchase Failed: " + product.definition.id);

    }
    private void OnPurchaseConfirmed(Order order)
    {
        switch (order)
        {
            case ConfirmedOrder confirmedOrder:
                OnPurchaseConfirmed(confirmedOrder);
                break;
            case PendingOrder failedOrder:
                OnPurchaseConfirmedFailed(failedOrder);
                break;
            default:
                Debug.Log("Purchase Confirmed: Unknown order type");
                break;
        }
    }
    private void OnPurchaseConfirmedFailed(PendingOrder failedOrder)
    {
      var p = GetFirstProductInOrder(failedOrder);
        if(p == null)
        {
            Debug.Log("Purchase Confirmed Failed: No product found in order");
            return;
        }
    }
    private void OnPurchaseConfirmed(ConfirmedOrder order)
    {
        var product = GetFirstProductInOrder(order);
        if (product == null)
        {
        Debug.Log("Purchase Confirmed: No product found in order");
            return;
        }
        Debug.Log("Purchase Confirmed: " + product.definition.id);
    }
    // Update is called once per frame
    void Update()
    {

    }
    Product GetFirstProductInOrder(Order order)
    {
        return order.CartOrdered.Items().First()?.Product;
    }
    void OnPurchasePending(PendingOrder order)
    {
        var product = GetFirstProductInOrder(order);
        if (product == null)
        {
            Debug.Log("Purchase Pending: No product found in order");
            return;
        }
        if(product.definition.id == productId50)
        {
            AddProductId50();
        }
        else if (product.definition.id == productId100)
        {
            AddProductId100();
        }
        else if (product.definition.id == productId500)
        {
            AddProductId500();
        }
        else if (product.definition.id == productId1000)
        {
            AddProductId1000();
        }
        else if (product.definition.id == productId2000)
        {
            AddProductId2000();
        }
        else if (product.definition.id == productId5000)
        {
            AddProductId5000();
        }
        else if (product.definition.id == productRemoveAds)
        {
           
        }
    }
    public void BuyProducId50()
    {
        m_StoreController.PurchaseProduct(productId50);
    }
    public void BuyProducId100()
    {
        m_StoreController.PurchaseProduct(productId100);
    }
    public void BuyProducId500()
    {
        m_StoreController.PurchaseProduct(productId500);
    }
    public void BuyProducId1000()
    {
        m_StoreController.PurchaseProduct(productId1000);
    }
    public void BuyProducId2000()
    {
        m_StoreController.PurchaseProduct(productId2000);
    }
    public void BuyProducId5000()
    {
        m_StoreController.PurchaseProduct(productId5000);
    }
    private void  AddProductId50()
    {
      DataManager.DataCoin += 50;
    }
    private void AddProductId100()
    {
        DataManager.DataCoin += 100;
    }
    private void AddProductId500()
    {
        DataManager.DataCoin += 500;
    }
    private void AddProductId1000()
    {
        DataManager.DataCoin += 1000;
    }
    private void AddProductId2000()
    {
        DataManager.DataCoin += 2000;
    }
    private void AddProductId5000()
    {
        DataManager.DataCoin += 5000;
    }

}
