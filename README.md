# DIKU2024S0

Ref: https://learn.unity.com/project/creator-kit-beginner-code?uv=2022.3
AssetStore Package: https://assetstore.unity.com/packages/templates/tutorials/creator-kit-beginner-code-urp-151986

#### Hvis man skal bruge dette repo er der en fil der skal unzippes da den er for stor til git: 'Buildings_Albedo.7z' den skal ligge i folderen ..\DIKU2024S0\Assets\UnityTechnologies\Creator Kit - Beginner Code\Art\Texture\Buildings

## Kort oversigt over matrialet (til underviser)
De kommende punkter giver en oversigt over hvad man skal gennemgå i matrialet med deltagerne.

### Set up
Lav nyt Unity projekt i **version 2022.3** (eller over).
Vælg **3d URP** template
Import **AssetStore Package**
Åben den nye importeret **ExampleScene**

Spil spillet og hvis de forskellige controls (Det er point and click Action RPG)

Herfra tager matrialet udgangspunk i det Gameobject der hedder **PotionSpawner** der ligger i LevelDesign -> PotionSpawner og scriptet der bruges er **SpawnerSample**

### Variables
Forklar Variabler ud fra den nævnte class ovenfor i **Set Up**
#### Opgave: Lav en variable der kan erstatte det hardcoded 2 som radius i **spawnPosition**, den nye variable skal ha værdien 5 og defor skal den være af typen int
**Spil og test**

### Functions
Forklar Functions, husk at gennemgå input params og hvorfor det er smart ikke at gentage kode
#### Opgave: Lav en Function der kan Spawn en potion og tage **angle** variable som input, kalde den evt. **SpawnPotion**
**Spil og test**

### Class
Forklar classes, men undlad til at starte med public keywork og nedarvning
#### Opgave: Lav en ny class i forlængelse af **SpawnerSample** (efter dens } ) og kald den *LootAngle*, den skal ha 2 int variable **angle** og **step**, den skal også ha en function til at udregne **NextAngle**. Der skal også være en constructor der kan tage et **increment** til brug i **step**. Brug nu den nye class til at udregne angles istedetfor de er hardcoded i **SpawnerSample**

**Din kode burde nu ger se sådan her ud og det virker ikke med vilje (bliver fikset i næste step)**
public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(45);

        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());

        void SpawnPotion(int angle)
        {
            int radius = 5;

            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
            Vector3 spawnPosition = transform.position + direction * radius;
            Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
public class LootAngle
{
    int angle;
    int step;

    LootAngle(int increment)
    {
        step = increment;
        angle = 0;
    }

    int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);

        return currentAngle;
    }
}


### Public keyword
Forklar hvorfor at **LootAngle** og **NextAngle** ikke kan kaldes da det mangler public keyword.
#### Opgave: Ret koden til med public keywords så det nu virker.

**Din kode burde nu ger se sådan her ud og virke igen**
public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(45);

        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());

        void SpawnPotion(int angle)
        {
            int radius = 5;

            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
            Vector3 spawnPosition = transform.position + direction * radius;
            Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
public class LootAngle
{
    int angle;
    int step;

    public LootAngle(int increment)
    {
        step = increment;
        angle = 0;
    }

    public int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);

        return currentAngle;
    }
}

**Spil og test**

### Lav en ny MoneySpawner
For at vise at vi kan genbruge det meste af det vi har lavet nu kan vi lave en ny **MoneySpawner**. Start med at lav et nyt 3dobject i spillet (sphere f.eks.) så vi har noget visuelt vi kan kalde *MoneySpawner*. Sæt derefter dens **Position** tæt på den anden spawner. Vælg **MoneySpawner** og tilføj det component vi har arbejdet med i **PotionSpawner** der hedder **SpawnerSample**. Istedetfor den her nu skal spawn Potions skal vi give den en ny prefab der hedder **MoneyLoot** (dette prefab ligger i .. -> Prefabs -> Tutorial) i det exposed public gameobject der hedder **Object To Spawn**.

**Spil og test**

### Nedarvning

Forklar kort nedarvning, her kan man bruge **MonoBehaviour** som eksempel men jeg plejer som regl at lave et eksempel med **Animal** der kan have porperties og functions som alle dyr har og derfra lave forskellige dyr som **Dog** og **Cat** extender **Animal** med deres egne properties og functions.