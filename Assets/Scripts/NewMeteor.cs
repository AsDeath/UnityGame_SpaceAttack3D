using UnityEngine;

public class NewMeteor : MonoBehaviour
{
    public GameObject meteor1;
    public GameObject meteor2;
    public GameObject meteor3;

    public GameObject galaxyL;
    public GameObject galaxyM;
    public GameObject galaxyS;
    public GameObject nebulaL;
    public GameObject nebulaM;
    public GameObject nebulaS;
    public GameObject supernovaA;
    public GameObject supernovaB;
    public GameObject supernovaC;
    public GameObject supernovaD;
    public GameObject supernovaE;
    public GameObject supernovaF;
    public GameObject gasPlanetA;
    public GameObject gasPlanetB;
    public GameObject gasPlanetC;
    public GameObject gasPlanetD;
    public GameObject gasPlanetE;
    public GameObject gasPlanetF;
    public GameObject gasPlanetG;
    public GameObject gasPlanetH;
    public GameObject gasPlanetI;
    public GameObject gasPlanetJ;
    public GameObject gasPlanetK;
    public GameObject gasPlanetL;
    public GameObject planetA;
    public GameObject planetB;
    public GameObject planetC;
    public GameObject planetD;
    public GameObject planetE;
    public GameObject planetF;
    public GameObject planetG;
    public GameObject planetH;
    public GameObject planetI;
    public GameObject planetJ;
    public GameObject planetK;
    public GameObject planetL;
    public GameObject sun;

    const int sizeArr = 300;
    private float[] positionArrMeteor = new float [sizeArr];
    private float[] positionArrPlanet = new float[sizeArr];
    float randX, randY, randZ;

    //private Transform t_player;
    void Start()
    {
        for(int i = 0; i<sizeArr; i++)
        {
            positionArrMeteor[i] = 0;
            positionArrPlanet[i] = 0;
        }
        for (int i = 0; i < sizeArr; i += 3)
        {
            int k = Random.Range(0, 3);
            randX = GetRandomSign() * Random.Range(20, 990);
            randY = GetRandomSign() * Random.Range(20, 990);
            randZ = GetRandomSign() * Random.Range(20, 990);
            for (int j = 0; j < i; j+=3)
            {
                if (randX == positionArrMeteor[j] && randY == positionArrMeteor[j+1] && randY == positionArrMeteor[j + 2])
                {
                    randX = GetRandomSign() * Random.Range(20, 990);
                    randY = GetRandomSign() * Random.Range(20, 990);
                    randZ = GetRandomSign() * Random.Range(20, 990);
                    j = 0;
                }
            }
                
            positionArrMeteor[i] = randX;
            positionArrMeteor[i + 1] = randY;
            positionArrMeteor[i + 2] = randZ;
            if (k == 0) Instantiate(meteor1, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 1) Instantiate(meteor2, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 2 || k == 3) Instantiate(meteor3, new Vector3(randX, randY, randZ), Random.rotation);
        }

        for(int i = 0; i<sizeArr; i += 3)
        {
            int k = Random.Range(0, 37);
            randX = GetRandomSign() * Random.Range(20, 990);
            randY = GetRandomSign() * Random.Range(20, 990);
            randZ = GetRandomSign() * Random.Range(20, 990);
            for (int j = 0; j < i; j += 3)
            {
                if ((randX == positionArrMeteor[j] && randY == positionArrMeteor[j + 1] && randY == positionArrMeteor[j + 2]) || (randX == positionArrPlanet[j] && randY == positionArrPlanet[j + 1] && randY == positionArrPlanet[j + 2]))
                {
                    randX = GetRandomSign() * Random.Range(20, 990);
                    randY = GetRandomSign() * Random.Range(20, 990);
                    randZ = GetRandomSign() * Random.Range(20, 990);
                    j = 0;
                }
            }
            positionArrPlanet[i] = randX;
            positionArrPlanet[i + 1] = randY;
            positionArrPlanet[i + 2] = randZ;
            if (k == 0) Instantiate(galaxyL, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 1) Instantiate(galaxyM, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 2) Instantiate(galaxyS, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 3) Instantiate(nebulaL, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 4) Instantiate(nebulaM, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 5) Instantiate(nebulaS, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 6) Instantiate(supernovaA, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 7) Instantiate(supernovaB, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 8) Instantiate(supernovaC, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 9) Instantiate(supernovaD, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 10) Instantiate(supernovaE, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 11) Instantiate(supernovaF, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 12) Instantiate(gasPlanetA, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 13) Instantiate(gasPlanetB, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 14) Instantiate(gasPlanetC, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 15) Instantiate(gasPlanetD, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 16) Instantiate(gasPlanetE, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 17) Instantiate(gasPlanetF, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 18) Instantiate(gasPlanetG, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 19) Instantiate(gasPlanetH, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 20) Instantiate(gasPlanetI, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 21) Instantiate(gasPlanetJ, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 22) Instantiate(gasPlanetK, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 23) Instantiate(gasPlanetL, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 24) Instantiate(planetA, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 25) Instantiate(planetB, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 26) Instantiate(planetC, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 27) Instantiate(planetD, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 28) Instantiate(planetE, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 29) Instantiate(planetF, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 30) Instantiate(planetG, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 31) Instantiate(planetH, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 32) Instantiate(planetI, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 33) Instantiate(planetJ, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 34) Instantiate(planetK, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 35) Instantiate(planetL, new Vector3(randX, randY, randZ), Random.rotation);
            if (k == 36 || k == 37) Instantiate(sun, new Vector3(randX, randY, randZ), Random.rotation);
        }
    }

    int GetRandomSign()
    {
        int sign = Random.Range(0, 2);
        if (sign == 0) return -1;
        else return 1;
    }
}
