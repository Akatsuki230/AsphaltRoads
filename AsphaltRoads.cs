using System.Diagnostics;
using JetBrains.Annotations;
using MSCLoader;
using UnityEngine;

[UsedImplicitly]
public class AsphaltRoads : Mod {
    public override string Name => "Asphalt Roads";
    public override string ID => nameof(AsphaltRoads);
    public override string Version => "1.0";
    public override string Author => "mldkyt";

    private SettingsCheckBox _dirtRoads, _dirtHouseRoads, _dirtGrass;
    private Material _asphaltMaterial, _pavementMaterial, _pavement2Material;
    private Material _originalDirtRoads, _originalDirtHouseRoads, _originalDirtHouseGravel, _originalGrass1, _originalGrass2;
    private PhysicMaterial _originalDirtRoadsPhysicMaterial, _originalDirtHouseRoadsPhysicMaterial, _originalDirtHouseGravelPhysicMaterial, _originalGrass1PhysicMaterial, _originalGrass2PhysicMaterial;
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
                // store the original material and physic material
                _originalDirtRoads = road.GetComponent<MeshRenderer>().material;
                _originalDirtRoadsPhysicMaterial = road.GetComponent<MeshCollider>().material;
                // apply the asphalt material and physic material to the dirt road
                road.GetComponent<MeshRenderer>().material = _asphaltMaterial;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
            }
        }
        
        if (_dirtHouseRoads.GetValue()) {
            GameObject road = GameObject.Find("MAP/MESH/TERRAIN_OBJ/DirtRoad");
            if (road != null) {
                // store the original material and physic material
                _originalDirtHouseRoads = road.GetComponent<MeshRenderer>().material;
                _originalDirtHouseRoadsPhysicMaterial = road.GetComponent<MeshCollider>().material;
                // apply the asphalt material and physic material to the dirt road
                road.GetComponent<MeshRenderer>().material = _pavement2Material;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
            }
            
            // also apply to MAP/MESH/TERRAIN_OBJ/Gravel
            road = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Gravel");
            if (road != null) {
                // store the original material and physic material
                _originalDirtHouseGravel = road.GetComponent<MeshRenderer>().material;
                _originalDirtHouseGravelPhysicMaterial = road.GetComponent<MeshCollider>().material;
                // apply the asphalt material and physic material to the dirt road
                road.GetComponent<MeshRenderer>().material = _pavementMaterial;
                road.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
            }
        }
        
        if (_dirtGrass.GetValue()) {
            GameObject grass = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Grass1");
            if (grass != null) {
                // store the original material and physic material
                _originalGrass1 = grass.GetComponent<MeshRenderer>().material;
                _originalGrass1PhysicMaterial = grass.GetComponent<MeshCollider>().material;
                // apply the asphalt material and physic material to the dirt road
                grass.GetComponent<MeshRenderer>().material = _pavementMaterial;
                grass.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
            }
            
            // also apply to MAP/MESH/TERRAIN_OBJ/Grass2
            grass = GameObject.Find("MAP/MESH/TERRAIN_OBJ/Grass2");
            if (grass != null) {
                // store the original material and physic material
                _originalGrass2 = grass.GetComponent<MeshRenderer>().material;
                _originalGrass2PhysicMaterial = grass.GetComponent<MeshCollider>().material;
                // apply the asphalt material and physic material to the dirt road
                grass.GetComponent<MeshRenderer>().material = _pavementMaterial;
                grass.GetComponent<MeshCollider>().material = _asphaltPhysicMaterial;
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