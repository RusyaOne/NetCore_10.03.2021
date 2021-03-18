Теория:
1. Информация о View: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-3.1
2. Общая инфо про Controller: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/actions?view=aspnetcore-3.1
3. Про внедрение зависимостей (DI) и зависимости в частности: https://habr.com/en/post/349836/, если будет интересно или необходимо можете прочитать весь цикл этих статьей, на который есть ссылка в статье.
4. Оригинальная статья про IoC и DI от Марка Фовлера: https://martinfowler.com/articles/injection.html#InversionOfControl

Практика:
1. В вашем репозитории с ДЗ содайте новый проект по шаблону MVC и скопируйте туда модель News и статический класс NewsBase из моего проекта. Создайте NewsController. В контроллер NewsController добавьте action Index, при его вызове должны вывестись все News из NewsBase в виде HTML таблицы.
2. Вынесите таблицу из прошлого задания в отдельную секцию. С помощью @RenderSection добавьте эту секцию в _Layout. 
3. В navigation bar, который определен у вас в _Layout (с использованием тега nav), добавьте элемент News, при нажатии на него вы должны будете обращаться к action Index контроллера News и соответственно будет отображена таблица с новостями из прошлого задания.
4. Создайте новый _Layout view. Сделайте так, чтоб он выполнялся только для папки Home.