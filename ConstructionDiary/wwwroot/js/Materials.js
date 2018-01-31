var materials = [];
var GetMaterials = function () {
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
    if (mat != null && mat != mat)
        this.materials = mat;
}