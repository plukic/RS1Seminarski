var KEY_TASKS = 'KEY_TASKS';
var tasks = [];
var id = 1;
var GetTasks = function () {
    return tasks;
}
var AddTask = function (taskId, title, description) {
    console.log("TRAZIM TASK " + taskId);
    var task = FindTask(taskId);

    if (task == undefined) {
        console.log("TASK NE POSTOJI ");
        tasks.push({ "id": id, "title": title, "description": description });
        id++;
    } else {
        console.log(task);
        task.title = title;
        task.description = description;

    }
}
var FindTask = function (taskId) {
    for (var i = 0; i < tasks.length; i++) {
        if (tasks[i].id == taskId)
            return tasks[i];
    }
    return undefined;
}
var DeleteTask = function (taskId) {
    var index = -1;
    for (var i = 0; i < tasks.length; i++) {
        if (tasks[i].id == taskId) {
            index = i;
            break;
        }
    }
    if (index != -1) {
        tasks.splice(index, 1);
    }
}
var InitTasks = function (ta) {
    if (ta != null && ta != ta)
        this.tasks = ta;
}