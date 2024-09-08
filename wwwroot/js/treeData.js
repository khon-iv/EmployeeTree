async function getData() {
    var response = await fetch("https://localhost:7204/Home/GetEmployees");
    try {
        var obj = await response.json();
        var data = await JSON.stringify(obj);
        TreeData(JSON.parse(data), "#tree");
    } catch {
        var main = document.querySelector("#tree");
        var treecanvas = document.createElement('div');
        treecanvas.innerHTML = "Пустая БД";
        treecanvas.className = 'tree';
        main.appendChild(treecanvas);
    }
}

function TreeData(data, select) {
    var main = document.querySelector(select);
    var treecanvas = document.createElement('div');
    treecanvas.className = 'tree';
    var head;
    for (var i in data) {
        if (data[i].parent == '') head = i
    }
    var treeCode = buildTree(data, head);

    treecanvas.innerHTML = "<ul>" + treeCode + "</ul>";
    main.appendChild(treecanvas);
}

function buildTree(obj, node) {
    var treeString = "<li><a href='#' title='id: " + obj[node].id + "'><span>" + obj[node].value + "</span></a>";
    var sons = [];
    for (var i in obj) {
        if (obj[i].parent == node)
            sons.push(i);
    }
    if (sons.length > 0) {
        treeString += "<ul>";
        for (var i in sons) {
            treeString += buildTree(obj, sons[i]);
        }
        treeString += "</ul>";
    }
    return treeString;
}

document.getElementById("hireButton").onclick = addNode;
function addNode() {
    let form = document.querySelector("#hireForm");
    console.log("hire employee");
    let params = serialize(form);
    fetch("https://localhost:7204/Home/Hire?" + params);
    location.reload();
}

document.getElementById("fireButton").onclick = fireEmployee;
function fireEmployee() {
    let form = document.querySelector("#fireForm");
    console.log("fire employee");
    let params = serialize(form);
    fetch("https://localhost:7204/Home/Fire?" + params);
    location.reload();
}

document.getElementById("deleteButton").onclick = deleteEmployee;
function deleteEmployee() {
    let form = document.querySelector("#deleteForm");
    console.log("delete employee");
    let params = serialize(form);
    fetch("https://localhost:7204/Home/Delete?" + params);
    location.reload();
}

document.getElementById("employeeInfoButton").onclick = getEmployeeInfo;
async function getEmployeeInfo() {
    let form = document.querySelector("#employeeInfoForm");
    var response = await fetch("https://localhost:7204/Home/Employee/" + form.elements[0].value);
    try {
        var obj = await response.json(); //если в response получено пусое значение, выполняется блок catch
        var data = await JSON.stringify(obj); 
        let jsonInfoAboutEmployee = JSON.parse(data);
        var strResult = '';

        if (jsonInfoAboutEmployee.marked === true) {
            strResult += "Уволен\n";
        } else {
            strResult += "Действующий сотрудник\n";
        }

        strResult += "ФИО: " + jsonInfoAboutEmployee.fullName + "\n" + "Должность: " + jsonInfoAboutEmployee.position + "\n";
        response = await fetch("https://localhost:7204/Home/Employee/" + jsonInfoAboutEmployee.headId); // чтобы узнать имя руководителя, поиск по headId
        try {
            obj = await response.json();
            data = await JSON.stringify(obj);
            let jsonInfoAboutHead = JSON.parse(data);

            strResult += "Руководитель: " + jsonInfoAboutHead.fullName;
            console.log(strResult);
            form.elements[1].value = strResult;
        } catch (error) {
            strResult += "У сотрудника нет руководителя";
            console.log(strResult);
            form.elements[1].value = strResult;
        }
    } catch (error) {
        console.error('Promise rejected');
        form.elements[1].value = "Сотрудник не найден";
    }
    
}

function serialize(form) {
    if (!form || form.nodeName !== "FORM") {
        return;
    }
    var q = [];
    for (i = 0; i < form.elements.length; i++) {
        if (form.elements[i].nodeName === "INPUT" && form.elements[i].type === "text") {
            q.push(form.elements[i].name + "=" + encodeURIComponent(form.elements[i].value));
        }
    }
    return q.join('&');
}