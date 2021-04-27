Теория:
1. Про Azure App Services: https://docs.microsoft.com/ru-ru/azure/app-service/overview#:~:text=%D0%A1%D0%BB%D1%83%D0%B6%D0%B1%D0%B0%20%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D0%B9%20Azure%20%E2%80%94%20%D1%8D%D1%82%D0%BE%20%D1%81%D0%BB%D1%83%D0%B6%D0%B1%D0%B0,NET%2C%20.
2. Обзор Portal Azure: https://docs.microsoft.com/ru-ru/azure/azure-portal/azure-portal-overview

Практика:
1. Напишите тесты для CharactersController/Get. В зависимости от данных возвращаемых charactersRepository.GetAll() задайте когда action должен отрабатывать корректно, а когда выбрасывать исключение.
2. Создайте тесты для UploadImageService. Как один из сценариев, можно проверить, что client.UploadImage() вызывается только в случае, когда channel.TryRead() возвращает значение.