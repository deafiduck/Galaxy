using UnityEngine;
using NUnit.Framework;
using System.IO;
using System;

public class TeethCheckTest
{
    private GameObject testObject;
    private AngleCalculator angleCalculator;
    private TestData[] testData;
    public MatchToothPhoto _matchToothPhoto;

    [SetUp]
    public void Setup()
    {
        _matchToothPhoto = GameObject.Find("ToothManager").GetComponent<MatchToothPhoto>();
        // Test için sahneye bir GameObject ekle ve AngleCalculator component'ini ekle
        testObject = new GameObject();
        angleCalculator = testObject.AddComponent<AngleCalculator>();

        // Metin dosyasýndan test verilerini oku
        string filePath = @"C:\Users\yibif\Documents\GitHub\GaziDisHekimligi\Assets\Tests\testdata.txt";
        
        Debug.Log($"Checking for file at: {filePath}");
        if (!File.Exists(filePath))
        {
            Debug.LogError($"Test data file not found at: {filePath}");
        }
        else
        {
            Debug.Log($"Test data file found at: {filePath}");
        }

        testData = LoadTestDataFromFile(filePath);
        
    }
    [Test]
   public void CheckTooth()
    {
        int expectedId = Convert.ToInt32(testData[0].TeethID);
        foreach (ToothClass data in _matchToothPhoto.Teeth ) {
            Debug.Log("girdi");
           
            Assert.AreEqual(expectedId,data.m_toothIndex);
        
        }
        
    }
    

    

    private TestData[] LoadTestDataFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        TestData[] data = new TestData[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            string teethID = parts[0].Split(':')[1].Trim();
            float angleValue = float.Parse(parts[1].Split(':')[1].Trim());

            data[i] = new TestData { TeethID = teethID, AngleValue = angleValue };
        }
        return data;
    }
}

[System.Serializable]
public class TestData
{
    public string TeethID;
    public float AngleValue;
}
