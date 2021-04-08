Теория:
1. Про протокол SMTP и SMTP сервера: https://www.unisender.com/ru/support/about/glossary/chto-takoe-smtp/
2. Детальнее про Configuration: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
3. Про маппинг конфигурации к обьекту: https://weblog.west-wind.com/posts/2017/dec/12/easy-configuration-binding-in-aspnet-core-revisited 

Практика:
1. Добавьте middleware Use в конвеер обработки запроса, сделайте так, что на этом middleware замкнулась обработка запроса (middleware должно быть терминальным).
2. В секцию Fiction в файлах конфигурации (appsettings или secrets) добавьте две подсекции для данных по Email и Sms, разделите информацию, необходимую для Email и Sms рассылки по этим секциям соответственно. Откоректируйте класс FictionConfiguration в соответствии с изменениями в файлах конфигурации.
3. Сделайте так, чтоб тип рассылки можно было выбирать при вызове метода SendMessage() в контроллере. 