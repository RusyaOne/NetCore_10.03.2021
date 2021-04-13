Теория:
1. Про hosted services: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio
2. Парочка примеров с hosted services: https://dotnetcoretutorials.com/2019/01/13/hosted-services-in-asp-net-core/
3. Про IMemoryCache: https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-3.1

Практика:
1. Создайте класс хелпер для кєширования и вынесите туда формирования ключа для изображения. 
2. Вынесите все захардкодженые строки/числа в конфигруацию (адрес ExternalImageService, Image ендпоинт и т.д.). В контроллере и REST клиенте (класс, который инкапсулирует обращение по REST  к ExternalImageService) не должны упоминаться захардкодженые строки/числа.
3. Добавьте возможность указывать имя изображения при выгрузке. Таким образом методы станут более универсальными.
4. Добавьте проверку на существование файла, перед тем как считавать его байты в проекте ExternalImageService.