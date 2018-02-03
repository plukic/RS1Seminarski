var materials = [];
var GetMaterials = function () {
    if (materials == null)
        materials = [];
    return materials;
}
var AddMaterials = function (materialId, amount, name) {
    var material = FindMaterial(materialId);

    if (material == undefined) {
        console.log("Material nije pronadjen");
        materials.push({ "id": materialId, "amount": amount, "name": name });
        console.log(materials);
    } else {
        console.log("Pronadjen materijal s id " + materialId);
        material.amount = amount;
        material.name = name;

    }
}
var FindMaterial = function (materialId) {
    for (var i = 0; i < materials.length; i++) {
        if (materials[i].id == materialId)
            return materials[i];
    }
    return undefined;
}
var DeleteMaterial = function (materialId) {
    var index = -1;
    for (var i = 0; i < materials.length; i++) {
        if (materials[i].id == materialId) {
            index = i;
            break;
        }
    }
    if (index != -1) {
        materials.splice(index, 1);
    }
}

var InitMaterials = function (mat) {
    console.log("mat = " + mat);
    if (mat != null && mat != undefined && mat != '' && mat != "") {
        this.materials = JSON.parse(mat);
    }
    if (materials == null)
        materials = [];
}