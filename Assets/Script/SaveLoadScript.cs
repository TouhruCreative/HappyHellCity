using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour
{
    public GameObject[] PlaceList;
    public GameObject Home;
    public GameObject Fabric;
    public GameObject Shop;

    public void Start(){
        LoadAllData();
    }
    public void SaveAllData(){
        //Save Player
        PlayerPrefs.SetInt("NewGame",1);
        GameObject Player = GameObject.FindWithTag("Player");
        PlayerPrefs.SetFloat("Cash", Player.GetComponent<PlayerScript>().nowCash);
        PlayerPrefs.SetFloat("Material", Player.GetComponent<PlayerScript>().nowMaterial);
        //Save Buildings
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savefile.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData[] GDList = new GameData[PlaceList.Length];
        for (int i = 0; i < PlaceList.Length; ++i){
            GDList[i] = new GameData(PlaceList[i]);
        }
        GameDataList data = new GameDataList(GDList);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void LoadAllData(){
        if(PlayerPrefs.GetInt("NewGame") == 1){
        //Load Player
        GameObject Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PlayerScript>().nowCash = PlayerPrefs.GetFloat("Cash");
        Player.GetComponent<PlayerScript>().nowMaterial = PlayerPrefs.GetFloat("Material");
        //Load Buildings
        string path = Application.persistentDataPath + "/savefile.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameDataList data = formatter.Deserialize(stream) as GameDataList;
            GameObject TempObject;
            stream.Close();
            foreach(GameData item in data.GDList){
                foreach(GameObject i in PlaceList){
                    if(item.script == 3){
                        continue;
                    }
                    if(i.name.Split(' ')[1] == item.coord[0] && i.name.Split(' ')[2] == item.coord[1]  ){//if coord equal
                        switch (item.script)
                        {
                            case 0:
                                TempObject=Instantiate(Shop, new Vector3(item.position[0], item.position[1], item.position[2]), Quaternion.identity);
                                TempObject.transform.GetComponent<IBuilding>().ModifOne = item.ModifOne;
                                TempObject.transform.GetComponent<IBuilding>().ModifTwo = item.ModifTwo;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifOne = item.priceUpgradeModifOne;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifTwo = item.priceUpgradeModifTwo;
                                TempObject.transform.SetParent(i.transform);
                                break;
                            case 1:
                                TempObject=Instantiate(Home, new Vector3(item.position[0], item.position[1], item.position[2]), Quaternion.identity);
                                TempObject.transform.GetComponent<IBuilding>().ModifOne = item.ModifOne;
                                TempObject.transform.GetComponent<IBuilding>().ModifTwo = item.ModifTwo;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifOne = item.priceUpgradeModifOne;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifTwo = item.priceUpgradeModifTwo;
                                TempObject.transform.SetParent(i.transform);
                                break;
                            case 2:
                                TempObject=Instantiate(Fabric, new Vector3(item.position[0], item.position[1], item.position[2]), Quaternion.identity);
                                TempObject.transform.GetComponent<IBuilding>().ModifOne = item.ModifOne;
                                TempObject.transform.GetComponent<IBuilding>().ModifTwo = item.ModifTwo;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifOne = item.priceUpgradeModifOne;
                                TempObject.transform.GetComponent<IBuilding>().priceUpgradeModifTwo = item.priceUpgradeModifTwo;
                                TempObject.transform.SetParent(i.transform);
                                break;
                        }
                    }
                    
                }
            }
        }
    }
    }
    public void SaveAndQuit(){
        SaveAllData();
        Application.Quit();
    }
    public void SaveAndQuitToTitle(){
        SaveAllData();
        //StartCoroutine(desUnloadAsync());
        //StartCoroutine(LoadAsync());
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadAsync(){
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(0);
        loadAsync.allowSceneActivation = false;
        while(!loadAsync.isDone){
            //scale.value = loadAsync.progress;
            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation){
                yield return new WaitForSeconds(1f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
[System.Serializable]
public class GameDataList
{
    public GameData[] GDList;
    public GameDataList(GameData[] GDL1st) {
		GDList = GDL1st;
	}
}

[System.Serializable]
public class GameData
{
    public float[] position;
    public float ModifOne;
    public float ModifTwo;
    public float priceUpgradeModifOne;
    public float priceUpgradeModifTwo;
    public string[] coord;
    public float script;

    public GameData(GameObject gO)
    {
        if(gO.transform.childCount==2){
        if( gO.transform.GetChild(1).GetComponent<BuildingEconomic>() || gO.transform.GetChild(1).GetComponent<BuildingHouse>() || gO.transform.GetChild(1).GetComponent<BuildingFabric>()){
            ModifOne=gO.transform.GetChild(1).GetComponent<IBuilding>().ModifOne;
            ModifTwo=gO.transform.GetChild(1).GetComponent<IBuilding>().ModifTwo;
            priceUpgradeModifOne=gO.transform.GetChild(1).GetComponent<IBuilding>().priceUpgradeModifOne;
            priceUpgradeModifTwo=gO.transform.GetChild(1).GetComponent<IBuilding>().priceUpgradeModifTwo;
            coord=gO.transform.GetChild(1).GetComponent<IBuilding>().xy;
        }
        }
        position = new float[3];
        position[0] = gO.transform.position.x;
        position[1] = gO.transform.position.y;
        position[2] = gO.transform.position.z;
        if(gO.transform.childCount==2){
        if( gO.transform.GetChild(1).GetComponent<BuildingEconomic>() ){
            script=0;
        } else if ( gO.transform.GetChild(1).GetComponent<BuildingHouse>() ){
            script=1;
        } else if ( gO.transform.GetChild(1).GetComponent<BuildingFabric>() ){
            script=2;
        } } else {
            script=3;
        }
        
    }
}