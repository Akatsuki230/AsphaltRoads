using System.Diagnostics;
using JetBrains.Annotations;
using MSCLoader;
using UnityEngine;

[UsedImplicitly]
public class AsphaltRoads : Mod {
    public override string Name => "Asphalt Roads";
    public override string ID => nameof(AsphaltRoads);
    public override string Version => "1.0";
    public override string Author => "アカツキ";

    private SettingsCheckBox _dirtRoads, _dirtHouseRoads, _dirtGrass;
    private Material _asphaltMaterial, _pavementMaterial, _pavement2Material;
    private PhysicMaterial _asphaltPhysicMaterial;

    public override void ModSetup() {
        base.ModSetup();
        SetupFunction(Setup.OnLoad, Load);
    }
    
    void Load() {
        AssetBundle bundle = AssetBundle.CreateFromMemoryImmediate(Resource1.asphaltassets);
        _asphaltMaterial = bundle.LoadAsset<Material>("asphalt");
        _pavementMaterial = bundle.LoadAsset<Material>("pavement");
        _pavement2Material = bundle.LoadAsset<Material>("pavement2");
        _asphaltPhysicMaterial = bundle.LoadAsset<PhysicMaterial>("Road");
        bundle.Unload(false);
        
        if (_dirtRoads.GetValue()) {
            GameObject road = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Road");
            if (road != null) {
                road.GetComponent<MeshRenderer>().material = _asphaltMaterial;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
                // set the tag to "Concrete"
                road.tag = "Concrete";
            }
        }
        
        if (_dirtHouseRoads.GetValue()) {
            GameObject road = GameObject.Find("MAP/MESH/TERRAIN_OBJ/DirtRoad");
            if (road != null) {
                road.GetComponent<MeshRenderer>().material = _pavement2Material;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
                // set the tag to "Concrete"
                road.tag = "Concrete";
            }

            road = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Gravel");
            if (road != null) {
                road.GetComponent<MeshRenderer>().material = _pavementMaterial;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
                // set the tag to "Concrete"
                road.tag = "Concrete";
            }
        }
        
        if (_dirtGrass.GetValue()) {
            GameObject grass = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Grass1");
            if (grass != null) {
                grass.GetComponent<MeshRenderer>().material = _pavementMaterial;
                grass.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
                // set the tag to "Concrete"
                grass.tag = "Concrete";
            }

            grass = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Grass2");
            if (grass != null) {
                grass.GetComponent<MeshRenderer>().material = _pavementMaterial;
                grass.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
                // set the tag to "Concrete"
                grass.tag = "Concrete";
            }
        }
    }

    public override void ModSettings() {
        base.ModSettings();
        _dirtRoads = Settings.AddCheckBox(this, "dirtroads", "Make Dirt Roads asphalt.", true);
        _dirtHouseRoads = Settings.AddCheckBox(this, "dirthouseroads", "Make Dirt Roads that go to the Houses asphalt.");
        _dirtGrass = Settings.AddCheckBox(this, "dirtgrass", "[Not Recommended] Make Grass Asphalt.");
    }
}
