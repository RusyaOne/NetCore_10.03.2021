Теория:
1. Просмотрите презентации и удостоверьтесь что понимаете изложеный там материал. Не стесняйтесь писать вопросы по непонятным моментам.
2. Если необходимо, почиайте доп. информацию по классам Startup: https://metanit.com/sharp/aspnet5/2.1.php, https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/?view=aspnetcore-3.1&tabs=windows#the-startup-class
и Program: https://metanit.com/sharp/aspnet5/2.13.php, https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/?view=aspnetcore-3.1&tabs=windows#host
На метанит часто неплохо описано, однако бывает немного замудрено, потому лучше также читать на MSDN и желательно английскую версию, т.к. перевод иногда привносит очень странные термины.
3. Если необходимо, прочитайте вступительную теорию по системам контроля версий и Git: https://git-scm.com/book/ru/v2 (1.1, 1.2, 1.3, 2.1).

Практика:
1. Создайте проект на основе шаблона Empty Project. Удалите класс Startup. Создайте новый класс с произвольным названием(но не Startup). Сделайте так чтоб новый, созданный вами класс выполнял фунции класса Startup и чтоб приложение работало.
2. Выведите в браузере значение ключа "Microsoft.Hosting.Lifetime" из файла appsettings.json.
3. Добавьте ваш репозиторий с ДЗ под Continuous Integration в AppVeyor.
4. Добавьте в ваш репозиторий с ДЗ файл .gitignore для .NET Core чтоб убрать лишние файла из под версионного контроля. Исключение должны составить файлы необходимые для AppVeyor, при этом иключить нужно только необходимые файлы, а не всю директорию obj.