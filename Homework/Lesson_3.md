Теория:
1. Академическое описание паттерна Repository: http://design-pattern.ru/patterns/repository.html
2. Основные концепции в EF Core: https://metanit.com/sharp/entityframeworkcore/, https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli

Практика:
0. Создайте проект Fiction (или на любую другую выбраную вами тему) в вашем репозитории с ДЗ. Добавьте туда материал сущности EF Core, которые мы прошли на уроке. Этот проект мы будем в дальнейшей расширять новым функционалом.

1. В вашем проекте с прошлого ДЗ (в который вы копировали NewsBase) c помощью EF Core и подхода code first создайте БД с таблицей News.
2. Данные из NewsBase (или MockNewsRepository) занесите в созданную вами таблицу. Сделайте это с помощью OnModelCreating. 
3. В раннее созданном вами action Get в NewsController сделайте так чтоб входящий параметр можно было передавать через route (например News/Get/3) а только через query (например News/Get?index=3).