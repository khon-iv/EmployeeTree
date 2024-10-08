# EmployeeTree
EmployeeTree - это WEB-приложение для работы со списком сотрудников компании.
При создании приложения использовался Microsoft Visual Studio.

## Сборка репозитория
Выполните в консоли 

    git clone https://github.com/khon-iv/EmployeeTree.git

Либо используйте Microsoft Visual Studio: в начальном окне выберите раздел Клонировать репозиторий, введите сылку https://github.com/khon-iv/EmployeeTree.git

## Наполнение БД
Выполните скрипт TestDataSqlScript.sql

## Запуск
Для запуска приложения используйте Microsoft Visual Studio и браузер Google Chrome

### Примечания
1. Реализованные методы:
- /hire – добавляет в БД нового сотрудника. В метод передаются следующие обязательные параметры: ФИО, должность, id руководителя. Руководитель – существующий сотрудник, запись о котором присутствует в базе данных. Может быть только один сотрудник, у которого нет руководителя.
- /delete – удаляет из БД запись о существующем, уволенном сотруднике. В метод передается id удалемого сотрудника.
- /employee – возвращает информацию о существующем сотруднике (ФИО, должность, руководитель, информация о том, является ли этот сотрудник действующим (или уволен)). В метод передается id сотрудника.
- /fire - увольняет сотрудника. Помечает запись в БД соответствующим признаком, но не удаляет из базы данных. В метод передается параметр id увольняемого сотрудника, а также id сотрудника, который станет новым руководителем, если прошлый сотрудник занимал руководящую должность. Новым руководителем может стать только кто-то из непосредственных подчиненных.

2. Методы можно протестировать, используя кнопки на странице или адрессную строку (пример для добавления сотрудника: https://localhost:7204/Home/Hire?fullName=Гарольд&position=Юрист&headId=1)

3. В дереве отображаются только ФИО, но при наведении курсора мыши на узел дерева, будет отбражен id сотруднка, который необходим для работы с вышеуказанными функциями.
