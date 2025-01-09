using UnityEngine;

public class EdgePolerTerrain : MonoBehaviour
{
    
    [Header("Road")]
    public int CurrentLevel = 1;
    private int length = 4;
    public GameObject RoadObject;

    public Vector3 StartPoint;

    public GameObject Connecter;
    public GameObject WinPoint;

    public GameObject Points;
    public void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for (int i = 0; i < length + CurrentLevel; i++)
        {
            RoadMaker(i);
        }
    }
    public void RoadMaker(int LastPoint)
    {
        int trans = Random.Range(0, 3); // 0 y = 40 , 1 & 2 y = 45 , 

        Vector3 MidPoint = StartPoint;
        MidPoint.x =  StartPoint.x;
        StartPoint.y = (trans == 0 || trans == 2) ? StartPoint.y : StartPoint.y - 4;
        Instantiate(RoadObject,StartPoint,RoadObject.transform.rotation);

        int Devider = Random.Range(0, 2);

        Vector3 PointSpawn = StartPoint;
        PointSpawn.y += RoadObject.transform.localScale.z;
        PointSpawn.x = (Devider == 1)? PointSpawn.x - (RoadObject.transform.localScale.x / 2) : PointSpawn.x + (RoadObject.transform.localScale.x / 2);
        PointSpawn.z = Random.Range(StartPoint.z - RoadObject.transform.localScale.y / 2, StartPoint.z + RoadObject.transform.localScale.y / 2);
        for (int i = 0; i < 9; i++)
        {
            Instantiate(Points, PointSpawn, Points.transform.rotation);
            PointSpawn.x += Points.transform.localScale.y + 0.4f;
        }

        if (LastPoint == length)
        {
            Vector3 WinPos = StartPoint;
            WinPos.y += RoadObject.transform.localScale.z;
            WinPos.z -= RoadObject.transform.localScale.y;
            WinPos.x += RoadObject.transform.localScale.x / 2;

            Instantiate(WinPoint, WinPos, WinPoint.transform.rotation);
            return;
        }
        StartPoint.x += (trans == 0) ? 40 : 45;

        MidPoint.x = (StartPoint.x + MidPoint.x) / 2;

        MidPoint.y = (StartPoint.y + RoadObject.transform.localScale.z ) - 0.2f;
        
        switch(trans)
        {
            case 2:
            Instantiate(Connecter, MidPoint ,Connecter.transform.rotation);
                break;

                case 1:
                float rnd = Random.Range(0, 2);
                Instantiate(Connecter,new Vector3(MidPoint.x,MidPoint.y,MidPoint.z + rnd),Connecter.transform.rotation);
                Instantiate(Connecter, new Vector3(MidPoint.x, MidPoint.y, MidPoint.z - rnd), Connecter.transform.rotation);
                break;
        }



    }
}
