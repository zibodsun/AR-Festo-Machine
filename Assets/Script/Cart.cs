using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Cart : MonoBehaviour
{
    public List<string> cartData = new List<string>();

    public CartJSON[] cartObjectArray;

    public string listInfo;

    //public ItemDisplayer currentOrdersInfo;

    [NaughtyAttributes.ReadOnly] public float timer = 5f;
    [NaughtyAttributes.ReadOnly] public float time;

    private void Awake()
    {
        //currentOrdersInfo = GetComponent<ItemDisplayer>();
        GetCart();
    }

    private void Update()
    {
        if (time <= timer)
        {
            time += Time.deltaTime;
        }
        else { 
            GetCart();
            time = 0;
        }
    }

    // Method to receive data from the server and update UI
    public void ReceieveData(string cartStringPHPMany)
    {
        // Ensure JSON is formatted correctly
        string newCartStringPHPMany = fixJson(cartStringPHPMany);

        Debug.LogWarning(newCartStringPHPMany);

        // Parse JSON data into an array of objects
        cartObjectArray = JsonHelper.FromJson<CartJSON>(newCartStringPHPMany);

        cartData.Clear();
        listInfo = "";

        // Iterate through the array, log each order, and add to the list
        for (int i = 0; i < cartObjectArray.Length; i++)
        {
            cartData.Add("CarrierID: " + cartObjectArray[i].CarrierID + ", ONo: " + cartObjectArray[i].ONo);
        }

        // Concatenate the list items into a string with new lines
        foreach (var listMember in cartData)
        {
            listInfo += listMember.ToString() + "\n" + "\n";
        }
    }

    // Ensure JSON format compatibility
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    // Coroutine to make a GET request to the server
    public void GetCart()
    {
        StartCoroutine(GetRequest("http://172.21.0.90/SQLDataStudents.php?Command=cart"));     //calls coroutine and sets string
    }

    // Coroutine to handle the GET request and update UI based on response
    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            // Handle different results of the web request
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    // Process received data
                    ReceieveData(webRequest.downloadHandler.text);
                    Debug.LogError("Current Orders Success");
                    break;
            }
        }
    }
}
