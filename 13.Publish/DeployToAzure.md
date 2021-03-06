Настраиваем БД в Azure:
1) Запускаем Azure Shell
2) Создаем Resource Group:      az group create --name FictionResourceGroup --location "West Europe"
Показать доступные FREE хостинги:      az appservice list-locations --sku FREE
3) Создаем SQL server в Azure:       az sql server create --name fiction --resource-group FictionResourceGroup --location "West Europe" --admin-user TestUser --admin-password password
4) Конфигурим firewall:      az sql server firewall-rule create --resource-group FictionResourceGroup --server fiction --name AllowAzureIps --start-ip-address 0.0.0.0 --end-ip-address 0.0.0.0    
Если 0.0.0.0 то достучаться к SQL серверу можно только из других ресурсов Azure. Устанавливаем на свой локальный адрес.
5) Создаем БД:      az sql db create --resource-group FictionResourceGroup --server fiction --name FictionDB --service-objective S0
6) Формируем строку подключения:      az sql db show-connection-string --client ado.net --server fiction --name FictionDB
7) Заменяем строку подключения в проекте и запускаем приложение локально и смотрим что запрос и правда идет к базе в Azure.

Депллоим приложение в Azure:
1) Cоздаем deployment user:      az webapp deployment user set --user-name FictionTestUser --password Password1
2) Создаем App Service plan:      az appservice plan create --name FictionServicePlan --resource-group FictionResourceGroup --sku FREE
3) Создаем web app:      az webapp create --resource-group FictionResourceGroup --plan FictionServicePlan --name Fiction --deployment-local-git
4) Конфигурим connection string: az webapp config connection-string set --resource-group FictionResourceGroup --name Fiction --settings MyDbConnection="<connection-string>" --connection-string-type SQLAzure
5) Создаем remote для Azure (до этого был только origin):      git remote add azure https://FictionTestUser@fiction.scm.azurewebsites.net/Fiction.git
6) Пушим изменения в Azure:      git push azure master
7) Смотрим содержимое сервера Kudu:      https://fiction.scm.azurewebsites.net/
8) Делаем изменение и репаблишим.


Адреса по которым можно попросить доступ к запуску тестов в Azure Pipelines:
private: azpipelines-freetier@microsoft.com
public: azpipelines-ossgrant@microsoft.com